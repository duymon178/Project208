var isInTheSameLocation = function (pageModel, locationId) {
    if (pageModel.filterData.locationId() == locationId) return true;
    else return false;
};

/* List: */
var removeContractByContractId = function (list, contractId) {
    for (var i = 0; i < list().length; i++) {
        if (list()[i].contractId() == contractId) {
            list.remove(list()[i]);
            break;
        }
    }
};

var removeContractsByCustomerId = function (list, customerId) {
    var count = 0;

    for (var i = 0; i < list().length; i++) {
        if (list()[i].customerId() == customerId) {
            list.remove(list()[i]);
            // We need to subtract i by 1 to be able to correctly remove the next element
            // because after removing an OBSERVABLE OBJECT of an OBSERVABLE ARRAY, the array automatically shrinks.
            // This is for multiple elements removing purpose only.
            // This will not happen to an observable array only (which doesn't contain observable objects).
            i--;
            count++;
        }
    }

    return count;
};

var updateCustomerDetail = function (list, customer) {
    for (var i = 0; i < list().length; i++) {
        if (list()[i].customerId() == customer.customerId) {
            list()[i].customerName(customer.customerName);
            list()[i].customerAddress(customer.customerAddress);
            list()[i].customerPhoneNumber(customer.customerPhoneNumber);
            list()[i].customerNote(customer.customerNote);
            // Note here we don't need to change the data in our list to an empty string (in case of null),
            // because we will do it when we bind value to the customer detail view.
        }
    }
};

/* Common: */
var setBackgroundStatus = function (contractStatusId) {
    switch (contractStatusId) {
        case ContractStatusEnum.Paying:
            return "bg-success text-success";
        case ContractStatusEnum.Renewed:
            return "bg-info text-info";
        case ContractStatusEnum.SlowlyReturn:
            return "bg-warning text-warning";
        case ContractStatusEnum.UnableToPay:
            return "bg-danger text-danger";
        default:
            return "";
    }
};

var setContractStatus = function (contractNumber, contractType) {
    switch (contractType) {
        case ContractStatusEnum.Paying:
            if (contractNumber > 0) return "badge-green";
        case ContractStatusEnum.SlowlyReturn:
            if (contractNumber > 0) return "badge-yellow";
        case ContractStatusEnum.UnableToPay:
            if (contractNumber > 0) return "badge-red";
        default:
            return "badge";
    }
};

var setDetailContractStatusLabel = function (contractStatusId) {
    switch (contractStatusId) {
        case ContractStatusEnum.Paying:
            return "label label-success";
        case ContractStatusEnum.Renewed:
            return "label label-info";
        case ContractStatusEnum.SlowlyReturn:
            return "label label-warning"; 
        case ContractStatusEnum.Done:
            return "label label-default";
        case ContractStatusEnum.UnableToPay:
            return "label label-danger";
        default:
            return "";
    }
};

var setPaymentDetailAmountStatus = function (amount, needToPayDate, actualPayDate) {
    var css = "";

    if (needToPayDate != null && actualPayDate != null && amount > 0) {
        css = "bg-success text-success";
    }
    else if (needToPayDate != null && actualPayDate != null && amount == 0) {
        css = "bg-info";
    }
    else if (needToPayDate == null && actualPayDate != null && amount > 0) {
        css = "bg-warning text-warning";
    }

    return css;
};


$(function () {
    ko.applyBindings();

    setDefaultCallbacks(
        function (data) {
            if (data) {
                console.log("---Success---");
                console.log(JSON.stringify(data));
            }
            else {
                console.log("Success (no data)");
            }
            commonModel.gotError(false);
        },
        function (responseText, statusCode, statusText) {
            console.log("Error: " + statusCode + " (" + statusText + ")");
            console.log(responseText);

            commonModel.error(statusCode + " (" + statusText + ")");
            commonModel.gotError(true);
        }
    );
});