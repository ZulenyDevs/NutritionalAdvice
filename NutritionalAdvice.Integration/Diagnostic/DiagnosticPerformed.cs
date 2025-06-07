using Joseco.Communication.External.Contracts.Message;

namespace NutritionalAdvice.Integration.MealPlan
{
	public record DiagnosticPerformed : IntegrationMessage
	{
		public Guid DiagnosticId { get; set; }
		public string DiagnosticDescription { get; set; } = string.Empty;
		public Guid PatientId { get; private set; }

		public DiagnosticPerformed(Guid id, string descripcion, Guid pacienteId, string? correlationId = null, string? source = null)
			: base(correlationId, source)
		{
			DiagnosticId = id;
			DiagnosticDescription = descripcion;
			PatientId = pacienteId;
		}
	}
}
