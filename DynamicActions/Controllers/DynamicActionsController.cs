using DynamicActions.Interfaces;
using DynamicActions.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NCalc;
using System.ComponentModel.DataAnnotations;

namespace DynamicActions.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DynamicActionsController : Controller
    {
        private readonly IDynamicActionService _service;

        public DynamicActionsController(IDynamicActionService service)
        {
            _service = service;
        }

        /// <summary>
        /// Create Dynamic Action
        /// </summary>
        /// <returns></returns>
        [HttpPost("~/api/DynamicActions")]
        public async Task<ActionResult<DynamicActionLogicModel>> Create(DynamicActionCreateLogicModel model)
        {
            try
            {
                return Ok(await _service.Add(model));
            }
            catch (ValidationException exp)
            {
                return BadRequest(exp.Message);
            }
        }

        /// <summary>
        /// Get Dynamic Actions
        /// </summary>
        /// <returns></returns>
        [HttpGet("~/api/DynamicActions")]
        public async Task<ActionResult<DynamicActionLogicModel>> Get()
        {
            return Ok(await _service.GetAvailableActions());
        }

        /// <summary>
        /// Get Dynamic Actions
        /// </summary>
        /// <returns></returns>
        [HttpGet("~/api/DynamicActions/History")]
        public async Task<ActionResult<DynamicActionHistoryLogicModel>> History([FromQuery] int dynamicActionId)
        {
            return Ok(await _service.History(dynamicActionId));
        }

        /// <summary>
        /// Calculate Dynamic Action
        /// </summary>
        /// <returns></returns>
        [HttpPost("~/api/DynamicActions/Calculate")]
        public async Task<ActionResult<DynamicActionCalculateResultLogicModel>> Calculate(DynamicActionCalculateLogicModel model)
        {
            try
            {
                return Ok(await _service.Calculate(model));
            }
            catch (ValidationException exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}