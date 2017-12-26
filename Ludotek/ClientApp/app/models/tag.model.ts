import { JsonProperty } from "json-typescript-mapper";

export class Tag {
    @JsonProperty('nomTag')
    public nomTag: string;
    
    constructor() {
        this.nomTag = void 0;
    }
}