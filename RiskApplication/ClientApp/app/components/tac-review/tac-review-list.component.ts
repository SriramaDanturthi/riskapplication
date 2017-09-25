import { Component, Inject, Input, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { GridDataResult, PageChangeEvent, RowClassArgs } from '@progress/kendo-angular-grid';
@Component({
    selector: 'app-tac-review-list',
    templateUrl: './tac-review-list.component.html'
})
export class TacReviewListComponent implements OnInit {
    @Input() public list: any;
    private finalresult: GridDataResult;
    private skip: number = 0;
    private pageSize: number = 10;
    constructor(http: Http) {
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
        this.finalresult = {
            data: this.list.slice(this.skip, this.skip + this.pageSize),
            total: this.list.length
        };
    }

}
