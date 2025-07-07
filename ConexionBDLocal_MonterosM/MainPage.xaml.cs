using ConexionBDLocal_MonterosM.Models;

namespace ConexionBDLocal_MonterosM;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        LoadNotes();
    }

    async void LoadNotes()
    {
        notesCollection.ItemsSource = await MauiProgram.Database.GetNotesAsync();
    }

    async void OnSaveClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(noteEntry.Text))
        {
            var note = new Note
            {
                Text = noteEntry.Text,
                Date = DateTime.Now
            };

            await MauiProgram.Database.SaveNoteAsync(note);
            noteEntry.Text = string.Empty;
            LoadNotes();
        }
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (sender is SwipeItem swipe && swipe.BindingContext is Note note)
        {
            await MauiProgram.Database.DeleteNoteAsync(note);
            LoadNotes();
        }
    }
}