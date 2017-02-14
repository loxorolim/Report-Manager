$(document).ready(function () {
    Index.init();
});
var Index = {
    start: 0,
    numberToFetch: 100,
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
                result.forEach(function (entry, index) {
                    result[index]["editMode"] = false
                    result[index]["date"] = new Date(result[index]["date"]);
                    result[index] = ko.mapping.fromJS(entry);
                });
                var concatedResult = Index.viewModel.reports().concat(result);
                Index.viewModel.reports(concatedResult);
                Index.start += result.length;
            },

            error: function (error) {
            }
        });
    }
}

