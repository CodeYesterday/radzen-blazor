using Radzen.Blazor;
using Radzen.Blazor.Rendering;

namespace Radzen.Blazor;

public static class MeterialIcons
{
    public static IRadzenIcon Search { get; } = new FontIcon("search");
    public static IRadzenIcon Home { get; } = new FontIcon("home");
    public static IRadzenIcon Menu { get; } = new FontIcon("menu");
    public static IRadzenIcon Close { get; } = new FontIcon("close");
    public static IRadzenIcon Settings { get; } = new FontIcon("settings");
    public static IRadzenIcon ArrowForward { get; } = new FontIcon("arrow_forward");
}
