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
    public class VotersController : ControllerBase
    {
        private IVoterService _voterService;

        public VotersController(IVoterService voterService)
        {
            _voterService = voterService;
        }
        [HttpGet]
        [Route("forgotPassword/{email}")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                var response = _voterService.ForgotPassword(email);
                if (response.Status)
                {
                    return Ok(new ApiResponse<Voters>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<Voters>()
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
        public IActionResult Login(Voters voters)
        {
            try
            {
                var response = _voterService.Login(voters);
                if (response.Status)
                {
                    return Ok(new ApiResponse<VotersListdata>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<VotersListdata>()
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
        public IActionResult Post(Voters voters)
        {
            try
            {
                var response = _voterService.Post(voters);
                if (response.Status)
                {
                    return Ok(new ApiResponse<Voters>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<Voters>()
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
        [Route("getAll/{size}/{skip}/{filter}")]
        public IActionResult GetAll(int size, int skip, string filter)
        {
            try
            {
                filter = filter == "0" ? "" : filter;
                var response = _voterService.GetAll(size, skip, filter);
                if (response.Status)
                {
                    return Ok(new ApiResponse<IEnumerable<VotersListdata>>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<VotersListdata>()
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
                var response = _voterService.Status(id);
                if (response.Status)
                {
                    return Ok(new ApiResponse<Voters>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<Voters>()
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
                var response = _voterService.Get(id);
                if (response.Status)
                {
                    return Ok(new ApiResponse<VotersListdata>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<VotersListdata>()
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
                var response = _voterService.ChangePassword(id, oldPassword, newPassword);
                if (response.Status)
                {
                    return Ok(new ApiResponse<VotersListdata>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<VotersListdata>()
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
        [Route("vote/{voterId}/{candidateId}/{electionId}")]
        public IActionResult Vote(int voterId, int candidateId, int electionId)
        {
            try
            {

                var response = _voterService.Vote(voterId, candidateId, electionId);
                if (response.Status)
                {
                    return Ok(new ApiResponse<VotersListdata>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<VotersListdata>()
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
        public IActionResult Put(int id,Voters voters)
        {

            try
            {
                var response = _voterService.Put(id,voters);
                if (response.Status)
                {
                    return Ok(new ApiResponse<Voters>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<Voters>()
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
