using ToDoApp.Views;

namespace ToDoApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new ToDoListPage())
		{
			BarTextColor = Color.FromRgb(255, 255, 255)
		};
	}
}
