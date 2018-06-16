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
});