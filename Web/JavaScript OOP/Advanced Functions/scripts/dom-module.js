var domModule = (function () {

    function applyPseudoSelector(pseudoSelector, selected, container) {
        var firstChild = 'first-child';
        var lastChild = 'last-child';
        var elementToRemove;

        if (pseudoSelector.indexOf(firstChild) > -1) {
            elementToRemove = container.querySelectorAll(selected)[0];
        } else if (pseudoSelector.indexOf(lastChild) > -1) {
            var len = container.querySelectorAll(selected).length;
            elementToRemove = container.querySelectorAll(selected)[len - 1];
        }
        return elementToRemove;
    }

    function appendChild(domElementToAdd, containerElementSelector) {

        if (containerElementSelector.indexOf(':') > -1) {
            var pseudoSelector = containerElementSelector.split(':')[1];
            containerElementSelector = containerElementSelector.split(':')[0];
        }

        var selected = getElementsBySelector(containerElementSelector);

        if (pseudoSelector) {
            selected = applyPseudoSelector(pseudoSelector, selected, containerElementSelector);
        }

        if (selected.length) {
            for (var item = 0; item < selected.length; item++) {
                selected[item].appendChild(domElementToAdd);
            }
        }
    }

    function removeChild(containerSelector, selectorForElementToRemove) {
        var containerElement = getElementsBySelector(containerSelector);
        var elementToRemove;
        var item;

        if (selectorForElementToRemove.indexOf(':') > -1) {
            var pseudoSelector = selectorForElementToRemove.split(':')[1];
            selectorForElementToRemove = selectorForElementToRemove.split(':')[0];

            for (item = 0; item < containerElement.length; item++) {
                elementToRemove = (applyPseudoSelector(pseudoSelector, selectorForElementToRemove, containerElement[item]));
                if (elementToRemove) {
                    elementToRemove.parentNode.removeChild(elementToRemove);
                }
            }

        } else {
            for (item = 0; item < containerElement.length; item++) {
                elementToRemove = getElementsBySelector(selectorForElementToRemove, containerElement[item]);
                for (var i = 0; i < elementToRemove.length; i++) {
                    elementToRemove[i].parentNode.removeChild(elementToRemove[i]);
                }
            }
        }
    }

    var buffer = {};
    var counterWhenToAppendToDOM = 100;

    function appendToBuffer(parentStringSelector, HTMLElementToAppend) {
        var parent = document.querySelector(parentStringSelector);
        if (!parent) {
            return;
        }

        if (!buffer[parent]) {
            buffer[parent] = [];
        }

        buffer[parent].push(HTMLElementToAppend);

        if (buffer[parent].length == counterWhenToAppendToDOM) {
            var frag = document.createDocumentFragment();

            for (var i = 0; i < buffer[parent].length; i++) {
                frag.appendChild(buffer[parent][i]);
            }

            parent.appendChild(frag);

            buffer[parent] = [];
        }
    }

    function getElementsBySelector(selector, parent) {
        if (parent) {
            return parent.querySelectorAll(selector);
        } else {
            return document.querySelectorAll(selector)
        }
    }

    function addHandler(selector, event, func) {
        var selected = getElementsBySelector(selector);

        for (var item = 0; item < selected.length; item++) {
            selected[item].addEventListener(event, func);
        }
    }

    return{
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer,
        getElementsBySelector: getElementsBySelector
    }
}());