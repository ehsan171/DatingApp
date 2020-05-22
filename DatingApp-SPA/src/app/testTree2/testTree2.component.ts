import { Component, OnInit, ViewChild } from '@angular/core';
import { enableRipple } from '@syncfusion/ej2-base';
import { TreeViewComponent } from '@syncfusion/ej2-angular-navigations';
import { UploadingEventArgs } from '@syncfusion/ej2-angular-inputs';
 
@Component({
  selector: 'app-testTree2',
  templateUrl: './testTree2.component.html',
  styleUrls: ['./testTree2.component.css']
})
export class TestTree2Component implements OnInit {
  public path: Object = {
    saveUrl: 'http://localhost:5000/api/' + 'episode/upload/',
    removeUrl: 'http://localhost:5000/api/episode/upload/delete' };
    public onUploadSuccess(args: any): void  {
      if (args.operation === 'upload') {
          console.log('File uploaded successfully');
      }
  }

  public onUploadFailure(args: any): void  {
  console.log('File failed to upload');
  }

  public dropEle: HTMLElement ;

  public onUploadBegin(args: UploadingEventArgs) {
    // check whether the file is uploading from paste.
    // if (args.fileData.fileSource === 'paste') {
        // let newName: string = getUniqueID(args.fileData.name.substring(0, args.fileData.name.lastIndexOf('.'))) + '.png';
        args.customFormData = [{'fileName': "ggggggg"}];
    // }
}
  constructor() {

  }
  skillForm = {
    skillname: [],
    skillname2: [],
    skillname3: [],
    skillname4: [],
    skillname5: [],
    skillname6: [],
    skillname7: [],
    sname: '',
    smail: ''
};

  // dataSource
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
  public fields :Object = { dataSource: this.data, value: 'id', text: 'name', parentValue:"pid", hasChildren: 'hasChild'  };
  ngOnInit() {
    this.dropEle = document.getElementById('droparea');
  }
  
  register(){
    console.log("jhjhg")
    console.log(this.skillForm.skillname7)
    console.log(this.skillForm.skillname6)
    
  }

  cancel(){
    
  }

}
