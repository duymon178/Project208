using Microsoft.AspNetCore.Mvc;
using Project208.Services.Abstract;
using System.Threading.Tasks;
using Project208.Services.DTOs.ContractsInfoDTOs;

namespace Project208.WebUI.Controllers.APIs
{
    [Route("api/[controller]")]
    public class ContractsController : Controller
    {
        private readonly ICommonContractService commonService;
        private readonly IT1ContractService t1Service;
        private readonly IT2ContractService t2Service;

        public ContractsController(ICommonContractService commonServiceParam, IT1ContractService t1ServiceParam,
            IT2ContractService t2ServiceParam)
        {
            commonService = commonServiceParam;
            t1Service     = t1ServiceParam;
            t2Service     = t2ServiceParam;
        }

        // GET: api/contracts/info/?getTotal=false
        // Only HTTP method and optional segments are used to differentiate between action methods.
        // The name of the action method isn't part of the URL required to target specific method.
        [HttpGet("info")]
        public async Task<IActionResult> GetContractsInfo(bool getTotal)
        {
            ContractsInfoDTO contractsInfo = new ContractsInfoDTO
            {
                DailyInfo = await commonService.GetDailyInfoAsync()
            };

            if (getTotal)
                contractsInfo.TotalInfo = await commonService.GetTotalInfoAsync();

            return Ok(contractsInfo);
        }

        // GET: api/contracts/?locationId=1&contractType=1&contractStatusId=1&isDaily=false&searchString=
        [HttpGet]
        public async Task<IActionResult> GetContractsByFilterData(int locationId, int contractType, int contractStatusId, bool isDaily, string searchString)
        {
            var contracts = await commonService.GetContractsByFilterDataAsync(locationId, contractType, contractStatusId, isDaily, searchString);

            if (contracts != null)
                return Ok(contracts);

            return NotFound("Không tìm thấy danh sách bát họ/khoản nóng.");
        }

        // GET: api/contracts/customer/?customerId=1
        [HttpGet("customer")]
        public async Task<IActionResult> GetContractsByCustomerId(int customerId)
        {
            var contracts = await commonService.GetContractsByCustomerIdAsync(customerId);

            if (contracts != null)
                return Ok(contracts);

            return NotFound($"Không tìm thấy danh sách bát họ/khoản nóng của khách hàng có mã KH: {customerId}.");
        }
    }
}