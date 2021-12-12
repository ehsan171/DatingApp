import { Component, OnInit, Input, Output } from '@angular/core';
// import { Screenplay } from '../_models/screenplay';
import { ScreenplayService } from '../_services/screenplay.service';
import { AlertifyService } from '../_services/alertify.service';
// import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../_services/auth.service';

import { EventEmitter } from '@angular/core';
import { DataManager, Query, ODataV4Adaptor } from '@syncfusion/ej2-data';
import { FilteringEventArgs } from '@syncfusion/ej2-angular-dropdowns';
import { EmitType } from '@syncfusion/ej2-base';
import { User } from '../_models/user';
// import { UserService } from '../_services/user.service';
// import { SafeScript } from '@angular/platform-browser';
import { Person } from '../_models/person';
import { BasicData } from '../_models/basicData';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Status } from '../_models/status';
import { Episode } from '../_models/episode';
import { HttpEventType, HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

declare var $: any;
@Component({
  selector: 'app-episode-reg',
  templateUrl: './episode-reg.component.html',
  styleUrls: ['./episode-reg.component.css']
})
export class EpisodeRegComponent implements OnInit {

  @Input() valuesFromDetail;
  @Output() cancelRegister = new EventEmitter();
  @Output() public onUploadFinished = new EventEmitter();
  episodeRegForm: FormGroup;



  constructor(private screenplayService: ScreenplayService,
              private authService: AuthService,
              private alertify: AlertifyService,
              private http: HttpClient,
              private router: Router) { }




  public message: string;
  public progress: number;
  screenplayId: any;
  model: any = {};
  modelProcess: any = {};

  users: User[];
  persons: Person[];
  formats: BasicData[];
  concepts: BasicData[];
  statuses: Status[];
  genres: BasicData[];
  episodes: Episode[];
  screenplayTitle: [];

  public response: string;
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


  public dataPerson: { [key: string]: any }[] = [];

  public fieldsPerson: object = { text: 'name', value: 'id' };

  // set the placeholder to the DropDownList input
  public textWriter = 'نویسنده';

  // Dropdown Filtering End
  // Producer End ---- Producer End ---- Producer End ---- Producer End ---- Producer End ---- Producer End ---- Producer End ----

  // Total Number Episodes Start ---- Total Number Episodes Start ---- Total Number Episodes Start ---- Total Number Episodes Start ----
  public textEpisodeNumber = 'شماره قسمت ';
  // Total Number Episods End ---- Total Number Episods End ---- Total Number Episods End ----
  public textConcept = 'محتوا ';
  // Baravord Start --- Baravord Start --- Baravord Start --- Baravord Start --- Baravord Start --- Baravord Start ---
  public textBaravord = 'شماره برآورد';


  // ---------------------------------CONCEPT START-------------------------------------
  public data: { [key: string]: any }[] = [];


  public conceptFields: any = [];

  // defining fieldMapping
  gettingDataConcepts() {

    this.screenplayService.getConcepts().subscribe((concepts: BasicData[]) => {
      this.concepts = concepts;
      for (let index = 0; index < concepts.length; index++) {
        this.data.push({ id: '', pid: '', name: '', hasChild: true, expanded: true });
        this.data[index].id = concepts[index].id;
        this.data[index].name = concepts[index].name;
        this.data[index].pid = concepts[index].parent;
        this.data[index].hasChild = true;
        this.data[index].expanded = false;
      }
      this.conceptFields = { dataSource: this.data, value: 'id', text: 'name', parentValue: 'pid', hasChildren: 'hasChild' };

    }, error => {
      this.alertify.error('This is from format');
    }
    );

  }



  gettingEpisodeTitle() {
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


  gettingDataWriter() {
    this.screenplayService.getPersons().subscribe((persons: Person[]) => {
      this.persons = persons;
      for (let index = 0; index < persons.length; index++) {
        this.dataPerson.push({ id: '', firstName: '', lastName: '' });
        this.dataPerson[index].firstName = persons[index].firstName;
        this.dataPerson[index].lastName = persons[index].lastName;
        this.dataPerson[index].name = persons[index].firstName + ' ' + persons[index].lastName;
        this.dataPerson[index].id = persons[index].id;
      }
    }, error => {
      this.alertify.error('This is from member');
    }
    );

  }
  // Bind the filter event
  public onFilteringPerson: EmitType<any> = (e: FilteringEventArgs) => {
    let queryWriter = new Query();
    // frame the query based on search string with filter type.
    queryWriter = (e.text !== '') ? queryWriter.where('name', 'contains', e.text, true) : queryWriter;
    // pass the filter data source, filter query to updateData method.
    e.updateData(this.dataPerson, queryWriter);
  }
  // Total Number Episodes End ---- Total Number Episodes End ---- Total Number Episodes End ---- Total Number Episodes End ----






  // ---------------------------------CONCEPT END-------------------------------------

  // ---------------------------------STATUS START--------------------------------------


  // ---------------------------------STATUS END---------------------------------------

  // ----------------------------------GENER START--------------------------------------

  // -----------------------------------GENER END----------------------------------------



  public uploadFinished = (event) => {

    this.response = event;
  }


  ngOnInit() {
    this.episodeRegForm = new FormGroup({
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
    this.gettingDataConcepts();
    this.episodeRegForm.patchValue({
      concept: []
    });
  }

  register2() {
    // if (this.episodeRegForm.valid){
    //   this.model = Object.assign({}, this.episodeRegForm.value);
    // }
    // this.model.name = this.skillForm.screenplayTitle[0];
    this.authService.register(this.model).subscribe(() => {
      this.alertify.success('ثبت قسمت با موفقست انجام شئ.');
    }, error => {
      this.alertify.error('This is error from register2');
    }
    );

  }


  register() {

    if (this.episodeRegForm.valid) {

      this.model = Object.assign({}, this.episodeRegForm.value);
      // this.model = Object.assign({}, this.episodeRegForm.value);

    }
    this.model = Object.assign({}, this.episodeRegForm.value);
    this.model.url = this.response;
    //  this.model = Object.assign({}, this.episodeRegForm.value);
    this.screenplayService.episodeRegister(this.model, this.valuesFromDetail).subscribe(() => {

      this.modelProcess.UserId = this.authService.decodedToken?.nameid;

      this.modelProcess.Type = '3';
      this.modelProcess.ScreenplayId = this.valuesFromDetail;
      this.modelProcess.Activity = 'ثبت قسمت ' + this.model.Title;
      this.authService.processReg(this.modelProcess).subscribe(() => {
      }, error => {
        this.alertify.error('This is error from register Process');
      }
      );
      this.alertify.success('ثبت قسمت با موفقیت انجام شد');
      this.router.navigate(['/screenplay/' + this.valuesFromDetail] );
      
    }, error => {
      this.alertify.error('پر کردن تمامی قسمت ها الزامیست.');
    }
    );





  }

  cancel() {
    this.cancelRegister.emit(false);
    this.alertify.message('cancel...');
  }
}
