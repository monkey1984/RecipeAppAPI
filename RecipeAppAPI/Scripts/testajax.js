$(function)(){
    $.ajax({
        type: 'GET',
        url: '/api/values',
        success: function (data) {
            console.log('success', data);
        }
    });
});