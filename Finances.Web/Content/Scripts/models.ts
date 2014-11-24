/// <reference path="typings/knockout/knockout.d.ts" />

class Settings {
    urlExit: string;
    urlAccount: string;
}

class Account {
    id: string;
    created: Date;
    name: string;
    amount: number;
} 

class Operation {
    id: string;
    accountId: string;
    date: Date;
    title: string;
    amount: number;
    charge: number;
}

class AppViewModel {

    clear() {
        this.accounts.removeAll();
        this.incomes.removeAll();
        this.expenses.removeAll();
    }

    accounts: KnockoutObservableArray<Account>;
    incomes: KnockoutObservableArray<Operation>;
    expenses: KnockoutObservableArray<Operation>;
}