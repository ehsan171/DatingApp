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
  episodes: any[];
  @Input() valuesFromDetail;
  
  public dataEpisode: { [key: string]: Object }[] = [];

// gettingEpisode(){
//   console.log(this.valuesFromDetail)
//   this.screenplayService.getEpidode(this.valuesFromDetail).subscribe((episodes: Episode[]) => {
//     this.episodes = episodes;
//     console.log("fsdsdfsdf")
    
//     for (let index = 0; index < episodes.length; index++) {
//       this.dataEpisode.push({ id: '', title: '', episodeNumber: '', writer: ''});
//       this.dataEpisode[index].id = episodes[index].id;
//       this.dataEpisode[index].title = episodes[index].episodeTitle;
//       this.dataEpisode[index].baravordNo = episodes[index].episodeNumber;
//       this.dataEpisode[index].writer = episodes
//               .map(item => item.writers)
//               .reduce((prev, curr) => prev.concat(curr), [])
//               .filter((item, i, arr) => arr.indexOf(item) === i)[index];
    

//     }
//     episodes.map(item => item.writers);
//     console.log(episodes.map(item => item.writers)
//     .reduce((prev, curr) => prev.concat(curr), [])
//     .filter((item, i, arr) => arr.indexOf(item) === i)[1]
   
// )
    
//   }, error => {
//     // this.alertify.error('gettingDataTitle');
//   }
//   );

// }

  constructor(
    private screenplayService: ScreenplayService,
    private userService: UserService,
    private authService: AuthService,
    private alertify: AlertifyService,
    private http: HttpClient,
    public router: Router){ }

  ngOnInit() {
    // this.gettingEpisode();
    const data = this.dataEpisode;
    console.log(data)
  }

}
