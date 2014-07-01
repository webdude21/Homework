var AnimalProperties;
(function (AnimalProperties) {
    "use strict";
    (function (Diet) {
        Diet[Diet["Carnivore"] = 0] = "Carnivore";
        Diet[Diet["Herbivore"] = 1] = "Herbivore";
        Diet[Diet["Omnivore"] = 2] = "Omnivore";
    })(AnimalProperties.Diet || (AnimalProperties.Diet = {}));
    var Diet = AnimalProperties.Diet;
    (function (SocialBehavior) {
        SocialBehavior[SocialBehavior["Egoistic"] = 0] = "Egoistic";
        SocialBehavior[SocialBehavior["Cooperative"] = 1] = "Cooperative";
        SocialBehavior[SocialBehavior["Altruistic"] = 2] = "Altruistic";
        SocialBehavior[SocialBehavior["Revengeful"] = 3] = "Revengeful";
    })(AnimalProperties.SocialBehavior || (AnimalProperties.SocialBehavior = {}));
    var SocialBehavior = AnimalProperties.SocialBehavior;
    (function (Environment) {
        Environment[Environment["Forest"] = 0] = "Forest";
        Environment[Environment["Plains"] = 1] = "Plains";
        Environment[Environment["Jungle"] = 2] = "Jungle";
        Environment[Environment["Urban"] = 3] = "Urban";
        Environment[Environment["Arctic"] = 4] = "Arctic";
        Environment[Environment["Sea"] = 5] = "Sea";
        Environment[Environment["Ocean"] = 6] = "Ocean";
        Environment[Environment["River"] = 7] = "River";
    })(AnimalProperties.Environment || (AnimalProperties.Environment = {}));
    var Environment = AnimalProperties.Environment;

    var State = (function () {
        function State(hungry, healthy, happy) {
            this.hungry = hungry || true;
            this.healthy = healthy || true;
            this.happy = happy || true;
        }
        return State;
    })();
    AnimalProperties.State = State;
})(AnimalProperties || (AnimalProperties = {}));
//# sourceMappingURL=animal-properties.js.map
