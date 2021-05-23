import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ThemeListComponent } from './theme-list/theme-list.component';
import { ThemeListItemComponent } from './theme-list-item/theme-list-item.component';
import { ThemeService } from './theme.service';

@NgModule({
  declarations: [
    ThemeListComponent,
    ThemeListItemComponent,
  ],
  imports: [
    CommonModule
  ],
  providers:[
    ThemeService
  ],
  exports:[
    ThemeListComponent,
    ThemeListItemComponent,
  ]
})
export class ThemeModule { }
