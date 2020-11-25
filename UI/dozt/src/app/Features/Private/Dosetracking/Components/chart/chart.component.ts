import { Component, Input, OnInit } from '@angular/core';
declare var Highcharts: any;

@Component({
  selector: 'chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css']
})
export class ChartComponent implements OnInit {

  public chartType = "";
  public chartData = [];
  public yLabel ='';
  public xLabels = [];
  public title = '';


  @Input() set data(value:any) {
    if (value.length == 0)
      return;
    this.chartData = value.serieData;
    this.yLabel = value.yLabel;
    this.xLabels = value.xLabels;
    this.title = value.title;
    this.loadChart();
  }
  constructor() { }

  ngOnInit() {
  }
  loadChart(){
    Highcharts.chart('container', {
      chart: {
        type: this.chartType
      },
      title: {
        text: this.title
      },
      xAxis: {
        categories: this.xLabels,
        crosshair: true
      },
      yAxis: {
        min: 0,
        title: {
          text: this.yLabel
        }
      },
      tooltip: {
        headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
        pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
          '<td style="padding:0"><b>{point.y:.1f} mm</b></td></tr>',
        footerFormat: '</table>',
        shared: true,
        useHTML: true
      },
      plotOptions: {
        column: {
          pointPadding: 0.2,
          borderWidth: 0
        }
      },
      series: [{
        name: 'Sar',
        data: this.chartData[1]
      }]
    })
  }
  onChangeChartType(type) {
    if (type == 1) {
      this.chartType = "line"
      
    }
    else if (type == 2) {
      this.chartType = "column"
    }
    else{
      return;
    }
    this.loadChart();
  }
}
