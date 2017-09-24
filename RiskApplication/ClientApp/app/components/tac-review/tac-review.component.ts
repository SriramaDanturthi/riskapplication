import { DomSanitizer } from '@angular/platform-browser';
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
    constructor(http: Http, @Inject('BASE_URL') baseUrl: string, private sanitizer: DomSanitizer) {
        http.get(baseUrl + 'api/riskapplication/GetAuditReportSummary').subscribe(result => {
            this.auditReportSummary = result.json() as AuditReportSummary[];
        }, error => console.error(error));
    }
    ngOnInit() {
    }
    public colorCode(code: TacReview) {
        let result= "red";
        //switch (code) {
        //    case "C1":
        //        result = "red";
        //        break;
        //    case "C2":
        //        result = "orange";
        //        break;
        //    default:
        //        result = "light-green";
        //        break;
        //}
        return this.sanitizer.bypassSecurityTrustStyle(result);
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