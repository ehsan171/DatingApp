import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './member-list/member-list.component';
import { MessagesComponent } from './messages/messages.component';
import { ListsComponent } from './lists/lists.component';
import { ScreenplayComponent } from './screenplay/screenplay.component';
import { AuthGuard } from './_guards/auth.guard';
import { AuthService } from './_services/auth.service';
import { ScreenplayDetailComponent } from './screenplay-detail/screenplay-detail.component';
import { ScreenplayEditComponent } from './screenplay-edit/screenplay-edit.component';
import { ResourceRegComponent } from './resource-reg/resource-reg.component';
import { RequestRegComponent } from './request-reg/request-reg.component';
import { FinalRegistrationComponent } from './final-registration/final-registration.component';
import { FinalRegistrationTwoComponent } from './final-registration-two/final-registration-two.component';



export const appRoutes: Routes = [
    {path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {path: 'members', component: MemberListComponent},
            {path: 'messages', component: MessagesComponent},
            {path: 'screenplay', component: ScreenplayComponent},
            {path: 'screenplay/edit', component: ScreenplayEditComponent},
            {path: 'screenplay/:id', component: ScreenplayDetailComponent},
            {path: 'resource', component: ResourceRegComponent},
            {path: 'request', component: RequestRegComponent},
            {path: 'final-registration', component: FinalRegistrationComponent},
            {path: 'final-registration_two', component: FinalRegistrationTwoComponent},
        ]
    },
    {path: 'lists', component: ListsComponent, canActivate: [AuthGuard]},
    {path: '**', redirectTo: '', pathMatch: 'full'},
];
