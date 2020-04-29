import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { __importDefault } from 'tslib';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
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
