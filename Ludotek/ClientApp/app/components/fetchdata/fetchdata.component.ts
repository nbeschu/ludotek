import { Component, OnInit } from '@angular/core';
import { Item } from '../../models/item.model';
import { Observable } from 'rxjs/Observable';
import { FetchDataService } from '../../services/fetchdata.service';
import { Tag } from '../../models/tag.model';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent implements OnInit {
    items: Observable<Array<Item>>;
    existingTags: Observable<Array<Tag>>;
    selectedTag: string

    constructor(private ludotheque: FetchDataService) {
        this.selectedTag = void 0;
    };

    ngOnInit() {
        this.existingTags = this.ludotheque.getExistingTags();
    };

    onSelectionChange(tag: Tag) {
        this.selectedTag = tag.nomTag;
    }

    getLudotheque(searchedItem: string) {
        if (this.selectedTag === undefined) {
            this.getLudothequeByItem(searchedItem);
        }
        else {
            this.getLudothequeByTagAndItem(this.selectedTag, searchedItem);
        }
    };

    getLudothequeByItem(searchedItem: string) {
        this.items = this.ludotheque.getLudothequeByItem(searchedItem);
    };

    getLudothequeByTagAndItem(searchedTag: string, searchedItem: string) {
        this.items = this.ludotheque.getLudothequeByTagAndItem(searchedTag, searchedItem);
    };
}
