import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Item } from '../models/item.model';
import { deserialize } from 'json-typescript-mapper';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Injectable()
export class FetchDataService {
    constructor(private http: HttpClient) {}

    getLudotheque(searchedItem: string): Observable<Array<Item>> {
        return this.http.get('api/Ludotheque/' + searchedItem)
            .map((result: Array<Object>) => result.map((item: Object) => deserialize(Item, item)));
    }
}