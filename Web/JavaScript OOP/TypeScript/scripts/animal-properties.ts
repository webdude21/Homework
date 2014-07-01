module AnimalProperties {
    "use strict";
    export enum Diet { Carnivore, Herbivore, Omnivore }
    export enum SocialBehavior { Egoistic, Cooperative, Altruistic, Revengeful }
    export enum Environment { Forest, Plains, Jungle, Urban, Arctic, Sea, Ocean, River }

    export class State {
        hungry: boolean;
        healthy: boolean;
        happy: boolean;

        constructor(hungry?: boolean, healthy?: boolean, happy?: boolean) {
            this.hungry = hungry || true;
            this.healthy = healthy || true;
            this.happy = happy || true;
        }
    }
}

