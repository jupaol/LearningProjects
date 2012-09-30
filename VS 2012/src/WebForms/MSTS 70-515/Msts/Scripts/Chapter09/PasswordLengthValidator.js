Type.registerNamespace("Msts.UI.Client.Controls.Validators");

Msts.UI.Client.Controls.Validators.passwordStrength = function () {
};

Msts.UI.Client.Controls.Validators.passwordStrength.prototype = {
    Weak: 0,
    Medium: 1,
    Strong: 2
};

Msts.UI.Client.Controls.Validators.passwordStrengthValidator = function (shouldValidate, minNumberOfCharacteres) {
    Msts.UI.Client.Controls.Validators.passwordStrengthValidator.initializeBase(this);

    this._shouldValidate = shouldValidate;
    this._minNumberOfCharacteres = minNumberOfCharacteres;
};

Msts.UI.Client.Controls.Validators.passwordStrengthValidator.prototype = {
    get_shouldValidate: function () {
        return this._shouldValidate;
    },
    get_minNumberOfCharacteres: function () {
        return this._minNumberOfCharacteres;
    },
    set_minNumberOfCharacteres: function (value) {
        this._minNumberOfCharacteres = value;
    },
    getPasswordStrength: function (value) {
        if (!typeof(value) === 'string') {
            throw new Error("The parameter: 'value' must be a string");
        }

        var s = new String(value);

        if (s.length <= 3) {
            return Msts.UI.Client.Controls.Validators.passwordStrength.Weak;
        }

        if (s.length > 3 && s.length <= 6) {
            return Msts.UI.Client.Controls.Validators.passwordStrength.Medium;
        }

        return Msts.UI.Client.Controls.Validators.passwordStrength.Strong;
    },
    isValid: function (value) {
        if (this.get_shouldValidate()) {
            var s = new String(value);

            if (s.length < this.get_minNumberOfCharacteres()) {
                return false;
            }
            else {
                return true;
            }
        }

        return true;
    }
};

Msts.UI.Client.Controls.Validators.passwordStrength.registerEnum("Msts.UI.Client.Controls.Validators.passwordStrength");

Msts.UI.Client.Controls.Validators.passwordStrengthValidator.registerClass(
    "Msts.UI.Client.Controls.Validators.passwordStrengthValidator",
    Sys.Component,
    Sys.IDisposable
    );

if (typeof(Sys) !== 'undefined') {
    Sys.Application.notifyScriptLoaded();
}