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
    public class LuckyController : ControllerBase
    {
        private ILuckyService _luckyService;

        public LuckyController(ILuckyService luckyService)
        {
            _luckyService = luckyService;
        }
        [HttpGet]
        [Route("forgotPassword/{email}")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                var response = _luckyService.ForgotPassword(email);
                if (response.Status)
                {
                    return Ok(new ApiResponse<LuckydrawUser>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<LuckydrawUser>()
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
        public IActionResult Login(LuckydrawUser luckydrawUser)
        {
            try
            {
                var response = _luckyService.Login(luckydrawUser);
                if (response.Status)
                {
                    return Ok(new ApiResponse<LuckydrawUser>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<LuckydrawUser>()
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
        public IActionResult Post(LuckydrawUser luckydrawUser)
        {
            try
            {
                var response = _luckyService.Post(luckydrawUser);
                if (response.Status)
                {
                    return Ok(new ApiResponse<LuckydrawUser>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                      //  Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<LuckydrawUser>()
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
               
                var response = _luckyService.GetAll();
                if (response.Status)
                {
                    return Ok(new ApiResponse<IEnumerable<LuckydrawUser>>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<LuckydrawUser>()
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
                var response = _luckyService.Get(id);
                if (response.Status)
                {
                    return Ok(new ApiResponse<LuckydrawUser>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<LuckydrawUser>()
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
        [Route("changePassword/{id}/{oldPassword}/{newPassword}")]
        public IActionResult ChangePassword(int id, string oldPassword, string newPassword)
        {
            try
            {
                var response = _luckyService.ChangePassword(id, oldPassword, newPassword);
                if (response.Status)
                {
                    return Ok(new ApiResponse<LuckydrawUser>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<LuckydrawUser>()
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


        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, LuckydrawUser luckydrawUser)
        {

            try
            {
                var response = _luckyService.Put(id, luckydrawUser);
                if (response.Status)
                {
                    return Ok(new ApiResponse<LuckydrawUser>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<LuckydrawUser>()
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
        [Route("status/{id}")]
        public IActionResult Status(int id)
        {
            try
            {
                var response = _luckyService.Status(id);
                if (response.Status)
                {
                    return Ok(new ApiResponse<LuckydrawUser>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<LuckydrawUser>()
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
        [Route("adminStatus/{id}")]
        public IActionResult AdminStatus(int id)
        {
            try
            {
                var response = _luckyService.AdminStatus(id);
                if (response.Status)
                {
                    return Ok(new ApiResponse<LuckydrawUser>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<LuckydrawUser>()
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
