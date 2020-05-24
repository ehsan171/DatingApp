import { Component, OnInit, Input, Output } from '@angular/core';
import { Screenplay } from '../_models/screenplay';
import { ScreenplayService } from '../_services/screenplay.service';
import { AlertifyService } from '../_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../_services/auth.service';

import {  EventEmitter} from '@angular/core';
import { DataManager, Query, ODataV4Adaptor } from '@syncfusion/ej2-data';
import { FilteringEventArgs } from '@syncfusion/ej2-angular-dropdowns';
import { EmitType } from '@syncfusion/ej2-base';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { SafeScript } from '@angular/platform-browser';
import { Person } from '../_models/person';
import { BasicData } from '../_models/basicData';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Status } from '../_models/status';
import { Episode } from '../_models/episode';
import { HttpEventType, HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-episode-reg',
  templateUrl: './episode-reg.component.html',
  styleUrls: ['./episode-reg.component.css']
})
export class EpisodeRegComponent implements OnInit {

  
  constructor(private screenplayService: ScreenplayService,
              private userService: UserService,
              private authService: AuthService,
              private alertify: AlertifyService,
              private http: HttpClient) { }

@Input() valuesFromDetail;
@Output() cancelRegister = new EventEmitter();
@Output() public onUploadFinished = new EventEmitter();

public message: string;
  public progress: number;
screenplayId: any;
model: any = {};
screenplayRegForm: FormGroup;
users: User[];
persons: Person[];
formats: BasicData[];
statuses: Status[];
genres: BasicData[];
episodes: Episode[];
screenplayTitle: [];
public response: {'dbPath': ''};
skillForm = {
screenplayTitle: [],
writer: [],
episodeNumber: [],
baravord: [],
format: [],
genre: [],
};


public sportsData: string[] = [];
public eposideTitleData: string[] = [];
public text = 'عنوان قسمت';

// AutoComplete End

// Producer Start ---- Producer Start ---- Producer Start ---- Producer Start ---- Producer Start ---- Producer Start ----
// Dropdown Filtering Start

// defined the array of data

// tslint:disable-next-line: member-ordering
// tslint:disable-next-line: ban-types
public dataPerson: { [key: string]: Object }[] = [];
// tslint:disable-next-line: ban-types
public dataFormat: { [key: string]: Object }[] = [];
// tslint:disable-next-line: ban-types
public dataStatus: { [key: string]: Object }[] = [];
// tslint:disable-next-line: ban-types
public dataGenre: { [key: string]: Object }[] = [];
// maps the appropriate column to fields property

public fieldsPerson: object = { text: 'name', value: 'id' };
public fieldsFormat: object = { text: 'name', value: 'id' };
public fieldsStatus: object = { text: 'name', value: 'id' };
public fieldsGenre: object = { text: 'name', value: 'id' };

// set the placeholder to the DropDownList input
public textWriter = 'نویسنده';
public textFormat = 'قالب';
public textStatus = 'وضعیت';
public textGenre = 'ژانر';
public textOrgStructure = 'ساختار سازمانی';

// Dropdown Filtering End
// Producer End ---- Producer End ---- Producer End ---- Producer End ---- Producer End ---- Producer End ---- Producer End ----

// Total Number Episodes Start ---- Total Number Episodes Start ---- Total Number Episodes Start ---- Total Number Episodes Start ----
public textEpisodeNumber = 'شماره قسمت ';
// Total Number Episods End ---- Total Number Episods End ---- Total Number Episods End ----
public textConcept = 'محتوا ';
// Baravord Start --- Baravord Start --- Baravord Start --- Baravord Start --- Baravord Start --- Baravord Start ---
public textBaravord = 'شماره برآورد';


// ---------------------------------CONCEPT START-------------------------------------

public data: { [key: string]: Object }[] = [
  { id: 1, name: 'Discover Music', hasChild: true, expanded: true },
  { id: 2, pid: 1, name: 'Hot Singles' },
  { id: 3, pid: 1, name: 'Rising Artists' },
  { id: 25, pid: 1, name: 'Rising Artists', hasChild: true },
  { id: 4, pid: 25, name: 'Live Vi' },
  { id: 4, pid: 1, name: 'Live Music' },
  { id: 6, pid: 1, name: 'Best of 2017 So Far' },
  { id: 7, name: 'Sales and Events', hasChild: true },
  { id: 8, pid: 7, name: '100 Albums - $5 Each' },
  { id: 9, pid: 7, name: 'Hip-Hop and R&B Sale' },
  { id: 10, pid: 7, name: 'CD Deals' },
  { id: 11, name: 'Categories', hasChild: true },
  { id: 12, pid: 11, name: 'Songs' },
  { id: 13, pid: 11, name: 'Bestselling Albums' },
  { id: 14, pid: 11, name: 'New Releases' },
  { id: 15, pid: 11, name: 'Bestselling Songs' },
  { id: 16, name: 'MP3 Albums', hasChild: true },
  { id: 17, pid: 16, name: 'Rock' },
  { id: 18, pid: 16, name: 'Gospel' },
  { id: 19, pid: 16, name: 'Latin Music' },
  { id: 20, pid: 16, name: 'Jazz' },
  { id: 21, name: 'More in Music', hasChild: true },
  { id: 22, pid: 21, name: 'Music Trade-In' },
  { id: 23, pid: 21, name: 'Redeem a Gift Card' },
  { id: 24, pid: 21, name: 'Band T-Shirts' },
];
// defining fieldMapping
public conceptFields :Object = { dataSource: this.data, value: 'id', text: 'name', parentValue:"pid", hasChildren: 'hasChild'  };
// Baravord End --- Baravord End --- Baravord End --- Baravord End --- Baravord End ---



gettingEpisodeTitle(){
this.screenplayService.getEpisode(this.valuesFromDetail).subscribe((episodes: Episode[]) => {
this.episodes = episodes;
for (let index = 0; index < episodes.length; index++) {
this.eposideTitleData[index] = episodes[index].episodeTitle;
}
}, error => {
this.alertify.error('getting Episode Title');
}
);

}


gettingDataWriter(){
this.screenplayService.getPersons().subscribe((persons: Person[]) => {
this.persons = persons;
for (let index = 0; index < persons.length; index++) {
this.dataPerson.push({ id: '', firstName: '', lastName: '' });
this.dataPerson[index].firstName = persons[index].firstName;
this.dataPerson[index].lastName = persons[index].lastName;
this.dataPerson[index].name = persons[index].firstName + ' ' + persons[index].lastName ;
this.dataPerson[index].id = persons[index].id;
}
}, error => {
this.alertify.error('This is from member');
}
);

}
// Bind the filter event
public onFilteringPerson: EmitType<any> =  (e: FilteringEventArgs) => {
let queryWriter = new Query();
// frame the query based on search string with filter type.
queryWriter = (e.text !== '') ? queryWriter.where('name', 'contains', e.text, true) : queryWriter;
// pass the filter data source, filter query to updateData method.
e.updateData(this.dataPerson, queryWriter);
}
// Total Number Episodes End ---- Total Number Episodes End ---- Total Number Episodes End ---- Total Number Episodes End ----





gettingDataFormats(){
this.screenplayService.getFormats().subscribe((formats: BasicData[]) => {
this.formats = formats;
for (let index = 0; index < formats.length; index++) {
this.dataFormat.push({ id: '', name: ''});
this.dataFormat[index].id = formats[index].id;
this.dataFormat[index].name = formats[index].name;
}
}, error => {
this.alertify.error('This is from format');
}
);

}
// Bind the filter event
public onFilteringFormat: EmitType<any> =  (e: FilteringEventArgs) => {
let queryFormat = new Query();
// frame the query based on search string with filter type.
queryFormat = (e.text !== '') ? queryFormat.where('name', 'contains', e.text, true) : queryFormat;
// pass the filter data source, filter query to updateData method.
e.updateData(this.dataFormat, queryFormat);
}


// ---------------------------------CONCEPT END-------------------------------------

// ---------------------------------STATUS START--------------------------------------


gettingDataStatuses(){
this.screenplayService.getStatuses().subscribe((statuses: Status[]) => {
this.statuses = statuses;
for (let index = 0; index < statuses.length; index++) {
this.dataStatus.push({ id: '', name: ''});
this.dataStatus[index].id = statuses[index].id;
this.dataStatus[index].name = statuses[index].name;
}
}, error => {
this.alertify.error('This is from status');
}
);

}
// Bind the filter event
public onFilteringStatus: EmitType<any> =  (e: FilteringEventArgs) => {
let queryStatus = new Query();
// frame the query based on search string with filter type.
queryStatus = (e.text !== '') ? queryStatus.where('name', 'contains', e.text, true) : queryStatus;
// pass the filter data source, filter query to updateData method.
e.updateData(this.dataStatus, queryStatus);
}
// ---------------------------------STATUS END---------------------------------------

// ----------------------------------GENER START--------------------------------------
gettingDataGeners(){
this.screenplayService.getGenres().subscribe((genres: BasicData[]) => {
this.genres = genres;
for (let index = 0; index < genres.length; index++) {
this.dataGenre.push({ id: '', name: ''});
this.dataGenre[index].id = genres[index].id;
this.dataGenre[index].name = genres[index].name;
}
}, error => {
this.alertify.error('This is from gettingDataGeners');
}
);

}
// Bind the filter event
public onFilteringGenre: EmitType<any> =  (e: FilteringEventArgs) => {
let queryGenre = new Query();
// frame the query based on search string with filter type.
queryGenre = (e.text !== '') ? queryGenre.where('name', 'contains', e.text, true) : queryGenre;
// pass the filter data source, filter query to updateData method.
e.updateData(this.dataGenre, queryGenre);
}
// -----------------------------------GENER END----------------------------------------



public uploadFinished = (event) => {
  this.response = event;
}


  ngOnInit() {
  this.screenplayRegForm = new FormGroup({
  Title: new FormControl('', [
  Validators.required
  ]),
  writer: new FormControl(),
  episodeNumber: new FormControl(),
  concept: new FormControl(),
  url: new FormControl(),
  file: new FormControl(),
  fileSource: new FormControl('', [Validators.required])

  });

  this.gettingEpisodeTitle();
  this.gettingDataWriter();
  }

  register2(){
  // if (this.screenplayRegForm.valid){
  //   this.model = Object.assign({}, this.screenplayRegForm.value);
  // }
  // this.model.name = this.skillForm.screenplayTitle[0];
  this.authService.register(this.model).subscribe(() => {
  this.alertify.success('register succ...');
  }, error => {
  this.alertify.error('This is error from register2');
  }
  );

  }


  register(){

    if (this.screenplayRegForm.valid){
      this.model = Object.assign({}, this.screenplayRegForm.value);
      // this.model = Object.assign({}, this.screenplayRegForm.value);
     
    }
    this.model = Object.assign({}, this.screenplayRegForm.value);
    this.model.url = this.response.dbPath;
    //  this.model = Object.assign({}, this.screenplayRegForm.value);
    this.screenplayService.episodeRegister(this.model, this.valuesFromDetail).subscribe(() => {
      this.alertify.success('register succ...');
    }, error => {
      this.alertify.error('This is error from register EPISODE');
    }
    );





  }

cancel(){
this.cancelRegister.emit(false);
this.alertify.message('cancel...');
}
}
