import { Component, OnInit } from '@angular/core';
declare var require: any;
const FileSaver = require('file-saver');

@Component({
  selector: 'app-test-download',
  templateUrl: './test-download.component.html',
  styleUrls: ['./test-download.component.scss']
})
export class TestDownloadComponent implements OnInit {
 
  constructor() { }
 

  ngOnInit() {
  }

}
