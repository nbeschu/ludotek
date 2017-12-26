import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Item } from '../models/item.model';
import { Tag } from '../models/tag.model';
import { deserialize } from 'json-typescript-mapper';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Injectable()
export class FetchDataService {
    constructor(private http: HttpClient) {}

    getExistingTags(): Observable<Array<Tag>> {
        return this.http.get('api/tag/')
            .map((result: Array<Object>) => result.map((item: Object) => deserialize(Tag, item)));
    }

    getLudothequeByItem(searchedItem: string): Observable<Array<Item>> {
        return this.http.get('api/ludotheque/' + searchedItem)
            .map((result: Array<Object>) => result.map((item: Object) => deserialize(Item, item)));
    }

    getLudothequeByTagAndItem(searchedTag: string, searchedItem: string): Observable<Array<Item>> {
        return this.http.get('api/tag/' + searchedTag + '/items/' + searchedItem)
            .map((result: Array<Object>) => result.map((item: Object) => deserialize(Item, item)));
    }
}