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
    
    $(".u-btn-order-submit").on('click', function () {
        //$(this).attr('data-rel')
        arrOrderInfo = new Array();
        arrOrderInfo['pagename'] = $(this).attr('data-pagename');
        arrOrderInfo['clientname'] = $("#" + $(this).attr('data-prefix') + "-clientname").val();
        arrOrderInfo['cellphone'] = $("#" + $(this).attr('data-prefix') + "-cellphone").val();
        arrOrderInfo['age'] = $("#" + $(this).attr('data-prefix') + "-age").val();
        orderInfoPost(arrOrderInfo);
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