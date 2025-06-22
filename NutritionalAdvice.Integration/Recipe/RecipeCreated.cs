using Joseco.Communication.External.Contracts.Message;

namespace NutritionalAdvice.Integration.Recipe
{
	public record RecipeCreated : IntegrationMessage
	{
		public Guid RecipeId { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;

		public RecipeCreated(Guid recipeId, string name, string description, string? correlationId = null, string? source = null)
			: base(correlationId, source)
		{
			RecipeId = recipeId;
			Name = name;
			Description = description;
		}
	
	}
}
