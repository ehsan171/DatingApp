import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { DataManager, Query, ODataV4Adaptor } from '@syncfusion/ej2-data';
import { FilteringEventArgs } from '@syncfusion/ej2-angular-dropdowns';
import { EmitType } from '@syncfusion/ej2-base';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { SafeScript } from '@angular/platform-browser';

@Component({
  selector: 'app-screenplay-reg',
  templateUrl: './screenplay-reg.component.html',
  styleUrls: ['./screenplay-reg.component.css']
})
export class ScreenplayRegComponent implements OnInit {


  constructor(private userService: UserService, private authService: AuthService, private alertify: AlertifyService) { }
  @Input() valuesFromHome;
  @Output() cancelRegister = new EventEmitter();
  model: any = {};
  users: User[];
  skillForm = {
    screenplayTitle: [],
    producer: [],
    totalNumberEpisodes: [],
    baravord: [],
    skillname5: [],
};


public sportsData: string[] = [];
public text = 'عنوان فیلمنامه';

// AutoComplete End

// Producer Start ---- Producer Start ---- Producer Start ---- Producer Start ---- Producer Start ---- Producer Start ---- 
// Dropdown Filtering Start

 // defined the array of data

 // tslint:disable-next-line: member-ordering
 public dataProducer: { [key: string]: Object }[] = [];
// maps the appropriate column to fields property

public fieldsProducer: object = { text: 'username', value: 'id' };

// set the placeholder to the DropDownList input
public textProducer = 'تهیه کننده';

// Dropdown Filtering End
// Producer End ---- Producer End ---- Producer End ---- Producer End ---- Producer End ---- Producer End ---- Producer End ----

// Total Number Episodes Start ---- Total Number Episodes Start ---- Total Number Episodes Start ---- Total Number Episodes Start ----
public textTotalNumberEpisodes = 'تعداد قسمت ';
// Total Number Episods End ---- Total Number Episods End ---- Total Number Episods End ----

// Baravord Start --- Baravord Start --- Baravord Start --- Baravord Start --- Baravord Start --- Baravord Start ---
public textBaravord = 'شماره برآورد';
// Baravord End --- Baravord End --- Baravord End --- Baravord End --- Baravord End --- 

gettingDataTitle(){
  this.userService.getUsers().subscribe((users: User[]) => {
    this.users = users;
    for (let index = 0; index < users.length; index++) {
      this.sportsData[index] = users[index].username;
    }
  }, error => {
    this.alertify.error('gettingDataTitle');
  }
  );

}


gettingDataProducer(){
  this.userService.getUsers().subscribe((users: User[]) => {
    this.users = users;
    for (let index = 0; index < users.length; index++) {
      this.dataProducer.push({ id: '', username: '' });
      this.dataProducer[index].username = users[index].username;
      this.dataProducer[index].id = users[index].id;
    }
  }, error => {
    this.alertify.error('This is from member');
  }
  );

}
// Bind the filter event
public onFilteringProducer: EmitType<any> =  (e: FilteringEventArgs) => {
  let queryProducer = new Query();
  // frame the query based on search string with filter type.
  queryProducer = (e.text !== '') ? queryProducer.where('username', 'startswith', e.text, true) : queryProducer;
  // pass the filter data source, filter query to updateData method.
  e.updateData(this.dataProducer, queryProducer);
}
// Total Number Episodes End ---- Total Number Episodes End ---- Total Number Episodes End ---- Total Number Episodes End ----
  ngOnInit() {
    this.gettingDataTitle();
    this.gettingDataProducer();
  }

  register(){
    console.log(this.skillForm.screenplayTitle[0]);
    console.log(this.skillForm.producer[0]);
    console.log(this.skillForm.totalNumberEpisodes[0]);
    console.log(this.skillForm.baravord[0]);
    console.log(this.skillForm.skillname5[0]);
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
