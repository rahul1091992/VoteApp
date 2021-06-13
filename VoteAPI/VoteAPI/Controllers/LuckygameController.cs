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
    

    public class LuckygameController : ControllerBase
    {
        private ILuckygameService _luckygameService;

        public LuckygameController(ILuckygameService luckygameService)
        {
            _luckygameService = luckygameService;
        }

        [HttpPost]
        public IActionResult Post(LuckydrawGameData luckydrawGameData)
        {
            try
            {
                var response = _luckygameService.Post(luckydrawGameData);
                if (response.Status)
                {
                    return Ok(new ApiResponse<LuckydrawGame>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<LuckydrawGame>()
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

                var response = _luckygameService.GetAll();
                if (response.Status)
                {
                    return Ok(new ApiResponse<IEnumerable<LuckydrawGameCls>>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<LuckydrawGameCls>()
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
                var response = _luckygameService.Delete(id);
                if (response.Status)
                {
                    return Ok(new ApiResponse<LuckydrawGame>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<LuckydrawGame>()
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
                var response = _luckygameService.Get(id);
                if (response.Status)
                {
                    return Ok(new ApiResponse<LuckydrawGameCls>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                        Data = response.Data
                    });
                }
                else
                {
                    return Ok(new ApiResponse<LuckydrawGameCls>()
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
        public IActionResult Put(int id, LuckydrawGameData luckydrawGameData)
        {

            try
            {
                var response = _luckygameService.Put(id, luckydrawGameData);
                if (response.Status)
                {
                    return Ok(new ApiResponse<LuckydrawGame>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<LuckydrawGame>()
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
        [Route("getAllPrize/{gameId}")]
        public IActionResult GetAllPrize(int gameId)
        {
            try
            {

                var response = _luckygameService.GetAllPrize(gameId);
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

        [HttpGet]
        [Route("getAllUsers/{gameId}")]
        public IActionResult GetAllUsers(int gameId)
        {
            try
            {

                var response = _luckygameService.GetAllUsers(gameId);
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
        [Route("getPlayersPrize/{userId}/{gameId}")]
        public IActionResult GetPlayersPrize(int UserId, int GameId)
        {
            try
            {

                var response = _luckygameService.GetPlayersPrize(UserId, GameId);
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

        [HttpGet]
        [Route("giveChance/{userId}/{gameId}")]
        public IActionResult GiveChance(int UserId, int GameId)
        {
            try
            {

                var response = _luckygameService.GiveChance(UserId, GameId);
                if (response.Status)
                {
                    return Ok(new ApiResponse<LuckydrawGame>()
                    {
                        Status = response.Status,
                        Message = response.Message,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<LuckydrawGame>()
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
        [Route("playGame/{userId}/{gameId}")]
        public IActionResult PlayGame(int UserId, int GameId)
        {
            try
            {

                var response = _luckygameService.PlayGame(UserId, GameId);
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

        [HttpGet]
        [Route("saveWinPrize/{userId}/{gameId}/{prizeId}")]
        public IActionResult SaveWinPrize(int UserId, int GameId, int PrizeId)
        {
            try
            {

                var response = _luckygameService.SaveWinPrize(UserId, GameId, PrizeId);
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
    }
}
