import { Component, OnInit } from '@angular/core';
import { UploadingEventArgs } from '@syncfusion/ej2-angular-inputs';

@Component({
  selector: 'app-upload2',
  templateUrl: './upload2.component.html',
  styleUrls: ['./upload2.component.css']
})
export class Upload2Component implements OnInit {

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
  constructor() { }

  ngOnInit() {
  }

}
