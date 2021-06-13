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
    public class UCustomerController : ControllerBase
    {
        private IUCustomerService _uCustomerService;
        public UCustomerController(IUCustomerService uCustomerService)
        {
            _uCustomerService = uCustomerService;
        }


        [HttpPost]
        [Route("authentication")]
        public IActionResult Authentication(UCustomers uCustomers)
        {
            try
            {
                var response = _uCustomerService.Authentication(uCustomers);
                if (response.Status)
                {
                    return Ok(new ApiResponse<UCustomers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<UCustomers>()
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
        [Route("resendOtp")]
        public IActionResult ResendOtp(UCustomers uCustomers)
        {
            try
            {
                var response = _uCustomerService.ResendOtp(uCustomers);
                if (response.Status)
                {
                    return Ok(new ApiResponse<UCustomers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<UCustomers>()
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
        [Route("verifyOtp")]
        public IActionResult VerifyOtp(UCustomers uCustomers)
        {
            try
            {
                var response = _uCustomerService.VerifyOtp(uCustomers);
                if (response.Status)
                {
                    return Ok(new ApiResponse<UCustomers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<UCustomers>()
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
        public IActionResult GetProfile(int id)
        {
            try
            {
                var response = _uCustomerService.GetProfile(id);
                if (response.Status)
                {
                    return Ok(new ApiResponse<UCustomers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<UCustomers>()
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
        [Route("updateProfile")]
        public IActionResult UpdateProfile(UCustomers uCustomers)
        {
            try
            {
                var response = _uCustomerService.UpdateProfile(uCustomers);
                if (response.Status)
                {
                    return Ok(new ApiResponse<UCustomers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<UCustomers>()
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
        [Route("postOrder")]
        public IActionResult PostOrder(UOrders uOrders)
        {
            try
            {
                var response = _uCustomerService.PostOrder(uOrders);
                if (response.Status)
                {
                    return Ok(new ApiResponse<UCustomers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<UCustomers>()
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
        [Route("getOrder/{id}")]
        public IActionResult GetOrder(int id)
        {
            try
            {
                var response = _uCustomerService.GetOrder(id);
                if (response.Status)
                {
                    return Ok(new ApiResponse<IEnumerable<UOrdersCustomer>>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<UOrdersCustomer>()
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
                var response = _uCustomerService.GetOrderDetail(id);
                if (response.Status)
                {
                    return Ok(new ApiResponse<UOrdersCustomer>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<UOrdersCustomer>()
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
        [Route("deleteOrder/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            try
            {
                var response = _uCustomerService.DeleteOrder(id);
                if (response.Status)
                {
                    return Ok(new ApiResponse<UOrdersCustomer>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<UOrdersCustomer>()
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
