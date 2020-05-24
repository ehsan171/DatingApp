import { Component, OnInit, ViewChild, Input, ViewEncapsulation } from '@angular/core';
import { ScreenplayService } from '../_services/screenplay.service';
import { UserService } from '../_services/user.service';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { HttpClient, HttpEventType } from '@angular/common/http';
import { Router } from '@angular/router';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Screenplay } from '../_models/screenplay';
import { Episode } from '../_models/episode';




const ELEMENT_DATA2: PeriodicElement2[] = [
  {row: 1, id: 1, title: '', episodeNumber: '', writer: '', concept: '', url: ''},
]
export interface PeriodicElement2 {

  row: number;
  id: number;
  title: string;
  episodeNumber: string;
  writer: any;
  concept: string;
  url: string;
 
}
@Component({
  selector: 'app-episode-all',
  templateUrl: './episode-all.component.html',
  styleUrls: ['./episode-all.component.css'],
  encapsulation: ViewEncapsulation.None 
})
export class EpisodeAllComponent implements OnInit {
  episodes: any[];
  fileName: any;
  @Input() public disabled: boolean;
  @Input() valuesFromDetail;
  dataSource2: MatTableDataSource<PeriodicElement2>;

  displayedColumns: string[] = ['row', 'id', 'title', 'episodeNumber', 'writer', 'concept', 'url'];

  public dataEpisode: PeriodicElement2[] = [];
  screenplays2: any[];

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;


gettingDataEpisode()
{
      this.screenplayService.getEpisode(this.valuesFromDetail)
      .subscribe
      (
        (episodes: Episode[]) =>
        {
            this.episodes = episodes;
            for (let index = 0; index < episodes.length; index++)
            {
              this.dataEpisode.push({row: 0, id: 0, title: '', episodeNumber: '', writer: '', concept: '', url: ''});
              this.dataEpisode[index].row = index + 1;
              this.dataEpisode[index].id = episodes[index].id;
              this.dataEpisode[index].title = episodes[index].episodeTitle;
              this.dataEpisode[index].episodeNumber = episodes[index].episodeNumber;
              this.dataEpisode[index].concept = episodes[index].concept;
              this.dataEpisode[index].writer = episodes[index].writers;
              this.dataEpisode[index].url = episodes[index].url;
                      // .map(item => item.writers)
                      // .reduce((prev, curr) => prev.concat(curr), [])
                      // .filter((item, i, arr) => arr.indexOf(item) === i)[index];

            }

            this.dataSource2 = new MatTableDataSource<PeriodicElement2>(this.dataEpisode);
            this.dataSource2.paginator = this.paginator;
            this.dataSource2.sort = this.sort;

    }, error => {
      this.alertify.error('episode-all');
    }
    );

}



applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource2.filter = filterValue.trim().toLowerCase();
  }



  constructor(
    private screenplayService: ScreenplayService,
    private userService: UserService,
    private authService: AuthService,
    private alertify: AlertifyService,
    private http: HttpClient,
    public router: Router,

  ) {  }

  getRecord(id: { id: string; }){
      window.location.href = 'screenplay/' + id.id;

  }


  public download(fileName?: string) {
  

    this.fileName = fileName || '';

    // this.downloadStatus.emit( {status: ProgressStatusEnum.START});
    this.screenplayService.downloadFile(this.fileName).subscribe(
      data => {

        switch (data.type) {

          case HttpEventType.Response:
            const downloadedFile = new Blob([data.body], { type: data.body.type });
            const a = document.createElement('a');
            a.setAttribute('style', 'display:none;');
            document.body.appendChild(a);
            a.download = this.fileName;
            a.href = URL.createObjectURL(downloadedFile);
            a.target = '_blank';
            a.click();
            document.body.removeChild(a);
            break;
        }
      },
      error => {

      }
    );
  }
  ngOnInit() {
    
    this.gettingDataEpisode();

  }
}

