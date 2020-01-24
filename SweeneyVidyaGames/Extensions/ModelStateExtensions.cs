using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SweeneyVidyaGames.Api.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            return dictionary.SelectMany(mn => mn.Value.Errors)
                .Select(mn => mn.ErrorMessage)
                .ToList();
        }
    }
}
