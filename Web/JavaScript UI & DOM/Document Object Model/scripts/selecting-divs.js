function selectInnerDivs() {
    return document.querySelectorAll('div > div');
}

function selectInnerDivsAlternative() {
    var divs = document.getElementsByTagName('div');
    var innerDivs = [];
    for (var i = 0, len = divs.length; i < len; i++) {
        var currentDivNodeList = divs[i].getElementsByTagName('div');
        if (currentDivNodeList.length > 0) {
            for (var j = 0, leng = currentDivNodeList.length; j < leng; j++) {
                innerDivs.push(currentDivNodeList[j]);
            }
        }
    }
    return innerDivs;
}

function test() {
    console.log("Function using querySelectorAll");
    console.log(selectInnerDivs());
    console.log("Function using getElementsByTagName");
    console.log(selectInnerDivsAlternative());
}