function updateColor(textArea, textColor, backGroundColor) {
    textArea.style.color = textColor;
    textArea.style.backgroundColor = backGroundColor;
}

function getTextAreaAndChangeColor() {
    updateColor(document.getElementById('ta-test'),
        document.getElementById('text-color').value, document.getElementById('bg-color').value)
}