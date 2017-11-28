var clearCustomerList = function () {
    customerPageModel.customerList.removeAll();
};

var changeFilterStates = function (locationId) {
    clearCustomerList();

    customerPageModel.filterData.searchString("");
    changeCustomerPageLocation(locationId);
};

var changeCustomerPageLocation = function (locationId) {
    customerPageModel.filterData.locationId(locationId);
};

var setCustomerObject = function (customer) {
    customerPageModel.customerList.push(convertToObservableObject(customer));
};

var removeCustomerFromList = function (customerId) {
    for (var i = 0; i < customerPageModel.customerList().length; i++) {
        if (customerPageModel.customerList()[i].customerId() == customerId) {
            customerPageModel.customerList.remove(customerPageModel.customerList()[i]);
            break;
        }
    }
};

var updateCustomerTotalCount = function (locationId, value) {
    var customersCount = customerPageModel.customerTotalCount()[locationId - 1].customersCount;
    customersCount(customersCount() + value);
};


var getSearchStringBasedCustomers = function () {
    if (customerPageModel.filterData.searchString()) {
        clearCustomerList();
        getCustomers(customerPageModel.filterData, setCustomerList, null);
    }
};


var getAllCustomers = function (location) {
    changeFilterStates(location);
    getCustomers(customerPageModel.filterData, setCustomerList, null);
};

var setCustomerList = function (data) {
    customerPageModel.customerList.push.apply(customerPageModel.customerList, convertToObservableList(data));
};

var getCustomerTotalCount = function () {
    getCustomersInfo(setCustomerTotalCount, null);
};

var setCustomerTotalCount = function (data) {
    customerPageModel.customerTotalCount.removeAll();
    customerPageModel.customerTotalCount.push.apply(customerPageModel.customerTotalCount, convertToObservableList(data));
};

$(function () {
    getCustomerTotalCount();
});