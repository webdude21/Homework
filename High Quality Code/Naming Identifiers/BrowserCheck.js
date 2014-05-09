function BrowserCheckButton_Click(sender, args) {
    var browserWindow = window;
    var browserName = browserWindow.navigator.appCodeName;
    var isNamedMozilla = browserName == "Mozilla";

    if (isNamedMozilla) {
        alert("Yes");
    }
    else {
        alert("No");
    }
}