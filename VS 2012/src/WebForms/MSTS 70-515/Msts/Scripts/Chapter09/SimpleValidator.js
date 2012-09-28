Type.registerNamespace("Msts.UI.Client.Controls.Validators");

Msts.UI.Client.Controls.Validators.RequiredFieldValidator = function (fieldValue, shouldValidate) {
    Msts.UI.Client.Controls.Validators.RequiredFieldValidator.initializeBase(this);

    this.FieldValue = fieldValue;
    this._fieldValue = fieldValue;

    if(typeof(shouldValidate) !== 'boolean' || shouldValidate === 'undefined'){
        this._shouldValidate = true;
    }
    else{
        this._shouldValidate = shouldValidate;
    }
};

Msts.UI.Client.Controls.Validators.RequiredFieldValidator.prototype = {
    get_ShouldValidate:function () {
        return this._shouldValidate;
    },
    get_FieldValue: function () {
        return this.FieldValue;
    },
    set_FieldValue: function (value) {
        this.FieldValue = value;
    },
    isValid: function () {
        if (this.get_ShouldValidate()) {
            var s = new String(this.get_FieldValue());

            if (s.toString() === '') {
                return false;
            }

            return true;
        }
        else {
            return true;
        }
    }
};

Msts.UI.Client.Controls.Validators.RequiredFieldValidator.registerClass(
    "Msts.UI.Client.Controls.Validators.RequiredFieldValidator",
    null,
    Sys.IDisposable);

if (typeof (Sys) != 'undefined') {
    Sys.Application.notifyScriptLoaded();
}