$(function () {
    $.datetimepicker.setDateFormatter('moment');
    $(".datetimefield").datetimepicker({
        format: 'MM/DD/YYYY hh:mm A',
        formatTime: 'h:mm A'
    });
});