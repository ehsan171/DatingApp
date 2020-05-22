import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { HttpEventType, HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {
  public message: string;
  public progress: number;
  // tslint:disable-next-line: no-output-on-prefix
  @Output() public onUploadFinished = new EventEmitter();
  @Input() valuesFromDetail;
  
  constructor(private http: HttpClient) { }

  ngOnInit() {
    
  }

  public uploadFile = (files, screenplayId) => {
  
    if (files.length === 0) {
      return;
    }

    // let fileToUpload = <File>files[0];
    const fileToUpload = files[0] as File;
    const formData = new FormData();
 
    formData.append('file', fileToUpload, fileToUpload.name);
    console.log('http://localhost:5000/api/' + 'episode/upload/')
    // this.http.post('http://localhost:5000/api/upload', formData);
    this.http.post('http://localhost:5000/api/' + 'episode/upload/', formData, {reportProgress: true, observe: 'events'})
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress) {
         
          this.progress = Math.round(100 * event.loaded / event.total);
        }
        else if (event.type === HttpEventType.Response) {
          console.log("fffffff")
          this.message = 'فایل با موفقیت دریافت شد.';
          this.onUploadFinished.emit(event.body);
        }
      });
  }
}