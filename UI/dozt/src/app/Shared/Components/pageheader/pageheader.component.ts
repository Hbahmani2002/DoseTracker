import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'pageheader',
  templateUrl: './pageheader.component.html',
  styleUrls: ['./pageheader.component.css']
})
export class PageheaderComponent implements OnInit {

  @Input() set headertext(value: any) {
    if (value == undefined)
      return;
    this.headerText = value;
  }
  @Input() set pageposition(value: any) {
    if (value == undefined)
      return;
    this.pagePosition = value;
  }
  public headerText: string;
  public pagePosition: string;
  constructor() { }

  ngOnInit(): void {
  }

}
