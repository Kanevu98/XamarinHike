
namespace XamarinMHike
{
    public partial class App : Application
    {
        private static SQLiteDatabase db;

        public static SQLiteDatabase MyDb
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "HikeManagement.db3"));
                }
                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}