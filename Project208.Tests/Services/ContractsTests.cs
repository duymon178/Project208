using System;
using Xunit;
using Moq;
using Project208.Domain.Abstract;
using Project208.Domain.Entities;
using System.Collections.Generic;
using Project208.Domain.Enums;

namespace Project208.Tests.Services
{
    public class ContractsTests
    {
        private List<Customer> customers = new List<Customer>
        {
            new Customer { CustomerId = 1, Name = "Mon", Address = "HN", LocationId = 1 },
            new Customer { CustomerId = 2, Name = "Bet", Address = "HN", LocationId = 1 },
            new Customer { CustomerId = 3, Name = "Tu", Address = "SG", LocationId = 2 },
            new Customer { CustomerId = 4, Name = "Bi", Address = "SG", LocationId = 2 }
        };

        private Mock<ILocationRepository> locationMock = new Mock<ILocationRepository>();
        private Mock<IT1ContractRepository> t1ContractsMock = new Mock<IT1ContractRepository>();
        private Mock<IT2ContractRepository> t2ContractsMock = new Mock<IT2ContractRepository>();

        public ContractsTests()
        {
            /*locationMock.Setup(m => m.Locations).Returns(new List<Location>
            {
                new Location { LocationID = 1, Name = "HN" },
                new Location { LocationID = 2, Name = "SG" }
            });

            t1ContractsMock.Setup(m => m.Contracts).Returns(new List<ContractType1>
            {
                new ContractType1 { ContractID = 1, Customer = customers[0], ContractStatusID = (int)ContractStatusEnum.Paying,
                    PaymentDetailsType1s = new PaymentDetailsType1[] { new PaymentDetailsType1 { ContractID = 1, PaymentDetailsID = 1, ActualPayDate = null, Amount = 0, NeedToPayDate = DateTime.Today } } },
                new ContractType1 { ContractID = 2, Customer = customers[1], ContractStatusID = (int)ContractStatusEnum.Paying,
                    PaymentDetailsType1s = new PaymentDetailsType1[] { new PaymentDetailsType1 { ContractID = 2, PaymentDetailsID = 1, ActualPayDate = null, Amount = 0, NeedToPayDate = new DateTime(2017, 6, 17) } } },
                new ContractType1 { ContractID = 3, Customer = customers[2], ContractStatusID = (int)ContractStatusEnum.Paying,
                    PaymentDetailsType1s = new PaymentDetailsType1[] { new PaymentDetailsType1 { ContractID = 1, PaymentDetailsID = 1, ActualPayDate = null, Amount = 0, NeedToPayDate = DateTime.Today } } },
                new ContractType1 { ContractID = 4, Customer = customers[0], ContractStatusID = (int)ContractStatusEnum.Paying,
                    PaymentDetailsType1s = new PaymentDetailsType1[] { new PaymentDetailsType1 { ContractID = 4, PaymentDetailsID = 1, ActualPayDate = null, Amount = 0, NeedToPayDate = DateTime.Today } } },
                new ContractType1 { ContractID = 5, Customer = customers[3], ContractStatusID = (int)ContractStatusEnum.Paying,
                    PaymentDetailsType1s = new PaymentDetailsType1[] { new PaymentDetailsType1 { ContractID = 5, PaymentDetailsID = 1, ActualPayDate = null, Amount = 0, NeedToPayDate = new DateTime(2017, 6, 18) } } },
                new ContractType1 { ContractID = 6, Customer = customers[1], ContractStatusID = (int)ContractStatusEnum.SlowlyReturn, LastReturnDate = null },
                new ContractType1 { ContractID = 7, Customer = customers[0], ContractStatusID = (int)ContractStatusEnum.SlowlyReturn, LastReturnDate = new DateTime(2017, 6, 8) },
                new ContractType1 { ContractID = 8, Customer = customers[2], ContractStatusID = (int)ContractStatusEnum.SlowlyReturn, LastReturnDate = DateTime.Today.AddDays(1) },
                new ContractType1 { ContractID = 9, Customer = customers[1], ContractStatusID = (int)ContractStatusEnum.UnableToPay }
            });

            t2ContractsMock.Setup(m => m.Contracts).Returns(new List<ContractType2>
            {
                new ContractType2 { ContractID = 1, Customer = customers[0], ContractStatusID = (int)ContractStatusEnum.Paying,
                    PaymentDetailsType2s = new PaymentDetailsType2[] { new PaymentDetailsType2 { ContractID = 1, PaymentDetailsID = 1, ActualPayDate = null, Amount = 0, NeedToPayDate = DateTime.Today } } },
                new ContractType2 { ContractID = 2, Customer = customers[1], ContractStatusID = (int)ContractStatusEnum.Paying,
                    PaymentDetailsType2s = new PaymentDetailsType2[] { new PaymentDetailsType2 { ContractID = 2, PaymentDetailsID = 1, ActualPayDate = null, Amount = 0, NeedToPayDate = new DateTime(2017, 6, 17) } } },
                new ContractType2 { ContractID = 3, Customer = customers[2], ContractStatusID = (int)ContractStatusEnum.Paying,
                    PaymentDetailsType2s = new PaymentDetailsType2[] { new PaymentDetailsType2 { ContractID = 1, PaymentDetailsID = 1, ActualPayDate = null, Amount = 0, NeedToPayDate = DateTime.Today } } },
                new ContractType2 { ContractID = 4, Customer = customers[0], ContractStatusID = (int)ContractStatusEnum.Paying,
                    PaymentDetailsType2s = new PaymentDetailsType2[] { new PaymentDetailsType2 { ContractID = 4, PaymentDetailsID = 1, ActualPayDate = null, Amount = 0, NeedToPayDate = DateTime.Today } } },
                new ContractType2 { ContractID = 6, Customer = customers[1], ContractStatusID = (int)ContractStatusEnum.SlowlyReturn,
                    PaymentDetailsType2s = new PaymentDetailsType2[] { new PaymentDetailsType2 { ContractID = 6, PaymentDetailsID = 1, ActualPayDate = null, Amount = 0, NeedToPayDate = DateTime.Today } } },
                new ContractType2 { ContractID = 7, Customer = customers[0], ContractStatusID = (int)ContractStatusEnum.SlowlyReturn,
                    PaymentDetailsType2s = new PaymentDetailsType2[] { new PaymentDetailsType2 { ContractID = 7, PaymentDetailsID = 1, ActualPayDate = null, Amount = 0, NeedToPayDate = new DateTime(2017, 6, 8) } } },
                new ContractType2 { ContractID = 8, Customer = customers[2], ContractStatusID = (int)ContractStatusEnum.SlowlyReturn,
                    PaymentDetailsType2s = new PaymentDetailsType2[] { new PaymentDetailsType2 { ContractID = 8, PaymentDetailsID = 1, ActualPayDate = null, Amount = 0, NeedToPayDate = DateTime.Today } }},
                new ContractType2 { ContractID = 9, Customer = customers[3], ContractStatusID = (int)ContractStatusEnum.UnableToPay }
            });*/
        }
    }
}
