import { Component } from '@angular/core';
import { Item } from '../../models/item.model';
import { Observable } from 'rxjs/Observable';
import { FetchDataService } from './fetchdata.service';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
    private items: Observable<Array<Item>>;

    constructor(private ludotheque: FetchDataService) {
        this.getFullLudotheque();
    }

    getFullLudotheque() {
        this.items = this.ludotheque.getLudotheque();
    }
}
