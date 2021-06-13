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
    
    public class CandidateController : ControllerBase
    {
        private ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }


        [HttpPost]
        public IActionResult Post(Candidates candidates)
        {
            try
            {
                var response = _candidateService.Post(candidates);
                if (response.Status)
                {
                    return Ok(new ApiResponse<Candidates>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<Candidates>()
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
        public IActionResult Put(Candidates candidates, int id)
        {
            try
            {
                var response = _candidateService.Put(candidates, id);
                if (response.Status)
                {
                    return Ok(new ApiResponse<Candidates>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<Candidates>()
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
                var response = _candidateService.Get(id);
                if (response.Status)
                {
                    return Ok(new ApiResponse<CandidatesData>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<CandidatesData>()
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

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var response = _candidateService.Delete(id);
                if (response.Status)
                {
                    return Ok(new ApiResponse<Candidates>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<Candidates>()
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
        [Route("getAll/{electionId}")]
        public IActionResult GetAll(int electionId)
        {
            try
            {
                var response = _candidateService.GetAll(electionId);
                if (response.Status)
                {
                    return Ok(new ApiResponse<IEnumerable<CandidatesData>>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<CandidatesData>()
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
                var response = _candidateService.Status(id);
                if (response.Status)
                {
                    return Ok(new ApiResponse<Candidates>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<Elections>()
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
