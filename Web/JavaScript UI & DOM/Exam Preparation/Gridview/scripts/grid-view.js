function getGridView(component, nestedGrid) {
    var gridContainer;

    if (nestedGrid) {
        gridContainer = component;
    } else {
        gridContainer = document.querySelector(component);
    }

    var table = document.createElement('table');
    table.style.borderCollapse = 'collapse';
    var tableHead = document.createElement('thead');
    var tableBody = document.createElement('tbody');
    table.appendChild(tableHead);
    table.appendChild(tableBody);

    // set styles

    function setBorder(obj) {
        obj.style.border = '1px solid black';
    }

    gridContainer.addHeader = function addHeader() {
        var tableRow = document.createElement('tr');
        var tableHeadCell = document.createElement('th');
        setBorder(tableHeadCell);
        addCellsToRow(tableHeadCell, tableRow, arguments);
        tableHead.appendChild(tableRow);
    };

    gridContainer.addRow = function addRow() {
        var tableRow = document.createElement('tr');
        var tableCell = document.createElement('td');
        setBorder(tableCell);
        addCellsToRow(tableCell, tableRow, arguments);
        tableBody.appendChild(tableRow);
        tableRow.getNestedGridView = function getNestedGridView() {
            if (!tableRow.nestedGrid) {
                var nestedGrid = getGridView(tableRow, true);
                nestedGrid.render();
                nestedGrid.addEventListener('click', function () {
                    var nodeToWorkWith = this.getElementsByTagName('table')[0];
                    if (nodeToWorkWith.style.display == 'none') {
                        nodeToWorkWith.style.display = 'initial';
                    } else {
                        nodeToWorkWith.style.display = 'none';
                    }
                });
                return nestedGrid;
            }
        };
        return tableRow;
    };

    gridContainer.render = function render() {
        gridContainer.appendChild(table);
    };

    function addCellsToRow(cellPrototype, tableRow, cellContents) {
        for (var i = 0; i < cellContents.length; i++) {
            cellPrototype.textContent = cellContents[i];
            tableRow.appendChild(cellPrototype.cloneNode(true))
        }
    }

    return gridContainer;
}