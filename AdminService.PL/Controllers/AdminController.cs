using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using AdminService.BLL.Interfaces;
using AdminService.DAL.Entities;
using AdminService.BLL.Infrastructures;

namespace AdminService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EducationController : ControllerBase
    {
        private readonly IOrderService orderServ;
        private readonly ILogger<EducationController> logger;

        public EducationController(IOrderService orderService, ILogger<EducationController> logger)
        {
            this.orderServ = orderService;
            this.logger = logger;
        }

        [HttpGet("product-orders", Name = "GetProductOrders")]
        public ActionResult<IEnumerable<ProductOrder>> getAllProductOrders()
        {
            try
            {
                return Ok(orderServ.getAllOrders());
            }
            catch (AdminServiceException ex)
            {
                return NotFound(new { msg = ex.Message, prop = ex.property });
            }
            catch (DbException ex)
            {
                return BadRequest(new { msg = ex.Message, prop = ex.SqlState });
            }
        }
    }
}
