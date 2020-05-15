import { Component, OnInit } from '@angular/core';
import { User } from '../_models/user';
import { Screenplay } from '../_models/screenplay';
import { AlertifyService } from '../_services/alertify.service';
import { UserService } from '../_services/user.service';
import { ScreenplayService } from '../_services/screenplay.service';



@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
  users: User[];
  screenplays: Screenplay[];
  va: any;
  constructor(private userService: UserService, private screenplayService: ScreenplayService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadUsers();
    this.loadScreenplays();
    this.test();

  }
  test() {
    this.userService.test().subscribe((users: any) => {
      this.va = users;
    }, error => {
      this.alertify.error('This is from member');
    }
    );
  }
   loadUsers() {
    this.userService.getUsers().subscribe((users: User[]) => {
      this.users = users;
    }, error => {
      this.alertify.error('This is from member');
    }
    );
  }
   loadScreenplays() {
      this.screenplayService.getScreenplays().subscribe((screenplays: Screenplay[]) => {
      this.screenplays = screenplays;
    }, error => {
      this.alertify.error('This is from member');
    }
    );
  }

}
