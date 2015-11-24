var MyQrCodeList = {
    viewModel: {
        QrCodeList: ko.observableArray()
    }
};
function getQueryStringByName(name) {
    var result = location.search.match(new RegExp("[\?\&]" + name + "=([^\&]+)", "i"));
    if (result == null || result.length < 1) {
        return "";
    }
    return result[1];
}

$(function () {
    ko.applyBindings(MyQrCodeList);
    
    var model = {        
        code: getQueryStringByName("code"),
    };   
    $.get('/api/HeaderSetting/', function (base64) {
        $.ajax({
            type: "get",
            data: model,
            url: "http://WeChatService.mangoeasy.com/api/WeChartUserInfo/",
            beforeSend: function (xhr) { //beforeSend定义全局变量
                xhr.setRequestHeader("Authorization", base64); //Authorization 需要授权,即身体验证
            },
            success: function (xmlDoc, textStatus, xhr) {
                if (xhr.status == 200) {
                    var user = {
                        id: xhr.responseJSON.openid                        
                    }
                    
                    $.get('/api/MyQrCodeList/'+user.id, function (result) {
                        ko.mapping.fromJS(result, {}, MyQrCodeList.viewModel.QrCodeList);

                    })
                }
            }
        });
    });
});