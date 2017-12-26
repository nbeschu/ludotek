import { Component } from '@angular/core';
import { Item } from '../../models/item.model';
import { Observable } from 'rxjs/Observable';
import { FetchDataService } from '../../services/fetchdata.service';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
    private items: Array<Item>;

    constructor(private ludotheque: FetchDataService) {
    }

    ngOnInit() {
        this.getFullLudotheque();

        console.log(this.items);
    }

    getFullLudotheque() {
        this.ludotheque.getLudotheque().subscribe(data => {
            this.items = data
        });
    }
}
