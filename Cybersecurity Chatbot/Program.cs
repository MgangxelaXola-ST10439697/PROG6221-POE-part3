using System;
using System.IO;
using System.Windows.Forms;
using Cybersecurity_Chatbot.Forms;

namespace Cybersecurity_Chatbot
{
    static class Program
    {
        public static string UserName { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += (sender, args) =>
            {
                LogError("error.log", args.Exception);
                MessageBox.Show("An unexpected error occurred:\n" + args.Exception.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                Exception ex = (Exception)args.ExceptionObject;
                LogError("fatal.log", ex);
                MessageBox.Show("A fatal error occurred. The application will now close.",
                    "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            };

            // Show username GUI form
            using (var nameForm = new UsernameForm())
            {
                if (nameForm.ShowDialog() == DialogResult.OK)
                {
                    UserName = nameForm.EnteredName;
                }
                else
                {
                    // User canceled
                    return;
                }
            }

            // Launch main form
            try
            {
                Application.Run(new MainChatForm());
            }
            catch (Exception ex)
            {
                LogError("crash.log", ex);
                MessageBox.Show("The application failed to start:\n" + ex.Message,
                    "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void LogError(string fileName, Exception ex)
        {
            string path = Path.Combine(Application.StartupPath, fileName);
            File.AppendAllText(path, $"[{DateTime.Now}] {ex}\n");
        }
    }
}
