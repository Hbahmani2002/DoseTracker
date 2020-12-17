import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.css']
})
export class FilterComponent implements OnInit {


  @Input() set header(value: any) {
    if (value == undefined)
      return;
    this.headertext = value;
  }
  public headertext: string;
  public isCollapsed: boolean = false;

  constructor() { }

  ngOnInit() {
  }
}
