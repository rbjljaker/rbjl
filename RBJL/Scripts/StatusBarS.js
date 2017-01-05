//var setStatusBar = function (percentage) {
//    percentage = (typeof (percentage) !== 'undefined') ? percentage : 0;
//    var widthValue = percentage.toString() + "%";
//    var widthValueBlue = (100 - percentage).toString() + "%";
//    $(".statusBarValue").css("width", widthValue);
//    $(".statusBarBlue").css("width", widthValueBlue);
//}


function progressBar(percent, $element) {
    var progressBarWidth = percent * $element.width() / 100;
    $element.find('div').animate({ width: progressBarWidth }, 500).html(percent + "%&nbsp;");
}

function progressBarS(percent1, percent2, $element) {
    if (percent1 != 0 && percent2 != 0) {
        //var progressBarWidth = (percent1 + percent2) / 2 * $element.width() / 100;
        var progressBarWidth1 = percent1 * $element.width() / 100;
        var progressBarWidth2 = percent2 * $element.width() / 100;
        $element.find('sapn#billable').animate({ width: progressBarWidth1 }, 500).html(percent1 + "%&nbsp;");
        $element.find('sapn#nonBillalbe').animate({ width: progressBarWidth2 }, 500).html(percent2 + "%&nbsp;");
        $element.find('sapn#billable').addClass("setFRadius");
        $element.find('sapn#nonBillalbe').addClass("setSRadius");

    }
    else if (percent1 == 0 && percent2 != 0) {
        var progressBarWidth = percent2 * $element.width() / 100;
        $element.find('sapn#nonBillalbe').animate({ width: progressBarWidth }, 500).html(percent2 + "%&nbsp;");
        $element.find('sapn#nonBillalbe').addClass("setFullRadius");
    }
    else if (percent1 != 0 && percent2 == 0) {
        var progressBarWidth = percent1 * $element.width() / 100;
        $element.find('sapn#billable').animate({ width: progressBarWidth }, 500).html(percent1 + "%&nbsp;");
        $element.find('sapn#billable').addClass("setFullRadius");
    }
}


function progressBarB(percent1, percent2, $element) {
    if (percent1 != 0 && percent2 != 0) {
        //var progressBarWidth = (percent1 + percent2) / 2 * $element.width() / 100;
        var progressBarWidth1 = percent1 * $element.width() / 100;
        var progressBarWidth2 = percent2 * $element.width() / 100;
        $element.find('sapn#billable').animate({ width: progressBarWidth1 }, 500).html(percent1 + "%&nbsp;");
        $element.find('sapn#nonBillalbe1').animate({ width: progressBarWidth2 }, 500).html(percent2 + "%&nbsp;");
        $element.find('sapn#billable').addClass("setFRadius");
        $element.find('sapn#nonBillalbe1').addClass("setSRadius");

    }
    else if (percent1 == 0 && percent2 != 0) {
        var progressBarWidth = percent2 * $element.width() / 100;
        $element.find('sapn#nonBillalbe1').animate({ width: progressBarWidth }, 500).html(percent2 + "%&nbsp;");
        $element.find('sapn#nonBillalbe1').addClass("setFullRadius");
    }
    else if (percent1 != 0 && percent2 == 0) {
        var progressBarWidth = percent1 * $element.width() / 100;
        $element.find('sapn#billable').animate({ width: progressBarWidth }, 500).html(percent1 + "%&nbsp;");
        $element.find('sapn#billable').addClass("setFullRadius");
    }
}