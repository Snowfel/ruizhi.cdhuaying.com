//以下代码 放在页面中或js文件中 都可以
(function(w){if(!("WebSocket"in w&&2===w.WebSocket.CLOSING)){var d=document.createElement("div");d.className="browsehappy";d.innerHTML='<div style="width:100%;height:100px;font-size:20px;line-height:100px;text-align:center;background-color:#E90D24;color:#fff;margin-bottom:40px;">\u4f60\u7684\u6d4f\u89c8\u5668\u5b9e\u5728<strong>\u592a\u592a\u65e7\u4e86</strong>\uff0c\u592a\u592a\u65e7\u4e86 <a target="_blank" href="https://www.google.com/chrome/" style="background-color:#31b0d5;border-color: #269abc;text-decoration: none;padding: 6px 12px;background-image: none;border: 1px solid transparent;border-radius: 4px;color:#FFEB3B;">\u7acb\u5373\u5347\u7ea7</a></div>';var f=function(){var s=document.getElementsByTagName("body")[0];if("undefined"==typeof(s)){setTimeout(f,10)}else{s.insertBefore(d,s.firstChild)}};f()}}(window));

$(function(){
    //教师
    $(".g-teacher-recommend .u-content").each(function(i){
        $(this).hover(function(){
            $(".g-teacher-recommend .u-content .u-info:eq("+i+")").stop().animate({"margin-top":"0"});
            $(".g-teacher-recommend .u-content .u-btn:eq("+i+")").stop().addClass("u-btn-light");
        },function(){
            $(".g-teacher-recommend .u-content .u-info:eq("+i+")").stop().animate({"margin-top":"371px"});
            $(".g-teacher-recommend .u-content .u-btn:eq("+i+")").stop().removeClass("u-btn-light");
        });
    });

    //报名信息
    $(".u-btn-order-submit").on('click', function () {
        //$(this).attr('data-rel')
        arrOrderInfo = new Array();
        arrOrderInfo['pagename'] = $(this).attr('data-pagename');
        arrOrderInfo['clientname'] = $("#" + $(this).attr('data-prefix') + "-clientname").val();
        arrOrderInfo['cellphone'] = $("#" + $(this).attr('data-prefix') + "-cellphone").val();
        arrOrderInfo['age'] = $("#" + $(this).attr('data-prefix') + "-age").val();
        orderInfoPost(arrOrderInfo);
    });

    /*锚点平滑滚动*/
    $('.a-name-smooth').click(function() {
        if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
            var $target = $(this.hash);
            $target = $target.length && $target || $('[name=' + this.hash.slice(1) + ']');
            if ($target.length) {
                var targetOffset = $target.offset().top;
                $('html,body').animate({
                        scrollTop: targetOffset
                    },
                    1000);
                return false;
            }
        }
    });

    //视频图片点击播放
    $("#m-video").on('click', function () {
        if(this.paused){
            this.play();
        }else{
            this.pause();
        }
    });
});

/**
 * 底部报名提交
 */
function orderInfoPost(arrOrderInfo) {
    if (Array.isArray(arrOrderInfo)) {            
        if(arrOrderInfo['pagename']){
            pagename = arrOrderInfo['pagename'];
        } else {
            pagename = '';
        }

        console.debug('客户姓名：' + arrOrderInfo['clientname']);
        if(arrOrderInfo['clientname']){
            clientname = arrOrderInfo['clientname'];
        } else {
            clientname = '';
        }
        if(arrOrderInfo['cellphone']){
            cellphone = arrOrderInfo['cellphone'];
        } else {
            cellphone = '';
        }
        if(arrOrderInfo['age']){
            age = arrOrderInfo['age'];
        } else {
            age = '';
        }
    
        var dataArr = {
            pagename: pagename,
            clientname: clientname,
            cellphone: cellphone,
            age: age
        };
        if (!dataArr.clientname) {
            alert('请填写姓名！');
            return false;
        }
        if (!dataArr.cellphone) {
            alert('请填写电话！');
            return false;
        }
    
        console.debug(dataArr.cellphone);
    
        $.ajax({
            url: "/Webhandler/OverallData2018.ashx?t=send",
            type: "post",
            async: true,
            data: dataArr,
            success: function (e) {
                alert(e)
            },
            error: function (jqXHR) {
            }
        });
    }
}