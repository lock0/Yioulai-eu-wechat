var QrCodeHandle = {
    viewModel: {
        WeChatUserModel: {            
            OpenId: ko.observable(),
            NickName: ko.observable(),
            Headimgurl: ko.observable(),
            Mail: ko.observable(),
            Country: ko.observable(),
        },
        ConiqOfferModel: {
            id: ko.observable()
        },
        ShareId: ko.observable(),
        Registered: ko.observable(true),
        RegisterForm: {
            openid: ko.observable(),
            offerid: ko.observable(),
            first_name: ko.observable(),
            last_name: ko.observable(),
            email: ko.observable(),
            phone:
            {
                country_code: ko.observable(),
                number: ko.observable(),
            },
            date_of_birth: ko.observable()
        }
    }
};
QrCodeHandle.viewModel.SignUp = function () {    
    var weChatUser = ko.toJS(QrCodeHandle.viewModel.WeChatUserModel);
    var coniqOffer = ko.toJS(QrCodeHandle.viewModel.ConiqOfferModel);
    var model = ko.toJS(QrCodeHandle.viewModel.RegisterForm);
    model.openid = weChatUser.OpenId;
    model.offerid = coniqOffer.id;
    $.post('/api/SendMailForSignUp/', model, function (result) {
        alert(result.Message);
    });
}

function getQueryStringByName(name) {
    var result = location.search.match(new RegExp("[\?\&]" + name + "=([^\&]+)", "i"));
    if (result == null || result.length < 1) {
        return "";
    }
    return result[1];
}
$(function () {
    ko.applyBindings(QrCodeHandle);
    var model = {
        offid: getQueryStringByName("offid"),
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
                    var QrCodeHandleModel = {
                        ConiqOfferModel: { id: model.offid },
                        WeChatUserModel: {
                            OpenId: xhr.responseJSON.openid,
                            NickName: xhr.responseJSON.nickname,
                            Gender: xhr.responseJSON.sex,
                            City: xhr.responseJSON.city,
                            Province: xhr.responseJSON.province,
                            Country: xhr.responseJSON.country,
                            Headimgurl: xhr.responseJSON.headimgurl,
                        }
                    }
                    ko.mapping.fromJS(QrCodeHandleModel.WeChatUserModel, {}, QrCodeHandle.viewModel.WeChatUserModel);
                    ko.mapping.fromJS(QrCodeHandleModel.ConiqOfferModel, {}, QrCodeHandle.viewModel.ConiqOfferModel);

                    $.post('/api/QrCodeHandle/', QrCodeHandleModel, function (result) {
                        QrCodeHandle.viewModel.Registered(result.ErrorCode != 1);

                        alert(result.Message)

                    })
                }
            }
        });
    });
});