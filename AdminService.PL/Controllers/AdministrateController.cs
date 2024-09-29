using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using AdminService.BLL.Interfaces;
using AdminService.DAL.Entities;
using AdminService.BLL.Infrastructures;
using Asp.Versioning;
using System.Net;
using AdminService.DAL.Infrastructures;

namespace AdminService.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class AdministrateController : ControllerBase
    {
        private readonly IOrderService orderServ;
        private readonly ILogger<AdministrateController> logger;

        public AdministrateController(IOrderService orderService, ILogger<AdministrateController> logger)
        {
            this.orderServ = orderService;
            this.logger = logger;
        }

        ///<include file='../DocXML/AdministrateControllerDoc.xml' path='docs/members[@name="controller"]/GetAllProductOrders/*'/>
        [MapToApiVersion("1.0")]
        [HttpGet("product-orders", Name = "GetProductOrders")]
        [ProducesResponseType(typeof(IEnumerable<ProductOrder>), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(StatusCode404), (int)HttpStatusCode.NotFound)]
        public ActionResult<IEnumerable<ProductOrder>> GetAllProductOrders()
        {
            try
            {
                return Ok(orderServ.getAllOrders());
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
                orderServ.deleteOrder(guid);
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
    }
}
