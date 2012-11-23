/* File Created: november, 2012 */
Sys.Mvc.ValidatorRegistry.validators["indetoekomst"] = function (rule) {
    var message = rule.ErrorMessage;

    return function (value, context) {
        var mydate = new Date(value);
        var today = new Date();
        if (mydate.getDate() < today.getDate())) {
            return false;
    }
    return true;
};
};

Sys.Mvc.ValidatorRegistry.validators["isnodig"] = function (rule) {
    var message = rule.ErrorMessage;

    return function (value, context) {
        if (value == null || value == "") {
            return false;
        }
        return true;
    };
};


Sys.Mvc.ValidatorRegistry.validators["uurvalidatie"] = function (rule) {
    var message = rule.ErrorMessage;
    var regex = rule.ValidationParameters.regex;

    return function (value, context) {
        var re = new RegExp(regex);
        if (!(re.exec(value))) {
            return false;
        }
        return true;
    };
};

Sys.Mvc.ValidatorRegistry.validators["emailvalidatie"] = function (rule) {
    var message = rule.ErrorMessage;
    var regex = rule.ValidationParameters.regex;

    return function (value, context) {
        var re = new RegExp(regex);
        if (!(re.exec(value))) {
            return false;
        }
        return true;
    };
};


Sys.Mvc.ValidatorRegistry.validators["telefoonvalidatie"] = function (rule) {
    var message = rule.ErrorMessage;
    var regex = rule.ValidationParameters.regex;

    return function (value, context) {
        var re = new RegExp(regex);
        if (!(re.exec(value))) {
            return false;
        }
        return true;
    };
};

Sys.Mvc.ValidatorRegistry.validators["postcodevalidatie"] = function (rule) {
    var message = rule.ErrorMessage;
    var regex = rule.ValidationParameters.regex;

    return function (value, context) {
        var re = new RegExp(regex);
        if (!(re.exec(value)) || value.length != 4) {
            return false;
        }
        return true;
    };
};


Sys.Mvc.ValidatorRegistry.validators["wachtwoordvalidatie"] = function (rule) {
    var message = rule.ErrorMessage;

    return function (value, context) {
        if (value.length < 4) {
            return false;
        }
        return true;
    };
};