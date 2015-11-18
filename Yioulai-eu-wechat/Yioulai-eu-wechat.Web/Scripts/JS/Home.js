var Home = {
    viewModel: {
        cardTypes: ko.observableArray(),
        employees: ko.observableArray(),
    }
};
$(function () {
    ko.applyBindings(Home);
    $.get("/api/CardType/", function (data) {
        ko.mapping.fromJS(data, {}, Home.viewModel.cardTypes);
        $.get("/api/Employee/", function (employees) {
            ko.mapping.fromJS(employees, {}, Home.viewModel.employees);
        });
    });
});