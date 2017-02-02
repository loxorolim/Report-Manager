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
    fetchReports: function () {
        $.ajax({
            type: 'GET',
            url: '/Report/GetReportCollectionByRecentDate/1',
            data: {
                start: Index.start,
                size: Index.numberToFetch
            },
            dataType: 'json',

            success: function (result) {
                Index.viewModel.reports(result);
            },

            error: function (error) {
            }
        });
    }
}

