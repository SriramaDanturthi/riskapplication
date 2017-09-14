import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
@Component({
  selector: 'app-tac-review',
  templateUrl: './tac-review.component.html',
  styleUrls: ['./tac-review.component.css']
})
export class TacReviewComponent implements OnInit {
    public tacReviews: TacReview[];
    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/riskapplication/tacreviewdetails').subscribe(result => {
            this.tacReviews = result.json().auditIssues as TacReview[];
        }, error => console.error(error));
    }
    ngOnInit() {
    }

}

interface TacReview {
    Division: string;
    SuperDept: string;
    Department: string;
    Metric: string;
    IdentifierType: string;
    Identifier: string;
    Rating: string;
    Owner: string;
    Title: string;
    DueOccured: Date;
    Source: string;
    Link: string;
    AsOf: Date;
    Comments: string;
}
