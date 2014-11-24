/// <reference path="typings/knockout/knockout.d.ts" />
var Settings = (function () {
    function Settings() {
    }
    return Settings;
})();

var Account = (function () {
    function Account() {
    }
    return Account;
})();

var Operation = (function () {
    function Operation() {
    }
    return Operation;
})();

var AppViewModel = (function () {
    function AppViewModel() {
    }
    AppViewModel.prototype.clear = function () {
        this.accounts.removeAll();
        this.incomes.removeAll();
        this.expenses.removeAll();
    };
    return AppViewModel;
})();
//# sourceMappingURL=models.js.map
