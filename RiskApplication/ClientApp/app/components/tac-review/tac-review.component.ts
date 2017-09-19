import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { AuditReportSummary } from './reviewSummary';
import { IdType } from './IdType';
@Component({
    selector: 'app-tac-review',
    templateUrl: './tac-review.component.html',
    styleUrls: ['./tac-review.component.css']
})
export class TacReviewComponent implements OnInit {
    public auditReportSummary: AuditReportSummary[];
    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/riskapplication/GetAuditReportSummary').subscribe(result => {
            this.auditReportSummary = result.json() as AuditReportSummary[];
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