import { Component, OnInit, Output, EventEmitter, Input, ViewChild } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { DataManager, Query, ODataV4Adaptor, ReturnOption } from '@syncfusion/ej2-data';
import { FilteringEventArgs } from '@syncfusion/ej2-angular-dropdowns';
import { EmitType } from '@syncfusion/ej2-base';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { SafeScript } from '@angular/platform-browser';
import { data } from '../test_data/datasource';
import { TreeViewComponent } from '@syncfusion/ej2-angular-navigations';
import { ScreenplayService } from '../_services/screenplay.service';




const SERVICE_URI = 'http://localhost:5000/api/tusers';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {
  
  public dropEle: HTMLElement ;
  constructor(private screenplayService: ScreenplayService,
              private userService: UserService, 
              private authService: AuthService, 
              private alertify: AlertifyService) { }
  // @ViewChild('samples')
  
  public tree: TreeViewComponent;

  @Input() valuesFromHome;
  @Output() cancelRegister = new EventEmitter();
  model: any = {};
  public users: User[];
  public items: object[];
  public s: any
  skillForm = {
    skillname: [],
    skillname2: [],
    skillname3: [],
    skillname4: [],
    skillname5: [],
    skillname7: [],
    sname: '',
    smail: ''
};

// -------------------------------------------------------------------
// defined the array of data
public dataTree: { [key: string]: Object }[] = [
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
     nodeId: '03', nodeText: 'Documents',
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
 public fieldsTree: Object = { dataSource: this.dataTree, value: 'nodeId', text: 'nodeText', child: 'nodeChild' };




// ------------------------------------------------------------------------
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
// maps the appropriate column to fields property

public fieldsDropdown: object = { text: 'username', value: 'id' };

// set the placeholder to the DropDownList input
public text: string = 'Select a country';

// Dropdown Filtering End

// -----------------------------------------------------------------

// AutoComplete Start

public sportsData: string[] = ['Badminton', 'Basketball', 'Cricket', 'Football', 
'Golf', 'Gymnastics', 'Hockey', 'Rugby', 'Snooker', 'Tennis'];

// AutoComplete End

public countries: Object[] = [
  { id: 1, name: 'Australia', hasChild: true, expanded: true },
  { id: 2, pid: 1, name: 'New South Wales' },
  { id: 3, pid: 1, name: 'Victoria' },
  { id: 4, pid: 1, name: 'South Australia' },
  { id: 6, pid: 1,  name: 'Western Australia' },
  { id: 7, name: 'Brazil', hasChild: true },
  { id: 8, pid: 7, name: 'Paraná' },
  { id: 9, pid: 7, name: 'Ceará' },
  { id: 10, pid: 7, name: 'Acre' },
  { id: 11, name: 'China', hasChild: true },
  { id: 12, pid: 11, name: 'Guangzhou' },
  { id: 13, pid: 11, name: 'Shanghai' },
  { id: 14, pid: 11, name: 'Beijing' },
  { id: 15, pid: 11, name: 'Shantou' },
  { id: 16, name: 'France', hasChild: true },
  { id: 17, pid: 16, name: 'Pays de la Loire' },
  { id: 18, pid: 16, name: 'Aquitaine' },
  { id: 19, pid: 16, name: 'Brittany' },
  { id: 20, pid: 16, name: 'Lorraine' , hasChild: true },
  { id: 20, pid: 20, name: 'Lorraine2' },
  { id: 21, name: 'India', hasChild: true },
  { id: 22, pid: 21, name: 'Assam' },
  { id: 23, pid: 21, name: 'Bihar' },
  { id: 24, pid: 21, name: 'Tamil Nadu' },
  { id: 25, pid: 21, name: 'Punjab' }
];

 // maps the appropriate column to fields property
 public fieldT: Object = { dataSource: this.countries, id: 'id', parentID: 'pid', text: 'name', hasChildren: 'hasChild' };
    // set the CheckBox to the TreeView
    public showCheckBox: boolean = true;
    //set the checknodes to the TreeView
    public checkedNodes: string[] = ['2','6'];
    public nodeChecked(args): void{
      console.log("The checked node's id is: "+this.tree.checkedNodes);

    }


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
// Bind the filter event
public onFiltering: EmitType<any> =  (e: FilteringEventArgs) => {
  let query = new Query();
  // frame the query based on search string with filter type.
  query = (e.text !== '') ? query.where('username', 'startswith', e.text, true) : query;
  // pass the filter data source, filter query to updateData method.
  e.updateData(this.data_dropdown, query);
}

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

  ngOnInit(): void {
    new DataManager({ url: SERVICE_URI }).executeQuery(new Query().where('username', 'equal', 'aaa').take(6)).then((e: ReturnOption) => {
      this.items = e.result as object[];
  }).catch((e) => true);

    this.gettingData();
    this.gettingData2();
    this.dropEle = document.getElementById('droparea');
  }


  register(){
    
    console.log(this.skillForm.skillname7[0]);
    console.log(this.skillForm);
    console.log("csacascdasd")
    console.log("The checked node's id is: "+this.tree.nodeChecked);
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
