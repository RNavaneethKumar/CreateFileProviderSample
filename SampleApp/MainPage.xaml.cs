using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Extensions.FileProviders;

namespace SampleApp;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        CustomBlazorWebView customBlazorWebView = new CustomBlazorWebView();
        BlazorWebView webView = customBlazorWebView.CreateWebViewControl(FileSystem.AppDataDirectory);
    }
}

public class CustomBlazorWebView : BlazorWebView
{
    public override IFileProvider CreateFileProvider(string contentRootDir)
    {
        var defaultFileProvider = new PhysicalFileProvider(contentRootDir);
        return defaultFileProvider;
    }

    public BlazorWebView CreateWebViewControl(string path)
    {
        BlazorWebView blazorWebView = new BlazorWebView();
        blazorWebView.CreateFileProvider(path);
        //blazorWebView.HostPage = "index.html";
        return blazorWebView;
    }
}
