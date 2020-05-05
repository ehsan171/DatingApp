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

@Component({
  selector: 'app-screenplay-reg',
  templateUrl: './screenplay-reg.component.html',
  styleUrls: ['./screenplay-reg.component.css']
})
export class ScreenplayRegComponent implements OnInit {


  constructor(private screenplayService: ScreenplayService,
              private userService: UserService,
              private authService: AuthService,
              private alertify: AlertifyService) { }

  @Input() valuesFromHome;
  @Output() cancelRegister = new EventEmitter();
  model: any = {};
  users: User[];
  persons: Person[];
  formats: BasicData[];
  screenplays: Screenplay[];
  screenplayTitle: [];
  skillForm = {
    screenplayTitle: [],
    producer: [],
    totalNumberEpisodes: [],
    baravord: [],
    format: [],
};


public sportsData: string[] = [];
public titleData: string[] = [];
public text = 'عنوان فیلمنامه';

// AutoComplete End

// Producer Start ---- Producer Start ---- Producer Start ---- Producer Start ---- Producer Start ---- Producer Start ----
// Dropdown Filtering Start

 // defined the array of data

 // tslint:disable-next-line: member-ordering
 public dataPerson: { [key: string]: Object }[] = [];
 public dataFormat: { [key: string]: Object }[] = [];
// maps the appropriate column to fields property

public fieldsPerson: object = { text: 'name', value: 'id' };
public fieldsFormat: object = { text: 'name', value: 'id' };

// set the placeholder to the DropDownList input
public textProducer = 'تهیه کننده';
public textFormat = 'قالب';

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
    this.alertify.error('gettingDataTitle');
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
    console.log(this.dataPerson)
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
    console.log(formats)
    for (let index = 0; index < formats.length; index++) {
      this.dataFormat.push({ id: '', name: ''});
      this.dataFormat[index].id = formats[index].id;
      this.dataFormat[index].name = formats[index].Name;
    }
    console.log(this.dataFormat)
  }, error => {
    this.alertify.error('This is from format');
  }
  );

}
// Bind the filter event
public onFilteringFormat: EmitType<any> =  (e: FilteringEventArgs) => {
  let queryFormat = new Query();
  // frame the query based on search string with filter type.
  queryFormat = (e.text !== '') ? queryFormat.where('Name', 'contains', e.text, true) : queryFormat;
  // pass the filter data source, filter query to updateData method.
  e.updateData(this.dataFormat, queryFormat);
}
// Total Number Episodes End ---- Total Number Episodes End ---- Total Number Episodes End ---- Total Number Episodes End ----




ngOnInit() {
    this.gettingDataTitle();
    this.gettingDataProducer();
    this.gettingDataFormats();
  }

  register(){
    console.log(this.skillForm.screenplayTitle[0]);
    console.log(this.skillForm.producer[0]);
    console.log(this.skillForm.totalNumberEpisodes[0]);
    console.log(this.skillForm.baravord[0]);
    console.log(this.skillForm.format[0]);
    console.log(this.skillForm);
    console.log(this.model.username);
    this.model.name = this.skillForm.screenplayTitle[0];
    this.authService.register(this.model).subscribe(() => {
      this.alertify.success('register succ...');
    }, error => {
      this.alertify.error('This is error from register');
    }
    );

  }

  cancel(){
    this.cancelRegister.emit(false);
    this.alertify.message('cancel...');
  }
}
