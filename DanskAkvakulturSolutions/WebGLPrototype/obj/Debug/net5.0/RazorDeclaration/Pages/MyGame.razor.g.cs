// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace WebGLPrototype.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "F:\Projects\github_repos\hovedforlob\h6\Fisk-DanskAkvakultur\DanskAkvakulturSolutions\WebGLPrototype\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Projects\github_repos\hovedforlob\h6\Fisk-DanskAkvakultur\DanskAkvakulturSolutions\WebGLPrototype\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\Projects\github_repos\hovedforlob\h6\Fisk-DanskAkvakultur\DanskAkvakulturSolutions\WebGLPrototype\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\Projects\github_repos\hovedforlob\h6\Fisk-DanskAkvakultur\DanskAkvakulturSolutions\WebGLPrototype\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\Projects\github_repos\hovedforlob\h6\Fisk-DanskAkvakultur\DanskAkvakulturSolutions\WebGLPrototype\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\Projects\github_repos\hovedforlob\h6\Fisk-DanskAkvakultur\DanskAkvakulturSolutions\WebGLPrototype\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "F:\Projects\github_repos\hovedforlob\h6\Fisk-DanskAkvakultur\DanskAkvakulturSolutions\WebGLPrototype\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "F:\Projects\github_repos\hovedforlob\h6\Fisk-DanskAkvakultur\DanskAkvakulturSolutions\WebGLPrototype\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "F:\Projects\github_repos\hovedforlob\h6\Fisk-DanskAkvakultur\DanskAkvakulturSolutions\WebGLPrototype\_Imports.razor"
using WebGLPrototype;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "F:\Projects\github_repos\hovedforlob\h6\Fisk-DanskAkvakultur\DanskAkvakulturSolutions\WebGLPrototype\_Imports.razor"
using WebGLPrototype.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/my-game")]
    public partial class MyGame : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 21 "F:\Projects\github_repos\hovedforlob\h6\Fisk-DanskAkvakultur\DanskAkvakulturSolutions\WebGLPrototype\Pages\MyGame.razor"
       
    [Inject] IJSRuntime JS { get; set; }
    string message;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            try
            {
                await JS.InvokeVoidAsync("initializeUnityInstance", "libs/MyGame/Build/game proto.json", "{onProgress: UnityProgress}");
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }
    }

    private async Task SetFullscreen(int isFullscreen)
    {
        await JS.InvokeVoidAsync("setFullscreen", isFullscreen);
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591