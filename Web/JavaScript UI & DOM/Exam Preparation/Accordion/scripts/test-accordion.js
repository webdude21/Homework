function testAccordion(){
    var accordion = getAccordion("#accordion-holder");
    accordion.add("Web");
    accordion.add("Desktop");
    accordion.add("Mobile");
    accordion.add("Embedded");
    accordion.render();
}