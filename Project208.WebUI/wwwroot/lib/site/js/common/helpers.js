var LocationEnum       = Object.freeze({ "HN": 1, "SG": 2 });
var ContractTypeEnum   = Object.freeze({ "Type1": 1, "Type2": 2 });
var ContractStatusEnum = Object.freeze({ "Paying": 1, "Renewed": 2, "SlowlyReturn": 3, "Done": 4, "UnableToPay": 5 });

var removeErrorSuccessState = function (formId) {
    $('#' + formId + ' div.form-group').removeClass('has-error').removeClass('has-success');

    $('#' + formId + ' div.form-group span.field-validation-error').empty().removeClass('field-validation-error').addClass('field-validation-valid');
};

// By default jquery validator ignores hidden fields.
// change the setting here to ignore nothing:
$.validator.setDefaults({ ignore: null });

/* List effects: */
var show = function (elem) {
    if (elem.nodeType === 1) $(elem).hide().fadeIn()
};
var hide = function (elem) {
    if (elem.nodeType === 1) $(elem).fadeOut(function () { $(elem).remove(); })
};

/* Custom binding handler for bootstrap buttons and knockout checked: */
ko.bindingHandlers.bsChecked = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        var value = valueAccessor();
        var newValueAccessor = function () {
            return {
                change: function () {
                    value(element.value);
                }
            }
        };
        ko.bindingHandlers.event.init(element, newValueAccessor, allBindingsAccessor, viewModel, bindingContext);
    },
    update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        if ($(element).val() == ko.unwrap(valueAccessor())) {
            setTimeout(function () {
                $(element).closest('.btn').button('toggle');
            }, 1);
        }
    }
}

/* Bootstrap validation styles with ASP.NET Unobtrusive validation */
jQuery.validator.setDefaults({
    highlight: function (element, errorClass, validClass) {
        if (element.type === 'radio') {
            this.findByName(element.name).addClass(errorClass).removeClass(validClass);
        } else {
            $(element).addClass(errorClass).removeClass(validClass);
            $(element).closest('.form-group').removeClass('has-success').addClass('has-error');
        }
    },
    unhighlight: function (element, errorClass, validClass) {
        if (element.type === 'radio') {
            this.findByName(element.name).removeClass(errorClass).addClass(validClass);
        } else {
            $(element).removeClass(errorClass).addClass(validClass);
            $(element).closest('.form-group').removeClass('has-error').addClass('has-success');
        }
    }
});

var convertToObservableList = function (list) {
    var newList = [];

    $.each(list, function (i, obj) {
        var newObj = convertToObservableObject(obj);
        newList.push(newObj);
    });

    return newList;
};

var convertToObservableObject = function (obj) {
    var newObj = {};

    Object.keys(obj).forEach(function (key) {
        _.isObject(obj[key]) ? newObj[key] = convertToObservableObject(obj[key]) : newObj[key] = ko.observable(obj[key]);
    });

    return newObj;
};

ko.utils.extendObservable = function (target, source) {
    var prop, srcVal, isObservable = false;

    for (prop in source) {
        if (!source.hasOwnProperty(prop)) continue;

        if (ko.isWriteableObservable(source[prop])) {
            isObservable = true;
            srcVal = source[prop]();
        } else if (typeof (source[prop]) !== 'function') {
            srcVal = source[prop];
        }

        if (ko.isWriteableObservable(target[prop])) {
            target[prop](srcVal);
        } else if (target[prop] === null || target[prop] === undefined) {
            target[prop] = isObservable ? ko.observable(srcVal) : srcVal;
        } else if (typeof (target[prop]) !== 'function') {
            target[prop] = srcVal;
        }

        isObservable = false;
    }

    return target;
};

ko.utils.clone = function (obj, emptyObj) {
    var json = ko.toJSON(obj);
    var js = JSON.parse(json);

    return ko.utils.extendObservable(emptyObj, js);
};

$(function () {
    // Scroll to top:
    $('.info-body a').on('click', function () {
        $('html, body').animate({
            scrollTop: 0
        }, 600);
    });

    $('.printBtn').on('click', function () {
        window.print();
    });

    /* Overlay backdrop multiple modals: */
    $(document).on('show.bs.modal', '.modal', function () {
        var zIndex = 1040 + (10 * $('.modal:visible').length);
        $(this).css('z-index', zIndex);
        setTimeout(function () {
            $('.modal-backdrop').not('.modal-stack').css('z-index', zIndex - 1).addClass('modal-stack');
        }, 0);
    });

    /* Scrollbar fix multiple modals: */
    $(document).on('hidden.bs.modal', '.modal', function () {
        $('.modal:visible').length && $(document.body).addClass('modal-open');
    });
});