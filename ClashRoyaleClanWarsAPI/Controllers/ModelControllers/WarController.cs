﻿using AutoMapper;
using ClashRoyaleClanWarsAPI.Dtos.WarDto;
using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;
using ClashRoyaleClanWarsAPI.Services;
using ClashRoyaleClanWarsAPI.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClashRoyaleClanWarsAPI.Controllers.ModelControllers
{
    [Route("api/wars")]
    [ApiController]
    public class WarController : ControllerBase
    {
        private readonly IWarService _warService;
        private readonly IMapper _mapper;

        public WarController(IWarService warService, IMapper mapper) 
        {
            _warService = warService;
            _mapper = mapper;
        }
        // GET: api/wars
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<WarModel>? wars = null;
            try
            {
                wars = await _warService.GetAllAsync();
            }
            catch (ModelNotFoundException<WarModel> e)
            {
                return NotFound(new RequestResponse<WarModel>(message: e.Message, success: false));
            }

            return Ok(new RequestResponse<IEnumerable<WarModel>>(wars!));
        }

        // GET api/wars/{warId:int}
        [HttpGet("{warId:int}")]
        public async Task<IActionResult> Get(int warId)
        {
            WarModel? war = null;

            try
            {
                war = await _warService.GetSingleByIdAsync(warId);
            }
            catch (ModelNotFoundException<WarModel> e)
            {
                return NotFound(new RequestResponse<WarModel>(message: e.Message, success: false));
            }
            catch (IdNotFoundException<WarModel> e)
            {
                return NotFound(new RequestResponse<WarModel>(message: e.Message, success: false));
            }

            return Ok(new RequestResponse<WarModel>(war!));
        }

        // POST api/wars
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddWarDto warDto)
        {
            WarModel war = _mapper.Map<WarModel>(warDto);

            try
            {
                await _warService.Add(war);
            }
            catch (ModelNotFoundException<WarModel> e)
            {
                return NotFound(new RequestResponse<WarModel>(message: e.Message, success: false));
            }

            return Created($"api/wars/{war.Id}", new RequestResponse<WarModel>(data: war, message: "War created", success: true));
        }

        // DELETE api/wars/{warId:int}
        [HttpDelete("{warId:int}")]
        public async Task<IActionResult> Delete(int warId)
        {
            try
            {
                await _warService.Delete(warId);
            }
            catch (ModelNotFoundException<WarModel> e)
            {
                return NotFound(new RequestResponse<WarModel>(message: e.Message, success: false));
            }
            catch (IdNotFoundException<WarModel> e)
            {
                return NotFound(new RequestResponse<WarModel>(message: e.Message, success: false));
            }

            return NoContent();
        }

        // GET: api/wars/date/{date:DateTime}
        [HttpGet("date/{date:DateTime}")]
        public async Task<IActionResult> GetUpCommingWars(DateTime date)
        {
            IEnumerable<WarModel>? wars = null;
            try
            {
                wars = await _warService.GetWarsByDate(date);
            }
            catch (ModelNotFoundException<WarModel> e)
            {
                return NotFound(new RequestResponse<WarModel>(message: e.Message, success: false));
            }

            return Ok(new RequestResponse<IEnumerable<WarModel>>(wars!));
        }
    }
}