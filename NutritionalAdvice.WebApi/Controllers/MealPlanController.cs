using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NutritionalAdvice.Application.MealPlans.CreateMealPlan;
using NutritionalAdvice.Application.MealPlans.GetMealPlans;
using Sentry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionalAdvice.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MealPlanController : ControllerBase
	{
		private readonly IMediator _mediator;

		public MealPlanController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<ActionResult> CreateItem([FromBody] CreateMealPlanCommand command)
		{
			try
			{
				var id = await _mediator.Send(command);

				return Ok(id);

			}
			catch (Exception ex)
			{
				SentrySdk.CaptureException(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpGet]
		public async Task<ActionResult> GetItems()
		{
			try
			{
				var result = await _mediator.Send(new GetMealPlansQuery(""));
				return Ok(result);
			}
			catch (Exception ex)
			{
				SentrySdk.CaptureException(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
	}
}
