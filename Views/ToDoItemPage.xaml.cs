using ToDoApp.Data;
using ToDoApp.Models;

namespace ToDoApp.Views;

public partial class ToDoItemPage : ContentPage
{
	public ToDoItemPage()
	{
		InitializeComponent();
	}

	async void OnSaveClicked(object sender, EventArgs e)
	{
		var toDoItem = (ToDoItem)BindingContext;
		ToDoItemDatabase database = await ToDoItemDatabase.Instance;
		await database.SaveItemAsync(toDoItem);
		await Navigation.PopAsync();
	}

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        var toDoItem = (ToDoItem)BindingContext;
        ToDoItemDatabase database = await ToDoItemDatabase.Instance;
        await database.DeleteItemAsync(toDoItem);
        await Navigation.PopAsync();
    }

	async void OnCancelClicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
}