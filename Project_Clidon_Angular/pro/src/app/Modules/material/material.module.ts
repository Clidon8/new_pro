import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatButtonModule} from  '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatInputModule} from '@angular/material/input';
import {MatBadgeModule} from '@angular/material/badge';

const materialcomponent=[MatBadgeModule,MatIconModule, MatButtonModule,MatProgressSpinnerModule,MatInputModule]
@NgModule({
 exports: [materialcomponent],
  imports: [
    materialcomponent
  ]
})
export class MaterialModule { }
