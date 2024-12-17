using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Radzen.Blazor;

public interface IRadzenIcon
{
    RenderFragment RenderIcon(string style, string cssClass, string id, IEnumerable<KeyValuePair<string, object>> attributes);
}
