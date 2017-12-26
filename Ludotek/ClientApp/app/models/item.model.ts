import { Tag } from './tag.model';
import { JsonProperty } from 'json-typescript-mapper';

export class Item {
    @JsonProperty('nomItem')
    nomItem: string;

    @JsonProperty('tags')
    tags: Array<Tag>;

    constructor() {
        this.nomItem = "";
        this.tags = new Array<Tag>();
    }
}