var customerModel = {
    isInCustomerDetailView: ko.observable(false),

    customerT1ContractList: ko.observableArray(),
    customerT2ContractList: ko.observableArray(),

    prevCustomerName       : ko.observable(),
    prevCustomerAddress    : ko.observable(),
    prevCustomerLocationId : ko.observable(),
    prevCustomerPhoneNumber: ko.observable(),
    prevCustomerNote       : ko.observable(),


    newCustomer: {
        CustomerName       : ko.observable(""),
        CustomerAddress    : ko.observable(""),
        LocationId         : ko.observable(LocationEnum.HN),
        CustomerPhoneNumber: ko.observable(""),
        CustomerNote       : ko.observable("")
    },

    tempCustomer: {
        CustomerId         : ko.observable(0),
        CustomerName       : ko.observable(""),
        CustomerAddress    : ko.observable(""),
        LocationId         : ko.observable(LocationEnum.HN),
        CustomerPhoneNumber: ko.observable(""),
        CustomerNote       : ko.observable("")
    }
};