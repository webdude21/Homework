function moveDivs() {
    var divCount = 5;
    var centerX = 300;
    var centerY = 300;
    var radius = 300;
    var angle = 0;
    var increment = 5;
    var twoTimesPI = Math.PI * 2;

    var documentFragment = generateDivs(divCount);
    window.document.body.appendChild(documentFragment);
    var myDivs = window.document.getElementsByClassName('my-div');

    var rotateDivs = function () {
        for (var i = 0, len = myDivs.length; i < len; i++) {
            rotateInCircle(myDivs[i]);
        }
    };

    window.setInterval(rotateDivs, 100);
    function rotateInCircle(element) {
        angle += 0.01;
        if (angle >= twoTimesPI) {
            angle = 0;
        }
        element.style.left = (centerX + Math.cos((angle + increment)) * radius) + "px";
        element.style.top = (centerY + Math.sin((angle + increment)) * radius) + "px";
    }
}