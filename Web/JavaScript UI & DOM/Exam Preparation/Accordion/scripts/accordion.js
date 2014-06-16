function getAccordion(container, isElement) {
    var accordionHolder;
    if (isElement) {
        accordionHolder = container;
    } else {
        accordionHolder = document.querySelector(container);
    }

    accordionHolder.addClassName('accordion-control-element');

    var protoItem = document.createElement('div');
    protoItem.style.border = '1px solid black';
    protoItem.style.padding = '10px 0px 0px 10px';

    accordionHolder.add = function add(content) {
        var currentItem = protoItem.cloneNode(true);
        currentItem.textContent = content;
        currentItem = getAccordion(currentItem, true);
        accordionHolder.appendChild(currentItem);
        return currentItem;
    };

    var collapseExpandEvent = function collapseExpandEvent() {
        var child = this.firstElementChild;
        if (this.hasClassName('collapsed')) {
            while (child) {
                child.style.display = 'block';
                child = child.nextElementSibling;
            }
            this.removeClassName('collapsed');
        } else {
            while (child) {
                child.style.display = 'none';
                child = child.nextElementSibling;
            }
            this.addClassName('collapsed');
        }

        var sibling = this.parentNode.firstElementChild;
        while (sibling) {
            if (sibling !== this) {
                for (var i = 0, len = sibling.children.length; i < len; i++) {
                    sibling.children[i].style.display = 'none'
                }
                sibling.addClassName('collapsed');
            }
            sibling = sibling.nextElementSibling;
        }
        event.stopPropagation();

    };

    accordionHolder.addEventListener('click', collapseExpandEvent);
    accordionHolder.render = function render() {
        if (!protoItem.parentNode === accordionHolder) {
            accordionHolder.appendChild(protoItem);
        }
    };

    return accordionHolder;
}

if (!Element.prototype.addClassName) {
    Element.prototype.addClassName = function (name) {
        if (!this.hasClassName(name)) {
            this.className = this.className ? [this.className, name].join(' ') : name;
        }
    };
}

if (!Element.prototype.removeClassName) {
    Element.prototype.removeClassName = function (name) {
        if (this.hasClassName(name)) {
            var c = this.className;
            this.className = c.replace(new RegExp("(?:^|\\s+)" + name + "(?:\\s+|$)", "g"), "");
        }
    };
}

if (!Element.prototype.hasClassName) {
    Element.prototype.hasClassName = function (name) {
        return new RegExp("(?:^|\\s+)" + name + "(?:\\s+|$)").test(this.className);
    };
}