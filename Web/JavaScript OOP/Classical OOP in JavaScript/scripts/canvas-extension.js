'use strict';

var AdvancedCanvas = function (canvasElementId) {
    var canvas = document.getElementById(canvasElementId);
    var ctx = canvas.getContext("2d");

    var drawRect = function (x, y, width, height, strokeColor, lineWidth, fillColor) {
        ctx.beginPath();
        ctx.lineWidth = lineWidth || 1;
        ctx.strokeStyle = strokeColor || 'black';
        ctx.rect(x, y, width, height);
        ctx.fillStyle = fillColor;
        ctx.fill();
        ctx.stroke();
    };

    var drawCircle = function (x, y, radius, strokeColor, lineWidth, fillColor) {
        ctx.beginPath();
        ctx.lineWidth = lineWidth || 1;
        ctx.strokeStyle = strokeColor || 'black';
        ctx.arc(x, y, radius, 0, 2 * Math.PI);
        ctx.fillStyle = fillColor;
        ctx.fill();
        ctx.stroke();
    };

    var drawLine = function (startX, startY, endX, endY, strokeColor, lineWidth) {
        ctx.beginPath();
        ctx.lineWidth = lineWidth || 1;
        ctx.strokeStyle = strokeColor || 'black';
        ctx.moveTo(startX, startY);
        ctx.lineTo(endX, endY);
        ctx.stroke();
    };
    return {
        drawLine: drawLine,
        drawCircle: drawCircle,
        drawRect: drawRect
    }
};