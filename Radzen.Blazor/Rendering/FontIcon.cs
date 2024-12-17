using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Radzen.Blazor.Rendering;

public class FontIcon : IRadzenIcon
{
    public string Icon { get; }

    public FontIcon(string icon)
    {
        Icon = icon;
    }

    public RenderFragment RenderIcon(string style, string cssClass, string id, IEnumerable<KeyValuePair<string, object>> attributes) => builder =>
        {
            builder.OpenElement(1, "i");
            builder.AddAttribute(2, "style", style);
            builder.AddAttribute(3, "class", cssClass);
            builder.AddAttribute(4, "id", id);
            builder.AddMultipleAttributes(5, attributes);
            builder.AddMarkupContent(6, Icon);
            builder.CloseElement();
        };
}
