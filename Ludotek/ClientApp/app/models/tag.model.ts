import { JsonProperty } from "json-typescript-mapper";

export class Tag {
    @JsonProperty('nomTag')
    nomTag: string;

    constructor() {
        this.nomTag = "";
    }
}