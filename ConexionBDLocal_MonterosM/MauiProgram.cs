using ConexionBDLocal_MonterosM;
using ConexionBDLocal_MonterosM.Data;

namespace ConexionBDLocal_MonterosM;

public static class MauiProgram
{
    public static NotesDatabase Database { get; private set; } = null!;

    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "notes.db3");
        Database = new NotesDatabase(dbPath);

        return builder.Build();
    }
}
