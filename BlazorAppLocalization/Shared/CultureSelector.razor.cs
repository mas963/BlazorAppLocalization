using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System.Globalization;

namespace BlazorAppLocalization.Shared;

public partial class CultureSelector
{
    [Inject]
    public NavigationManager NavManager { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    CultureInfo[] cultures = new[]
    {
        new CultureInfo("tr-TR"),
        new CultureInfo("en-US"),
    };

    CultureInfo Culture
    {
        get => CultureInfo.CurrentCulture;
        set
        {
            if (CultureInfo.CurrentCulture != value)
            {
                var js = (IJSInProcessRuntime)JSRuntime;
                js.InvokeVoid("blazorCulture.set", value.Name);

                NavManager.NavigateTo(NavManager.Uri, forceLoad: true);
            }
        }
    }
}
