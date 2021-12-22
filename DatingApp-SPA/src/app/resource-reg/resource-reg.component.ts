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
import { animate, state, style, transition, trigger } from '@angular/animations';

      declare var $: any;
      
      @Component({
        selector: 'app-resource-reg',
        templateUrl: './resource-reg.component.html',
        styleUrls: ['./resource-reg.component.css'],
        animations: [
          trigger('openClose', [
            // ...
            state('open', style({
              // height: '200px',
              
              opacity: 1,
              display: '',
              // backgroundColor: 'yellow'
            })),
            state('closed', style({
              opacity: 0,
              height: '000px',
              display: 'none' ,
              
              // backgroundColor: 'blue'
            })),
            transition('open => closed', [
              animate('1s')
            ]),
            transition('closed => open', [
              animate('0.1s')
            ]),
          ]),
        ],
        
      })
      export class ResourceRegComponent implements OnInit {

        options = [
          {name:'OptionA', value:'1', checked:true},
          {name:'OptionB', value:'2', checked:false},
          {name:'OptionC', value:'3', checked:true}
        ]
        selectedDaysForDeletion = [
          {name:1, value:1, checked:true},
       
        ]
       


                  
     
      
        get selectedOptions() { // right now: ['1','3']
          return this.options
                    .filter(opt => opt.checked)
                    .map(opt => opt.value)
                    
        }  


 math = Math;
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
        header: any = [];
        RowsData: any = [];
        RowsDataForColor: any = [];
        RowsDataForEachBarname: any = [];
        IsCellClick: any = [ ]  
        IsCellClickForColor: any = [ ]  
        IsCellClickForEachBarname: any = [ ]  
        test: any = {};
        test2: any = {};
        requestVolume: number = 90;
        resourceId: number = 7;
        totalDay: number;
        totalHour: number = 24;
        year: number;
        //month: number  = +moment().locale('fa').format('mm');;
        dayName:string;
        month: number ;
        barnameId: number =2 ;
        model: any = {};
        modelProcess: any = {};
        screenplayRegForm: FormGroup;
        users: User[];
        resources: Resource[];
        resourceInfo: any;
        resourceInfoForColor: any;
        resourceInfoForEachBarname: any;
        resourceUnit: string;
        allocation: Allocation[];
        allocationForColor: Allocation[];
        allocationForEachBarname: Allocation[];
        allocationRegister: AllocationRegister[];
        id: any;
        selectedDayForDelete: Array<number>=[];
        selectAllDays: boolean = false;
        monthName:any = ['فروردین', 'اردیبهشت', 'خرداد', 'تیر', 'مرداد', 'شهریور', 'مهر', 'آبان', 'آذر', 'دی', 'بهمن', 'اسفند', ];

        nameFarsi: any = ['روز'];
        ArrayRowsExtraDataset: any = [];
        isShown: boolean;

   

    divFunction() {
       this.isShown = !this.isShown;

    }
  
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
          console.log("mouse:   "+this.clickDown +" from down  " + event.which)
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

        gettingAllocation(resourceId: number, year: number, month: number) {
          var monthNumber = month < 7 ? 31 : (month < 12 ? 30:29);
          this.totalDay = monthNumber;

          this.resourceService.getAllocations(resourceId,year,month).subscribe((allocation: Allocation[]) => {
            this.header=["hour"]
          
            for (let i = 1; i <= 24;i++){
              this.header.push(i)
            }
            this.RowsData = [ ]  
            this.IsCellClick = [ ]  
          
            this.allocation = allocation['allocations'];
            this.resourceInfo = allocation['test'];
            let formattedMonth = month.toLocaleString('en-US', {
              minimumIntegerDigits: 2,
              useGrouping: false
            })

      for (let index = 0; index <=monthNumber ; index++) { 
          

          let formattedNumber = index.toLocaleString('en-US', {
            minimumIntegerDigits: 2,
            useGrouping: false
          })
      

          let myDate =(year.toString()+formattedMonth.toString()+formattedNumber.toString())
      this.test =   
                {  
                  "hour" : moment(myDate,"jYYYYjMMjDD",'fa').format('ddd, ll')
        
                }
              
      this.test2 =   
                {  
                  "hour" : index
                }
              
              this.RowsData.push(this.test);
              this.IsCellClick.push(this.test2);
            
              
            
            }

            for (let index = 0; index <= monthNumber; index++) { 
          
              for (let index2 = 1; index2 <= 24; index2++) {
                  this.RowsData[index][index2] = this.resourceInfo[0]['resourceCapacity'];
                  this.IsCellClick [index][index2] = false;
              }
          
                   
            }
            for (let index = 0; index < this.allocation.length; index++) {

              this.RowsData[this.allocation[index].day][this.allocation[index].hour]-=this.allocation[index].usedUnit;
              // this.IsCellClick[this.allocation[index].hour][this.allocation[index].day]=false;

            }
            //this.RowsData.shift()

          }, () => {
            this.alertify.error('This is from orgField');
          }
          );
          
          
          this.resourceService.getWaitingAllocationsForColor(resourceId,year,month).subscribe((allocation: Allocation[]) => {
            this.header=["hour"]
          
            for (let i = 1; i <= 24;i++){
              this.header.push(i)
            }
            this.RowsDataForColor = [ ]  
        
            this.IsCellClickForColor = [ ]  
          
            this.allocationForColor = allocation['allocations'];
            this.resourceInfoForColor = allocation['test'];

      for (let index = 0; index <=monthNumber ; index++) { 
          
      this.test =   
                {  
                  "hour" : index
                }
              
      this.test2 =   
                {  
                  "hour" : index
                }
              
              this.RowsDataForColor.push(this.test);
        
              this.IsCellClickForColor.push(this.test2);
            
              
            
            }

            for (let index = 0; index <= monthNumber; index++) { 
          
              for (let index2 = 1; index2 <= 24; index2++) {
                  this.RowsDataForColor[index][index2] = this.resourceInfoForColor[0]['resourceCapacity'];
                  this.IsCellClickForColor [index][index2] = false;
              }
          
                   
            }

            for (let index = 0; index < this.allocationForColor.length; index++) {

              this.RowsDataForColor[this.allocationForColor[index].day][this.allocationForColor[index].hour]-=this.allocationForColor[index].usedUnit;

            }
            //this.RowsData.shift()

          }, () => {
            this.alertify.error('This is from orgField');
          }
          );

          this.resourceService.getWaitingAllocationsForEachBarname(resourceId,year,month,this.barnameId).subscribe((allocation: Allocation[]) => {
            this.header=["hour"]
          
            for (let i = 1; i <= 24;i++){
              this.header.push(i)
            }
          
            this.RowsDataForEachBarname = [ ]  
            this.IsCellClickForEachBarname = [ ]  
          
            this.allocationForEachBarname = allocation['allocations'];
            this.resourceInfoForEachBarname = allocation['test'];

      for (let index = 0; index <=monthNumber ; index++) { 
          
      this.test =   
                {  
                  "hour" : index
                }
              
      this.test2 =   
                {  
                  "hour" : index
                }
              
        
              this.RowsDataForEachBarname.push(this.test);
              this.IsCellClickForEachBarname.push(this.test2);
            
              
            
            }

            for (let index = 0; index <= monthNumber; index++) { 
          
              for (let index2 = 0; index2 < 24; index2++) {
                 
                  this.IsCellClickForEachBarname [index][index2] = false;
              }
          
                   
            }

            for (let index = 0; index < this.allocationForEachBarname.length; index++) {
console.log("10004", this.allocationForEachBarname[index].day," hour:  ",this.allocationForEachBarname[index].hour, "  id:", this.barnameId)
              this.IsCellClickForEachBarname[this.allocationForEachBarname[index].day-1][this.allocationForEachBarname[index].hour]=true;

            }
            //this.RowsData.shift()

          }, () => {
            this.alertify.error('This is from orgField');
          }
          );

          this.selectedDaysForDeletion=[]
          for (let index = 1; index <=monthNumber ; index++) { 
            
            let dayTest =   
            {name:index, value:index, checked:false}
   
                    
            this.selectedDaysForDeletion.push(dayTest);
        }

      }

        onChangeRequestRes(requestResValue) {
          this.requestVolume = requestResValue;

          this.gettingAllocation(this.resourceId,this.year,this.month);


        }

        onChangeResource(deviceValue) {

        
        
          this.resourceId = deviceValue;
          this.gettingAllocation(this.resourceId,this.year,this.month);
          this.gettingDataCapacity( this.resourceId);

        }
        onChangeYear(value) {
        
          let todayJalali = moment().locale('fa').format('YYYY');

          this.year = value;

          this.gettingAllocation(this.resourceId,this.year,this.month);

        }
        onChangeMonth(valueMonth) {
 
          this.month = valueMonth;
        

          this.gettingAllocation(this.resourceId,this.year,this.month);

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
          rowIndex +=1;
          if(this.clickDown){
              if(this.requestVolume <= this.RowsData[rowIndex][columnIndex])
              {
                this.IsCellClick[rowIndex-1][columnIndex] = (this.IsCellClick[rowIndex-1][columnIndex]) ? false : true;
                
              }
              const listOfObjecs = [
                { id: 1,  score: 11 },

              ];
              listOfObjecs.push( { id: rowIndex,  score: columnIndex })

              
          }
        

        }
        onCellClickSingleClick(rowIndex,columnIndex,event){

          if(event.which==1){
           if(this.requestVolume <= this.RowsData[rowIndex+1][columnIndex])
              {
              
                this.IsCellClick[rowIndex][columnIndex] = (this.IsCellClick[rowIndex][columnIndex]) ? false : true;
                
              }
              const listOfObjecs = [
                { id: 1,  score: 11 },

              ];
              listOfObjecs.push( { id: rowIndex,  score: columnIndex })

              
        
            }

        }

        


deleteRequestConform(resourceId: any, year: any, month: any, day: any, barnameId: any){
  this.alertify.confirm('آیا مطمئن هستید؟ ',()=>{
    this.resourceService.deleteRequestByGroup(resourceId,year,month, day, barnameId).subscribe((allocation: Allocation[]) => {
      this.gettingAllocation(
        this.resourceId,
        this.year,
        this.month);

  }, () => {
    this.alertify.error('امکان حذف وجود ندارد');
  }
  );});
}

deleteAll(resourceId, year, month,  barnameId){
  
console.log("8007",barnameId)
  this.alertify.confirm('آیا مطمئن هستید؟ ',()=>{
      for (var deleteDay of this.selectedDaysForDeletion) {
          if(deleteDay.checked){
            this.resourceService.deleteRequestByGroup(resourceId,year,month, deleteDay.value, barnameId).subscribe((allocation: Allocation[]) => {
              this.gettingAllocation(
                this.resourceId,
                this.year,
                this.month);
        
          }, () => {
            this.alertify.error('امکان حذف وجود ندارد');
          }
    );
    }
    
}
  ;});

}

selectAll(){
console.log(this.selectAllDays)

  for (let index =0 ; index < this.selectedDaysForDeletion.length; index++) {
        this.selectedDaysForDeletion[index].checked = !this.selectAllDays;
        console.log("804",this.selectedDaysForDeletion[index].checked)
    }

      
    


}

clickOnRadioBtn(event, day: number){
  this.selectedDayForDelete.push(day);
  console.log("801", this.selectedDaysForDeletion)
  console.log("801", event.checked)
  console.log("803", this.options)
}

toggleShow() {

  this.isShown = ! this.isShown;
  
  }
        onSave(){
          
          this.allocationRegister = [];
          for( let dayIndex = 0; dayIndex <= this.totalDay; dayIndex++){
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



        }

      
        register(){
          this.allocationRegister
          this.resourceService.registerAllocation(this.allocationRegister).subscribe(() => {

            this.alertify.success('ثبت نام با موفقیت انجام شد.');
            this.gettingAllocation(
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

        setMyStyle() {
          let styles = {
            'background':'#eb01a5',
            // 'background-image': 'url("https://getsatisfaction.com/corp/img/product/five_obstacles.png"), linear-gradient(red, yellow)',
            // 'background-repeat':'no-repeat'
          };
          return styles;
      }
        setMyStyle2() {
          let styles = {
            'background':'green',
            // 'background-image': 'url("https://getsatisfaction.com/corp/img/product/five_obstacles.png"), linear-gradient(red, yellow)',
            // 'background-repeat':'no-repeat'
          };
          return styles;
      }
        setMyStyle3() {
          let styles = {
            'background':'red',
            // 'background-image': 'url("https://getsatisfaction.com/corp/img/product/five_obstacles.png"), linear-gradient(red, yellow)',
            // 'background-repeat':'no-repeat'
          };
          return styles;
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

          this.gettingAllocation(7,1400,4);
          // this.gettingDataCapacity(4);
          this.gettingResources();
          this.gettingDataResource();
          this.gettingDataYearMonth();
          this.screenplayRegForm.patchValue({
            orgStructure: []
          });


        
        }

      }
