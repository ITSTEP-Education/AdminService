using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using AdminService.BLL.Interfaces;
using AdminService.DAL.Entities;
using Asp.Versioning;
using System.Net;
using AdminService.DAL.Infrastructures;
using AutoMapper;
using AdminService.BLL.Services;

namespace AdminService.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AdministrateController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IClientDataService clientDataService;
        private readonly IClientOrderService clientOrderService;

        private readonly ILogger<AdministrateController> logger;

        public AdministrateController(ILogger<AdministrateController> logger,
            IOrderService orderService, IClientDataService clientDataService, IClientOrderService clientOrderService)
        {
            this.orderService = orderService;
            this.clientDataService = clientDataService;
            this.clientOrderService = clientOrderService;

            this.logger = logger;
        }

        //=======================HttpRequest of entity ProductOrder=======================//
        ///<include file='../DocXML/AdministrateControllerDoc.xml' path='docs/members[@name="controller"]/GetAllProductOrders/*'/>
        [MapToApiVersion("1.0")]
        [HttpGet("product-orders", Name = "GetProductOrders")]
        [ProducesResponseType(typeof(IEnumerable<ProductOrder>), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(StatusCode404), (int)HttpStatusCode.NotFound)]
        public ActionResult<IEnumerable<ProductOrder>> GetAllProductOrders()
        {
            try
            {
                return Ok(orderService.getAllOrders());
            }
            catch (StatusCode404 ex)
            {
                return NotFound(new { ex.code, ex.Message, ex.property });
            }
            catch (DbException ex)
            {
                return BadRequest(new { ex.ErrorCode, ex.Message, ex.Source });
            }
        }

        ///<include file='../DocXML/AdministrateControllerDoc.xml' path='docs/members[@name="controller"]/DeleteProductOrder/*'/>
        [MapToApiVersion("1.0")]
        [HttpDelete("product-order", Name = "DeleteProductOrder")]
        [ProducesResponseType(typeof(StatusCode201), (int)HttpStatusCode.Created)]
        public IActionResult DeleteProductOrder([FromQuery] string guid)
        {
            try
            {
                orderService.deleteOrder(guid);
                return Ok(new StatusCode201(guid));
            }
            catch (StatusCode404 ex)
            {
                return NotFound(new { ex.code, ex.Message, ex.property });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { code = 400, ex.Message, ex.ParamName });
            }
        }

        //=======================HttpRequest of entity ClientData=======================//

        ///<include file='../DocXML/AdministrateControllerDoc.xml' path='docs/members[@name="controller"]/GetClientData/*'/>
        [MapToApiVersion("2.0")]
        [HttpGet("client-data/{firstName}-{lastName}", Name = "GetClientData")]
        [ProducesResponseType(typeof(ClientData), (int)HttpStatusCode.OK)]
        public ActionResult<ClientData> GetClientData([FromRoute] string firstName, string lastName)
        {
            try
            {
                return Ok(clientDataService.getClientData($"{firstName}-{lastName}"));
            }
            catch (StatusCode404 ex)
            {
                return NotFound(new { ex.code, ex.Message, ex.property });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { code = 400, ex.Message, ex.ParamName });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.HResult, ex.Message, ex.InnerException });
            }
        }

        ///<include file='../DocXML/AdministrateControllerDoc.xml' path='docs/members[@name="controller"]/AddClientData/*'/>
        [MapToApiVersion("2.0")]
        [HttpPost("client-data", Name = "AddClientData")]
        [ProducesResponseType(typeof(StatusCode201), (int)HttpStatusCode.Created)]
        public IActionResult AddClientData([FromQuery] string guid, [FromBody] ClientData? clientData)
        {
            if (!ModelState.IsValid) return BadRequest("model is not valid");
            else if (clientData == null) return BadRequest("ClientData is null");

            try
            {
                ProductOrder productOrder = orderService.getProductOrder(guid);

                //mapping ProductOrder -> ClientOrder
                IMapper mapper = new MapperConfiguration(c => c.CreateMap<ProductOrder, ClientOrder>()).CreateMapper();
                var clientOrder = mapper.Map<ProductOrder, ClientOrder>(productOrder);

                //add to SQL DB two entities binded ClientData.HasOne.WithOne.ClientOrder
                ClientData tempClientData = new ClientData()
                {
                    firstName = clientData.firstName.ToLower(),
                    lastName = clientData.lastName.ToLower(),
                    age = Math.Abs(clientData.age),
                    mobile = clientData.mobile,
                };

                clientDataService.addClientData(tempClientData);

                ClientOrder tempClientOrder = new ClientOrder()
                {
                    name = clientOrder.name,
                    typeEngeeniring = clientOrder.typeEngeeniring,
                    timeStudy = clientOrder.timeStudy,
                    sumPay = clientOrder.sumPay,
                    clientData = tempClientData
                };

                clientOrderService.addClientOrder(tempClientOrder);

                return Ok(new StatusCode201($"{clientData?.firstName}-{clientData?.lastName}"));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { code = 400, ex.Message, ex.ParamName });
            }
            catch (SystemException ex)
            {
                return BadRequest(new { ex.HResult, ex.Message, ex.InnerException });
            }
        }

        ///<include file='../DocXML/AdministrateControllerDoc.xml' path='docs/members[@name="controller"]/DeleteClientData/*'/>
        [MapToApiVersion("2.0")]
        [HttpDelete("client-data/{firstName}-{lastName}", Name = "DeleteClientData")]
        [ProducesResponseType(typeof(StatusCode201), (int)HttpStatusCode.Created)]
        public IActionResult DeleteClientData([FromRoute] string firstName, string lastName)
        {
            try
            {
                clientDataService.deleteClientData($"{firstName}-{lastName}");
                return Ok(new StatusCode201($"{firstName}-{lastName}"));
            }
            catch (StatusCode404 ex)
            {
                return NotFound(new { ex.code, ex.Message, ex.property });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { code = 400, ex.Message, ex.ParamName });
            }
        }
    }
}
