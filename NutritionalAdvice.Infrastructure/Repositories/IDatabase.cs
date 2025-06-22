using System;

namespace NutritionalAdvice.Infrastructure.Repositories
{
	public interface IDatabase : IDisposable
	{
		void Migrate();
	}
}
