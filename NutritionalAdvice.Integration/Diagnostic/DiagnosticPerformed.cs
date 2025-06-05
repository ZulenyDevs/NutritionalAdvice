using Joseco.Communication.External.Contracts.Message;

namespace NutritionalAdvice.Integration.MealPlan
{
	public record DiagnosticPerformed : IntegrationMessage
	{
		public Guid DiagnosticId { get; set; }
		public Guid PatientId { get; private set; }
		public string PatientName { get; set; } = string.Empty;

		public DiagnosticPerformed(Guid diagnosticId, Guid patientId, string patientName, string? correlationId = null, string? source = null)
			: base(correlationId, source)
		{
			DiagnosticId = diagnosticId;
			PatientId = patientId;
			PatientName = patientName;
		}
	}
}
