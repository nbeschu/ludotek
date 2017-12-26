import { Tag } from './tag.model';
import { JsonProperty } from 'json-typescript-mapper';

export class Item {
    @JsonProperty('nomItem')
    public nomItem: string;

    @JsonProperty({ name: 'tags', clazz: Tag })
    public tags: Array<Tag>;

    constructor() {
        this.nomItem = void 0;
        this.tags = void 0;
    }
}