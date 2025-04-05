using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NutritionalAdvice.Application.Recipes.CreateRecipe;
using NutritionalAdvice.Application.Recipes.GetRecipeById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionalAdvice.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RecipeController : ControllerBase
	{
		private readonly IMediator _mediator;

		public RecipeController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<ActionResult> CreateRecipe([FromBody] CreateRecipeCommand command)
		{
			try
			{
				var id = await _mediator.Send(command);

				return Ok(id);

			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpGet]
		public async Task<ActionResult> GetRecipeById([FromQuery] GetRecipeByIdQuery query)
		{
			try
			{
				var result = await _mediator.Send(new GetRecipeByIdQuery(query.Id));
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
	}
}
