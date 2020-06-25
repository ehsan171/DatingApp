import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { DataManager, Query, ODataV4Adaptor } from '@syncfusion/ej2-data';
import { FilteringEventArgs } from '@syncfusion/ej2-angular-dropdowns';
import { EmitType } from '@syncfusion/ej2-base';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { SafeScript } from '@angular/platform-browser';
import { ScreenplayService } from '../_services/screenplay.service';
import { Screenplay } from '../_models/screenplay';
import { Person } from '../_models/person';
import { BasicData } from '../_models/basicData';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Status } from '../_models/status';
import { data } from '../test_data/datasource';
import { Router } from '@angular/router';
import { OrgStructure } from '../_models/orgStructure';

declare var $: any;

@Component({
  selector: 'app-screenplay-reg',
  templateUrl: './screenplay-reg.component.html',
  styleUrls: ['./screenplay-reg.component.css']
})
export class ScreenplayRegComponent implements OnInit {


  constructor(private screenplayService: ScreenplayService,
              private userService: UserService,
              private authService: AuthService,
              private alertify: AlertifyService,
              private router: Router) { }

  @Input() valuesFromDetail;
  @Output() cancelRegister = new EventEmitter();
  model: any = {};
  modelProcess: any = {};
  screenplayRegForm: FormGroup;
  users: User[];
  persons: Person[];
  formats: BasicData[];
  orgs: OrgStructure[];
  statuses: Status[];
  genres: BasicData[];
  screenplays: Screenplay[];
  screenplayTitle: [];
  skillForm = {
    screenplayTitle: [],
    producer: [],
    totalNumberEpisodes: [],
    baravord: [],
    format: [],
    genre: [],
};
myDate: any;
id: any;

public sportsData: string[] = [];
public titleData: string[] = [];
public text = 'عنوان فیلمنامه';

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
public textProducer = 'تهیه کننده';
public textFormat = 'قالب';
public textStatus = 'وضعیت';
public textGenre = 'ژانر';
public textOrgStructure = 'ساختار سازمانی';

// Dropdown Filtering End
// Producer End ---- Producer End ---- Producer End ---- Producer End ---- Producer End ---- Producer End ---- Producer End ----

// Total Number Episodes Start ---- Total Number Episodes Start ---- Total Number Episodes Start ---- Total Number Episodes Start ----
public textTotalNumberEpisodes = 'تعداد قسمت ';
// Total Number Episods End ---- Total Number Episods End ---- Total Number Episods End ----

// Baravord Start --- Baravord Start --- Baravord Start --- Baravord Start --- Baravord Start --- Baravord Start ---
public textBaravord = 'شماره برآورد';
// Baravord End --- Baravord End --- Baravord End --- Baravord End --- Baravord End ---



gettingDataTitle(){
  this.screenplayService.getScreenplays().subscribe((screenplays: Screenplay[]) => {
    this.screenplays = screenplays;
    for (let index = 0; index < screenplays.length; index++) {
      this.titleData[index] = screenplays[index].title;
    }
  }, error => {
    this.alertify.error('gettingDataTitle 106');
  }
  );

}


gettingDataProducer(){
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
  let queryProducer = new Query();
  // frame the query based on search string with filter type.
  queryProducer = (e.text !== '') ? queryProducer.where('name', 'contains', e.text, true) : queryProducer;
  // pass the filter data source, filter query to updateData method.
  e.updateData(this.dataPerson, queryProducer);
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


public focusIn(target: HTMLElement): void {

  target.parentElement.classList.add('e-input-focus');
}

public focusOut(target: HTMLElement): void {
  target.parentElement.classList.remove('e-input-focus');
}

public onMouseDown(target: HTMLElement): void {
  target.classList.add('e-input-btn-ripple');

}

public onMouseUp(target: HTMLElement): void {
  let ele: HTMLElement = target;
  setTimeout(
          () => {ele.classList.remove('e-input-btn-ripple'); },
          500);
}


public data: { [key: string]: any }[] = [];


public orgFields: any = [];

// defining fieldMapping
gettingDataOrgs() {

  this.screenplayService.getOrgs().subscribe((orgs: OrgStructure[]) => {
    this.orgs = orgs;
    for (let index = 0; index < orgs.length; index++) {
      this.data.push({ id: '', pid: '', name: '', hasChild: true, expanded: true });
      this.data[index].id = orgs[index].id;
      this.data[index].name = orgs[index].name;
      this.data[index].pid = orgs[index].parentId;
      this.data[index].isinner = orgs[index].isInner;
      this.data[index].orgId = orgs[index].orgId;
      this.data[index].hasChild = true;
      this.data[index].expanded = false;
    }
    this.orgFields = { dataSource: this.data, value: 'id', text: 'name', parentValue: 'pid', hasChildren: 'hasChild' };

    console.log(this.data);
  }, error => {
    this.alertify.error('This is from format');
  }
  );

}
ngOnInit() {

  $(document).ready(function() {

    $('.example1').pDatepicker({
      observer: true,
      format: 'YYYY/MM/DD',
      altField: '.observer-example-alt',
      initialValue: false,
      onSelect: function(dateText) {
        $('#exa2').val(dateText);
        // alert(dateText)

}

    });

  });

//   $(document).ready(function(){
//    $( ".table-days" ).click(function() {
//   $('#exa2').val(this.dataset.unix);
//   // alert(this.dataset.unix)
// });
//     });


  // tslint:disable-next-line: only-arrow-functions
  $('.awsome_input').focusin(function() {
    $('#tool-tip').show();
}).change(function()
{
 //  alert($(this).val());
  if ($(this).val() === ''){
    if ($(this).val() === ''){
     $('#tool-tip').hide();
    }
  }

});


  this.screenplayRegForm = new FormGroup({
      Title: new FormControl('', [
        Validators.required
      ]),

      orgStructure: new FormControl(),
      producer: new FormControl(),
      baravordNo: new FormControl('', [
        Validators.required,
        Validators.pattern( '^[0-9]*$'),
        Validators.minLength(6),
        Validators.maxLength(6)
      ]),
      totalNumberEpisodes: new FormControl(),
      format: new FormControl(),
      statusId: new FormControl(),
      genre: new FormControl(),
      regDate: new FormControl(),

  });

  this.gettingDataTitle();
  this.gettingDataProducer();
  this.gettingDataFormats();
  this.gettingDataGeners();
  this.gettingDataStatuses();
  this.gettingDataOrgs();
  this.screenplayRegForm.patchValue({
    orgStructure: []
  });
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

    const el = document.querySelector('table tr td');
    // alert((document.getElementById('exa2') as HTMLInputElement).value);
    const regDate = (document.getElementById('exa') as HTMLInputElement).value;
    const regDate2 = (document.getElementById('exa') as HTMLInputElement).dataset[0];
    const unixTimestamp = 1590020379  ;

    this.model.regDate = (document.getElementById('exa2') as HTMLInputElement).value;

    const date = new Date(this.model.regDate * 1);


    if (this.screenplayRegForm.valid){
        this.model = Object.assign({}, this.screenplayRegForm.value);
        this.model.regDate = `${date.getFullYear()}/${date.getMonth() + 1}/${date.getDate()}`;
        // alert(regDate)
        // this.myDate = new Date();

        // this.model.regDate =  '5/21/2020';
        // this.model.orgStructure = [1];
        console.log(this.model);
        this.screenplayService.register(this.model).subscribe(res => {

          this.modelProcess.UserId = this.authService.decodedToken?.nameid;
          this.modelProcess.Type = '3';
          this.modelProcess.Activity = 'ثبت فیلمنامه ' +  this.model.Title ;
          this.authService.processReg(this.modelProcess).subscribe(() => {
          }, error => {
            this.alertify.error('This is error from register Process');
          }
          );

          this.alertify.success('فیلمنامه «' + this.model.Title + '» باموفقیت ثبت شد.');
          this.router.navigate(['/screenplay/' + res['data'].id]);
        }, error => {
          this.alertify.error('This is error from register sssssstest');
        }
        );
      }
      else{

        this.alertify.error('ثبت تمامی قسمت ها الزامی می باشد');
      }

  }

  cancel(){
    this.cancelRegister.emit(false);
    this.alertify.message('cancel...');
  }
}
