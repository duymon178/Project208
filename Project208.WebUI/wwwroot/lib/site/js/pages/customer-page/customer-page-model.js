var customerPageModel = {
    customerList: ko.observableArray(),
    customerTotalCount: ko.observableArray(),

    /* Filter data object */
    filterData: {
        locationId  : ko.observable(LocationEnum.HN),
        searchString: ko.observable("")
    }
};