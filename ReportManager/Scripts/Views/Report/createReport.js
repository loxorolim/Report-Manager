$(document).ready(function () {
    CreateReport.init();
});
var CreateReport = {
    viewModel: {
        report: ko.observable()
    },
    init: function () {
        ko.applyBindings(CreateReport.viewModel);
        CreateReport.viewModel.report(CreateReport.getEmptyReport());
    },
    getEmptyReport : function () {
        return {
            date : null,
            status: null,
            flow: null,
            application: null,
            impact: null,
            workaround: null,
            workaroundTime: null,
            solution: null,
            solutionTime: null,
            reporter: null,
            description: null,
            responsibleTeam: null
        }
    }
}


