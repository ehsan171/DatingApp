import {Component, OnInit, ViewChild} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import { Screenplay } from '../_models/screenplay';
import { ScreenplayService } from '../_services/screenplay.service';
import { UserService } from '../_services/user.service';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { MatSort } from '@angular/material/sort';
import { ViewEncapsulation } from '@angular/core';

/**
 * @title Table with pagination
 */



const ELEMENT_DATA2: PeriodicElement2[] = [
  {row: 1, id: 1, title: '', format: '', genre: '', baravordNo: '', producer: '', writer: '', url: ''},
];
export interface PeriodicElement2 {

  row: number;
  id: number;
  title: string;
  baravordNo: string;
  writer: any;
  producer: any;
  format: string;
  genre: string;
  url: string;
}
@Component({
  selector: 'app-screenplay-all',
  templateUrl: './screenplay-all.component.html',
  styleUrls: ['./screenplay-all.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ScreenplayAllComponent implements OnInit {
  dataSource2: MatTableDataSource<PeriodicElement2>;

  displayedColumns: string[] = ['row', 'id', 'title', 'baravordNo', 'writer', 'producer', 'format', 'genre', 'url'];

  public dataScreenplay2: PeriodicElement2[] = [];
  screenplays2: any[];
  dummy: any[];

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

   onlyUnique(value, index, self) {
    return self.indexOf(value) === index;
}
  gettingDataTitle(){
    this.screenplayService.getScreenplays().subscribe((screenplays: Screenplay[]) => {
      this.screenplays2 = screenplays;
      for (let index = 0; index < screenplays.length; index++) {
        this.dataScreenplay2.push( {row: 0, id: 0, title: '', baravordNo: '', writer: '', producer: '', format: '', genre: '', url: '' });
        this.dataScreenplay2[index].row = index + 1;
        this.dataScreenplay2[index].id = screenplays[index].id;
        this.dataScreenplay2[index].title = screenplays[index].title;
        this.dataScreenplay2[index].baravordNo = screenplays[index].baravordNo;
        this.dataScreenplay2[index].writer = screenplays[index].writers;
        const merged = [].concat.apply([], this.dataScreenplay2[index].writer);
        this.dataScreenplay2[index].writer = merged.filter( this.onlyUnique );
        this.dataScreenplay2[index].producer = screenplays[index].producers;
        this.dataScreenplay2[index].format = screenplays[index].format;
        this.dataScreenplay2[index].genre = screenplays[index].genre;
        
      }
      this.dataSource2 = new MatTableDataSource<PeriodicElement2>(this.dataScreenplay2);
      this.dataSource2.paginator = this.paginator;
      this.dataSource2.sort = this.sort;


    }, error => {
      this.alertify.error('خطا در ارسال داده');
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
  ngOnInit() {
    this.gettingDataTitle();

  }
}

