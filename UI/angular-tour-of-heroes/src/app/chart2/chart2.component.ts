import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare var Highcharts: any;

@Component({
  selector: 'chart2-component',
  template: `
  <div id="container" style="height: 400px; min-width: 310px"></div>
    `
})
export class Chart2Component {
  constructor(private http: HttpClient) {

    //this.http.get("https://demo-live-data.highcharts.com/aapl-ohlc.json")
    this.http.get("https://localhost:44308/Stat/GetSarGroupData?HospitalIDList[0]=1&HospitalIDList[1]=2&DateStart=2020-01-29&DateEnd=2020-03-15&Group=3")
      .subscribe(dataPacket => {
        let data = dataPacket.data;
        var data2 = data.map(o => [o[0], o[1] + 1]);
        debugger;
        Highcharts.stockChart('container', {


          rangeSelector: {
            selected: 1
          },

          title: {
            text: 'AAPL Stock Price'
          },

           series: [
          {
            type: 'candlestick',
            name: 'AAPL Stock Price',
            data: data,
            dataGrouping: {
              units: [
                [
                  'week', // unit name
                  [1] // allowed multiples
                ], [
                  'month',
                  [1, 2, 3, 4, 6]
                ]
              ]
            }
          },
          {
            name: 'AAPL Stock Scatter',
            data: data2,
            lineWidth: 0,
            marker: {
              enabled: true,
              radius: 2
            }
          }

          ]
        });

      })







  }
}