import { Component, OnInit } from '@angular/core';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-screenplay',
  templateUrl: './screenplay.component.html',
  styleUrls: ['./screenplay.component.css']
})
export class ScreenplayComponent implements OnInit {
  registerMode = true;
  values: any;
  users: User[];

  selectedDay: any = '';

  // event handler for the select element's change event
  selectChangeHandler(event: any) {
    this.selectedDay = event.target.value;
    this.alertify.message(this.selectedDay);
  }
  constructor(private userService: UserService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadUsers();
  }

  loadUsers() {
    this.userService.getUsers().subscribe((users: User[]) => {
      this.users = users;
    }, error => {
      this.alertify.error('This is from member');
    }
    );
  }


  cancelRegisterMode(registerMode: boolean){
    this.registerMode = registerMode;
  }

}
