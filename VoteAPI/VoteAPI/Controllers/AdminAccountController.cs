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

    public class AdminAccountController : ControllerBase
    {
        private IAdminAccountService _adminAccountService;
        public AdminAccountController(IAdminAccountService adminAccountService)
        {
            _adminAccountService = adminAccountService;
        }

        [HttpGet]
        [Route("forgotPassword/{email}")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                var response = _adminAccountService.ForgotPassword(email);
                if (response.Status)
                {
                    return Ok(new ApiResponse<AdminUsers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<AdminUsers>()
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
        public IActionResult Register(AdminUsers adminUsers)
        {
            try
            {
                var response = _adminAccountService.Register(adminUsers);
                if (response.Status)
                {
                    return Ok(new ApiResponse<AdminUsers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<AdminUsers>()
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
        public IActionResult Login(AdminUsers adminUsers)
        {
            try
            {
                var response = _adminAccountService.Login(adminUsers);
                if (response.Status)
                {
                    return Ok(new ApiResponse<AdminUsers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<AdminUsers>()
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
        [Route("getProfile/{userId}")]
        public IActionResult GetProfile(int userId)
        {
            try
            {
                var response = _adminAccountService.GetProfile(userId);
                if (response.Status)
                {
                    return Ok(new ApiResponse<AdminUsers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<AdminUsers>()
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
        public IActionResult UpdateProfile(AdminUsers adminUsers)
        {
            try
            {
                var response = _adminAccountService.UpdateProfile(adminUsers);
                if (response.Status)
                {
                    return Ok(new ApiResponse<AdminUsers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<AdminUsers>()
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
        [Route("changePassword")]
        public IActionResult ChangePassword(ChangePasswordModel changePasswordModel)
        {
            try
            {
                var response = _adminAccountService.ChangePassword(changePasswordModel);
                if (response.Status)
                {
                    return Ok(new ApiResponse<AdminUsers>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<AdminUsers>()
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
        [Route("dashboard")]
        public IActionResult Dashboard()
        {
            try
            {
                var response = _adminAccountService.Dashboard();
                if (response.Status)
                {
                    return Ok(new ApiResponse<DashboardData>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<DashboardData>()
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
