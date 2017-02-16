var ReportPartial = {
    makeCopy: function (report) {
        report["copy"] = {};
        for (var attribute in report) {
            if (attribute !== "__ko_mapping__" && attribute !== "mode" && attribute !== "copy") {
                report["copy"][attribute] = report[attribute]();
            }
        }
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
    }
}
