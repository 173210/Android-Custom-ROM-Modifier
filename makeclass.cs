using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Ionic.Zip;
using Ionic.Zlib;

namespace Android_Custom_ROM_Modifier
{
    class makeclass
    {
        public static Thread makethread;
        //private static Form form = Application.OpenForms["Menu"];
        //private static object Program.menuinstance;
        public Process makecmd;
        public bool makecmd_started = false;
        private bool update_tmp_zip_exists;
        private int ProgressBar_Add_Value;
        private int ProgressBar_Added_Value;
        private String work2 = Program.path + "\\work2";

        public void makeloader()
        {
            //Program.menuinstance = Menu.formobj;
            makethread = new Thread(new ThreadStart(makemethod));
            makethread.IsBackground = true;
            makethread.Start();
        }

        public void makemethod()
        {
            Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
            {
                Program.menuinstance.toolStripStatusLabel.Text = "現在の状態を確認しています…";
                Program.menuinstance.Console.AppendText("現在の状態を確認しています…\r\n元ROMを確認しています… [1/4]\r\n");
            });
            if (Program.menuinstance.BaseROMFile.Text == "")
            {
                Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                {
                    Program.menuinstance.toolStripStatusLabel.Text = "エラー";
                    Program.menuinstance.Console.AppendText("エラー：元ROMが指定されていません\r\n");
                });
                MessageBox.Show("元ROMを指定してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                {
                    Program.menuinstance.toolStripStatusLabel.Text = "";
                });
                make_finish();
                return;
            }
            if (File.Exists(Program.menuinstance.BaseROMFile.Text) == false)
            {
                Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                {
                    Program.menuinstance.toolStripStatusLabel.Text = "エラー";
                    Program.menuinstance.Console.AppendText("エラー：元ROMが見つかりません\r\n");
                });
                MessageBox.Show("元ROMを指定してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                {
                    Program.menuinstance.toolStripStatusLabel.Text = "";
                });
                make_finish();
                return;
            }
            Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
            {
                Program.menuinstance.Console.AppendText("確認しました。\r\n保存先を確認しています… [2/4]\r\n");
                Program.menuinstance.toolStripProgressBar.Value = 85;
            });
            if (Program.menuinstance.SaveFile.Text == "")
            {
                Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                {
                    Program.menuinstance.toolStripStatusLabel.Text = "エラー";
                    Program.menuinstance.Console.AppendText("エラー：保存先が指定されていません\r\n");
                });
                MessageBox.Show("保存先を指定してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                make_finish();
                return;
            }
            if (Directory.Exists(Program.menuinstance.SaveFile.Text))
            {
                Program.menuinstance.SaveFile.Text = Program.menuinstance.SaveFile.Text + "\\update.zip";
            }
            else if (Directory.Exists(Path.GetDirectoryName(Program.menuinstance.SaveFile.Text)) == false)
            {
                Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                {
                    Program.menuinstance.toolStripStatusLabel.Text = "エラー";
                    Program.menuinstance.Console.AppendText("エラー：保存先が見つかりません\r\n");
                });
                MessageBox.Show("保存先を指定してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                make_finish();
                return;
            }
            Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
            {
                Program.menuinstance.Console.AppendText("確認しました。\r\nworkフォルダを調べています… [3/4]\r\n");
                Program.menuinstance.toolStripProgressBar.Value = 170;
            });
            if (Directory.Exists(Program.work))
            {
                Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                {
                    Program.menuinstance.toolStripStatusLabel.Text = "警告";
                    Program.menuinstance.Console.AppendText("workフォルダが見つかりました。\r\n");
                });
                DialogResult question = MessageBox.Show("workフォルダが存在します。workフォルダを削除しますか?\n削除せずに続行する場合はいいえを、中止する場合はキャンセルを押してください。", "カスタムROM改変一撃ツール", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (question == DialogResult.Yes)
                {
                    if (delete("フォルダ","work") == false)
                    {
                        make_finish();
                        return;
                    }
                }
                else if (question == DialogResult.Cancel)
                {
                    Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                    {
                        Program.menuinstance.Console.AppendText("処理がユーザーにより中止されました。\r\n");
                    });
                    make_finish();
                    return;
                }
            }
            Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
            {
                Program.menuinstance.Console.AppendText("確認しました。\r\nwork2フォルダを調べています… [4/4]\r\n");
                Program.menuinstance.toolStripProgressBar.Value = 170;
            });
            if (Directory.Exists(work2))
            {
                Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                {
                    Program.menuinstance.toolStripStatusLabel.Text = "警告";
                    Program.menuinstance.Console.AppendText("workフォルダが見つかりました。\r\n");
                });
                DialogResult question = MessageBox.Show("work2フォルダが存在します。work2フォルダを削除しますか?\n削除せずに続行する場合はいいえを、中止する場合はキャンセルを押してください。", "カスタムROM改変一撃ツール", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (question == DialogResult.Yes)
                {
                    if (delete("フォルダ","work2") == false)
                    {
                        make_finish();
                        return;
                    }
                }
                else if (question == DialogResult.Cancel)
                {
                    Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                    {
                        Program.menuinstance.Console.AppendText("処理がユーザーにより中止されました。\r\n");
                    });
                    make_finish();
                    return;
                }
            }
            string[] SelectedProfiles = new string[Program.menuinstance.ProfileSelect.CheckedItems.Count];
            int Processes_Number = 3 + SelectedProfiles.Length;
            ProgressBar_Add_Value = 256 / Processes_Number;
            Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
            {
                Program.menuinstance.toolStripProgressBar.Value = 0;
                Program.menuinstance.Console.AppendText("状態の確認が完了しました。\r\n元ROMを展開します。\r\n元ROMの展開中… [1/" + Processes_Number + "]\r\n");
                Program.menuinstance.toolStripStatusLabel.Text = "展開中…";
            });
            using (ZipFile zip = ZipFile.Read(@Program.menuinstance.BaseROMFile.Text))
            {
                zip.ExtractExistingFile =
                    Ionic.Zip.ExtractExistingFileAction.OverwriteSilently;
                zip.ExtractProgress += zip_ExtractProgress;
            extrom:
                try
                {
                    zip.ExtractAll(Program.work);
                }
                catch (Exception ex)
                {
                    Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                    {
                        Program.menuinstance.Console.AppendText(ex.Message + "\r\n");
                        Program.menuinstance.toolStripStatusLabel.Text = "エラー";
                    });
                    DialogResult ext = MessageBox.Show("ROMの展開に失敗しました。\r\n" + ex.Message, "エラー", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (ext == DialogResult.Retry)
                    {
                        Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                        {
                            Program.menuinstance.Console.AppendText("元ROMの展開中… [1/" + Processes_Number + "]\r\n");
                            Program.menuinstance.toolStripStatusLabel.Text = "展開中…";
                        });
                        goto extrom;
                    }
                Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                {
                    Program.menuinstance.Console.AppendText("作業が中止されました。\r\n");
                });
                temp_delete();
                make_finish();
                return;
                }
            }
            Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
            {
                Program.menuinstance.toolStripProgressBar.Value = ProgressBar_Add_Value;
                Program.menuinstance.Console.AppendText("元ROMの展開が完了しました。\r\nプロファイルの適用を開始します\r\n");
                Program.menuinstance.toolStripStatusLabel.Text = "プロファイルの適用中…";
            });
            Program.menuinstance.ProfileSelect.CheckedItems.CopyTo(SelectedProfiles, 0);
            StreamReader reader;
            DialogResult makecmd_error;
            String readline;
            ProcessStartInfo makeinfo = new ProcessStartInfo();
            Directory.CreateDirectory(work2);
            for (int i = 0; i < SelectedProfiles.Length; i++)
            {
                Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                {
                    Program.menuinstance.Console.AppendText(SelectedProfiles[i] + "の適用中… [" + (i + 2) + "/" + SelectedProfiles.Length + "]\r\n");
                    Program.menuinstance.toolStripStatusLabel.Text = SelectedProfiles[i] + "の適用中…";
                });
                makeinfo.FileName = Program.profiles + "\\" + SelectedProfiles[i] + "\\make.cmd";
                makeinfo.Arguments = "\"" + Program.profiles + "\\" + SelectedProfiles[i] + "\"";
                makeinfo.CreateNoWindow = true;
                makeinfo.ErrorDialog = true;
                makeinfo.RedirectStandardError = true;
                makeinfo.RedirectStandardOutput = true;
                makeinfo.RedirectStandardInput = true;
                makeinfo.UseShellExecute = false;
                makeinfo.WorkingDirectory = Program.path;
                makecmd_started = true;
            makecmd_start:
                try
                {
                    makecmd = Process.Start(makeinfo);
                }
                catch (Exception ex)
                {
                    Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                    {
                        Program.menuinstance.Console.AppendText(ex.Message);
                        Program.menuinstance.toolStripStatusLabel.Text = "エラー";
                    });
                    makecmd_error = MessageBox.Show(SelectedProfiles[i] + "のmake.cmd起動に失敗しました。\r\n" + ex.Message, "エラー", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (makecmd_error == DialogResult.Retry)
                    {
                        goto makecmd_start;
                    }
                    Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                    {
                        Program.menuinstance.toolStripStatusLabel.Text = "エラー";
                        Program.menuinstance.Console.AppendText("エラー：" + SelectedProfiles[i] + "の適用中にエラーが発生しました。\r\n");
                    });
                    DialogResult make_error = MessageBox.Show(SelectedProfiles[i] + "でエラーが発生しました。このまま続行しますか？", "エラー", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (make_error == DialogResult.No)
                    {
                        Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                        {
                            Program.menuinstance.Console.AppendText("作業が中止されました。\r\n");
                        });
                        temp_delete();
                        make_finish();
                        return;
                    }
                }
                reader = makecmd.StandardOutput;

                while (makecmd.HasExited == false)
                {
                    while (!reader.EndOfStream)
                    {
                        readline = reader.ReadLine() + "\r\n";
                        Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                        {
                            Program.menuinstance.Console.AppendText(readline);
                        });
                    }
                }
                reader.Close();
                makecmd_started = false;
                if (makecmd.ExitCode == 1)
                {

                    Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                    {
                        Program.menuinstance.toolStripStatusLabel.Text = "エラー";
                        Program.menuinstance.Console.AppendText("エラー：" + SelectedProfiles[i] + "の適用中にエラーが発生しました。\r\n");
                    });
                    DialogResult make_error = MessageBox.Show(SelectedProfiles[i] + "でエラーが発生しました。このまま続行しますか？", "エラー", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (make_error == DialogResult.No)
                    {
                        Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                        {
                            Program.menuinstance.Console.AppendText("作業が中止されました。\r\n");
                        });
                        temp_delete();
                        make_finish();
                        return;
                    }
                }
                Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                {
                    Program.menuinstance.Console.AppendText(SelectedProfiles[i] + "の適用が完了しました。[" + (i + 1) + "/" + SelectedProfiles.Length + "]\r\n");
                    Program.menuinstance.toolStripProgressBar.Value = Program.menuinstance.toolStripProgressBar.Value + ProgressBar_Add_Value;
                });
                String[] list = Directory.GetFiles(work2);
                for (int n = 0; n < list.Length; n++)
                {
                    File.Delete(list[n]);
                }
                list = Directory.GetDirectories(work2);
                for (int n = 0; n < list.Length; n++)
                {
                    Directory.Delete(list[n],true);
                }
            }
            ProgressBar_Added_Value = Program.menuinstance.toolStripProgressBar.Value;
            Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
            {
                Program.menuinstance.Console.AppendText("すべてのプロファイルの適用が完了しました。\r\nROMをパッケージしています… [" + (SelectedProfiles.Length + 2) + "/" + Processes_Number + "]\r\n");
                Program.menuinstance.toolStripStatusLabel.Text = "ROMをパッケージしています…";
            });
            using (ZipFile zip = new ZipFile(Encoding.GetEncoding("utf-8")))
            {
                zip.CompressionLevel = CompressionLevel.None;
                zip.AddDirectory(Program.work);
                zip.Save(Program.path + "\\update-tmp.zip");
            }
            Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
            {
                Program.menuinstance.toolStripProgressBar.Value = Program.menuinstance.toolStripProgressBar.Value + ProgressBar_Add_Value;
                Program.menuinstance.Console.AppendText("パッケージしました。署名しています… [" + Processes_Number + "/" + Processes_Number + "]\r\n");
            });
            ProcessStartInfo signinfo = new ProcessStartInfo();
            signinfo.CreateNoWindow = true;
            signinfo.ErrorDialog = true;
            signinfo.FileName = "java.exe";
            signinfo.Arguments = "-jar \"" + Program.tools + "\\signapk.jar\" \"" + Program.tools + "\\testkey.x509.pem\" \"" + Program.tools + "\\testkey.pk8\" \"" + Program.path + "\\update-tmp.zip\" \"" + Program.menuinstance.SaveFile.Text + "\"";
            signinfo.RedirectStandardError = true;
            signinfo.RedirectStandardOutput = true;
            signinfo.UseShellExecute = false;
            Process sign = Process.Start(signinfo);
            if (Program.menuinstance.TempDelete.Checked == false)
            {
                update_tmp_zip_exists = false;
                temp_delete();
                Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                {
                    Program.menuinstance.Console.AppendText("完了しました。署名が完了するまで待機します。\r\n");
                });
                sign.WaitForExit();
                Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                {
                    Program.menuinstance.Console.AppendText("署名が完了しました。\r\n");
                });
                delete("ファイル","update-tmp.zip");
            }
            else
            {
                sign.WaitForExit();
                Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                {
                    Program.menuinstance.Console.AppendText("署名が完了しました。\r\n");
                });
            }
            Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
            {
                Program.menuinstance.toolStripProgressBar.Value = 256;
                Program.menuinstance.Console.AppendText("全作業が完了しました。\r\n");
            });
            make_finish();
        }
        private void temp_delete()
        {
            if (Program.menuinstance.TempDelete.Checked == false)
            {
                Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                {
                    Program.menuinstance.toolStripStatusLabel.Text = "一時ファイルを削除しています…";
                });
                delete("フォルダ","work");
                delete("フォルダ","work2");
                if (update_tmp_zip_exists == true)
                {
                    delete("ファイル", "update-tmp.zip");
                }
            }
            make_finish();
        }

        private void make_finish()
        {
            Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
            {
                Program.menuinstance.Make.Text = "作成";
                Program.menuinstance.toolStripProgressBar.Value = 0;
                Program.menuinstance.toolStripStatusLabel.Text = "";
            });
        }

        private bool delete(String type,String name)
        {
        workdel:
            Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
            {
                Program.menuinstance.toolStripStatusLabel.Text = name + type + "を削除しています…";
                Program.menuinstance.Console.AppendText(name + type + "を削除しています…\r\n");
            });
            try
            {
                if (type == "フォルダ")
                {
                    new DirectoryInfo(Program.path + "\\" + name).Delete(true);
                }
                if (type == "ファイル")
                {
                    new FileInfo(Program.path + "\\" + name).Delete();
                }
            }
            catch (IOException)
            {
                name = name + type;
                Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                {
                    Program.menuinstance.toolStripStatusLabel.Text = "エラー";
                    Program.menuinstance.Console.AppendText(name + "はアプリケーションの現在の作業" + type + "です。\r\n");
                });
                DialogResult workdelerr = MessageBox.Show(name + "はアプリケーションの現在の作業" + type + "です。\r\n" + name + "を参照しているすべてのプログラムを中止して再試行してください。", "カスタムROM改変一撃ツール", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                if (workdelerr == DialogResult.Retry)
                {
                    goto workdel;
                }
                Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                {
                    Program.menuinstance.Console.AppendText("処理がユーザーにより中止されました。\r\n");
                });
                return false;
            }
            catch (System.Security.SecurityException)
            {
                Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                {
                    Program.menuinstance.toolStripStatusLabel.Text = "エラー";
                    Program.menuinstance.Console.AppendText("呼び出し元に、必要なアクセス許可がありません。\r\n");
                });
                DialogResult workdelerr = MessageBox.Show("呼び出し元に、必要なアクセス許可がありません。", "カスタムROM改変一撃ツール", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                if (workdelerr == DialogResult.Retry)
                {
                    goto workdel;
                }
                Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                {
                    Program.menuinstance.Console.AppendText("処理がユーザーにより中止されました。\r\n");
                });
                return false;
            }
            Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
            {
                Program.menuinstance.Console.AppendText(name + type + "を削除しました\r\n");
            });
            return true;
        }

        private void zip_ExtractProgress(
        object sender, Ionic.Zip.ExtractProgressEventArgs e)
        {
            if (e.EventType ==
                Ionic.Zip.ZipProgressEventType.Extracting_EntryBytesWritten)
            {
                //エントリを展開中
                Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                {
                    Program.menuinstance.toolStripStatusLabel.Text = "展開中… " + e.BytesTransferred + "/" + e.TotalBytesToTransfer + "バイト展開しました";
                    Program.menuinstance.toolStripProgressBar.Value = (int)(ProgressBar_Add_Value / e.TotalBytesToTransfer * e.BytesTransferred);
                });
            }
        }

        private void zip_SaveProgress(
            object sender, Ionic.Zip.SaveProgressEventArgs e)
        {
            if (e.EventType ==
                Ionic.Zip.ZipProgressEventType.Saving_EntryBytesRead)
            {
                //エントリを書き込み中
                Program.menuinstance.Invoke((Menu.SetFocusDelegate)delegate()
                {
                    Program.menuinstance.toolStripStatusLabel.Text = "パッケージしています…" + e.BytesTransferred + "/" + e.TotalBytesToTransfer + "バイト 書き込みました";
                    Program.menuinstance.toolStripProgressBar.Value = (int)(ProgressBar_Add_Value / e.TotalBytesToTransfer * e.BytesTransferred + ProgressBar_Added_Value);
                });
            }
        }
    }
}
