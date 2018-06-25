$(function(){
    $(".g-teacher-recommend .u-content").each(function(i){
        $(this).hover(function(){
            $(".g-teacher-recommend .u-content .u-info:eq("+i+")").stop().animate({"margin-top":"0"});
            $(".g-teacher-recommend .u-content .u-btn:eq("+i+")").stop().addClass("u-btn-light");
        },function(){
            $(".g-teacher-recommend .u-content .u-info:eq("+i+")").stop().animate({"margin-top":"430px"});
            $(".g-teacher-recommend .u-content .u-btn:eq("+i+")").stop().removeClass("u-btn-light");
        });
    });


    var $centerwell_first = $('#centerwell .s:first');
    $centerwell_first.animate({ width: '640px' }, "fast");
    $centerwell_first.find('h3').addClass("on");

    $('#centerwell .s').mouseenter(function(j) {
        $("#centerwell .s .mask").show();
        $(this).children('#centerwell .mask').hide();
        $(this).stop(true,true).animate({ width: '640px' },'2000').siblings().stop(true,true).animate({ width: '120px' },'2000');
    });


    var $centerwell_first = $('.g-teacher-box .s:first');
    $centerwell_first.animate({ width: '640px' }, "fast");
    $centerwell_first.find('h3').addClass("on");

    $('.g-teacher-box .s').mouseenter(function(j) {
        $(".g-teacher-box .s .mask").show();
        $(this).children('#centerwell .mask').hide();
        $(this).stop(true,true).animate({ width: '640px' },'2000').siblings().stop(true,true).animate({ width: '120px' },'2000');
    });
});