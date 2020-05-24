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
        ]
    },
    {path: 'lists', component: ListsComponent, canActivate: [AuthGuard]},
    {path: '**', redirectTo: '', pathMatch: 'full'},
];
