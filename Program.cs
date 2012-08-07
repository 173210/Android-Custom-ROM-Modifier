using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace Android_Custom_ROM_Modifier
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Directory.Exists(profiles) == false)
            {
                MessageBox.Show("プロファイルがありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (File.Exists(tools + "\\signapk.jar") == false)
            {
                MessageBox.Show("tools\\sign.jarがありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (File.Exists(tools + "\\testkey.pk8") == false)
            {
                MessageBox.Show("tools\\testkey.pk8がありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (File.Exists(tools + "\\testkey.x509.pem")) { }
            else
            {
                MessageBox.Show("tools\\testkey.x509.pemがありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] profiles_dir = System.IO.Directory.GetDirectories(profiles);
            if (profiles_dir.Length == 0)
            {
                MessageBox.Show("プロファイルがありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                ProcessStartInfo java = new ProcessStartInfo();
                java.FileName = "java.exe";
                java.CreateNoWindow = true;
                java.UseShellExecute = false;
                Process.Start(java);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Javaが起動できません。\r\n" + ex.Message + "JREを動作可能にしてください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Menu menuloader = new Menu();
            menuinstance = menuloader;
            Application.Run(menuloader);
        }

        public static Menu menuinstance;
        public static String path = Path.GetDirectoryName(Application.ExecutablePath);
        public static String work = path + "\\work";
        public static String profiles = path + "\\profiles";
        public static String tools = path + "\\tools";
    }
}
