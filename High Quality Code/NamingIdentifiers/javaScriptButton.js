(function () {
    var userWindow= window,
        browser = userWindow.navigator.appCodeName,
        ism = browser == 'Mozilla';

    if(ism) {
        alert('Yes');
    } else {
        alert('No');
    }
}());