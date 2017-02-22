var ReportPartial = {
    getCopy: function (report) {
        var copy = {};
        for (var attribute in report) {
            if (attribute !== "__ko_mapping__" && attribute !== "mode" && attribute !== "copy" && attribute !== "id") {
                copy[attribute] = report[attribute]();
            }
        }
        return copy;
    },
    makeCopy: function (report) {
        report["copy"] = this.getCopy(report);
    },
    restore: function (report) {
        for (var attribute in report["copy"]) {
            report[attribute](report["copy"][attribute]);
        }
    },
    setEditMode: function (report) {
        report["mode"]("edit");
    },
    setViewMode: function(report) {
        report["mode"]("view");
    },
    updateReport: function (report) {
        var dateTime = report["date"]().toISOString();
        report["date"](dateTime);
        $.ajax({
            type: 'POST',
            url: '/Report/UpdateReport',
            data: report,
            success: function () {
                report["mode"]("view");
                report["date"](new Date(dateTime));
            },

            error: function (error) {
            }
        });
    },
    createReport: function (report) {
        var dateTime = report["date"]().toISOString();
        report["date"](dateTime);
        $.ajax({
            type: 'POST',
            url: '/Report/CreateReport',
            data: report,
            success: function () {
                Index.refresh();
            },

            error: function (error) {
            }
        });
    },
    deleteReport: function (report) {
        $.ajax({
            type: 'POST',
            url: '/Report/DeleteReport',
            data: report,
            success: function () {
                Index.refresh();
            },
            error: function (error) {
            }
        });
    }
}
