import { Component, OnInit, Output, EventEmitter, Input, Renderer2 } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { Query } from '@syncfusion/ej2-data';
import { FilteringEventArgs } from '@syncfusion/ej2-angular-dropdowns';
import { EmitType } from '@syncfusion/ej2-base';
import { User } from '../_models/user';
import { ResourceService } from '../_services/resource.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Resource } from '../_models/resource';
import { Allocation } from '../_models/allocation';
import * as moment from 'jalali-moment';
import { title } from 'process';
import { AllocationRegister } from '../_models/allocationRegister';
import { fromEvent } from 'rxjs';
import { skipUntil, takeUntil } from 'rxjs/operators';
import { event } from 'jquery';
declare var $: any;

@Component({
  selector: 'app-final-registration-two',
  templateUrl: './final-registration-two.component.html',
  styleUrls: ['./final-registration-two.component.css']
})
export class FinalRegistrationTwoComponent implements OnInit {

  
  name = 'Angular 5';
  mouseX: number;
  mouseY: number;
  sub: any;
  box: any;
  mousedown$;
  mouseup$;
  clickDown:boolean;

  selectedOption: string;
  selectedCapacity: number;

  constructor(
    public renderer: Renderer2,
    private resourceService: ResourceService,
    private alertify: AlertifyService) { }

  @Input() valuesFromDetail;
  @Output() cancelRegister = new EventEmitter();
  colors: any = [];
  random: number  ;
  color: number   ;
  totalOfColumn: any = [];
  remainResourceOfColumn: any = [];
  header: any = [];
  header2: any = [];
  RowsData: any = [];
  RowsExtraData: any = [];
  IsCellClick: any = [ ]  
  test: any = {};
  test2: any = {};
  requestVolume: number;
  resourceId: number = 1;
  totalDay: number;
  totalHour: number = 24;
  year: number;

 
  //month: number  = +moment().locale('fa').format('mm');;
  month: number ;
  barnameId: number ;
  model: any = {};
  modelProcess: any = {};
  screenplayRegForm: FormGroup;
  users: User[];
  resources: Resource[];
  resourceInfo: any;
  resourceUnit: string;
  allocation: Allocation[];
  allocationRegister: AllocationRegister[];
  id: any;
  


  public capacityFields: any = [];
  public yearFields: any = [];
  public monthFields: any = [];
  public resourceFields: any = [];
  public dataResource: { [key: string]: Object }[] = [];
  public fieldResource: object = { text: 'name', value: 'id' };
  public fieldMonth: object = { text: 'name', value: 'id' };

  

  public data: { [key: string]: any }[] = [];
  public yearData: { [key: string]: any }[] = [];
  public monthData: { [key: string]: any }[] = [];
  public dataTitleResource: { [key: string]: any }[] = [];

  public textResource = 'منبع';
  public textCapacity = 'ظرفیت مورد نیاز';
  public textYear = 'سال';
  public textMonth = 'ماه';

  resourceForm = new FormGroup({
    capacity: new FormControl(),
    yearFormControl: new FormControl(),
    monthFormControl: new FormControl(),
    resourceId: new FormControl('20')
}); 

mouseClickDown(event){
if(event.which == 1){
this.clickDown = true;

}
}
mouseClickUp(event){
if(event.which == 1){
this.clickDown = false;

}
}

  gettingDataCapacity(resourceId) {

    this.resourceService.getResource(resourceId).subscribe((resource: Resource[]) => {
      this.resourceInfo = resource;

      this.data=[]
      for (let index = 0; index < this.resourceInfo[0].capacity; index++) {
        this.data.push({ value: 0,  name: '' });
        this.data[index].value = index + 1;
        this.data[index].name = index + 1;

      }
  
      this.capacityFields = { dataSource: this.data, value: 0, text: 'name'};
      this.resourceUnit = this.resourceInfo[0].unit;

    }, () => {
      this.alertify.error('This is from orgField');
    }
    );

  }
  gettingDataYearMonth() {
    var currentTime = new Date()
    var year = +moment().locale('fa').format('YYYY');
   
    

      for (let y = year-2; y < year+3; y++) {
        this.yearData.push({ value: y,  name: y });
 
      }

  
      this.yearFields = { dataSource: this.yearData, value: 0, text: 'name'};

      let month = ['فروردین', 'اردیبهشت', 'خرداد', 'تیر', 'مرداد', 'شهریور', 'مهر', 'آبان', 'آذر', 'دی', 'بهمن', 'اسفند', ]

      month.forEach((value, index) => {
   
        this.monthData.push({ id: '' });

        this.monthData[index].name = value;
        this.monthData[index].id = index+1;
    });

      this.monthFields = { dataSource: this.monthData, value: 0, text: 'name'};
     
  }



  gettingWaitingForAcceptAllocation(resourceId, year, month) {
    this.colors = [ '#358cff ', '	#ff6e4a', '#c3e3f5 ', '#76b3e8' ];

this.random  = Math.floor((Math.random() * 9) + 1);
this.color   = Math.floor((Math.random() * this.colors.length - 1) + 1);

      this.RowsData = [ ]
      this.RowsExtraData = [ ]
      this.totalOfColumn = []  
      this.IsCellClick = [ ]  
      
          this.header=["hour"]
          this.header2=["hour"]
          

           this.header2.push("تاریخ ثبت")
          for (let i = 1; i <= 24;i++){
            this.header.push(i)
            this.totalOfColumn[i]= 0;
          }
           this.resourceService.getWaitingRequestAllocations(resourceId,year,month).subscribe((allocation: Allocation[]) => {
        
          //this.resourceService.getAllocations(1,1400,m).subscribe((allocation: Allocation[]) => {


        
          this.allocation = allocation['allocations'];
          this.resourceInfo = allocation['test'];
      
                 
          for (let i = 1; i <= 24;i++){
         
            this.remainResourceOfColumn[i]= this.resourceInfo[0]['resourceCapacity'];
          }
                
          for (let index = -1; index <this.allocation[3].length; index++) { 
  


           let index2 =(index == -1 ? 0 : index);
          this.test =   
                    {  
                      "hour" :this.allocation[3][index2][0]['title']
                    }
          let test3 =   
                    {  
                      "hour" :this.allocation[3][index2][0]['title'],
                      "producer" :this.allocation[3][index2][0]['producers']
                    }
                  
          this.test2 =   
                    {  
                      "hour" : index
                    }
                  console.log("this.allocation[3][index2][0]['producers'][0]  ",this.allocation[3][index2][0]['producers'][0])
                  this.RowsData.push(this.test);
                 
                  this.RowsExtraData.push(test3);
                  this.IsCellClick.push(this.test2);
                 
                
          }
          this.test =   
          {  
            "hour" :"مجموع"
          }
          this.totalOfColumn.push(this.test);
     this.totalOfColumn['hour'] = "مجموع"

          for (let index = 1; index < this.RowsData.length; index++) { 
        

                // this.RowsData[index][index2] = this.resourceInfo[0]['resourceCapacity'];
                // this.RowsData[index][this.allocation[3][1][0]['hour']] = this.allocation[3][index2][0]['usedUnit'];
             
                  for(let j = 0 ; j < this.allocation[3][index-1].length; j++){
                    (this.RowsData[index][this.allocation[3][index-1][j]['hour']]) =0 ;
                  }
                     
                  for(let j = 0 ; j < this.allocation[3][index-1].length; j++){
                          
                    (this.RowsData[index][this.allocation[3][index-1][j]['hour']]) += (this.allocation[3][index-1][j]['usedUnit']) ;
                    this.totalOfColumn[this.allocation[3][index-1][j]['hour']] += this.allocation[3][index-1][j]['usedUnit'];
                   
                  }
                  this.remainResourceOfColumn['hour'] = "منبع آزاد"
              
             
                 
         
        
                
          }
          

          this.resourceService.getFreeResourcePerHour(resourceId,year,month,this.allocation[3][0][0]['day']).subscribe((allocation: Allocation[]) => {
        
            //this.resourceService.getAllocations(1,1400,m).subscribe((allocation: Allocation[]) => {
  
  
          
            this.allocation = allocation['allocations'];
            this.resourceInfo = allocation['test'];
        
             console.log("sssssss ", this.allocation)     
            for (let index = 0; index <this.allocation.length; index++) { 
    
  console.log(index);
  this.remainResourceOfColumn[this.allocation[index]['hour']] -= this.allocation[index]['usedResource']
  

                   
                  
            }
            
  
  
           
        
            //this.RowsData.shift()
  
          }, () => {
            this.alertify.error('This is from orgField');
          }
          );
         
         
      
          //this.RowsData.shift()

        }, () => {
          this.alertify.error('This is from orgField');
        }
        );
       


  }
  gettingWaitingAllocation(resourceId, year, month) {
    
    let monthName = ['فروردین', 'اردیبهشت', 'خرداد', 'تیر', 'مرداد', 'شهریور', 'مهر', 'آبان', 'آذر', 'دی', 'بهمن', 'اسفند', ]

    var numberOfDays: number[] = [31,62,93,124,155,186,216,246,276,306,336,365];
      this.RowsData = [ ]  
      this.IsCellClick = [ ]  
      
          this.header=["hour"]
          
          
          for (let i = 1; i <= 24;i++){
            this.header.push(i)
          }
           this.resourceService.getAcceptedAllocations(resourceId,year).subscribe((allocation: Allocation[]) => {
          //this.resourceService.getAllocations(1,1400,m).subscribe((allocation: Allocation[]) => {


        
          this.allocation = allocation['allocations'];
          this.resourceInfo = allocation['test'];
                
          for (let index = -1; index <365; index++) { 
            var index33=numberOfDays.findIndex(function(number) {
              return number > index;
            });
          this.test =   
                    {  
                      "hour" :1+(index33 <= 0 ? index : index-numberOfDays[index33-1] )+"  "+ monthName[index33]
                    }
                  
          this.test2 =   
                    {  
                      "hour" : index
                    }
                  
                  this.RowsData.push(this.test);
                  this.IsCellClick.push(this.test2);
                
                  
                
          }

          for (let index = 0; index <= 365; index++) { 
        
            for (let index2 = 1; index2 <= 24; index2++) {
                this.RowsData[index][index2] = this.resourceInfo[0]['resourceCapacity'];
                this.IsCellClick [index][index2] = false;
            }
        
                
          }
          

          
          for (let index = 0; index < this.allocation.length; index++) {
            var daysPassedInLastMonths = this.allocation[index].month == 0 ? 0 : numberOfDays[this.allocation[index].month-2];
            var dayIndexOfYear = this.allocation[index].day + daysPassedInLastMonths;

            this.RowsData[dayIndexOfYear][this.allocation[index].hour]-=this.allocation[index].usedUnit;
            // this.IsCellClick[this.allocation[index].hour][this.allocation[index].day]=false;
       

          }
          console.log("this.RowsData   "+this.RowsData[0][8])
          //this.RowsData.shift()

        }, () => {
          this.alertify.error('This is from orgField');
        }
        );
       

      
  


  }

  onChangeRequestRes(requestResValue) {
    this.requestVolume = requestResValue;

    this.gettingWaitingForAcceptAllocation(this.resourceId,this.year, this.month);


}

  onChangeResource(deviceValue) {

  
  
    this.resourceId = deviceValue;
    this.gettingWaitingForAcceptAllocation(this.resourceId,this.year, this.month);

    this.gettingDataCapacity( this.resourceId);

}
  onChangeYear(value) {
  
    let todayJalali = moment().locale('fa').format('YYYY');

  
    this.year = value;

    this.gettingWaitingForAcceptAllocation(this.resourceId,this.year, this.month);


}
  onChangeMonth(valueMonth) {

    this.month = valueMonth;
  

    this.gettingWaitingForAcceptAllocation(this.resourceId,this.year, this.month);


}

gettingDataResource(){
  this.resourceService.getResources().subscribe((resources: Resource[]) => {
    this.resources = resources;
    for (let index = 0; index < resources.length; index++) {
      this.dataResource.push({ id: '' });

      this.dataResource[index].name = resources[index].title;
      this.dataResource[index].id = resources[index].id;
    }
  }, () => {
    this.alertify.error('This is from member');
  }
  );

}
  
gettingResources() {
  this.resourceService.getResources().subscribe((resources: Resource[]) => {
    this.resources = resources;
  
    for (let index = 0; index < resources.length; index++) {

      this.dataTitleResource.push({ value: 0,  name: '' });
      this.dataTitleResource[index].value = resources[index].id;
      this.dataTitleResource[index].name = resources[index].title;
    
    }

    this.resourceFields = { dataSource: this.dataTitleResource, value: 0, text: 'name'};

    
  }, () => {
    this.alertify.error('gettingDataTitle 106');
  }
  );

}

onCellClick(rowIndex,columnIndex){

  if(this.clickDown){
      if(this.requestVolume <= this.RowsData[rowIndex][columnIndex])
      {
         this.IsCellClick[rowIndex][columnIndex] = (this.IsCellClick[rowIndex][columnIndex]) ? false : true;
        
      }
      const listOfObjecs = [
        { id: 1,  score: 11 },

      ];
      listOfObjecs.push( { id: rowIndex,  score: columnIndex })

       
  }
 

}
onCellClickSingleClick(rowIndex,columnIndex,event){

  if(event.which==1){
      if(this.requestVolume <= this.RowsData[rowIndex][columnIndex])
      {
         this.IsCellClick[rowIndex][columnIndex] = (this.IsCellClick[rowIndex][columnIndex]) ? false : true;
        
      }
      const listOfObjecs = [
        { id: 1,  score: 11 },

      ];
      listOfObjecs.push( { id: rowIndex,  score: columnIndex })

       

    }

}

onSave(){
  
  this.allocationRegister = [];
  for( let dayIndex = 0; dayIndex <= 365; dayIndex++){
    console.log("dayIndex   "+dayIndex)
    for (let hourIndex = 0; hourIndex < this.totalHour; hourIndex++){
      if(this.IsCellClick[dayIndex][hourIndex]){
        this.allocationRegister.push({ barnameId:0, year:0, month:0, day:0, hour:0, usedUnit:0, resourceId:0, isDeleted:true });
        let index =this.allocationRegister.length - 1;
        this.allocationRegister[index].barnameId = this.barnameId;
        this.allocationRegister[index].year = this.year;
        this.allocationRegister[index].month = this.month;
        this.allocationRegister[index].day = dayIndex + 1 ;
        this.allocationRegister[index].hour = hourIndex ;

        this.allocationRegister[index].usedUnit = this.selectedCapacity;
        this.allocationRegister[index].registerDate = new Date();
        this.allocationRegister[index].isDeleted = false;
        this.allocationRegister[index].resourceId = this.resourceId;
      }
    }
  }
console.log(this.allocationRegister)
}


register(){
this.allocationRegister
this.resourceService.registerAllocation(this.allocationRegister).subscribe(() => {

this.alertify.success('ثبت نام با موفقیت انجام شد.');
this.gettingWaitingForAcceptAllocation(
  this.allocationRegister[0].resourceId,
  this.allocationRegister[0].year,
  this.allocationRegister[0].month);
}, error => {
this.alertify.error(error.error);
}
);

}
cancelRegisterMode(event: number){
  this.barnameId = event;
}

public onFilteringResource: EmitType<any> =  (e: FilteringEventArgs) => {
  let queryResource = new Query();
  // frame the query based on search string with filter type.
  queryResource = (e.text !== '') ? queryResource.where('name', 'contains', e.text, true) : queryResource;
  // pass the filter data source, filter query to updateData method.
  e.updateData(this.dataResource, queryResource);
}



  ngOnInit() {

    $(document).ready(function () {

      $('.example1').pDatepicker({
        observer: true,
        format: 'YYYY/MM/DD',
        altField: '.observer-example-alt',
        initialValue: false,
        onSelect: function (dateText) {
          $('#exa2').val(dateText);
          // alert(dateText)

        }

      });

    });

    this.screenplayRegForm = new FormGroup({
      Title: new FormControl('', [
        Validators.required
      ]),

      orgStructure: new FormControl('', [
        Validators.required
      ]),
      producer: new FormControl('', [
        Validators.required
      ]),
      baravordNo: new FormControl('', [
        Validators.required,
        Validators.pattern('^[0-9]*$'),
        Validators.minLength(6),
        Validators.maxLength(6)
      ]),
      totalNumberEpisodes: new FormControl(),
      format: new FormControl('', [
        Validators.required
      ]),
      statusId: new FormControl('', [
        Validators.required
      ]),
      genre: new FormControl('', [
        Validators.required
      ]),
      regDate: new FormControl(),

    });

    this.gettingWaitingForAcceptAllocation(7,1400, 4);
  
    // this.gettingDataCapacity(4);
    this.gettingResources();
    this.gettingDataResource();
    this.gettingDataYearMonth();
    this.screenplayRegForm.patchValue({
      orgStructure: []
    });


  
  }

}
