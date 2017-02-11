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
                    result[index] = ko.mapping.fromJS(entry);
                    result[index]["editMode"] = ko.observable(false);
                    result[index]["copy"] = {};
                    result[index]["makeCopy"] = function () {
                        result[index]["editMode"](true);
                        for (var attribute in result[index]) {
                            if (typeof result[attribute] !== "function" && attribute !== "editMode" && attribute !== "__ko_mapping__"){
                                result[index]["copy"][attribute] = result[index][attribute]();
                            }
                        }
                    },
                    result[index]["restore"] = function () {
                        result[index]["editMode"](false);
                        for (var attribute in result[index]["copy"]) {
                            if (typeof result[attribute] !== "function" && attribute !== "editMode" && attribute !== "__ko_mapping__") {
                                result[index][attribute](result[index]["copy"][attribute]);
                            }
                        }
                    },
                    result[index]["update"] = function () {
                        result[index]["editMode"](false);
                        //persistir;
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

