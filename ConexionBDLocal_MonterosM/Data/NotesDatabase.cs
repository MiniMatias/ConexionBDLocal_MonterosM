using SQLite;
using ConexionBDLocal_MonterosM.Models;

namespace ConexionBDLocal_MonterosM.Data;

public class NotesDatabase
{
    private readonly SQLiteAsyncConnection _database;

    public NotesDatabase(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Note>().Wait();
    }

    public Task<List<Note>> GetNotesAsync() =>
        _database.Table<Note>().OrderByDescending(n => n.Date).ToListAsync();

    public Task<int> SaveNoteAsync(Note note) =>
        note.Id != 0 ? _database.UpdateAsync(note) : _database.InsertAsync(note);

    public Task<int> DeleteNoteAsync(Note note) =>
        _database.DeleteAsync(note);
}
