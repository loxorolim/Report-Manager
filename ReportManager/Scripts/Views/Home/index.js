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
        Index.fetchReports();
    },
    fetchReports: function () {
        $.ajax({
            type: 'GET',
            url: '/Report/GetReportCollectionByRecentDate',
            data: {
                start: Index.start,
                size: Index.numberToFetch
            },
            dataType: 'json',

            success: function (result) {
                var concatedResult = Index.viewModel.reports().concat(result);
                Index.viewModel.reports(concatedResult);
                Index.start = concatedResult.length;
            },

            error: function (error) {
            }
        });
    }
}

