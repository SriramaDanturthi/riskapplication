import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { GridModule } from '@progress/kendo-angular-grid';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { TacReviewComponent } from './components/tac-review/tac-review.component';
import { TacReviewListComponent } from './components/tac-review/tac-review-list.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        TacReviewComponent,
        TacReviewListComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        GridModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'tac-review', pathMatch: 'full' },
            { path: 'tac-review', component: TacReviewComponent },
            { path: '**', redirectTo: 'tac-review' }
        ])
    ]
})
export class AppModuleShared {
}
