function testAccordion(){
    var accordion = getAccordion("#accordion-holder");
    var webItem = accordion.add("Web");
    webItem.add("HTML");
    webItem.add("CSS");
    webItem.add("JavaScript");
    webItem.add("jQuery");
    webItem.add("ASP.NET MVC");
    accordion.add("Desktop");
    accordion.add("Mobile");
    accordion.add("Embedded");
    accordion.render();
}