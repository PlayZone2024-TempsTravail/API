using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace PlayZone.Razor.Services;

public class RazorViewRendererService
{
    private string Directory { get; set; } = "";

    private readonly IRazorViewEngine _razorViewEngine;
    private readonly ITempDataProvider _tempDataProvider;
    private readonly IServiceProvider _serviceProvider;

    public RazorViewRendererService(
        IRazorViewEngine razorViewEngine,
        ITempDataProvider tempDataProvider,
        IServiceProvider serviceProvider
    )
    {
        this._razorViewEngine = razorViewEngine;
        this._tempDataProvider = tempDataProvider;
        this._serviceProvider = serviceProvider;
    }

    public async Task<string> RenderViewToStringAsync(string viewName, object model)
    {
        using IServiceScope scope = this._serviceProvider.CreateScope();

        DefaultHttpContext httpContext = new DefaultHttpContext { RequestServices = scope.ServiceProvider };
        ActionContext actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

        await using StringWriter stringWriter = new StringWriter();

        ViewEngineResult viewResult = this._razorViewEngine.GetView(this.Directory, viewName, false);

        if (viewResult.View == null)
        {
            throw new ArgumentNullException($"The view '{viewName}' was not found.");
        }

        ViewDataDictionary viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
        {
            Model = model
        };

        TempDataDictionary tempData = new TempDataDictionary(actionContext.HttpContext, this._tempDataProvider);

        ViewContext viewContext = new ViewContext(
            actionContext,
            viewResult.View,
            viewDictionary,
            tempData,
            stringWriter,
            new HtmlHelperOptions()
        );

        await viewResult.View.RenderAsync(viewContext);
        return stringWriter.ToString();
    }
}
