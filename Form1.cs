using System;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ionic.Zip;
using Ionic.Zlib;
namespace Android_Custom_ROM_Modifier
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            string[] dirs = System.IO.Directory.GetDirectories(Program.profiles);
            for (int i = 0; i <= dirs.Length - 1; i++)
            {
                dirs[i] = dirs[i].Replace(Program.profiles + "\\","");
            }
            ProfileSelect.Items.AddRange(dirs);
        }
        private void BaseROMFileSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ROM(*.zip)|*.zip|すべてのファイル(*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.Title = "開くファイルを選択してください";
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                BaseROMFile.Text = ofd.FileName;
            }
        }

        private void SaveFileSelect_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "ROM(*.zip)|*.zip|すべてのファイル(*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.Title = "保存する場所を選択してください";
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveFile.Text = sfd.FileName;
            }
        }

        private void Make_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "現在の状態を確認しています…";
            Console.AppendText("現在の状態を確認しています…\r\n元ROMを確認しています… [1/3]\r\n");
            if (File.Exists(BaseROMFile.Text)) {
                Console.AppendText("確認しました。\r\n保存先を確認しています… [2/3]\r\n");
            }
            else
            {
                toolStripStatusLabel.Text = "エラー";
                Console.AppendText("エラー：元ROMが見つかりません\r\n");
                MessageBox.Show("元ROMを指定してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel.Text = "";
                return;
            }
            toolStripProgressBar.Value = 33;
            if (Directory.Exists(Path.GetDirectoryName(SaveFile.Text))) {
                Console.AppendText("確認しました。\r\nworkフォルダを調べています… [3/3]\r\n");
            }
            else
            {
                toolStripStatusLabel.Text = "エラー";
                Console.AppendText("エラー：保存先が見つかりません\r\n");
                MessageBox.Show("保存先を指定してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel.Text = "";
                return;
            }
            toolStripProgressBar.Value = 66;
            if (Directory.Exists(Program.work))
            {
                toolStripStatusLabel.Text = "警告";
                Console.AppendText("workフォルダが見つかりました。\r\n");
                DialogResult question = MessageBox.Show("workフォルダが存在します。workフォルダを削除しますか?\n削除せずに続行する場合はいいえを、中止する場合はキャンセルを押してください。", "カスタムROM改変一撃ツール", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (question == DialogResult.Yes) {
                    toolStripStatusLabel.Text = "workフォルダを削除しています…";
                    Console.AppendText("workフォルダを削除しています…\r\n");
                    DirectoryInfo workinfo = new DirectoryInfo(Program.work);
                    workinfo.Delete(true);
                    Console.AppendText("workフォルダを削除しました。\r\n");
                }
                else if (question == DialogResult.Cancel) {
                    toolStripProgressBar.Value = 0;
                    toolStripStatusLabel.Text = "";
                    Console.AppendText("処理がユーザーにより中止されました。\r\n");
                    return;
                }
                toolStripProgressBar.Value = 100;
            }
            toolStripProgressBar.Value = 0;
            string[] SelectedProfiles = new string[ProfileSelect.CheckedItems.Count];
            int Processes_Number = 3 + SelectedProfiles.Length;
            int ProgressBar_Add_Value = 100 / Processes_Number;
            Console.AppendText("状態の確認が完了しました。\r\nROMを作成します。\r\n元ROMの展開中… [1/" + Processes_Number + "]\r\n");
            toolStripStatusLabel.Text = "作成中…";
            using (ZipFile zip = ZipFile.Read(@BaseROMFile.Text))
            {
                zip.ExtractExistingFile =
                    Ionic.Zip.ExtractExistingFileAction.OverwriteSilently;
                zip.ExtractAll(Program.work);
            }
            Console.AppendText("完了しました。\r\n");
            toolStripProgressBar.Value = ProgressBar_Add_Value;
            ProfileSelect.CheckedItems.CopyTo(SelectedProfiles,0);
            StreamReader reader;
            for (int i = 0; i <= SelectedProfiles.Length - 1; i++) 
            {
                Console.AppendText(SelectedProfiles[i] + "の適用中… [" + (i + 2) + "/" + SelectedProfiles.Length + "]\r\n");
                ProcessStartInfo makeinfo = new ProcessStartInfo();
                makeinfo.CreateNoWindow = true;
                makeinfo.ErrorDialog = true;
                makeinfo.FileName = Program.profiles + "\\" + SelectedProfiles[i] + "\\make.cmd";
                makeinfo.RedirectStandardError = true;
                makeinfo.RedirectStandardOutput = true;
                makeinfo.UseShellExecute = false;
                makeinfo.WorkingDirectory = Program.path;
                Process make = Process.Start(makeinfo);
                reader = make.StandardOutput;
                while (make.HasExited == false)
                {
                    while (!reader.EndOfStream)
                    {
                        Console.AppendText(reader.ReadLine());
                    }
                }
                reader.Close();
                if (make.ExitCode == 1)
                {
                    toolStripStatusLabel.Text = "エラー";
                    Console.AppendText("\r\nエラー：" + SelectedProfiles[i] + "の適用中にエラーが発生しました。");
                    DialogResult make_error = MessageBox.Show(SelectedProfiles[i] + "でエラーが発生しました。このまま続行しますか？", "エラー", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (make_error == DialogResult.No)
                    {
                        Console.AppendText("\r\n作業が中止されました。\r\n");
                        if (TempDelete.Checked == false)
                        {
                            toolStripStatusLabel.Text = "一時ファイルを削除しています…";
                            Console.AppendText("workフォルダを削除しています…\r\n");
                            DirectoryInfo workinfo = new DirectoryInfo(Program.work);
                            workinfo.Delete(true);
                            toolStripStatusLabel.Text = "";
                        }
                        toolStripProgressBar.Value = 0;
                        return;
                    }
                }
                Console.AppendText("\r\n" + SelectedProfiles[i] + "の適用が完了しました。[" + (i + 1) + "/" + SelectedProfiles.Length + "]\r\n");
                toolStripProgressBar.Value = toolStripProgressBar.Value + ProgressBar_Add_Value;
            }
            Console.AppendText("すべてのプロファイルの適用が完了しました。\r\nROMをパッケージしています… [" + (SelectedProfiles.Length + 2) + "/" + Processes_Number  + "]\r\n");
            using (ZipFile zip = new ZipFile(Encoding.GetEncoding("utf-8")))
            {
                zip.CompressionLevel = CompressionLevel.None;
                zip.AddDirectory(Program.work);
                zip.Save(Program.path + "\\update-tmp.zip");
            }
            toolStripProgressBar.Value = toolStripProgressBar.Value + ProgressBar_Add_Value;
            Console.AppendText("パッケージしました。署名しています… [" + Processes_Number + "/" + Processes_Number + "]\r\n");
            ProcessStartInfo signinfo = new ProcessStartInfo();
            signinfo.CreateNoWindow = true;
            signinfo.ErrorDialog = true;
            signinfo.FileName = "java.exe";
            signinfo.Arguments = "-jar \"" + Program.tools + "\\signapk.jar\" \"" + Program.tools + "\\testkey.x509.pem\" \"" + Program.tools + "\\testkey.pk8\" \"" + Program.path + "\\update-tmp.zip\" \"" + SaveFile.Text + "\"";
            signinfo.RedirectStandardError = true;
            signinfo.RedirectStandardOutput = true;
            signinfo.UseShellExecute = false;
            Process sign = Process.Start(signinfo);
            if (TempDelete.Checked == false)
            {
                toolStripStatusLabel.Text = "一時ファイルを削除しています…";
                Console.AppendText("workフォルダを削除しています…\r\n");
                DirectoryInfo workinfo = new DirectoryInfo(Program.work);
                workinfo.Delete(true);
                Console.AppendText("完了しました。署名が完了するまで待機します。\r\n");
                sign.WaitForExit();
                Console.AppendText("署名が完了しました。\r\nupdate-tmp.zipを削除しています…\r\n");
                File.Delete(Program.path + "\\update-tmp.zip");
            }
            else
            {
                sign.WaitForExit();
                Console.AppendText("署名が完了しました。\r\n");
            }
            toolStripProgressBar.Value = 100;
            toolStripStatusLabel.Text = "";
            Console.AppendText("全作業が完了しました。\r\n");
            toolStripProgressBar.Value = 0;
        }
    }
}
