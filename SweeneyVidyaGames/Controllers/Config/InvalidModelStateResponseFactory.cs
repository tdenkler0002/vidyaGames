using System;
using Microsoft.AspNetCore.Mvc;
using SweeneyVidyaGames.Api.Extensions;
using SweeneyVidyaGames.Api.Resources;

namespace SweeneyVidyaGames.Api.Controllers.Config
{
    public class InvalidModelStateResponseFactory
    {
        public IActionResult ProduceErrorResponse(ActionContext context)
        {
            var errors = context.ModelState.GetErrorMessages();
            var response = new ErrorResource(messages: errors);

            return new BadRequestObjectResult(response);
        }
    }
}
