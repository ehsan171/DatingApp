import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-screenplay-reg',
  templateUrl: './screenplay-reg.component.html',
  styleUrls: ['./screenplay-reg.component.css']
})
export class ScreenplayRegComponent implements OnInit {
  @Input() valuesFromHome;
  @Output() cancelRegister = new EventEmitter();
  model: any = {};
  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  register(){
    this.authService.register(this.model).subscribe(() => {
      this.alertify.success('register succ...');
      console.log(this.model.photoUrl);
    }, error => {
      this.alertify.error('This is error from register');
    }
    );

  }

  cancel(){
    this.cancelRegister.emit(false);
    this.alertify.message('cancel...');
  }
}
