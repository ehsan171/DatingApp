import { Component, OnInit } from '@angular/core';
import { ChartType, ChartOptions } from 'chart.js';
import { SingleDataSet, Label, monkeyPatchChartJsLegend, monkeyPatchChartJsTooltip } from 'ng2-charts';
import { ScreenplayService } from '../_services/screenplay.service';
import { UserService } from '../_services/user.service';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { ScreenplayFormat } from '../_models/screenplayFormat';

@Component({
  selector: 'app-chart-format-all2',
  templateUrl: './chart-format-all2.component.html',
  styleUrls: ['./chart-format-all2.component.css']
})
export class ChartFormatAll2Component implements OnInit {
   // Pie
   pieChartOptions: ChartOptions = {
    responsive: true,
  };
  pieChartLabels: Label[] = [['سریال'], ['عروسکس'], 'کلیپ'];

  pieChartData: SingleDataSet = [0, 0, 0];
  pieChartType: ChartType = 'pie';
  pieChartLegend = true;
  pieChartPlugins = [];
  screenplayFormat: any[];
  dataScreenplayFormat = [];
  my_list = []

  constructor(
    private screenplayService: ScreenplayService,
    private userService: UserService,
    private authService: AuthService,
    private alertify: AlertifyService) {
    monkeyPatchChartJsTooltip();
    monkeyPatchChartJsLegend();
  }
  gettingDataFormatNumbers(){
    this.screenplayService.getFormatNumbers().subscribe((screenplayFormat: ScreenplayFormat[]) => {
      this.screenplayFormat = screenplayFormat;

      for (let index = 0; index < screenplayFormat.length; index++) {

        this.dataScreenplayFormat[index] = (screenplayFormat[index].formatNumber);
        
      }
      this.pieChartData = this.dataScreenplayFormat;
    }, error => {
      this.alertify.error('This is from gettingDataGeners');
    }
    );

  }
  ngOnInit() {
    this.gettingDataFormatNumbers();
  }
}
