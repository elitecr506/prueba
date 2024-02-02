using System;
namespace Ecommerce.SOS.Domain.Utils
{
	public static class EnvironmentManager
	{
        public static string GetEnvironmentValue(string variableName)
        {
            string? value = Environment.GetEnvironmentVariable(variableName);

            return !string.IsNullOrEmpty(value) ? value : string.Empty;
        }
    }
}

