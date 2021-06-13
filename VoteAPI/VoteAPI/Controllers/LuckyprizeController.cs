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
   
    public class LuckyprizeController : ControllerBase
    {
        private ILuckyprizeService _luckyprizeService;

        public LuckyprizeController(ILuckyprizeService luckyprizeService)
        {
            _luckyprizeService = luckyprizeService;
        }
        
        [HttpPost]
        public IActionResult Post(LuckydrawPrize luckydrawPrize)
        {
            try
            {
                var response = _luckyprizeService.Post(luckydrawPrize);
                if (response.Status)
                {
                    return Ok(new ApiResponse<LuckydrawPrize>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<LuckydrawPrize>()
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

                var response = _luckyprizeService.GetAll();
                if (response.Status)
                {
                    return Ok(new ApiResponse<IEnumerable<LuckydrawPrizeData>>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<LuckydrawPrizeData>()
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
                var response = _luckyprizeService.Delete(id);
                if (response.Status)
                {
                    return Ok(new ApiResponse<LuckydrawPrize>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<LuckydrawPrize>()
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
                var response = _luckyprizeService.Get(id);
                if (response.Status)
                {
                    return Ok(new ApiResponse<LuckydrawPrizeData>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<LuckydrawPrizeData>()
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
        public IActionResult Put(int id, LuckydrawPrize luckydrawPrize)
        {

            try
            {
                var response = _luckyprizeService.Put(id, luckydrawPrize);
                if (response.Status)
                {
                    return Ok(new ApiResponse<LuckydrawPrize>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<LuckydrawPrize>()
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
