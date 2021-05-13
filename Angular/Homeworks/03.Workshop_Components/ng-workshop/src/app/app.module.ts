import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { ThemeListComponent } from './theme-list/theme-list.component';
import { AsideComponent } from './aside/aside.component';
import { ThemeListItemComponent } from './theme-list-item/theme-list-item.component';
import { UserService } from './user.service';
import { storageServiceProvider } from './storage.service';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    ThemeListComponent,
    AsideComponent,
    ThemeListItemComponent,
  ],
  imports: [BrowserModule],
  providers: [UserService, storageServiceProvider],
  bootstrap: [AppComponent, HeaderComponent, FooterComponent],
})
export class AppModule {}
