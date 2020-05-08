import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { DataManager, Query, ODataV4Adaptor, ReturnOption } from '@syncfusion/ej2-data';
import { FilteringEventArgs } from '@syncfusion/ej2-angular-dropdowns';
import { EmitType } from '@syncfusion/ej2-base';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { SafeScript } from '@angular/platform-browser';
import { data } from '../test_data/datasource';


const SERVICE_URI = 'http://localhost:5000/api/tusers';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {

  @Input() valuesFromHome;
  @Output() cancelRegister = new EventEmitter();
  model: any = {};
  public users: User[];
  public items: object[];
  public s: any

  constructor(private userService: UserService, private authService: AuthService, private alertify: AlertifyService) { }
  skillForm = {
    skillname: [],
    skillname2: [],
    skillname3: [],
    skillname4: [],
    skillname5: [],
    sname: '',
    smail: ''
};



public skillset: string[] = [
  'ASP.NET', 'ActionScript', 'Basic',
  'C++' , 'C#' , 'dBase' , 'Delphi' ,
  'ESPOL' , 'F#' , 'FoxPro' , 'Java',
  'J#' , 'Lisp' , 'Logo' , 'PHP'
];
public placeholder: String = 'e.g: ActionScript';

// --------------------------------------------------------------------------------

// Dropdown Tree Start
// defined the array of data
public data: { [key: string]: Object }[] = [
{
   nodeId: '01', nodeText: 'Music',
   nodeChild: [
       { nodeId: '01-01', nodeText: 'Gouttes.mp3' }
   ]
},
{
   nodeId: '02', nodeText: 'Videos', expanded: true,
   nodeChild: [
       { nodeId: '02-01', nodeText: 'Naturals.mp4' },
       { nodeId: '02-02', nodeText: 'Wild.mpeg' },
   ]
},
{
   nodeId: '03', nodeText: 'Documents', expanded: true,
   nodeChild: [
       { nodeId: '03-01', nodeText: 'Environment Pollution.docx' },
       { nodeId: '03-02', nodeText: 'Global Water, Sanitation, & Hygiene.docx' },
       { nodeId: '03-03', nodeText: 'Global Warming.ppt' },
       { nodeId: '03-04', nodeText: 'Social Network.pdf' },
       { nodeId: '03-05', nodeText: 'Youth Empowerment.pdf' },
   ]
},
];
// binding data source through fields property
public fields: Object = { dataSource: this.data, value: 'nodeId', text: 'nodeText', child: 'nodeChild' };

// Dropdown Tree End
// ----------------------------------------------------------------------------------


// Dropdown Filtering Start

 // defined the array of data

 public data_dropdown: { [key: string]: Object }[] = [];


gettingData(){
  this.userService.getUsers().subscribe((users: User[]) => {
    this.users = users;
    for (let index = 0; index < users.length; index++) {
      this.data_dropdown.push({ id: '', username: '' });
      this.data_dropdown[index].username = users[index].username;
      this.data_dropdown[index].id = users[index].id;
    }
  }, error => {
    this.alertify.error('This is from member');
  }
  );

}
// maps the appropriate column to fields property

public fieldsDropdown: object = { text: 'username', value: 'id' };

// set the placeholder to the DropDownList input
public text: string = 'Select a country';
// Bind the filter event
public onFiltering: EmitType<any> =  (e: FilteringEventArgs) => {
  let query = new Query();
  // frame the query based on search string with filter type.
  query = (e.text !== '') ? query.where('username', 'startswith', e.text, true) : query;
  // pass the filter data source, filter query to updateData method.
  e.updateData(this.data_dropdown, query);
}

// Dropdown Filtering End

// -----------------------------------------------------------------

// AutoComplete Start

public sportsData: string[] = ['Badminton', 'Basketball', 'Cricket', 'Football', 
'Golf', 'Gymnastics', 'Hockey', 'Rugby', 'Snooker', 'Tennis'];

gettingData2(){
  this.userService.getUsers().subscribe((users: User[]) => {
    this.users = users;
    for (let index = 0; index < users.length; index++) {
      
      this.sportsData[index]= users[index].username;
     
    }
  }, error => {
    this.alertify.error('This is from member');
  }
  );

}

// AutoComplete End


  ngOnInit(): void {
    new DataManager({ url: SERVICE_URI }).executeQuery(new Query().where('username', 'equal', 'aaa').take(6)).then((e: ReturnOption) => {
      this.items = e.result as object[];
  }).catch((e) => true);

    this.gettingData();
    this.gettingData2();
  }


  register(){
    console.log(this.skillForm.skillname[0]);
    console.log(this.skillForm.skillname2[0]);
    console.log(this.skillForm.skillname3[0]);
    console.log(this.skillForm.skillname4[0]);
    console.log(this.skillForm.skillname5[0]);
    console.log(this.skillForm);
    console.log(this.model.username);
    this.model.name = this.skillForm.skillname[0];
    this.authService.register(this.model).subscribe(() => {
      this.alertify.success('register succ...');
    }, error => {
      this.alertify.error('This is error from register test');
    }
    );

  }

  cancel(){
    this.cancelRegister.emit(false);
    this.alertify.message('cancel...');
  }
}
