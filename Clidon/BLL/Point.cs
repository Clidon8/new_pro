using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class Point
    {

        //שורות
        public int x { get; set; }
        //עמודות
        public int y { get; set; }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Point()
        {

        }
        //בנאי מעתיק
        public Point(Point p)
        {
            this.x = p.x;
            this.y = p.y;
        }
    }
}
