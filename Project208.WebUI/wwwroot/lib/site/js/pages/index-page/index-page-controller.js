var clearContractList = function () {
    indexPageModel.t1List.removeAll();
    indexPageModel.t2List.removeAll();
};

var clearContractInfo = function () {
    indexPageModel.dailyInfo.removeAll();
    indexPageModel.totalInfo.removeAll();
};

var changeFilterStates = function (location, type, status, isDaily) {
    indexPageModel.filterData.searchString("");
    indexPageModel.filterData.locationId(location);
    indexPageModel.filterData.contractType(type);
    indexPageModel.filterData.contractStatusId(status);
    indexPageModel.filterData.isDaily(isDaily);
};

var isInT1List = function () {
    if (indexPageModel.t1List().length > 0) return true;
    else return false;
};


var getSearchStringBasedContracts = function () {
    if (indexPageModel.filterData.searchString()) {
        indexPageModel.filterData.isDaily(false);
        clearContractList();
        getContracts(indexPageModel.filterData, setContractList, defaultMsgErrorCallback);
    }
};

var getAllContracts = function (location, type, status, isDaily) {
    changeFilterStates(location, type, status, isDaily);
    clearContractList();
    getContracts(indexPageModel.filterData, setContractList, detailMsgErrorCallback);
};

var setContractList = function (data) {
    if (indexPageModel.filterData.contractType() == ContractTypeEnum.Type1) {
        indexPageModel.t1List.push.apply(indexPageModel.t1List, convertToObservableList(data));
    } else {
        indexPageModel.t2List.push.apply(indexPageModel.t2List, convertToObservableList(data));
    }
};


var getContractsInformation = function (getTotal) {
    indexPageModel.getTotal(getTotal);
    getContractsInfo(getTotal, setContractInfo, defaultMsgErrorCallback);
};

var setContractInfo = function (data) {
    clearContractInfo();

    indexPageModel.dailyInfo.push.apply(indexPageModel.dailyInfo, data.dailyInfo);

    if (indexPageModel.getTotal()) {
        indexPageModel.totalInfo.push.apply(indexPageModel.totalInfo, data.totalInfo);
    }
};

$(function () {
    getContractsInformation(true);
});