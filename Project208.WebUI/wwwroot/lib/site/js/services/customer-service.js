var customersUrl = "/api/customers/";

var customersInfoUrl = customersUrl + "info/";

var getCustomersInfo = function (successCallback, errorCallback) {
    sendRequest(customersInfoUrl, "GET", null,
        function (data) { if (successCallback) successCallback(data); },
        function (jqXHR) { if (errorCallback) errorCallback(jqXHR); }
    );
};

var getCustomers = function (filterData, successCallback, errorCallback) {
    sendRequest(customersUrl, "GET", filterData,
        function (data) { if (successCallback) successCallback(data); },
        function (jqXHR) { if (errorCallback) errorCallback(jqXHR); }
    );
};

var createCustomer = function (customer, successCallback, errorCallback) {
    sendRequest(customersUrl, "POST", customer,
        function (customer) { if (successCallback) successCallback(customer); },
        function (jqXHR) { if (errorCallback) errorCallback(jqXHR); },
        { headers: { "RequestVerificationToken": token }}
    );
};

var updateCustomer = function (customer, successCallback, errorCallback) {
    sendRequest(customersUrl, "PUT", customer,
        function (customer) { if (successCallback) successCallback(customer); },
        function (jqXHR) { if (errorCallback) errorCallback(jqXHR); },
        { headers: { "RequestVerificationToken": token }}
    );
};

// In POST or DELETE request, if we want to attach our data to query string, we have to
// add our data to the URL part, not the data part.
var deleteCustomer = function (customerId, successCallback, errorCallback) {
    sendRequest(customersUrl + customerId, "DELETE", null,
        function (customer) { if (successCallback) successCallback(customer); },
        function (jqXHR) { if (errorCallback) errorCallback(jqXHR); },
        { headers: { "RequestVerificationToken": token }}
    );
};

// In GET request, we can add our data to the query string by adding them to the URL part or the 'data' part.
// -> result: api/customers/?customerId=10
var checkIfCustomerExist = function (customerId, successCallback, errorCallback) {
    sendRequest(customersUrl /* + "?customerId=" + customerId*/, "GET", "customerId=" + customerId,
        function (customer) { if (successCallback) successCallback(customer); },
        function (jqXHR) { if (errorCallback) errorCallback(jqXHR); }
    );
};