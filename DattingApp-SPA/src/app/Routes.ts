import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MessagesComponent } from './Messages/Messages.component';
import { MembrelistsComponent } from './members/membrelists/membrelists.component';
import { ListsComponent } from './Lists/Lists.component';
import { AuthGuard } from './_guards/auth.guard';
import { MemberDetailedCardComponent } from './members/member-detailed-card/member-detailed-card.component';
import { MemberDetailResolver } from './_resolvers/member-detail.resolver';
import { MemberListResolver } from './_resolvers/member-list.resolver';



export const appRoutes: Routes = [
{path: '', component: HomeComponent},
{
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children : [
        {path: 'messages', component: MessagesComponent},
        {path: 'members', component: MembrelistsComponent, resolve : {users: MemberListResolver}},
        {path: 'members/:id', component: MemberDetailedCardComponent , resolve: {user: MemberDetailResolver } },
        {path: 'lists', component: ListsComponent},
    ]
},

{path: '**', redirectTo: '', pathMatch: 'full'
}
,
] ;
