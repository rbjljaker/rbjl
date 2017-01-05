function setCurrMenu(tarIndex) {
    // var curr = $("#MenuMain_PanBackGround_"+tarIndex).addClass("staticSelectedCss");
    if (tarIndex == 0) {
        var curr = $("[setcurr*='Matter']").addClass("staticSelectedCss");
    }

    else if (tarIndex == 1) {
        var curr = $("[setcurr*='Debit Note']").addClass("staticSelectedCss");
    }

    else if (tarIndex == 2) {
        var curr = $("[setcurr*='Report']").addClass("staticSelectedCss");
    }

    else if (tarIndex == 3) {
        var curr = $("[setcurr*='Master']").addClass("staticSelectedCss");
    }
    else if (tarIndex == 4) {
        var curr = $("[setcurr*='Log']").addClass("staticSelectedCss");
    }
    else if (tarIndex == 5) {
        var curr = $("[setcurr*='Settings']").addClass("staticSelectedCss");
    }


}