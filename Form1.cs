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
<<<<<<< HEAD
        
        public delegate void SetFocusDelegate();
        private makeclass makeinstance = new makeclass();
        
        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Make.Text == "中止")
            {
                DialogResult question = MessageBox.Show("作成中です。プロセスを終了しますか?", "カスタムROM改変一撃ツール", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (question == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    makeclass.makethread.Abort();
                }
            }
            Application.Exit();
        }

        private void BaseROMFile_DragOver(object sender, DragEventArgs e)
        {
            string[] fileNameArray = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (File.Exists(fileNameArray[0]) == false)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            if (fileNameArray.Length > 1)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            e.Effect = DragDropEffects.All;
        }

        private void BaseROMFile_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNameArray = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            BaseROMFile.Text = fileNameArray[0];
        }

        private void SaveFile_DragOver(object sender, DragEventArgs e)
        {
            string[] fileNameArray = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            if (fileNameArray.Length > 1)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            e.Effect = DragDropEffects.All;
        }

        private void SaveFile_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNameArray = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (Directory.Exists(fileNameArray[0]))
            {
                SaveFile.Text = fileNameArray[0] + "\\update.zip";
            }
            else
            {
                SaveFile.Text = fileNameArray[0];
            }
        }

=======
        private Process makecmd;
        private bool makecmd_started = false;
>>>>>>> origin/master
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
            sfd.FileName = "update.zip";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveFile.Text = sfd.FileName;
            }
        }

        private void Make_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if (Make.Text == "中止")
            {
                makeclass.makethread.Abort();
                Program.menuinstance.Make.Text = "作成";
                Program.menuinstance.toolStripProgressBar.Value = 0;
                Program.menuinstance.toolStripStatusLabel.Text = "";
                return;
            }
            makeclass make = new makeclass();
            make.makeloader();
            Make.Text = "中止";
            while (makeclass.makethread.IsAlive)
            {
                Application.DoEvents();
            }
        }

        private void command_inputed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (makeinstance.makecmd_started == true)
                {
                    makeinstance.makecmd.StandardInput.Write(command1.Text);
                }
                command1.ResetText();
            }
=======
            Make.Enabled = false;
            backgroundWorker.RunWorkerAsync();
            while(backgroundWorker.IsBusy)
            {
                Application.DoEvents();
            }
        }

        private void command_inputed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (makecmd_started == true)
                {
                    makecmd.StandardInput.Write(command1.Text);
                }
            }
        }

        delegate void SetFocusDelegate();

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke((SetFocusDelegate)delegate()
            {
                toolStripStatusLabel.Text = "現在の状態を確認しています…";
                Console.AppendText("現在の状態を確認しています…\r\n元ROMを確認しています… [1/3]\r\n");
            });
            if (File.Exists(BaseROMFile.Text))
            {
                Invoke((SetFocusDelegate)delegate()
                {
                    Console.AppendText("確認しました。\r\n保存先を確認しています… [2/3]\r\n");
                });
            }
            else
            {
                Invoke((SetFocusDelegate)delegate()
                {
                    toolStripStatusLabel.Text = "エラー";
                    Console.AppendText("エラー：元ROMが見つかりません\r\n");
                });
                MessageBox.Show("元ROMを指定してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel.Text = "";
                return;
            }
            backgroundWorker.ReportProgress(33);
            if (Directory.Exists(Path.GetDirectoryName(SaveFile.Text)))
            {
                Invoke((SetFocusDelegate)delegate()
                {
                    Console.AppendText("確認しました。\r\nworkフォルダを調べています… [3/3]\r\n");
                });
            }
            else
            {
                Invoke((SetFocusDelegate)delegate()
                {
                    toolStripStatusLabel.Text = "エラー";
                    Console.AppendText("エラー：保存先が見つかりません\r\n");
                });
                MessageBox.Show("保存先を指定してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            backgroundWorker.ReportProgress(66);
            if (Directory.Exists(Program.work))
            {
                Invoke((SetFocusDelegate)delegate()
                {
                    toolStripStatusLabel.Text = "警告";
                    Console.AppendText("workフォルダが見つかりました。\r\n");
                });
                DialogResult question = MessageBox.Show("workフォルダが存在します。workフォルダを削除しますか?\n削除せずに続行する場合はいいえを、中止する場合はキャンセルを押してください。", "カスタムROM改変一撃ツール", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (question == DialogResult.Yes)
                {
                    Invoke((SetFocusDelegate)delegate()
                    {
                        toolStripStatusLabel.Text = "workフォルダを削除しています…";
                        Console.AppendText("workフォルダを削除しています…\r\n");
                    });
                    DirectoryInfo workinfo = new DirectoryInfo(Program.work);
                    workinfo.Delete(true);
                    Invoke((SetFocusDelegate)delegate()
                    {
                        Console.AppendText("workフォルダを削除しました。\r\n");
                    });
                }
                else if (question == DialogResult.Cancel)
                {
                    Console.AppendText("処理がユーザーにより中止されました。\r\n");
                    return;
                }
                backgroundWorker.ReportProgress(100);
            }
            backgroundWorker.ReportProgress(0);
            string[] SelectedProfiles = new string[ProfileSelect.CheckedItems.Count];
            int Processes_Number = 3 + SelectedProfiles.Length;
            int ProgressBar_Add_Value = 100 / Processes_Number;
            Invoke((SetFocusDelegate)delegate()
            {
                Console.AppendText("状態の確認が完了しました。\r\nROMを作成します。\r\n元ROMの展開中… [1/" + Processes_Number + "]\r\n");
                toolStripStatusLabel.Text = "作成中…";
            });
            using (ZipFile zip = ZipFile.Read(@BaseROMFile.Text))
            {
                zip.ExtractExistingFile =
                    Ionic.Zip.ExtractExistingFileAction.OverwriteSilently;
                zip.ExtractAll(Program.work);
            }
            Invoke((SetFocusDelegate)delegate(){
            Console.AppendText("完了しました。\r\n");});
            int toolStripProgressBar_Value = ProgressBar_Add_Value;
            backgroundWorker.ReportProgress(toolStripProgressBar_Value);
            ProfileSelect.CheckedItems.CopyTo(SelectedProfiles, 0);
            StreamReader reader;
            string readline;
            for (int i = 0; i <= SelectedProfiles.Length - 1; i++)
            {
                Invoke((SetFocusDelegate)delegate()
                {
                    Console.AppendText(SelectedProfiles[i] + "の適用中… [" + (i + 2) + "/" + SelectedProfiles.Length + "]\r\n");
                });
                ProcessStartInfo makeinfo = new ProcessStartInfo();
                makeinfo.FileName = Program.profiles + "\\" + SelectedProfiles[i] + "\\make.cmd";
                makeinfo.CreateNoWindow = true;
                makeinfo.ErrorDialog = true;
                makeinfo.RedirectStandardError = true;
                makeinfo.RedirectStandardOutput = true;
                makeinfo.RedirectStandardInput = true;
                makeinfo.UseShellExecute = false;
                makeinfo.WorkingDirectory = Program.path;
                makecmd_started = true;
                makecmd = Process.Start(makeinfo);
                reader = makecmd.StandardOutput;

                while (makecmd.HasExited == false)
                {
                    while (!reader.EndOfStream)
                    {
                        readline = reader.ReadLine() + "\r\n";
                        Invoke((SetFocusDelegate)delegate() {
                        Console.AppendText(readline);});
                    }
                }
                reader.Close();
                makecmd_started = false;
                if (makecmd.ExitCode == 1)
                {
                    Invoke((SetFocusDelegate)delegate()
                    {
                        toolStripStatusLabel.Text = "エラー";
                        Console.AppendText("エラー：" + SelectedProfiles[i] + "の適用中にエラーが発生しました。\r\n");
                    });
                    DialogResult make_error = MessageBox.Show(SelectedProfiles[i] + "でエラーが発生しました。このまま続行しますか？", "エラー", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (make_error == DialogResult.No)
                    {
                        Invoke((SetFocusDelegate)delegate()
                        {
                            Console.AppendText("作業が中止されました。\r\n");
                        });
                        if (TempDelete.Checked == false)
                        {
                            Invoke((SetFocusDelegate)delegate()
                            {
                                toolStripStatusLabel.Text = "一時ファイルを削除しています…";
                                Console.AppendText("workフォルダを削除しています…\r\n");
                            });
                            DirectoryInfo workinfo = new DirectoryInfo(Program.work);
                            workinfo.Delete(true);
                        }
                        return;
                    }
                }
                Invoke((SetFocusDelegate)delegate()
                {
                    Console.AppendText(SelectedProfiles[i] + "の適用が完了しました。[" + (i + 1) + "/" + SelectedProfiles.Length + "]\r\n");
                });
                    toolStripProgressBar_Value = toolStripProgressBar_Value + ProgressBar_Add_Value;
                    backgroundWorker.ReportProgress(toolStripProgressBar_Value);
            }
            Invoke((SetFocusDelegate)delegate()
            {
                Console.AppendText("すべてのプロファイルの適用が完了しました。\r\nROMをパッケージしています… [" + (SelectedProfiles.Length + 2) + "/" + Processes_Number + "]\r\n");
            });
            using (ZipFile zip = new ZipFile(Encoding.GetEncoding("utf-8")))
            {
                zip.CompressionLevel = CompressionLevel.None;
                zip.AddDirectory(Program.work);
                zip.Save(Program.path + "\\update-tmp.zip");
            }
            toolStripProgressBar_Value = toolStripProgressBar_Value + ProgressBar_Add_Value;
            backgroundWorker.ReportProgress(toolStripProgressBar_Value);
            Invoke((SetFocusDelegate)delegate()
            {
                Console.AppendText("パッケージしました。署名しています… [" + Processes_Number + "/" + Processes_Number + "]\r\n");
            });
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
                Invoke((SetFocusDelegate)delegate()
                {
                    toolStripStatusLabel.Text = "一時ファイルを削除しています…";
                    Console.AppendText("workフォルダを削除しています…\r\n");
                });
                DirectoryInfo workinfo = new DirectoryInfo(Program.work);
                workinfo.Delete(true);
                Invoke((SetFocusDelegate)delegate()
                {
                    Console.AppendText("完了しました。署名が完了するまで待機します。\r\n");
                });
                sign.WaitForExit();
                Invoke((SetFocusDelegate)delegate()
                {
                    Console.AppendText("署名が完了しました。\r\nupdate-tmp.zipを削除しています…\r\n");
                });
                File.Delete(Program.path + "\\update-tmp.zip");
            }
            else
            {
                sign.WaitForExit();
                Invoke((SetFocusDelegate)delegate() {
                    Console.AppendText("署名が完了しました。\r\n");});
            }
            backgroundWorker.ReportProgress(100);
            Console.AppendText("全作業が完了しました。\r\n");
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Make.Enabled = true;
            toolStripProgressBar.Value = 0;
            toolStripStatusLabel.Text = "";
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar.Value = e.ProgressPercentage;
>>>>>>> origin/master
        }
    }
}
