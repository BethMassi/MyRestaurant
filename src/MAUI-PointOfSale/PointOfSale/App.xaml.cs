using System.Linq.Expressions;

namespace PointOfSale;

public partial class App : Application
{
    public App()
	{
		InitializeComponent();

        App.Current.UserAppTheme = AppTheme.Dark;
            
        if (DeviceInfo.Idiom == DeviceIdiom.Phone)
        {
            MainPage = new AppShellMobile();
        }
        else
        {
            MainPage = new AppShell();
        }


        AppActions.SetAsync(
           new AppAction("add_product", "Add Product"),
           new AppAction("view_menu", "View Menu")
           );
        AppActions.OnAppAction += AppActions_OnAppAction;
    }

    private void AppActions_OnAppAction(object sender, AppActionEventArgs e)
    {
        if (e.AppAction.Id == "add_product")
        {
            //do something
        }
        else if (e.AppAction.Id=="view_menu")
        {
        }
    }
}