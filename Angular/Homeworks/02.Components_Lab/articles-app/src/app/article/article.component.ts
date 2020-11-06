import { Component, OnInit, Input } from '@angular/core';
import { Article } from '../models/article.model';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css']
})
export class ArticleComponent implements OnInit {
  private symbols: number;
  @Input() article: Article;
  @Input() articleDesc: string;
  descToShow: string;
  articleDescLen: number;
  showReadMoreBtn: boolean;
  showHideBtn: boolean;
  imageIsShown: boolean;
  imageButtonTitle: string;

  constructor() {
    this.symbols = 250;
    this.articleDescLen = 0;
    this.descToShow = '';
    this.showReadMoreBtn = true;
    this.showHideBtn = false;
    this.imageIsShown = false;
    this.imageButtonTitle = 'Show Image';
  }

  readMore(): void {
    this.articleDescLen += this.symbols;
    if (this.articleDescLen >= this.articleDesc.length) {
      this.showHideBtn = true;
      this.showReadMoreBtn = false;
    } else {
      this.descToShow = this.articleDesc.substring(0, this.articleDescLen);
    }
  }

  hideDesc(): void {
    this.descToShow = '';
    this.articleDescLen = 0;
    this.showHideBtn = false;
    this.showReadMoreBtn = true;
  }

  toggleImage(): void {
    this.imageIsShown = !this.imageIsShown;
    this.imageButtonTitle = this.imageButtonTitle === 'Show Image'
      ? 'Hide Image' : 'Show Image';
  }

  ngOnInit() {
  }
}
