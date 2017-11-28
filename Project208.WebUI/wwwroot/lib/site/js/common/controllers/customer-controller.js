var clearCustomerForm = function () {
    customerModel.newCustomer.CustomerName("");
    customerModel.newCustomer.CustomerAddress("");
    customerModel.newCustomer.LocationId(LocationEnum.HN);
    customerModel.newCustomer.CustomerPhoneNumber("");
    customerModel.newCustomer.CustomerNote("");

    removeErrorSuccessState('createCustomerForm');
};

var isInCustomerPage = function () {
    if (typeof getCustomerTotalCount !== 'undefined' && $.isFunction(getCustomerTotalCount)) return true;
    else return false;
}

var hideCreateCustomerModal = function () {
    $('#create-customer-modal').modal('hide');
};

var hideCustomerDetailModal = function () {
    $('#customer-detail-modal').modal('hide');
};

var setPrevCustomerDetail = function (customer) {
    customerModel.prevCustomerName(customer.customerName);
    customerModel.prevCustomerAddress(customer.customerAddress);
    customerModel.prevCustomerLocationId(customer.locationId);

    var prevPhoneNumber = customerModel.prevCustomerPhoneNumber;
    customer.customerPhoneNumber == null ? prevPhoneNumber("") : prevPhoneNumber(customer.customerPhoneNumber);

    var prevNote = customerModel.prevCustomerNote;
    customer.customerNote == null ? prevNote("") : prevNote(customer.customerNote);
};

var clearCustomerDetailModalAfterHidden = function () {
    $('#customer-detail-modal').on('hidden.bs.modal', function (e) {
        customerModel.isInCustomerDetailView(false);
        clearCustomerForm();
    });
};


var createNewCustomer = function (formElement) {
    if ($(formElement).valid()) createCustomer(customerModel.newCustomer, createCustomerSuccessCallback, detailMsgErrorCallback);
};

var createCustomerSuccessCallback = function (newCustomer) {
    detailMsgSuccessCallback(
        'Thêm thành công: <br/><strong>' + newCustomer.customerName + ', ' + newCustomer.customerAddress +
        '</strong><br />Mã KH: <strong>' + newCustomer.customerId + '</strong>');

    hideCreateCustomerModal();

    if (isInCustomerPage()) {
        updateCustomerTotalCount(newCustomer.locationId, 1)
        clearCustomerList();
        setCustomerObject(newCustomer);
        changeCustomerPageLocation(newCustomer.locationId);
    }

    clearCustomerForm();
};


var getCustomerDetail = function (customerId, customerName, customerAddress, locationId, customerPhoneNumber, customerNote) {
    removeErrorSuccessState('customerDetailForm');
    customerModel.isInCustomerDetailView(true);
    setTempCustomerDetail(customerId, customerName, customerAddress, locationId, customerPhoneNumber, customerNote);

    clearCustomerContractLists();
    getCustomerContracts(customerId, setCustomerContracts, null);
};

var setTempCustomerDetail = function (customerId, customerName, customerAddress, locationId, customerPhoneNumber, customerNote) {
    customerModel.tempCustomer.CustomerId(customerId);
    customerModel.tempCustomer.CustomerName(customerName);
    customerModel.tempCustomer.CustomerAddress(customerAddress);
    customerModel.tempCustomer.LocationId(locationId);

    // The server does not accept the value of null, so we need to change to an empty string (in case of null), to be able to save our data to the server:
    var tempPhoneNumber = customerModel.tempCustomer.CustomerPhoneNumber;
    customerPhoneNumber == null ? tempPhoneNumber("") : tempPhoneNumber(customerPhoneNumber);

    var tempNote = customerModel.tempCustomer.CustomerNote;
    customerNote == null ? tempNote("") : tempNote(customerNote);

    customerModel.prevCustomerName(customerName);
    customerModel.prevCustomerAddress(customerAddress);
    customerModel.prevCustomerLocationId(locationId);

    var prevPhoneNumber = customerModel.prevCustomerPhoneNumber;
    customerPhoneNumber == null ? prevPhoneNumber("") : prevPhoneNumber(customerPhoneNumber);

    var prevNote = customerModel.prevCustomerNote;
    customerNote == null ? prevNote("") : prevNote(customerNote);
};

var clearCustomerContractLists = function () {
    customerModel.customerT1ContractList.removeAll();
    customerModel.customerT2ContractList.removeAll();
};

var setCustomerContracts = function (data) {
    customerModel.customerT1ContractList.push.apply(customerModel.customerT1ContractList, convertToObservableList(data.t1Contracts));
    customerModel.customerT2ContractList.push.apply(customerModel.customerT2ContractList, convertToObservableList(data.t2Contracts));
};


var removeCustomer = function () {
    alertify.confirm(
        'Xóa Khách Hàng',
        '<p class="text-danger"><strong>Chú ý</strong>: Xóa khách hàng sẽ đồng thời xóa tất cả bát họ và khoản nóng của khách hàng đó.</p><br/><p>Bạn vẫn muốn xóa chứ?</p>',
        function () {
            deleteCustomer(customerModel.tempCustomer.CustomerId(), removeCustomerSuccessCallback, detailMsgErrorCallback);
        }, function () { })
        .set('labels', { ok: '<span class="glyphicon glyphicon-trash" aria-hidden="true"></span> Xóa', cancel: 'Thoát' })
        .set('reverseButtons', true);
};

var removeCustomerSuccessCallback = function (customer) {
    detailMsgSuccessCallback('Xóa thành công dữ liệu khách hàng:<br/><strong>' + customer.customerName + ', ' + customer.customerAddress + '</strong>');

    hideCustomerDetailModal();

    if (isInCustomerPage()) {
        removeCustomerFromList(customer.customerId);
        updateCustomerTotalCount(customer.locationId, -1);
    }
    else {
        if (isInT1List()) {
            removeContractsByCustomerId(indexPageModel.t1List, customer.customerId);
        } else {
            removeContractsByCustomerId(indexPageModel.t2List, customer.customerId);
        }

        getContractsInformation(true);
    }
};


var saveCustomerDetail = function (formElement) {
    if ($(formElement).valid()) {
        if (anyCustomerDetailChange()) updateCustomer(customerModel.tempCustomer, saveCustomerDetailSuccessCallback, detailMsgErrorCallback);
    }
};

var anyCustomerDetailChange = function () {
    if ((customerModel.prevCustomerName() != customerModel.tempCustomer.CustomerName())
        || (customerModel.prevCustomerAddress() != customerModel.tempCustomer.CustomerAddress())
        || (customerModel.prevCustomerPhoneNumber() != customerModel.tempCustomer.CustomerPhoneNumber())
        || (customerModel.prevCustomerLocationId() != customerModel.tempCustomer.LocationId())
        || (customerModel.prevCustomerNote() != customerModel.tempCustomer.CustomerNote())) {
        return true;
    }

    return false;
}

var saveCustomerDetailSuccessCallback = function (customer) {
    detailMsgSuccessCallback('Sửa thành công dữ liệu khách hàng:<br/><strong>' + customer.customerName + ', ' + customer.customerAddress + '</strong>');

    if (isInCustomerPage()) {
        if (isInTheSameLocation(customerPageModel, customer.locationId)) {
            updateCustomerDetail(customerPageModel.customerList, customer);
        }
        else {
            removeCustomerFromList(customer.customerId);

            updateCustomerTotalCount(customer.locationId, 1);
            updateCustomerTotalCount(customerModel.prevCustomerLocationId(), -1);
        }
    }
    else {
        if (isInTheSameLocation(indexPageModel, customer.locationId)) {
            (isInT1List()) ? updateCustomerDetail(indexPageModel.t1List, customer) :
                updateCustomerDetail(indexPageModel.t2List, customer);
        }
        else {
            (isInT1List()) ? removeContractsByCustomerId(indexPageModel.t1List, customer.customerId) :
                removeContractsByCustomerId(indexPageModel.t2List, customer.customerId);

            getContractsInformation(true);
        }
    }

    setPrevCustomerDetail(customer);
    hideCustomerDetailModal();
};

$(function () {
    clearCustomerDetailModalAfterHidden();

    $('#customer-detail-tabs a').click(function (e) {
        e.preventDefault();
        $(this).tab('show');
    })
});