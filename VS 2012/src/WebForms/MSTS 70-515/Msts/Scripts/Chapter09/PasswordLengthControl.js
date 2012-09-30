/// <reference Path="PasswordLengthValidator.js" />

Type.registerNamespace("Msts.UI.Client.Controls");

Msts.UI.Client.Controls.passwordLengthControl = function (element) {
    Msts.UI.Client.Controls.passwordLengthControl.initializeBase(this, [element]);

    this._weakCss = null;
    this._mediumCss = null;
    this._strongCss = null;
};

Msts.UI.Client.Controls.passwordLengthControl.prototype = {
    _weakCss: String,
    _mediumCss: String,
    _strongCss: String,
    get_weakCss: function () {
        return this._weakCss;
    },
    set_weakCss: function (value) {
        this._weakCss = value;
    },
    get_mediumCss: function () {
        return this._mediumCss;
    },
    set_mediumCss: function (value) {
        this._mediumCss = value;
    },
    get_strongCss: function () {
        return this._strongCss;
    },
    set_strongCss: function (value) {
        this._strongCss = value;
    },
    _onKeyUp: function (e) {
        var validator = new Msts.UI.Client.Controls.Validators.passwordStrengthValidator(true, 8);
        var value = new String(this.get_element().value);

        this.get_element().className = "";

        if (value.length <= 0) {
            return;
        }

        switch (validator.getPasswordStrength(value)) {
            case Msts.UI.Client.Controls.Validators.passwordStrength.Weak:
                this.get_element().className = this._weakCss;
                break;
            case Msts.UI.Client.Controls.Validators.passwordStrength.Medium:
                this.get_element().className = this._mediumCss;
                break;
            case Msts.UI.Client.Controls.Validators.passwordStrength.Strong:
                this.get_element().className = this._strongCss;
                break;
        }
    },
    initialize: function () {
        Msts.UI.Client.Controls.passwordLengthControl.callBaseMethod(this, 'initialize');

        this._onKeyUpHandler = Function.createDelegate(this.get_element(), this._onKeyUp);
        $addHandlers(this.get_element(), { "keyup": this._onKeyUp }, this);
    },
    dispose: function () {
        $clearHandlers(this.get_element());
        Msts.UI.Client.Controls.passwordLengthControl.callBaseMethod(this, "dispose");
    }
};

Msts.UI.Client.Controls.passwordLengthControl.registerClass(
    "Msts.UI.Client.Controls.passwordLengthControl",
    Sys.UI.Control,
    Sys.IDisposable);

if (typeof (Sys) !== 'undefined') {
    Sys.Application.notifyScriptLoaded();
}