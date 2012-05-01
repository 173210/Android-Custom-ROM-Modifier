using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
            if (Directory.Exists(profiles)) { }
            else
            {
                MessageBox.Show("プロファイルがありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            if (File.Exists(tools + "\\signapk.jar")) { }
            else
            {
                MessageBox.Show("tools\\sign.jarがありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            if (File.Exists(tools + "\\testkey.pk8")) { }
            else
            {
                MessageBox.Show("tools\\testkey.pk8がありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            if (File.Exists(tools + "\\testkey.x509.pem")) { }
            else
            {
                MessageBox.Show("tools\\testkey.x509.pemがありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            string[] profiles_dir = System.IO.Directory.GetDirectories(profiles);
            if (profiles_dir.Length == 0)
            {
                MessageBox.Show("プロファイルがありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
                Application.Run(new Menu());
        }
        public static string path = Path.GetDirectoryName(Application.ExecutablePath);
        public static string work = path + "\\work";
        public static string profiles = path + "\\profiles";
        public static string tools = path + "\\tools";
    }
}
