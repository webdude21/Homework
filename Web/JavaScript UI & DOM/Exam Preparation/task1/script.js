function createCalendar(selector, events) {
    // set innitial variables
    var dayBox = document.createElement('div');
    var title = document.createElement('div');
    var normalTitleColor = '#cccccc';
    var hoveredTitle = '#aaaaaa';
    var dateNormalColor = '#ffffff';
    var clickedColor = '#cccccc';
    var boxSize = '100px';
    dayBox.addClassName('container-day-box');
    dayBox.addClassName('calendar-component');
    dayBox.style.display = 'inline-block';
    dayBox.style.overflow = 'hidden';
    dayBox.style.border = '1px solid black';
    dayBox.style.width = boxSize;
    dayBox.style.height = boxSize;
    dayBox.style.padding = '0px, 10px';
    title.style.fontSize = '10px';
    title.style.textAlign = 'center';
    title.addClassName('title');
    title.style.backgroundColor = normalTitleColor;
    title.style.padding = '0px, 10px';

    var container = document.querySelector(selector);
    container.style.width = (100 * 7.5) + 'px';
    var documentFragment = window.document.createDocumentFragment();

    for (var i = 1; i < 31; i++) {
        createDay(i, addEventIfAny(i))
    }

    function addEventIfAny(index) {
        for (var i = 0; i < events.length; i++) {
            if (parseInt(events[i].date) === index) {
                return events[i];
            }
        }
    }

    function createDay(index, event) {
        var today = new Date();
        today.setDate(index);
        today.setMonth(6);
        today.setYear(2014);

        var newDateBox = dayBox.cloneNode(true);
        var newTitle = title.cloneNode(true);
        newTitle.textContent = today.toDateString();
        newDateBox.appendChild(newTitle);

        if (event) {
            newDateBox.appendChild(getEvent(event));
        }

        attachEventListeners(newDateBox);
        documentFragment.appendChild(newDateBox);
    }

    function getEvent(event) {
        var eventNode = document.createElement('span');
        eventNode.textContent = event.hour + ' ' + event.title;
        eventNode.style.fontSize = '10px';
        return eventNode;
    }

    function clearSelected() {
        var allSelected = document.getElementsByClassName('selected');
        for (var i = 0, len = allSelected.length; i < len; i++) {
            allSelected[i].style.backgroundColor = dateNormalColor;
            allSelected[i].removeClassName('selected');
        }
    }

    function attachEventListeners(dateBox) {
        dateBox.addEventListener('mouseover', function () {
            var title = this.getElementsByClassName('title')[0];
            title.style.backgroundColor = hoveredTitle;
        });

        dateBox.addEventListener('mouseout', function () {
            var title = this.getElementsByClassName('title')[0];
            title.style.backgroundColor = normalTitleColor;
        });

        dateBox.addEventListener('click', function () {
            if (this.hasClassName('selected')) {
                this.removeClassName('selected');
                this.style.backgroundColor = dateNormalColor;
            } else {
                clearSelected();
                this.addClassName('selected');
                this.style.backgroundColor = clickedColor;
            }
        });
    }
    container.appendChild(documentFragment);
}

Element.prototype.hasClassName = function (name) {
    return new RegExp("(?:^|\\s+)" + name + "(?:\\s+|$)").test(this.className);
};

Element.prototype.addClassName = function (name) {
    if (!this.hasClassName(name)) {
        this.className = this.className ? [this.className, name].join(' ') : name;
    }
};

Element.prototype.removeClassName = function (name) {
    if (this.hasClassName(name)) {
        var c = this.className;
        this.className = c.replace(new RegExp("(?:^|\\s+)" + name + "(?:\\s+|$)", "g"), "");
    }
};