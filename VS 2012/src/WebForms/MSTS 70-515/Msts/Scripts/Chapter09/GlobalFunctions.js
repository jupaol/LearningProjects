function typeOf(value) {
    var type = typeof (value);

    if (type !== 'object') {
        return type;
    }

    if (Object.prototype.toString.call(value) === '[object Array]' || $.isArray(value)) {
        return 'array';
    }

    if (value === null) {
        return 'null';
    }

    return value;
}

function validateArgs(args, opt) {
    var argsArray = $.makeArray(args);

    if (!$.isArray(argsArray)) {
        throw new Error("The 'args' parameter must be an array with the caller parameters.");
    }

    if(typeOf(opt) === 'null' || typeOf(opt) === 'undefined'){
        return true;
    }

    var optArray = $.makeArray(opt);

    if(!$.isArray(optArray)){
        throw new Error("The 'opt' parameter must be an array with the options for the parameters");
    }

    for (var i = 0; i < argsArray.length; i++) {
    }
}

function getParameterInfo() {
}