var Home = {
    viewModel: {
        qrcodes: ko.observableArray(),
        myqrcodeurl: ko.observable(),
    }
};
Home.viewModel.showmyqrcodelist = function () {
    $.get("/api/MyQrCodeList/", function (url) {
        ko.mapping.fromJS(url, {}, Home.viewModel.myqrcodeurl);
        $('#myqrcodelist').modal({
            show: true,
            backdrop: 'static'
        });
    });

}

$(function () {
    ko.applyBindings(Home);
    $.get("/api/Offer/", function (data) {
        ko.mapping.fromJS(data, {}, Home.viewModel.qrcodes);

    });
});