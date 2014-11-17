/// <reference path="typings/jquery/jquery.d.ts" />
/// <reference path="typings/knockout/knockout.d.ts" />

class AppViewModel {
    constructor(items : Array<string>) {
        this.items = ko.observableArray(items);
        this.itemToAdd = ko.observable("");
    }

    items: KnockoutObservableArray<string>;
    itemToAdd: KnockoutObservable<string>;

    addItem() {
        if (this.itemToAdd() != "") {
            this.items.push(this.itemToAdd());
            this.itemToAdd("");
        }
    }
}

jQuery(document).ready(() => {

    $("#exit").click((e) => {
        e.preventDefault();
        var $target = $(e.currentTarget);
        var url = $target.attr("href");
        $.getJSON(url, (data) => {
            if (data && data.exit) {
                $target.hide();
                alert("Application Closed");
            }
        });
    });

    ko.applyBindings(new AppViewModel(["Alpha", "Beta", "Gamma"]));

});


