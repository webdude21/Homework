define(function (){
    return (function () {
        Number.prototype.toRadians = function () {
            return this * (Math.PI / 180);
        };

        Number.prototype.toDegrees = function () {
            return  this * (180 / Math.PI);
        };

        CanvasRenderingContext2D.prototype.degreesArc = function degreesArc(x, y, radius, startAngle, endAngle, anticlockwise) {
            this.arc(x, y, radius, startAngle * Math.PI / 180, endAngle * Math.PI / 180,
                anticlockwise)
        };


        Array.prototype.unset = function (value) {
            if (this.indexOf(value) !== -1) {
                this.splice(this.indexOf(value), 1);
            }
        };

        if (CanvasRenderingContext2D.prototype.drawEllipse === undefined) {
            CanvasRenderingContext2D.prototype.drawEllipse = function drawEllipse(centerX, centerY, w, h) {
                this.beginPath();
                var lx = centerX - w / 2,
                    rx = centerX + w / 2,
                    ty = centerY - h / 2,
                    by = centerY + h / 2;
                var magic = 0.551784;
                var xmagic = magic * w / 2;
                var ymagic = h * magic / 2;
                this.moveTo(centerX, ty);
                this.bezierCurveTo(centerX + xmagic, ty, rx, centerY - ymagic, rx, centerY);
                this.bezierCurveTo(rx, centerY + ymagic, centerX + xmagic, by, centerX, by);
                this.bezierCurveTo(centerX - xmagic, by, lx, centerY + ymagic, lx, centerY);
                this.bezierCurveTo(lx, centerY - ymagic, centerX - xmagic, ty, centerX, ty);
            };
        }

        if (CanvasRenderingContext2D.prototype.drawCircle === undefined) {
            CanvasRenderingContext2D.prototype.drawCircle = function (centerX, centerY, radius) {
                this.drawEllipse(centerX, centerY, radius * 2, radius * 2)
            }
        }

        if (CanvasRenderingContext2D.prototype.drawCylinder === undefined) {
            CanvasRenderingContext2D.prototype.drawCylinder = function drawCylinder(x, y, w, h) {

                var i, xPos, yPos, pi = Math.PI, twoPi = 2 * pi;
                this.beginPath();
                for (i = 0; i < twoPi; i += 0.001) {
                    xPos = (x + w / 2) - (w / 2 * Math.cos(i));
                    yPos = (y + h / 8) + (h / 8 * Math.sin(i));

                    if (i === 0) {
                        this.moveTo(xPos, yPos);
                    } else {
                        this.lineTo(xPos, yPos);
                    }
                }
                this.moveTo(x, y + h / 8);
                this.lineTo(x, y + h - h / 8);

                for (i = 0; i < pi; i += 0.001) {
                    xPos = (x + w / 2) - (w / 2 * Math.cos(i));
                    yPos = (y + h - h / 8) + (h / 8 * Math.sin(i));

                    if (i === 0) {
                        this.moveTo(xPos, yPos);
                    } else {
                        this.lineTo(xPos, yPos);
                    }
                }
                this.moveTo(x + w, y + h / 8);
                this.lineTo(x + w, y + h - h / 8);
            }
        }
    }());
});