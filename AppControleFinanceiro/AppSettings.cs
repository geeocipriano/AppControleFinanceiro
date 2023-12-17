namespace AppControleFinanceiro
{
    public class AppSettings
    {
        private static string DatabaseName = "database.db"; // Nome do banco
        private static string DatabaseDirectory = FileSystem.AppDataDirectory; // Aonde vai ser salvo
        public static string DatabasePath = Path.Combine(DatabaseDirectory, DatabaseName); // Caminho
    }
}
