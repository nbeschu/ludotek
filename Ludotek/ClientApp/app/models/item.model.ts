import { Tag } from './tag.model';

export class Item {
    nomItem: string;

    tags: Array<Tag>;

    constructor() {
        this.nomItem = "";
        this.tags = new Array<Tag>();
    }
}