import { Component, OnInit, Input } from '@angular/core';
import { ScreenplayService } from '../_services/screenplay.service';
import { UserService } from '../_services/user.service';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Episode } from '../_models/episode';

@Component({
  selector: 'app-episode',
  templateUrl: './episode.component.html',
  styleUrls: ['./episode.component.css']
})
export class EpisodeComponent implements OnInit {
  screenplays: any[];
  values: any;
  @Input() valuesFromDetail;

  public dataEpisode: { [key: string]: Object }[] = [];



gettingDataEpisode()
  {
        this.screenplayService.getEpisode(this.valuesFromDetail)
        .subscribe
        (
          (episodes: Episode[]) =>
          {
              this.screenplays = episodes;

              for (let index = 0; index < episodes.length; index++)
              {
                this.dataEpisode.push({ id: '', title: '', episodeNumber: '', writer: '', concept: ''});
                this.dataEpisode[index].id = episodes[index].id;
                this.dataEpisode[index].title = episodes[index].episodeTitle;
                this.dataEpisode[index].episodeNumber = episodes[index].episodeNumber;
                this.dataEpisode[index].concept = episodes[index].concept;
                this.dataEpisode[index].writer = episodes
                        .map(item => item.writers)
                        .reduce((prev, curr) => prev.concat(curr), [])
                        .filter((item, i, arr) => arr.indexOf(item) === i)[index];

              }
              // screenplays.map(item => item.writers);
            //   .reduce((prev, curr) => prev.concat(curr), [])
            //   .filter((item, i, arr) => arr.indexOf(item) === i)[1]
            // )


              return this.dataEpisode;


      }, error => {
        this.alertify.error('getting Data Episode');
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
    this.gettingDataEpisode();
  }

}
