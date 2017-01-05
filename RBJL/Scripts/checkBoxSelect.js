$(document).ready(function () {
    // 點選單一checkbox 檢查是否設定全選/全消
    $('.chk input:checkbox').click(function () {
        if (this.checked) {
            if ($('.chk input:checked').length == $('.chk input:checkbox').length) {
                $('.CheckAll input:checkbox')[0].checked = true;
            }
        } else {
            $('.CheckAll input:checkbox')[0].checked = false;
        }
    });

    $('.SearchItem input:checkbox').click(function () {
        if (this.checked) {
            if ($('.SearchItem input:checked').length == $('.SearchItem input:checkbox').length) {
                $('.SearchAll input:checkbox')[0].checked = true;
            }
        } else {
            $('.SearchAll input:checkbox')[0].checked = false;
        }
    });

    $('.SearchItemD input:checkbox').click(function () {
        if (this.checked) {
            if ($('.SearchItemD input:checked').length == $('.SearchItemD input:checkbox').length) {
                $('.SearchDAll input:checkbox')[0].checked = true;
            }
        } else {
            $('.SearchDAll input:checkbox')[0].checked = false;
        }
    });

    $('.chkNoCount input:checkbox').click(function () {
        if (this.checked) {
            if ($('.chkNoCount input:checked').length == $('.chkNoCount input:checkbox').length) {
                $('.CheckAllNoCount input:checkbox')[0].checked = true;
            }
        } else {
            $('.CheckAllNoCount input:checkbox')[0].checked = false;
        }
    });

    $('.CheckBoxCopyOrMove input:checkbox').click(function () {
        if (this.checked) {
            if ($('.CheckBoxCopyOrMove input:checked').length == $('.CheckBoxCopyOrMove input:checkbox').length) {
                $('.CheckBoxAllCopyOrMove input:checkbox')[0].checked = true;
            }
        } else {
            $('.CheckBoxAllCopyOrMove input:checkbox')[0].checked = false;
        }
    });

});
function SelectAllCheckboxes(spanChk) {
    var e = $('.CheckAll input:checkbox')[0].checked;
    $('.chk input:checkbox').each(function () {
        this.checked = e;
    });
    if (e) {
        $('.chkNoCount input:checkbox').each(function () {
            this.checked = !e;
            $('.CheckAllNoCount input:checkbox')[0].checked = !e;
        });
    }
}


function SelectAllSearch(spanChk) {
    var e = $('.SearchAll input:checkbox')[0].checked;
    $('.SearchItem input:checkbox').each(function () {
        this.checked = e;
    });
}

function SelectAllCopyOrMove(spanChk) {
    var e = $('.CheckBoxAllCopyOrMove input:checkbox')[0].checked;
    $('.CheckBoxCopyOrMove input:checkbox').each(function () {
        this.checked = e;
    });
}

function SelectAllTypeD(spanChk) {
    var e = $('.SearchDAll input:checkbox')[0].checked;
    $('.SearchItemD input:checkbox').each(function () {
        this.checked = e;
    });
}


function SelectDebitNoteCount(object, index) {
    var tarCb = $('span[cbcount' + index + '=tar] input:checkbox').is(':checked') ? true : false;
    if (tarCb) {
        $('span[cbnocount' + index + '=tar] input:checkbox')[0].checked = false;
        $('.CheckAllNoCount input:checkbox')[0].checked = false;
    }
}

function SelectDebitNoteNoCount(object, index) {
    var tarCb = $('span[cbnocount' + index + '=tar] input:checkbox').is(':checked') ? true : false;
    if (tarCb) {
        $('span[cbcount' + index + '=tar] input:checkbox')[0].checked = false;
        $('.CheckAll input:checkbox')[0].checked = false;
    }
}


function SelectAllCheckboxesNoCount(spanChk) {
    var e = $('.CheckAllNoCount input:checkbox')[0].checked;
    $('.chkNoCount input:checkbox').each(function () {
        this.checked = e;
    });
    if (e) {
        $('.chk input:checkbox').each(function () {
            this.checked = !e;
            $('.CheckAll input:checkbox')[0].checked = !e;
        });
    }
}