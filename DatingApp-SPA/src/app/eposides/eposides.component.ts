import { Component, OnInit, Input } from '@angular/core';
import { Screenplay } from '../_models/screenplay';
import { ScreenplayService } from '../_services/screenplay.service';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Episode } from '../_models/episode';
import { data } from '../test_data/datasource';

@Component({
  selector: 'app-eposides',
  templateUrl: './eposides.component.html',
  styleUrls: ['./eposides.component.css']
})
export class EposidesComponent implements OnInit {
  screenplays: any[];
  @Input() valuesFromDetail;
  
  public dataEpisode: { [key: string]: Object }[] = [];


  public dataScreenplay: { [key: string]: Object }[] = [];

gettingDataTitle()
  {
        this.screenplayService.getEpisode(this.valuesFromDetail)
        .subscribe
        (
          (screenplays: Episode[]) =>
          {
              this.screenplays = screenplays;
              this.dataEpisode[0].title = screenplays[0].episodeTitle;
              // for (let index = 0; index < screenplays.length; index++)
              // {
              //   this.dataScreenplay.push({ id: '', title: '', episodeNumber: '', writer: ''});
              //   this.dataScreenplay[index].id = screenplays[index].id;
              //   this.dataScreenplay[index].title = screenplays[index].episodeTitle;
              //   // this.dataScreenplay[index].episodeNumber = screenplays[index].episodeNumber;
              //   // this.dataScreenplay[index].writer = screenplays
              //   //         .map(item => item.writers)
              //   //         .reduce((prev, curr) => prev.concat(curr), [])
              //   //         .filter((item, i, arr) => arr.indexOf(item) === i)[index];

              // }
              // screenplays.map(item => item.writers);
            //   .reduce((prev, curr) => prev.concat(curr), [])
            //   .filter((item, i, arr) => arr.indexOf(item) === i)[1]
            // )
              return this.dataScreenplay[0].title;

      }, error => {
        this.alertify.error('gettingDataTitle 55');
      }
      );

  }

  constructor(
    private screenplayService: ScreenplayService,
    private userService: UserService,
    private authService: AuthService,
    private alertify: AlertifyService,
    private http: HttpClient,
    public router: Router){ }

  ngOnInit() {
    this.gettingDataTitle();
  }

}
