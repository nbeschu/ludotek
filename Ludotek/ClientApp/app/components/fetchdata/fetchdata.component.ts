import { Component, OnInit } from '@angular/core';
import { Item } from '../../models/item.model';
import { Observable } from 'rxjs/Observable';
import { FetchDataService } from '../../services/fetchdata.service';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent implements OnInit {
    items: Observable<Array<Item>>;

    constructor(private ludotheque: FetchDataService) { };

    ngOnInit() {
    };

    getLudotheque(searchedItem: string) {
        this.items = this.ludotheque.getLudotheque(searchedItem);
    };
}
