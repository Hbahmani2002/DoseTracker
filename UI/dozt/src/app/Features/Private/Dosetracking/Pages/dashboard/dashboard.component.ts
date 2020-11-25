import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { defineLocale, trLocale } from 'ngx-bootstrap/chronos';
defineLocale('tr', trLocale);

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  public dateRange;
  public chartData = [];
  public selectedChartType = 1;
  public chartType = [
    {
      id: 1,
      name: "Sar-Cinsiyet"
    },
    {
      id: 2,
      name: "Sar-Yaş"
    },
    {
      id: 3,
      name: "Sar-Boy"
    },
    {
      id: 4,
      name: "Sar-Vücut Kitle İndeksi"
    }
  ]
  constructor(private http: HttpClient, private localeService: BsLocaleService) {
  }
  ngOnInit() {
    this.localeService.use('tr');
    this.onFilter();

  }
  onFilter() {
    //this.http.get("https://demo-live-data.highcharts.com/aapl-ohlc.json")
    var date1 = "2020-01-29";
    var date2 = "2020-03-15";
    if (this.dateRange) {
      date1 = this.dateRange[0].toISOString().slice(0, 10);
      date2 = this.dateRange[1].toISOString().slice(0, 10);
      console.log(this.dateRange);
    }

    this.http.get("https://test_dosetracker.proteksaglik.com/Stat/GetSarGroupData?HospitalIDList[0]=1&HospitalIDList[1]=2&DateStart=" + date1 + "&DateEnd=" + date2 + "&Group=" + this.selectedChartType)
      .subscribe((dataPacket: any) => {
        let data = dataPacket.data;
        let data2 = [];
        data.serieData.forEach(serie => {
          data2.push(serie[1])
        });
        data.serieData = data2;
debugger;

        // var data2 = data.map(o => [o[0], o[1] + 1]);
        this.chartData = data;
      });
  }
  onClearFilter() {
    alert("Clear Filter Work's");
  }

}
