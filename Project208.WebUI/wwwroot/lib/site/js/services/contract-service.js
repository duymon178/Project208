var contractsUrl = "/api/contracts/";

var contractsInfoUrl     = contractsUrl + "info/";
var customerContractsUrl = contractsUrl + "customer/";

var getContractsInfo = function (getTotal, successCallback, errorCallback) {
    sendRequest(contractsInfoUrl, "GET", "getTotal=" + getTotal,
        function (data) { if (successCallback) successCallback(data); },
        function (jqXHR) { if (errorCallback) errorCallback(jqXHR); }
    );
};

var getContracts = function (filterData, successCallback, errorCallback) {
    sendRequest(contractsUrl, "GET", filterData,
        function (data) { if (successCallback) successCallback(data); },
        function (jqXHR) { if (errorCallback) errorCallback(jqXHR); }
    );
};

var getCustomerContracts = function (customerId, successCallback, errorCallback) {
    sendRequest(customerContractsUrl, "GET", "customerId=" + customerId,
        function (data) { if (successCallback) successCallback(data); },
        function (jqXHR) { if (errorCallback) errorCallback(jqXHR); }
    );
};