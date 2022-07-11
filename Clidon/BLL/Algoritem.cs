using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Vision.V1;

namespace BLL
{
   public class Algoritem
    {
        //הגדרת משתנים כלליים
        //הגדרת צבע לבן
        Color color = Color.FromArgb(255, 255, 255, 255);
        //הגדרת רשימת נקודות לאות
        List<Point> lp = new List<Point>();
        //הגדרת התור של הנקודות השחורות
        Queue<Point> pointsletter = new Queue<Point>();
        //פונקציה ראשית
        public string imagetostring(string pathimg)
        {
            Bitmap newimg = new Bitmap(pathimg);
            List<Letters> l = new List<Letters>();
                //בהנחה שהתמונה בינארית
                //פונקציה שמקבלת תמונה בינארית וממירה אותה לרשימת אותיות
                l = ImgToLetters(newimg);
                //פונקציה שמקבלת את רשימת האותיות וממירה אותם לרשימה חדשה שהאותיות ה וק מסודרות
                l = IsTooCharecter(l);
                //פונקציה שמחזירה רשימת אותיות עם רווחים
                l = tab(l);
                //פונקציה שמוסיפה מסגרת לבנה לתמונה
                l = ImageInsertBorderW(l);
                //פונקציה ששולחת אות אות לגוגל
                string text = GetImagesPath(l);
                //טקסט מוקלד שחוזר
                return text;
            
        }

        //פונקציה שמוסיפה מסגרת לבנה לתמונת האות 
        public List<Letters> ImageInsertBorderW(List<Letters> letters)
        {
            List<Letters> LetBorderWhite = new List<Letters>();
            try
            {
                for (int i = 0; i < letters.Count; i++)
                {
                    //יצירת תמונה חדשה עם מסגרת בעובי 100 פיקסלים
                    Bitmap image = new Bitmap(letters[i].letter.Width + 200, letters[i].letter.Height + 200);
                    //צובע את התמונה בלבן
                    for (int j = 0; j < image.Width; j++)
                    {
                        for (int k = 0; k < image.Height; k++)
                        {
                            image.SetPixel(j, k, color);
                        }
                    }

                    List<Point> newp = new List<Point>();
                    //המרת התמונה המקורית לרשימת נקודות
                    newp = ImgToList(letters[i].letter);
                    if (newp.Count == 0)
                    {
                        //יצירת תמונה ריקה המסמלת רווח
                        Letters lTab = new Letters();
                        //תשלח לפונקציה שתיצור לי תמונה לבנה ותכניס אותה לרשימה
                        lTab.letter = ImageW();
                        lTab.firstheight = new Point(0, 0);
                        lTab.firstwidth = new Point(0, 0);
                        lTab.lastheight = new Point(0, 0);
                        lTab.lastwidth = new Point(0, 0);
                        //הוספת הרווח לרשימת האותיות
                        LetBorderWhite.Add(lTab);
                    }
                    else
                    {
                        //אם יש לך או ולא רווח
                        for (int l = 0; l < newp.Count; l++)
                        {
                            //תצבע כל פיקסל שחור בשחור לא לפני שתגדיל את כל נקודה ב 100 פיקסלים
                            image.SetPixel(newp[l].x + 100, newp[l].y + 100, Color.FromArgb(0, 0, 0, 0));
                        }
                        //הכנת אובייקט האות והכנסתו לרשימה של האותיות
                        Letters ln = new Letters();
                        ln.letter = image;
                        ln.firstheight = CalcSizePoint(newp, 1);
                        ln.lastheight = CalcSizePoint(newp, 2);
                        ln.firstwidth = CalcSizePoint(newp, 3);
                        ln.lastwidth = CalcSizePoint(newp, 4);
                        LetBorderWhite.Add(ln);
                    }
                }
            }
            catch(Exception ex)
            {

            }
            //תחזיר את רשימת האותיות עם המסגרת
            return LetBorderWhite;
        }
        //פונקציה שמחזירה כתב מוקלד
        public string GetImagesPath(List<Letters> l)
        {
            //נתיב תיקיה מקומית שבמהלך האלגוריתם תשמור את התמונות באופן זמני
            string path = @"C:\Users\שטרן\Documents\Clidon\API\Images\";
            //הגדרת קובץ בתיקיה הנוכחית
            System.IO.DirectoryInfo di = new DirectoryInfo(path);
            //מעבר על תוכן התיקייה ומחיקת התוכן ע"מ שנוכל להשתמש בה שוב למשפט חדש
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            DirectoryInfo Folder;
            FileInfo[] Images;
            //יצירת אובייקט תיקיה חדש שעליו נעבוד
            Folder = new DirectoryInfo(@"C:\Users\שטרן\Documents\Clidon\API\Images\");
            //יצירת משתנה שיוגדר כשווה לכל הקבצים בתיקיה
            Images = Folder.GetFiles();
            //מעבר על רשימת האותיות
            for (int i = 0; i < l.Count; i++)
            {
                //הגדרת גודל תמונה
                int width = l[i].letter.Width;
                int height = l[i].letter.Height;
                //הגדרת תמונה חדשה
                System.Drawing.Image image = l[i].letter;
                using (Bitmap bmp = new Bitmap(image))
                {
                    //יצירת הקובץ מסוג תמונה ושמירתו בנתיב התיקיה
                    bmp.Save(path + @"\" + i + ".jpeg", ImageFormat.Jpeg);
                }
            }
            //הגדרת משתנים הכרחיים
            string letter = "",text="", letterC="";
            //הגדרת רשימה של אותיות הטקסט
            List<string> ch = new List<string>();
            for (int i = 0; i < l.Count; i++)
            {
                //שליחת התמונות לפי הסדר לGoogle Api
                letter = UseGoogleAPI(@"C:\Users\שטרן\Documents\Clidon\API\Images\" + i+ ".jpeg");
                //אם חזר ריק, זה אומר שהוא קיבל רווח, אז תוסיף רווח. אחרת תשרשר את האות שקבלת
                if(letter=="")
                {
                    text += " ";
                }
                else
                {
                    text += letter;
                }
                //תלך לתו הבא ואם הוא שווה לC
                //זה אומר שאנחנו ב א ולכן תכניס א ותתקדם
                //אמורים לעשות פונקציה אחת לאנגלית ואחת לעברית ולשלוח את זה לאנגלית והשני לעברית
                //כרגע לא מופעל כי הפרויקט עובד על אנגלית
                //שליחת האות הבאה כל פעם כי החלק המתעגל של האות נמצא אחרי הקו שלו  - כדי למנוע תרגום של הקו
                //letterC = UseGoogleAPI(@"C:\Users\שטרן\Documents\Clidon\API\Files\" + (i+1) + ".jpeg");
                //if (letterC == "c")
                //{
                //    text="א";
                //    i++;
                //}
            }
            //תחזיר את הטקסט המוקלד
            return text;
        }
        //פונקציה ששולחת את האותיות לגוגל
        public string UseGoogleAPI(string path)
        {
            //יוצר משתנה שנמצא בתהליך הנוכחי
            //הוא מקבל שם ומקום להקצות אליו
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"C:\Users\שטרן\Documents\Downloads\clidon8\key.json");
            //מאפשר שימוש בכלים של גוגל
            ImageContext context = new ImageContext();
            //שינוי שפה לזיהוי
            //context.LanguageHints.Add("he");
            //context.LanguageHints.Remove("en");
            var client = ImageAnnotatorClient.Create();
            //יוצר אובייקט תמונה
            var image = Google.Cloud.Vision.V1.Image.FromFile(path);
            string text="";
            //מפרק את התמונה 
            var response = client.DetectText(image);
            //עובר על הקוד שפירק
            foreach (var annotation in response)
            {
                //אם הוא לא ריק תשים אותו ב text
                if (annotation.Description != null)
                {
                    text = annotation.Description;
                }
            }
            //תחזיר את הטקסט
            //למעשה הוא מחזיר אות 
            return text;
        }

        
        //פונקציה שמקבלת תמונה וממירה אותה לרשימת אותיות
        public List<Letters> ImgToLetters(Bitmap img)
        {

            //מגדיר את גודל התמונה
            int height = img.Height;

            int width = img.Width;

            //דגל שיאמר אם יש לנו אות להכניס לרשימה
            bool flag = false;
            //הגדרת נקודות
            Point p = new Point();
            Point p2 = new Point();
            //הגדרת רשימת אותיות חדשה
            List<Letters> letters = new List<Letters>();
 
            //עובר על כל תמונת הטקסט
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    //אם מצא פיקסל ששונה מלבן
                    if (img.GetPixel(i, j) != color)
                    {

                        //הכנסה לתור
                        p.x = i;
                        p.y = j;
                        pointsletter.Enqueue(p);
                        //כל נקודה שאני מכניסה לתור אני מכניסה למערך נקודות
                        lp.Add(new Point(i, j));
                        //הופכים את הנקודה ללבנה
                        img.SetPixel(i, j, color);
                        //כל עוד שהתור לא ריק - שיש עוד שכנים שחורים תרוץ
                        //כל עוד שלא גמרת את האות
                        while (pointsletter.Count() != 0)
                        {
                            //מוציא מהתור נקודה
                            p2 = pointsletter.Dequeue();
                            //הגדרת הנקודה השמאלית מלמעלה
                            Point pnt = new Point();
                            //הגדרת הנקודה הימינית מלמטה
                            Point pnt2 = new Point();
                            pnt.x = p2.x - 1;
                            pnt.y = p2.y - 1;
                            pnt2.x = p2.x + 1;
                            pnt2.y = p2.y + 1;
                            //מעבר על כל השכנים שלמעלה
                            for (int k = 0; k < 3; k++)
                            {
                                //שליחה לפונקציה שבודקת בעבור כל פיקסל ששולחים אם יש לו עוד שכנים שחורים
                                IsNeighbors(img, pnt);
                                //התקדמות בשורת השכנים מלמעלה
                                pnt.x++;
                            }
                            //שליחת השכן מימין
                            IsNeighbors(img, new Point(p2.x + 1, p2.y));
                            //מעבר על כל השכנים מלמטה
                            for (int r = 0; r < 3; r++)
                            {
                                IsNeighbors(img, pnt2);
                                //התקדמות ברוורס על שורת השכנים מלמטה
                                pnt2.x--;
                            }
                            //שליחת השכן משמאל
                            IsNeighbors(img, new Point(p2.x - 1, p2.y));
                        }
                        //הגדרת הדגל למאופשר משום שיש אות להכניס לרשימה
                        flag = true;
                    }
                    //אם יש אות להכניס
                    if (flag)
                    {
                        // isPoint = 1 : miny
                        // isPoint=2 : maxy
                        // isPoint=3 :minx
                        //isPoint=4 : maxx
                        //הגדרת גובה האות החדשה
                        //הנקודת מקסימום בגובה פחות נקודת המינימום בגובה
                        int Height = CalcSizePoint(lp, 2).y - CalcSizePoint(lp, 1).y;
                        //הגדרת רוחב האות
                        //רוחב הוא ה-X הגדול פחות ה-X הקטן
                        int Width = CalcSizePoint(lp, 4).x - CalcSizePoint(lp, 3).x;
                        //הגדרת אובייקט תמונה 
                        Bitmap im = new Bitmap(Height, Width);
                        //שולח לפונקציה שיוצרת אות מרשימת הנקודות
                        im = Newimgletter(lp, CalcSizePoint(lp, 4), CalcSizePoint(lp, 3), CalcSizePoint(lp, 2), CalcSizePoint(lp, 1));
                        //הוספת האות לרשימת האותיות
                        Letters l = new Letters();
                        l.letter = im;
                        l.firstheight = CalcSizePoint(lp, 1);
                        l.lastheight = CalcSizePoint(lp, 2);
                        l.firstwidth = CalcSizePoint(lp, 3);
                        l.lastwidth = CalcSizePoint(lp, 4);
                        letters.Add(l);
                        //ניקוי הרשימה 
                        lp.Clear();
                        //הגדרת הדגל ללא מאופשר כי גמר ואולי אין עוד אותיות
                        flag = false;
                    }
                }
            }
            //מחזיר את רשימת האותיות
            return letters;
        }
        //פונקציה שמחזירה את הנקודות קצה של האות
        public Point CalcSizePoint(List<Point> p, int isPoint)
        {
            // isPoint = 1 : miny
            // isPoint=2 : maxy
            // isPoint=3 :minx
            //isPoint=4 : maxx
            //הגדרת נקודה חדשה
            Point pnew = new Point();
            //אתחול משתנים
            int index = 0;
            int max = 0;
            int minx = p[0].x;
            int miny = p[0].y;
            //עובר על רשימת האותיות
            for (int i = 0; i < p.Count; i++)
            {
                //מקבל מספר מזהה של נקודה
                switch (isPoint)
                {
                    //בודק את נקודת המינימום בגובה
                    case 1:
                        //אם הנקודה הראשונה יותר גדולה מהנקודה הנוכחית נציב בה את הנקודה הנוכחית
                        if (p[i].y < miny)
                        {
                            //הצבת הנקודה ושמירת האינדקס
                            miny = p[i].y;
                            index = i;
                        }
                        //יצירת אובייקט נקודה
                        pnew.x = p[index].x;
                        pnew.y = miny;
                        //שבירת הלולאה
                        break;
                        //בודק את נקודת המקסימום בגובה
                    case 2:
                        if (max < p[i].y)
                        {
                            max = p[i].y;
                            index = i;
                        }
                        pnew.x = p[index].x;
                        pnew.y = max;
                        break;
                        //בודק את נקודת המינימום ברוחב
                    case 3:
                        if (p[i].x < minx)
                        {
                            minx = p[i].x;
                            index = i;
                        }
                        pnew.x = minx;
                        pnew.y = p[index].y;
                        break;
                    case 4:
                        //בודק את נקודת המקסימום ברוחב
                        if (max < p[i].x)
                        {
                            max = p[i].x;
                            index = i;
                        }
                        pnew.x = max;
                        pnew.y = p[index].y;
                        break;
                }
            }
            //מחזיר את הנקודה המבוקשת
            return pnew;
        }
        //פונקציה למציאת שכנים
        public void IsNeighbors(Bitmap img, Point p)
        {
            //הפונקציה מקבלת נקודה ותמונה
            //אם השכן שנשלח לא לבן
            if (img.GetPixel(p.x, p.y) != color)
            {
                //נכניס אותו לתור
                pointsletter.Enqueue(new Point(p.x, p.y));
                //נוסיף אותו לרשימת הנקודות
                lp.Add(p);
                //נלבין אותו בתמונה הגדולה כדי שנדע שעברנו עליו
                img.SetPixel(p.x, p.y, color);
            }
        }
        //פונקציה שבודקת אם יש 2 אותיות שמוכלות אחת בשניה
        public List<Letters> IsTooCharecter(List<Letters> letters)
        {
            //הגדרת רשימה חדשה
            List<Letters> Lnew = new List<Letters>();
            //הגדרת אובייקט חדש של אות
            Letters l = new Letters();
            //מעבר על רשימת האותיות
            //בגודל פחות האחרון כי הוא בטוח לא מהווה חלק ראשון  של אות ואם הוא מהווה חלק שני יגלו את זה בתמונה הקודמת לאחרון
            for (int i = 0; i < letters.Count - 1; i++)
            {
                //בדיקה אם יש 2 אותיות עוקבות שמוכלות אחת בשניה
                // אם הנקודת מינימום בגובה של האות הפנימית נמצא בין 2 הנקודות קצה של האות הקודמת
                //  if (letters[i+1].firstheight.x > letters[i].firstwidth.x && letters[i+1].firstheight.x < letters[i].lastwidth.x && letters[i+1].firstheight.y > letters[i].firstheight.y && letters[i+1].lastheight.x > letters[i].lastheight.x)
                //בדיקה אם קודות הקצה של הקטן מוכלות בנקודות הקצה של הגדול
                if (letters[i + 1].firstheight.y > letters[i].firstheight.y && letters[i + 1].lastheight.x < letters[i].lastheight.x)
                {
                    //אם יש 2 תמונות שמוכלות אחת בשניה ניצור גודל חדש לתמונה מאוחדת
                    //הגדרת גובה ורוחב תמונת האות החדשה
                    //הגדרת רוחב ע"י הפחתת המקסימום של האות הגדולה מהמקסימום של האות הקטנה
                    int width = letters[i].lastwidth.x - letters[i].firstwidth.x;
                    //הגדרת גובה ע"י חיבור 2 הגבהים והפחתת הקטע המשותף
                    //גובה תמונה הגדולה + גובה תמונה קטנה -ההפרש המשותף שמורכב מנקודת המקסימום של הגדול פחות נקודת המינימום של הקטן 
                    //ב -Y שהוא מסמל את הגובה
                    //הדרך הזו עובדת אך יש דרך פשוטה יותר
                    //int height = ((letters[i].lastheight.y - letters[i].firstheight.y) + (letters[i + 1].lastheight.y - letters[i + 1].firstheight.y)) - (letters[i].lastheight.y-letters[i+1].firstheight.y);
                    //גובה החלק הקטן + ההפרש של תחילת החלק הגדול עד לתחילת החלק הקטן
                    int sumH = (letters[i + 1].firstheight.y - letters[i].firstheight.y) + (letters[i + 1].lastheight.y - letters[i + 1].firstheight.y);
                    int height;
                    //אם הסכום של הגובה שיצא יותר גדול מגובה החלק הגדול אז תשים את חישוב הגובה
                    if (sumH > (letters[i].lastheight.y - letters[i].firstheight.y))
                    {
                        height = (sumH);
                    }
                    //אחרת גובה התמונה שווה לגובה של החלק הגדול
                    else
                    {
                        height = (letters[i].lastheight.y - letters[i].firstheight.y);
                    }
                    //הגדרת תמונה חדשה בגודל הנ"ל
                    Bitmap b = new Bitmap(width, height);
                    //הגדרת רשימה לחלק הגדול
                    List<Point> BigLetter = new List<Point>();
                    //הגדרת רשימה לחלק הקטן
                    List<Point> SmallLetter = new List<Point>();
                    //נהפוך את התמונות הגדולה לרשימה
                    BigLetter = ImgToList(letters[i].letter);
                    //נהפוך את התמונה הקטנה לרשימה
                    SmallLetter = ImgToList(letters[i + 1].letter);
                    //שליחה לפונקציה שמאחדת
                    b = TooImageToOne(BigLetter, SmallLetter, width, height, letters[i + 1].firstheight.y - letters[i].firstheight.y);
                    //בניית אוביקט אות חדש
                    l.letter = b;
                    //נקודת מינימום בגובה שווה לנקודת המינימום של הגובה של הגדול
                    l.firstheight = letters[i].firstheight;
                    //נקודת המקסימום של גובה שווה לנקודת המקסימום של גובה הקטן
                    l.lastheight = letters[i + 1].lastheight;
                    //נקודת המקסימום של הרוחב שווה לנקודת המקסימום של רוחב הגדול
                    l.lastwidth = letters[i].lastwidth;
                    //נקודת המינימום של הרוחב שווה לנקודת המינימום של הגדול
                    l.firstwidth = letters[i].firstwidth;
                    Lnew.Add(l);
                    //קידום האינדקס ב-1 כדי שידלג על החלק הבא ולא יוסיף אותו
                    i++;
                }
                else
                {
                    //אם החלק לא מוכל או מכיל תוסיף אותו לרשימה כך
                    Lnew.Add(letters[i]);

                }
            }
            //הוספת החלק האחרון
            Lnew.Add(letters[letters.Count - 1]);
            //הרשימה המעודכנת
            return Lnew;
        }
        //פונקציה שמאחדת מטריצות 
        public Bitmap TooImageToOne(List<Point> p1, List<Point> p2, int W, int H, int Ydifference)
        {
            //תמונה חדשה שנכניס אליה גובה ורוחב
            //גובה הוא ה-y הגדול פחות ה-y הקטן
            int height = H;
            //רוחב הוא ה-X הגדול פחות ה-X הקטן
            int width = W;
            //הגדרת מטריצה חדשה בגודל שצריך
            //הגדלת הגודל ב-1 כדי שלא יחרוג מהגודל
            Bitmap img = new Bitmap(++width, ++height);
            //אתחול המטריצה ללבן
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    img.SetPixel(i, j, Color.White);
                }
            }
            //נדביק את החלק הראשון ואז את השני כאשר נפחית מכל נקודה בשני את ה-Y של ההפרש
            //מצייר את החלק הגדול
            for (int i = 0; i < p1.Count; i++)
            {
                //צובע בשחור את החלק הגדול לפי האינדקסים המקוריים
                img.SetPixel(p1[i].x, p1[i].y, Color.FromArgb(0, 0, 0, 0));
            }
            //מצייר את החלק הקטן
            for (int i = 0; i < p2.Count; i++)
            {
                //לכל חלק בגובה מוסיף את הפרש הגובה
                img.SetPixel(p2[i].x, p2[i].y + Ydifference, Color.FromArgb(0, 0, 0, 0));
            }
            //מחזיר את תמונת האות המאוחדת
            return img;

        }
        //פונקציה שמציירת את האות ומחזירה תמונה שלה
        public Bitmap Newimgletter(List<Point> p, Point xmax, Point xmin, Point ymax, Point ymin)
        {
            //תמונה חדשה שנכניס אליה גובה ורוחב
            //גובה הוא ה-y הגדול פחות ה-y הקטן
            int height = (ymax.y - ymin.y);
            //רוחב הוא ה-X הגדול פחות ה-X הקטן
            int width = (xmax.x - xmin.x);
            //הגדרת מטריצה חדשה בגודל שצריך
            Bitmap img1 = new Bitmap(++width, ++height);
            //אתחול המטריצה ללבן
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    img1.SetPixel(i, j, Color.FromArgb(255, 255, 255, 255));
                }
            }
            //כל האינדקסים ברשימה נשים שם שחור
            for (int i = 0; i < p.Count; i++)
            {
                //נשים במטריצת התמונה שחור
                img1.SetPixel(p[i].x - xmin.x, p[i].y - ymin.y, Color.FromArgb(0, 0, 0, 0));
            }

            //תחזיר את התמונה של האות
            return img1;
        }
        //פונקציה שהופכת תמונה לרשימה  של נקודות 
        public List<Point> ImgToList(Bitmap img)
        {
           //הגדרת גובה ורוחב כדי שיהיה אפשר לעבור על התמונה
            int height = img.Height;
            int width = img.Width;
            //הגדרת רשימה של נקודות
            List<Point> pnew = new List<Point>();
            //מעבר על התמונה
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    //אם הפיקסל שחור תכניס אותו לרשימה
                    if (img.GetPixel(i, j) != color)
                    {
                        pnew.Add(new Point(i, j));
                    }

                }
            }
            //מחזיר רשימת פיקסלים שחורים
            return pnew;
        }
        //שומר את הקובץ מהסוג הרצוי בשם
        public void FileText(string text)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|doc files (*.doc)|*.doc|All files (*.*)|*.*";
            //ברירת המחדל  word
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    myStream.Close();

                }
                //הכנסת הטקסט המוקלד לקובץ שיצרנו
                write_to_file(text, (saveFileDialog1.FileName));
            }
        }
        
        //כתיבת הטקסט המוקלד בקובץ שיצרנו בפונקציה הקודמת
        public void write_to_file(string text, string FileName)
        {
            File.WriteAllText(FileName, text);
        }
        //פונקצית העלאת קובץ
        public string openFile()
        {
            //הפונקציה מחזירה נתיב לקובץ
            // העלאת קובץ
            //Image<Bgr, byte> img;
            OpenFileDialog ofd = new OpenFileDialog();
            ////פתיחת חלון חיפוש במחשב
            if (ofd.ShowDialog() == DialogResult.OK)
            {
              return "path file";
            //    //יצירת אובייקט תמונה חדש מהתמונה שהכניס לפי הנתיב שלה
            //    img = new Image<Bgr, byte>(ofd.FileName);
            }
            return "no open file";
        }
        //פונקציה שמוצאת רווחים ומחזירה רשימת אותיות עם רווחים בין המילים
        public List<Letters> tab(List<Letters> letters)
        {
            int avg = 0;
            int tab = 0;
            //הגדרת רשימה ריקה מסוג מספר
            List<int> numl = new List<int>();
            //בודק מה המרחק בין כל אות
            for (int i = 0; i < letters.Count; i++)
            {
                if (i != (letters.Count - 1))
                {
                    tab = letters[i + 1].firstwidth.x - letters[i].lastwidth.x;
                }

                //אם האותיות נכנסות אחת בתוך השניה
                if (tab < 0)
                {
                    //תשים במרחק 0
                    tab = 0;
                }
                //תוסיף את המרחק לרשימה
                numl.Add(tab);
            }
           
            //מציאת ממוצע בין 2 רווחים ראשונים
            avg = (numl[0] + numl[1]) / 2;
            //int avg = numl[0] * 2;
            int index = 0;
            //הגדרת רשימה חדשה מסוג מספר
            List<int> indextab = new List<int>();
            //מעבר על הרשימה הקודמת שיצרנו
            for (int i = 0; i < numl.Count; i++)
            {
                
                //אם מצאת רווח
                if (numl[i] >= (avg * 2))
                {
                    //תכניס -1 לרשימה
                    indextab.Add(i);
                    //תשמור את האינדקס
                    index = i;
                }
                else
                {
                    //אם  האינדקס לא 0
                    if (index != 0)
                    {
                        //תכניס -1 לרשימה
                        indextab.Add(-1);
                        //תאפס את אינדקס
                        index = 0;
                    }
                    //מספר האות בשורה של הטקסט
                    //רשימת האינדקסים של האותיות
                    indextab.Add(i);
                }

            }
            //ניצור רשימת אותיות חדשה
            List<Letters> listLettersTab = new List<Letters>();
            //אובייקט תמונה חדש של רווח
            Letters lTab = new Letters();
            //מעבר על רשימת האינדקסים החדשה שיש בה סמל לרווח
            for (int i = 0; i < indextab.Count; i++)
            {
                //אם מצאת בה -1
                if (indextab[i] == -1)
                {
                    //תשלח לפונקציה שתיצור לי תמונה לבנה ותכניס אותה לרשימה
                    lTab.letter = ImageW();
                    lTab.firstheight = new Point(0, 0);
                    lTab.firstwidth = new Point(0, 0);
                    lTab.lastheight = new Point(0, 0);
                    lTab.lastwidth = new Point(0, 0);
                    //תכניס את תמונת הרווח לרשימה
                    listLettersTab.Add(lTab);
                }
                else
                {
                    //אם זה לא רווח תכניס את תמונת האות
                    listLettersTab.Add(letters[indextab[i]]);
                }
            }
            //תחזיר את רשימת האותיות עם הרווחים בין המילים
            return listLettersTab;
        }
        //פונקציה שיוצרת תמונה לבנה כרווח
        public Bitmap ImageW()
        {
            //הגדרת תמונה חדשה
            Bitmap img = new Bitmap(2, 2);
            //צובע בלבן את התמונה החדשה שיצר
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    img.SetPixel(i, j, color);
                }
            }
            //מחזיר תמונת רווח לבנה בגודל 2 על2 
            return img;
        }

    }
}
