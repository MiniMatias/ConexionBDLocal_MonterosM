using SQLite;

namespace ConexionBDLocal_MonterosM.Models;

public class Note
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Text { get; set; } = string.Empty;

    public DateTime Date { get; set; }
}
