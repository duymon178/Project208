var sendRequest = function (url, verb, data, successCallback, errorCallback, options) {
    var requestOptions = options || {};

    requestOptions.type    = verb;
    requestOptions.success = successCallback;
    requestOptions.error   = errorCallback;

    if (!url || !verb) errorCallback(401, "URL and HTTP verb required");
    
    if (data) requestOptions.data = data;

    $.ajax(url, requestOptions);
};

var setDefaultCallbacks = function (successCallback, errorCallback) {
    $.ajaxSetup({
        complete: function (jqXHR, status) {
            (200 <= jqXHR.status && jqXHR.status < 300) ? successCallback(jqXHR.responseJSON) :
                                                          errorCallback(jqXHR.responseText, jqXHR.status, jqXHR.statusText);
        }
    });
};

var defaultMsgErrorCallback = function () {
    alertify.error('<span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> Có lỗi hệ thống xảy ra..', 8);
}

var detailMsgErrorCallback = function (jqXHR) {
    alertify.error('<span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> ' + jqXHR.responseText, 80);
};

var detailMsgSuccessCallback = function (message) {
    alertify.success('<span class="glyphicon glyphicon-ok-sign" aria-hidden="true"></span> ' + message, 8);
};

var detailMsgWarningCallback = function (message) {
    alertify.warning('<span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span> ' + message, 8);
};