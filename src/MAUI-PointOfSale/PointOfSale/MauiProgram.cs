using CommunityToolkit.Maui;
using Microsoft.Maui.LifecycleEvents;
using Microsoft.Maui.Platform;
using SkiaSharp.Views.Maui.Controls.Hosting;
using ZXing.Net.Maui;

#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

#if ANDROID
[assembly: Android.App.UsesPermission(Android.Manifest.Permission.Camera)]
#endif

namespace PointOfSale;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseBarcodeReader()
			.UseMauiCommunityToolkit()
            .UseSkiaSharp()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("opensans_semibold.ttf", "OpenSansSemiBold");
                fonts.AddFont("fa_solid.ttf", "FontAwesome");
                fonts.AddFont("fabmdl2.ttf", "Fabric");
            });

        builder.Services.AddMauiBlazorWebView();

#if WINDOWS
        builder.ConfigureLifecycleEvents(events =>
        {
            events.AddWindows(wndLifeCycleBuilder =>
            {
                wndLifeCycleBuilder.OnWindowCreated(window =>
                {
                    IntPtr nativeWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                    WindowId win32WindowsId = Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);
                    AppWindow winuiAppWindow = AppWindow.GetFromWindowId(win32WindowsId);

                    const int x = 10;
                    const int y = 10;
                    int width = (int)(winuiAppWindow.ClientSize.Width / 1.3);

                    winuiAppWindow.MoveAndResize(new RectInt32(x, y, width, winuiAppWindow.ClientSize.Height));
                });
            });
        });
#endif

        ModifyEntry();

        return builder.Build();
	}

    public static void ModifyEntry()
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoMoreBorders", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif IOS || MACCATALYST
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
            handler.PlatformView.FontWeight = Microsoft.UI.Text.FontWeights.Thin;
#endif
        });
    }
}
