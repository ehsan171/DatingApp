import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { HttpClient, HttpEvent, HttpRequest, HttpEventType } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ScreenplayService } from '../_services/screenplay.service';

@Component({
  selector: 'app-test-download',
  templateUrl: './test-download.component.html',
  styleUrls: ['./test-download.component.css'],
  // providers: [FileService]
})
export class TestDownloadComponent implements OnInit {
  @Input() public disabled: boolean;
  @Input() public fileName: string;
  @Input() valuesFromEpisodeAll;
  // @Output() public downloadStatus: EventEmitter<progressstatus>;
 
  constructor(
    private screenplayService: ScreenplayService,
  ) {
    // this.downloadStatus = new EventEmitter<progressstatus>();

  }
  ngOnInit(): void {

  }

  public download() {
  

    this.fileName = '1.pdf';

    // this.downloadStatus.emit( {status: ProgressStatusEnum.START});
    this.screenplayService.downloadFile(this.fileName).subscribe(
      data => {

        switch (data.type) {

          case HttpEventType.Response:
            const downloadedFile = new Blob([data.body], { type: data.body.type });
            const a = document.createElement('a');
            a.setAttribute('style', 'display:none;');
            document.body.appendChild(a);
            a.download = this.fileName;
            a.href = URL.createObjectURL(downloadedFile);
            a.target = '_blank';
            a.click();
            document.body.removeChild(a);
            break;
        }
      },
      error => {

      }
    );
  }

}
