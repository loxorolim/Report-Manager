$(document).ready(function () {
    Index.init();
});
var Index = {
    start: 0,
    numberToFetch: 10,
    viewModel: {
        reports: ko.observableArray([])
    },
    init: function () {
        ko.applyBindings(Index.viewModel);
    },
    fetchReports: function (json) {
        Index.viewModel.reports.push(json);
    }
}

