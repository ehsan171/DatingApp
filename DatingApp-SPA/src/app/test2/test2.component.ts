import { Component, OnInit, HostListener, ApplicationRef, NgZone } from '@angular/core';
import { ScreenplayService } from '../_services/screenplay.service';
import { UserService } from '../_services/user.service';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Screenplay } from '../_models/screenplay';
// import { Location, PlatformLocation } from '@angular/common';

import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';


@Component({
  selector: 'app-test2',
  templateUrl: './test2.component.html',
  styleUrls: ['./test2.component.css'],
})

export class Test2Component implements OnInit {
  title = 'My App';
  gridConfig: object;
  screenplays: any[];
  titleData: any;

  
  settings = {
    columns: {
      title: {
        title: 'عنوان',
        filter: {
          type: 'list',
        }
      },
      baravordNo: {
        title: 'شماره برآورد'
      },
      writers: {
        title: 'نویسنده'
      },
      producers: {
        title: 'تهیه کننده'
      },
      format: {
        title: 'قالب'
      },
      genre: {
        title: 'ژنر'
      }
    }
  };

  data2 = [
    {
      id: 1,
      name: "Leanne Graham",
      username: "Bret",
      email: "Sincere@april.biz"
    },
    {
      id: 2,
      name: "Ervin Howell",
      username: "Antonette",
      email: "Shanna@melissa.tv"
    },
    
    // ... list of items
    
    {
      id: 11,
      name: "Nicholas DuBuque",
      username: "Nicholas.Stanton",
      email: "Rey.Padberg@rosamond.biz"
    }
  ];

  public dataScreenplay: { [key: string]: Object }[] = [];

gettingDataTitle(){
  this.screenplayService.getScreenplays().subscribe((screenplays: Screenplay[]) => {
    this.screenplays = screenplays;
    for (let index = 0; index < screenplays.length; index++) {
      this.dataScreenplay.push({ id: '', title: '', baravordNo: '', writer: '', producer: '', format: '', genre: '', });
      this.dataScreenplay[index].id = screenplays[index].id;
      this.dataScreenplay[index].title = screenplays[index].title;
      this.dataScreenplay[index].baravordNo = screenplays[index].baravordNo;
      this.dataScreenplay[index].writer = screenplays
              .map(item => item.writers)
              .reduce((prev, curr) => prev.concat(curr), [])
              .filter((item, i, arr) => arr.indexOf(item) === i)[index];
      this.dataScreenplay[index].producer = screenplays[index].producers;
      this.dataScreenplay[index].format = screenplays[index].format;
      this.dataScreenplay[index].genre = screenplays[index].genre;
// console.log(this.dataScreenplay[index].writer )
    }
    screenplays.map(item => item.writers);
    console.log(screenplays.map(item => item.writers)
    .reduce((prev, curr) => prev.concat(curr), [])
    .filter((item, i, arr) => arr.indexOf(item) === i)[1]
)
    
  }, error => {
    this.alertify.error('gettingDataTitle 102');
  }
  );

}

  constructor(
    private screenplayService: ScreenplayService,
    private userService: UserService,
    private authService: AuthService,
    private alertify: AlertifyService,
    private http: HttpClient,
    public router: Router,
    
  
    
  ) {
   
   
    // this.gettingDataTitle();
    const data = this.dataScreenplay;
    
    this.gridConfig = {
      width: 930,
      events: [{
        rowclick(grid, o){
          window.location.href = 'screenplay/' + o.item.get('id');
        },
        scope: {}// not required
      }, {
        rowdblclick(grid, o){
        }
      }],
      paging: {
        barType: 'tbar',
        pageSize: 13,
      },
      height: 'fit',
      selModel: 'rows',
      trackOver: true,
      theme: 'bootstrap',
      data,
      defaults: {
        type: 'string',
        sortable: true,
        resizable: true,
        // width: 100
      },
      // tbar: [{
      //   type: 'search',
      //   // width: 350,
      //   emptyText: 'Search',
      //   paramsMenu: true,
      //   paramsText: 'Parameters'
      // }],

      columns: [{
        type: 'select'
      },
      {
            index: 'genre',
            title: 'ژانر',
            filter: {
              header: true,
              emptyText: 'Search'
            },
            render(o) {

              o.style = {
                'font-size': '14px',
                'text-align': 'right',
                'font-family': 'BTraffic',
              };
              return o;
            }
      },
      {
            index: 'format',
            title: 'قالب',
            filter: {
              header: true,
              emptyText: 'Search'
            },
            render(o) {

              o.style = {
                'font-size': '14px',
                'text-align': 'right',
                'font-family': 'BTraffic',
              };
              return o;
            }
      },
      {
        index: 'writer',
        title: 'نویسنده',
        filter: {
          header: true,
          emptyText: 'Search'
        },
        width: 200,
        render(o) {

          o.style = {
            'font-size': '14px',
            'text-align': 'right',
            'font-family': 'BTraffic',
          };

          return o;
        }
      },
      {
        index: 'producer',
        title: 'تهیه کننده',
        filter: {
          header: true,
          emptyText: 'Search'
        },
        width: 200,
        render(o) {

          o.style = {
            'font-size': '12px',
            'text-align': 'right',
            'font-family': 'BTraffic',
          };

          return o;
        }
      }, 
      {
        index: 'baravordNo',
        title: 'شماره برآورد',
        filter: {
          header: true,
          emptyText: 'Search'
        },
        align: 'center',
        render(o) {

          o.style = {
            'font-size': '14px',
            'text-align': 'center',
            'font-family': 'BTraffic',
          };
          return o;
        }
      }, {
        index: 'title',
        title: 'عنوان فیلمنامه',
        filter: {
          header: true,
          emptyText: 'Search',
           },
        width: 200,
        align: 'center',
        // type: 'number',
        // autoHeight: true,

  render(o) {

    o.style = {
      'font-size': '14px',
      'text-align': 'right',
      'font-family': 'BTraffic',
    };

    return o;
  }
      }]
    };
    
  }
 
  
  ngOnInit() {
  
    
  
    this.gettingDataTitle();
    const data3 = this.dataScreenplay;
   
   
  }

}
