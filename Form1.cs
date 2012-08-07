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
        }
    }
}
