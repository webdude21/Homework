(function() {
  require(['structures'], function(structures) {
    var bulgarianHeroesSection, greekHeroesSection, heroesContainer, superheroesSection;
    heroesContainer = structures.getContainer();
	
    superheroesSection = structures.getSection('Superheroes');
    heroesContainer.add(superheroesSection);
    superheroesSection.add(structures.getData('Batman'));
    superheroesSection.add(structures.getData('Ironman'));
    superheroesSection.add(structures.getData('Superman'));
    superheroesSection.add(structures.getData('Wonderwoman'));
    superheroesSection.add(structures.getData('The Flash'));
    superheroesSection.add(structures.getData('Spiderman'));
    superheroesSection.add(structures.getData('Captain America'));
    superheroesSection.add(structures.getData('The Hulk'));
    superheroesSection.add(structures.getData('Green arrow'));
    superheroesSection.add(structures.getData('Green Lantern'));
	
    greekHeroesSection = structures.getSection('Greek Heroes');
    heroesContainer.add(greekHeroesSection);
    greekHeroesSection.add(structures.getData('Ajax'));
    greekHeroesSection.add(structures.getData('Hercules'));
    greekHeroesSection.add(structures.getData('Jason'));
    greekHeroesSection.add(structures.getData('Perseus'));
    greekHeroesSection.add(structures.getData('Odysseus'));
	
    bulgarianHeroesSection = structures.getSection('Bulgarian Heroes');
    heroesContainer.add(bulgarianHeroesSection);
    bulgarianHeroesSection.add(structures.getData('Hristo Botev'));
    bulgarianHeroesSection.add(structures.getData('Vasil Levski'));
    bulgarianHeroesSection.add(structures.getData('Chavdar Vyivoda'));
	
    console.log(JSON.stringify(heroesContainer.getData()));
  });


  /* Should produce:
  [{ "title": "Superheroes",
     "items": [{ "content": "Batman" },
               { "content": "Ironman" },
               { "content": "Superman" },
               { "content": "Wonderwoman" },
               { "content": "The Flash" },
               { "content": "Spiderman" },
               { "content": "Captain America" },
               { "content": "The Hulk" },
               { "content": "Green arrow" },
               { "content": "Green Lantern" }]
   }, 
   { "title": "Greek Heroes",
     "items": [{ "content": "Ajax" },
               { "content": "Hercules" },
               { "content": "Jason" },
               { "content": "Perseus" },
               { "content": "Odysseus" }]
  
   }, 
   { "title": "Bulgarian Heroes",
     "items": [{ "content": "Hristo Botev" },
               { "content": "Vasil Levski" },
               { "content": "Chavdar Vyivoda" }]
  }]
   */

}).call(this);

//# sourceMappingURL=app.map
