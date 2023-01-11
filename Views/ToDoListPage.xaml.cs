using ToDoApp.Data;
using ToDoApp.Models;

namespace ToDoApp.Views;

public partial class ToDoListPage : ContentPage
{
	public ToDoListPage()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		ToDoItemDatabase database = await ToDoItemDatabase.Instance;
		listView.ItemsSource = await database.GetItemsAsync();
	}

	async void OnItemAdded(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new ToDoItemPage
		{
			BindingContext = new ToDoItem()
		});
	}

	async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		if(e.SelectedItem != null)
		{
			await Navigation.PushAsync(new ToDoItemPage
			{
				BindingContext = e.SelectedItem as ToDoItem
			});
		}
	}
}