function _timer(callback) {
    var time = 0;
    var mode = 1;
    var status = 0;
    var timer_id;

    this.start = function (interval) {
        interval = (typeof (interval) !== 'undefined') ? interval : 1000;
        if (status == 0) {
            status = 1;
            timer_id = setInterval(function () {
                switch (mode) {
                    case 0:
                        if (time) {
                            time--;
                            generateTime();
                            if (typeof (callback) === 'function') callback(time);
                        }
                        break;

                    case 1:
                        if (time < 86400) {
                            time++;
                            generateTime();
                            if (typeof (callback) === 'function') callback(time);
                        }
                        break;
                }
            }, interval);
        }
    }
    this.stop = function () {
        if (status == 1) {
            status = 0;
            clearInterval(timer_id);
        }
    }
    this.reset = function (sec) {
        sec = (typeof (sec) !== 'undefined') ? sec : 0;
        time = sec;
        generateTime(time);
    }
    this.mode = function (tmode) {
        mode = tmode;
    }
    this.getTime = function () {
        return time;
    }
    this.getMode = function () {
        return mode;
    }
    this.getStatus
    {
        return status;
    }
    function generateTime() {
        var second = time % 60;
        var minute = Math.floor(time / 60) % 60;
        var hour = Math.floor(time / 3600) % 60;

        second = (second < 10) ? '0' + second : second;
        minute = (minute < 10) ? '0' + minute : minute;
        hour = (hour < 10) ? '0' + hour : hour;

        //$('div.timer span.second').html(second);
        //$('div.timer span.minute').html(minute);
        //$('div.timer span.hour').html(hour);

        var result = hour + ":" + minute + ":" + second;
        $('div.timer span.time').html(result);
    }
}

var timer;

$(document).ready(function (e) {
    timer = new _timer
	(
		function (time) {
		    if (time == 0) {
		        timer.stop();
		        alert('time out');
		    }
		}
	);
    timer.reset(0);
    timer.mode(1);
});