import { Component, Inject, Input, OnInit } from '@angular/core';
import { Http, URLSearchParams } from '@angular/http';
import { GridDataResult, PageChangeEvent, RowClassArgs } from '@progress/kendo-angular-grid';
import { TacReview } from './tac-review.component';
@Component({
    selector: 'app-tac-review-list',
    templateUrl: './tac-review-list.component.html'
})
export class TacReviewListComponent implements OnInit {
    public tacReviews: TacReview[];
    @Input() public list: any;
    private finalresult: GridDataResult;
    private skip: number = 0;
    private pageSize: number = 10;
    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        let params: URLSearchParams = new URLSearchParams();
        params.set('metric', 'Audit Issue past its due date');
        params.set('idType', 'Audit Issues');
        http.get(baseUrl + 'api/riskapplication/GetAuditReportDetails', { search: params }).subscribe(result => {
            this.tacReviews = result.json() as TacReview[];
        }, error => console.error(error));
    }
    ngOnInit() {
        //this.finalresult = (<GridDataResult>{
        //    data:this.list,
        //    total:20
        //});
        //console.log(this.list);
        this.bindData();
    }


    protected pageChange(event: PageChangeEvent): void {
        this.skip = event.skip;
        console.log('SKIP : ' + this.skip);
        this.bindData();

    }

    private bindData(): void {
        console.log(this.list);
        //this.finalresult = {
        //    data: this.list.slice(this.skip, this.skip + this.pageSize),
        //    total: this.list.length
        //};
    }

}
