namespace VK_Music
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            bool isTokenExist = VK.CheckToken();
            if (isTokenExist)
                Application.Run(new MainForm());
            else
                Application.Run(new LoginForm());

        }
    }
}