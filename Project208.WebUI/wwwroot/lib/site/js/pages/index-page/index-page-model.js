var indexPageModel = {
    t1List: ko.observableArray(),
    t2List: ko.observableArray(),
    getTotal: ko.observable(false),

    dailyInfo: ko.observableArray(),
    totalInfo: ko.observableArray(),

    filterData: {
        locationId      : ko.observable(LocationEnum.HN),
        contractType    : ko.observable(ContractTypeEnum.Type1),
        contractStatusId: ko.observable(ContractStatusEnum.Paying),
        isDaily         : ko.observable(false),
        searchString    : ko.observable("")
    }
};