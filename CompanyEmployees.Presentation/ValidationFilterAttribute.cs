using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CompanyEmployees.Presentation
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];
            var param = context.ActionDescriptor.Parameters.SingleOrDefault(x => x.ParameterType.Name.ToString().Contains("Dto"));
            if (param is null)
            {
                if (!context.ModelState.ContainsKey(param.Name))
                {
                    context.Result = new BadRequestObjectResult(
                        $"DTO object is required. Controller: {controller}, action: {action}, parameter: {param.Name}");
                }
                return;
            }
            if (!context.ModelState.IsValid)
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //throw new NotImplementedException();
        }
    }
}
