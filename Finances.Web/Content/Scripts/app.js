/// <reference path="typings/jquery/jquery.d.ts" />
/// <reference path="typings/knockout/knockout.d.ts" />
var AppViewModel = (function () {
    function AppViewModel(items) {
        this.items = ko.observableArray(items);
        this.itemToAdd = ko.observable("");
    }
    AppViewModel.prototype.addItem = function () {
        if (this.itemToAdd() != "") {
            this.items.push(this.itemToAdd());
            this.itemToAdd("");
        }
    };
    return AppViewModel;
})();

jQuery(document).ready(function () {
    $("#exit").click(function (e) {
        e.preventDefault();
        var $target = $(e.currentTarget);
        var url = $target.attr("href");
        $.getJSON(url, function (data) {
            if (data && data.exit) {
                $target.hide();
                alert("Application Closed");
            }
        });
    });

    ko.applyBindings(new AppViewModel(["Alpha", "Beta", "Gamma"]));
});
//# sourceMappingURL=app.js.map
