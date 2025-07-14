namespace si730ebuu20220659.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using  Microsoft.AspNetCore.Mvc.ModelBinding;

public static class ModelStateExtensions
{
    public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
    {
        return dictionary
            .SelectMany(m => m.Value!.Errors)
            .Select(m => m.ErrorMessage)
            .ToList();
    }
}