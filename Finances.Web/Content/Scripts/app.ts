/// <reference path="typings/jquery/jquery.d.ts" />
/// <reference path="typings/knockout/knockout.d.ts" />
/// <reference path="models.ts" />

class Application {

    private vm: AppViewModel;
    private settings: Settings;

    constructor(settings: Settings) {
        this.vm = new AppViewModel();
        this.settings = settings;
    }

    init() {
        $("a.exit-application").click((e) => {
            e.preventDefault();
            this.exit();
        });

        ko.applyBindings(this.vm);
        this.loadAccount();
    }

    loadAccount() {
        
    }

    clear() {
        this.vm.clear();
    }

    exit() {
        $.getJSON(this.settings.urlExit, (data) => {
            if (data && data.exit) {
                this.clear();
                $("a.exit - application").hide();
                alert("Application Closed");
            }
        });
    }
}

jQuery(document).ready(() => {
    var app = new Application({
        urlExit: "/Exit",
        urlAccount: "/api/account",
    });
    app.init();
});


