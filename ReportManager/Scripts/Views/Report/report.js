$(document).ready(function () {
    Report.init();
});
var Report = {
    viewModel: {
        report: ko.observable()
    },
    init: function () {
        ko.applyBindings(Report.viewModel);
    },
    buildReport: function (json) {
        Report.viewModel.report(json);
    }
}


