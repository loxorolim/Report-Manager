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
        Index.setupDatetimePicker();
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
    },
    setupDatetimePicker: function () {
        ko.bindingHandlers.dateTimePicker = {
            init: function (element, valueAccessor, allBindingsAccessor) {
                //initialize datepicker with some optional options
                var options = allBindingsAccessor().dateTimePickerOptions || { locale: 'pt-br' };
                $(element).datetimepicker(options);

                //when a user changes the date, update the view model
                ko.utils.registerEventHandler(element, "dp.change", function (event) {
                    var value = valueAccessor();
                    if (ko.isObservable(value)) {
                        if (event.date != null && !(event.date instanceof Date)) {
                            value(event.date.toDate());
                        } else {
                            value(event.date);
                        }
                    }
                });

                ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
                    var picker = $(element).data("DateTimePicker");
                    if (picker) {
                        picker.destroy();
                    }
                });
            },
            update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {

                var picker = $(element).data("DateTimePicker");
                //when the view model is updated, update the widget
                if (picker) {
                    var koDate = ko.utils.unwrapObservable(valueAccessor());

                    //in case return from server datetime i am get in this form for example /Date(93989393)/ then fomat this
                    koDate = (typeof (koDate) !== 'object') ? new Date(parseFloat(koDate.replace(/[^0-9]/g, ''))) : koDate;

                    picker.date(koDate);
                }
            }
        };
    }
}

