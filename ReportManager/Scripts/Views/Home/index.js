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
                result.forEach(function(entry) {
                    entry["editMode"] = ko.observable(false);
                    entry["copy"] = {};
                    entry["makeCopy"] = function () {
                        entry["editMode"](true);
                        for (var attribute in entry) {
                            if (attribute != "copy" && attribute != "makeCopy" && attribute != "restore") {
                                entry["copy"][attribute] = entry[attribute];
                            }
                        }
                    },
                    entry["restore"] = function () {
                        entry["editMode"](false);
                        for (var attribute in entry["copy"]) {
                            if (attribute != "copy" && attribute != "makeCopy" && attribute != "restore") {
                                entry[attribute] = entry["copy"][attribute];
                            }
                        }
                    }
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

