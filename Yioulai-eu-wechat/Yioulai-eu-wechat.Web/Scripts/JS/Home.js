var Home = {
    viewModel: {
        qrcodes: ko.observableArray(),
        myqrcodeurl: ko.observable(),
    }
};
Home.viewModel.showmyqrcodelist = function () {    
    $('#myqrcodelist').modal({
        show: true,
        backdrop: 'static'
    });
}
ko.bindingHandlers.qrcode = {
    update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        var value = valueAccessor();
        var allBindings = allBindingsAccessor();
        var valueUnwrapped = ko.utils.unwrapObservable(value);
        if (valueUnwrapped !== null && valueUnwrapped !== undefined && valueUnwrapped.length > 0) {
            $(element).qrcode({
                "size": 200,
                "text": valueUnwrapped
            })
        }
    }
};
$(function () {
    ko.applyBindings(Home);
    $.get("/api/Offer/", function (data) {
        ko.mapping.fromJS(data, {}, Home.viewModel.qrcodes);

    });
    $.get("/api/MyQrCodeList/", function (url) {
        ko.mapping.fromJS(url, {}, Home.viewModel.myqrcodeurl);
    });
});