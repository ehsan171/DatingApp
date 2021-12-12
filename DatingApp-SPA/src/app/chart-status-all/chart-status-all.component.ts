import { Component, OnInit } from '@angular/core';
import { ChartType, ChartOptions } from 'chart.js';
import { SingleDataSet, Label, monkeyPatchChartJsLegend, monkeyPatchChartJsTooltip } from 'ng2-charts';
import { ScreenplayService } from '../_services/screenplay.service';
import { UserService } from '../_services/user.service';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { ScreenplayFormat } from '../_models/screenplayFormat';
import { ScreenplayStatus } from '../_models/screenplayStatus';

@Component({
  selector: 'app-chart-status-all',
  templateUrl: './chart-status-all.component.html',
  styleUrls: ['./chart-status-all.component.css']
})
export class ChartStatusAllComponent implements OnInit {
  pieChartOptions: ChartOptions = {
    responsive: true,
  };
  pieChartLabels: Label[] = [['نگارش'], ['تولید'], 'پخش'];
  
  pieChartData: SingleDataSet = [0, 0, 0];
  pieChartType: ChartType = 'pie';
  pieChartLegend = true;
  pieChartPlugins = [];
  screenplayFormat: any[];
  dataScreenplayStatus = [];


  constructor(
    private screenplayService: ScreenplayService,
    private userService: UserService,
    private authService: AuthService,
    private alertify: AlertifyService) {
    monkeyPatchChartJsTooltip();
    monkeyPatchChartJsLegend();
  }
  gettingDataStatusNumbers(){
    this.screenplayService.getStatusNumbers().subscribe((screenplayStatus: ScreenplayStatus[]) => {
      this.dataScreenplayStatus = screenplayStatus;

      for (let index = 0; index < screenplayStatus.length; index++) {

        this.dataScreenplayStatus[index] = (screenplayStatus[index].statusNumber);

      }
      this.pieChartData = this.dataScreenplayStatus;
    }, error => {
      this.alertify.error('This is from gettingDataGeners');
    }
    );

  }
  ngOnInit() {
    this.gettingDataStatusNumbers();
  }
}
