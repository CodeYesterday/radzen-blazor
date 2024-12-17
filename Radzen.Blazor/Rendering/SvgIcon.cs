using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using Microsoft.AspNetCore.Components;

namespace Radzen.Blazor.Rendering;

public class SvgIcon : IRadzenIcon
{
    private string? _svgData;

    public Assembly RessourecAssembly { get; init; }

    public string ResourceName { get; init; }

    internal string GetSvgData()
    {
        if (_svgData == null)
        {
            using var stream = RessourecAssembly.GetManifestResourceStream(ResourceName);
            if (stream == null) throw new InvalidOperationException($"Could not load svg icon resource {ResourceName}");

            using var reader = new StreamReader(stream, System.Text.Encoding.UTF8);
            var xSvg = XElement.Parse(reader.ReadToEnd());

            // Set `style="fill:currentColor;"`. This will be used by all elements that do not explicitly set `style="fill:x;"`.
            var svgStyle = (string?)xSvg.Attribute("style") ?? string.Empty;
            if (svgStyle.Length > 0 && !svgStyle.EndsWith(";"))
            {
                svgStyle += ";";
            }

            svgStyle += "fill:currentColor;";

            xSvg.SetAttributeValue("style", svgStyle);

            // Remove `width` and set `height="100%"` to match the parent height constraints
            xSvg.SetAttributeValue("width", null);
            xSvg.SetAttributeValue("height", "100%");
            // TODO: have some handling for non-quadratic svg's to be rendered nicely.

            // Only `style="fill:x;"` will overwrite the svg `style="fill:x;"`. The `fill` attribute will have no effect.
            // TODO: Recursively walk through all elements and replace the attribute `fill="x"` with `style="fill:x;"`

            _svgData = xSvg.ToString(SaveOptions.OmitDuplicateNamespaces);
        }

        return _svgData;
    }

    public RenderFragment RenderIcon(string style, string cssClass, string id, IEnumerable<KeyValuePair<string, object>> attributes) => builder =>
        {
            builder.OpenElement(1, "span");
            builder.AddAttribute(2, "style", "font-family: initial; display: inline-block; height: 1em; " + style);
            builder.AddAttribute(3, "class", cssClass);
            builder.AddAttribute(4, "id", id);
            builder.AddMultipleAttributes(5, attributes);
            builder.AddMarkupContent(6, GetSvgData());
            builder.CloseElement();
        };
}
