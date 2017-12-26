import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Item } from '../models/item.model';
import { deserialize } from 'json-typescript-mapper';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Injectable()
export class FetchDataService {
    constructor(private http: Http) {}

    getLudotheque(): Observable<Array<Item>> {
        return this.http.get('api/Ludotheque')
            .map(res => {
                return res.json().results.map((item: Object) => deserialize(Item, item));
            });
    }
}