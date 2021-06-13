using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vote.Model;
using Vote.Model.Models;
using Vote.Service.Abstraction;

namespace VoteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UDriverController : ControllerBase
    {
        private IUDriverService _uDriverService;

        public UDriverController(IUDriverService uDriverService)
        {
            _uDriverService = uDriverService;
        }
        [HttpGet]
        [Route("forgotPassword/{email}")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                var response = _uDriverService.ForgotPassword(email);
                if (response.Status)
                {
                    return Ok(new ApiResponse<UDrivers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<UDrivers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(UDrivers uDrivers)
        {
            try
            {
                var response = _uDriverService.Login(uDrivers);
                if (response.Status)
                {
                    return Ok(new ApiResponse<UDrivers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<UDrivers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(UDrivers uDrivers)
        {
            try
            {
                var response = _uDriverService.Register(uDrivers);
                if (response.Status)
                {
                    return Ok(new ApiResponse<UDrivers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<UDrivers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("updateLocation")]
        public IActionResult UpdateLocation(UDrivers uDrivers)
        {
            try
            {
                var response = _uDriverService.UpdateLocation(uDrivers);
                if (response.Status)
                {
                    return Ok(new ApiResponse<UDrivers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<UDrivers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var response = _uDriverService.Get(id);
                if (response.Status)
                {
                    return Ok(new ApiResponse<UDrivers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data

                    });
                }
                else
                {
                    return Ok(new ApiResponse<UDrivers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                var response = _uDriverService.GetAll();
                if (response.Status)
                {
                    return Ok(new ApiResponse<IEnumerable<UDrivers>>()
                    {
                        Status = response.Status,
                        Message = response.Message,Data= response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<UDrivers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }




        [HttpGet]
        [Route("getOrder/{id}/{size}/{skip}")]
        public IActionResult GetOrder(int id, int size, int skip)
        {
            try
            {
                var response = _uDriverService.GetOrder(id,   size,   skip);
                if (response.Status)
                {
                    return Ok(new ApiResponse<IEnumerable<UOrdersDriver>>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<UOrdersDriver>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("getOrderDetail/{id}")]
        public IActionResult GetOrderDetail(int id)
        {
            try
            {
                var response = _uDriverService.GetOrderDetail(id);
                if (response.Status)
                {
                    return Ok(new ApiResponse<UOrdersDriver>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<UOrdersDriver>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }




        [HttpGet]
        [Route("getAllProduct")]
        public IActionResult GetAllProduct()
        {
            try
            {
                var response = _uDriverService.GetAllProduct();
                if (response.Status)
                {
                    return Ok(new ApiResponseData<IEnumerable<UProduct>>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        TotalProduct=response.TotalProduct,
                        ProductName = response.ProductName,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponseData<UProduct>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("notification")]
        public IActionResult Notification(UDrivers uDrivers)
        {
            try
            {
                var response = _uDriverService.Notification(uDrivers);
                if (response.Status)
                {
                    return Ok(new ApiResponse<UDrivers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<UDrivers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }


        [HttpGet]
        [Route("getAllBProduct")]
        public IActionResult GetAllBProduct()
        {
            try
            {
                var response = _uDriverService.GetAllBProduct();
                if (response.Status)
                {
                    return Ok(new ApiResponse<IEnumerable<UBProductData>>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<UBProductData>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }


        [HttpPost]
        [Route("saveCollection")]
        public IActionResult SaveCollection(UBProduct uBProduct)
        {
            try
            {
                var response = _uDriverService.SaveCollection(uBProduct);
                if (response.Status)
                {
                    return Ok(new ApiResponse<UDrivers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<UDrivers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }


        [HttpPost]
        [Route("saveProduct")]
        public IActionResult SaveProduct(UBProductSave uBProductSave)
        {
            try
            {
                var response = _uDriverService.SaveProduct(uBProductSave);
                if (response.Status)
                {
                    return Ok(new ApiResponse<UDrivers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<UDrivers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }
    }
}
