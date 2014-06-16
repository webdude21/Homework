function testGridView() {
    var schoolsGrid = getGridView("#grid-view-holder");
    schoolsGrid.addHeader("Name", "Location", "Total Students", "Specialty");
    schoolsGrid.addRow("PMG", "Burgas", 400, "Math");
    schoolsGrid.addRow("TUES", "Sofia", 500, "IT");
    var academyRow = schoolsGrid.addRow("Telerik Academy", "Sofia", "5000", "IT");
    var academyGrid = academyRow.getNestedGridView();
    academyGrid.addHeader("Title", "Start Date", "Total Students");
    academyGrid.addRow("JS 2", "11-april-2013", 400);
    academyGrid.addRow("SEO", "15-may-2013", 1300);
    academyGrid.addRow("Slice and Dice", "05-april-2013", 500);
    schoolsGrid.render();
}