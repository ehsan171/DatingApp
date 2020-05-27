import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';
import { environment } from 'src/environments/environment';
import { Episode } from '../_models/episode';

@Component({
  selector: 'app-upload-test2',
  templateUrl: './upload-test2.component.html',
  styleUrls: ['./upload-test2.component.css']
})
export class UploadTest2Component implements OnInit {
  @Output() uploadName = new EventEmitter();
  uploader: FileUploader;
  hasBaseDropZoneOver: false;
  baseUrl = environment.apiUrl;


  constructor() {
  }

  ngOnInit() {
    this.initializeUploader();
  }

  public fileOverBase(e: any): void {
    this.hasBaseDropZoneOver = e;
  }

  initializeUploader(){
    this.uploader = new FileUploader({
      url: this.baseUrl + 'episode/upload/',
      authToken: 'Bearer' + localStorage.getItem('token'),
      isHTML5: true,
      allowedFileType: ['pdf'],
      removeAfterUpload: true,
      autoUpload: false,
    });

    this.uploader.onAfterAddingFile = (file) => {file.withCredentials = false; };
    this.uploader.onSuccessItem = (item, response, status, headers) => {
       if (response){
        this.uploadName.emit(response);
       }
    };
  }

}
