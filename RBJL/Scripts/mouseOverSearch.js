function mouseOverSearchInit(tar, searchArea,leftValue) {

    var tarArea = tar + ", " + searchArea;

    $(tarArea).mouseover(function () {
        $(searchArea).css("display", "block");
    });
    $(tarArea).mouseout(function () {
        $(searchArea).css("display", "none");
    });

    var x = $(tar).offset().left;
    var y = $(tar).offset().top;

    var w = $(window);
    var sl = w.scrollLeft();
    var st = w.scrollTop();

    var resultX = x - sl;
    var resultY = y - st;


    //console.log(x + "," + x1);
    //    $(searchArea).css({ left: x - 200, top: y +10 });
    $(searchArea).css({ left: leftValue, top: y + 10 });
}