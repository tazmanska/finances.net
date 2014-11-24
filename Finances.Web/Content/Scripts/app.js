/// <reference path="typings/jquery/jquery.d.ts" />
/// <reference path="typings/knockout/knockout.d.ts" />
/// <reference path="models.ts" />
var Application = (function () {
    function Application(settings) {
        this.vm = new AppViewModel();
        this.settings = settings;
    }
    Application.prototype.init = function () {
        var _this = this;
        $("a.exit-application").click(function (e) {
            e.preventDefault();
            _this.exit();
        });

        ko.applyBindings(this.vm);
        this.loadAccount();
    };

    Application.prototype.loadAccount = function () {
    };

    Application.prototype.clear = function () {
        this.vm.clear();
    };

    Application.prototype.exit = function () {
        var _this = this;
        $.getJSON(this.settings.urlExit, function (data) {
            if (data && data.exit) {
                _this.clear();
                $("a.exit - application").hide();
                alert("Application Closed");
            }
        });
    };
    return Application;
})();

jQuery(document).ready(function () {
    var app = new Application({
        urlExit: "/Exit",
        urlAccount: "/api/account"
    });
    app.init();
});
//# sourceMappingURL=app.js.map
