namespace Android_Custom_ROM_Modifier
{
    partial class Menu
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.BaseROMFile = new System.Windows.Forms.TextBox();
            this.BaseROMFileLabel = new System.Windows.Forms.Label();
            this.ProfileSelect = new System.Windows.Forms.CheckedListBox();
            this.ProfileSelectLabel = new System.Windows.Forms.Label();
            this.BaseROMFileSelect = new System.Windows.Forms.Button();
            this.SaveFileLabel = new System.Windows.Forms.Label();
            this.SaveFile = new System.Windows.Forms.TextBox();
            this.SaveFileSelect = new System.Windows.Forms.Button();
            this.Make = new System.Windows.Forms.Button();
            this.TempDelete = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.Console = new System.Windows.Forms.TextBox();
            this.Console_Label = new System.Windows.Forms.Label();
            this.command1 = new System.Windows.Forms.TextBox();
            this.Command = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BaseROMFile
            // 
            this.BaseROMFile.Location = new System.Drawing.Point(72, 165);
            this.BaseROMFile.Name = "BaseROMFile";
            this.BaseROMFile.Size = new System.Drawing.Size(132, 19);
            this.BaseROMFile.TabIndex = 0;
            // 
            // BaseROMFileLabel
            // 
            this.BaseROMFileLabel.AutoSize = true;
            this.BaseROMFileLabel.Location = new System.Drawing.Point(14, 168);
            this.BaseROMFileLabel.Name = "BaseROMFileLabel";
            this.BaseROMFileLabel.Size = new System.Drawing.Size(42, 12);
            this.BaseROMFileLabel.TabIndex = 1;
            this.BaseROMFileLabel.Text = "元ROM";
            // 
            // ProfileSelect
            // 
            this.ProfileSelect.FormattingEnabled = true;
            this.ProfileSelect.Location = new System.Drawing.Point(14, 28);
            this.ProfileSelect.Name = "ProfileSelect";
            this.ProfileSelect.Size = new System.Drawing.Size(257, 102);
            this.ProfileSelect.TabIndex = 2;
            // 
            // ProfileSelectLabel
            // 
            this.ProfileSelectLabel.AutoSize = true;
            this.ProfileSelectLabel.Location = new System.Drawing.Point(12, 9);
            this.ProfileSelectLabel.Name = "ProfileSelectLabel";
            this.ProfileSelectLabel.Size = new System.Drawing.Size(100, 12);
            this.ProfileSelectLabel.TabIndex = 3;
            this.ProfileSelectLabel.Text = "適用するプロファイル";
            // 
            // BaseROMFileSelect
            // 
            this.BaseROMFileSelect.Location = new System.Drawing.Point(210, 165);
            this.BaseROMFileSelect.Name = "BaseROMFileSelect";
            this.BaseROMFileSelect.Size = new System.Drawing.Size(63, 19);
            this.BaseROMFileSelect.TabIndex = 4;
            this.BaseROMFileSelect.Text = "参照";
            this.BaseROMFileSelect.UseVisualStyleBackColor = true;
            this.BaseROMFileSelect.Click += new System.EventHandler(this.BaseROMFileSelect_Click);
            // 
            // SaveFileLabel
            // 
            this.SaveFileLabel.AutoSize = true;
            this.SaveFileLabel.Location = new System.Drawing.Point(14, 195);
            this.SaveFileLabel.Name = "SaveFileLabel";
            this.SaveFileLabel.Size = new System.Drawing.Size(41, 12);
            this.SaveFileLabel.TabIndex = 5;
            this.SaveFileLabel.Text = "保存先";
            // 
            // SaveFile
            // 
            this.SaveFile.Location = new System.Drawing.Point(72, 191);
            this.SaveFile.Name = "SaveFile";
            this.SaveFile.Size = new System.Drawing.Size(132, 19);
            this.SaveFile.TabIndex = 6;
            // 
            // SaveFileSelect
            // 
            this.SaveFileSelect.Location = new System.Drawing.Point(210, 190);
            this.SaveFileSelect.Name = "SaveFileSelect";
            this.SaveFileSelect.Size = new System.Drawing.Size(62, 20);
            this.SaveFileSelect.TabIndex = 7;
            this.SaveFileSelect.Text = "参照";
            this.SaveFileSelect.UseVisualStyleBackColor = true;
            this.SaveFileSelect.Click += new System.EventHandler(this.SaveFileSelect_Click);
            // 
            // Make
            // 
            this.Make.Location = new System.Drawing.Point(197, 216);
            this.Make.Name = "Make";
            this.Make.Size = new System.Drawing.Size(75, 21);
            this.Make.TabIndex = 8;
            this.Make.Text = "作成";
            this.Make.UseVisualStyleBackColor = true;
            this.Make.Click += new System.EventHandler(this.Make_Click);
            // 
            // TempDelete
            // 
            this.TempDelete.AutoSize = true;
            this.TempDelete.Location = new System.Drawing.Point(16, 143);
            this.TempDelete.Name = "TempDelete";
            this.TempDelete.Size = new System.Drawing.Size(144, 16);
            this.TempDelete.TabIndex = 9;
            this.TempDelete.Text = "一時ファイルを削除しない";
            this.TempDelete.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 240);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(546, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(429, 17);
            this.toolStripStatusLabel.Spring = true;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // Console
            // 
            this.Console.BackColor = System.Drawing.SystemColors.HighlightText;
            this.Console.Location = new System.Drawing.Point(277, 28);
            this.Console.Multiline = true;
            this.Console.Name = "Console";
            this.Console.ReadOnly = true;
            this.Console.Size = new System.Drawing.Size(257, 167);
            this.Console.TabIndex = 11;
            // 
            // Console_Label
            // 
            this.Console_Label.AutoSize = true;
            this.Console_Label.Location = new System.Drawing.Point(275, 9);
            this.Console_Label.Name = "Console_Label";
            this.Console_Label.Size = new System.Drawing.Size(53, 12);
            this.Console_Label.TabIndex = 12;
            this.Console_Label.Text = "実行状況";
            // 
            // command1
            // 
            this.command1.Location = new System.Drawing.Point(282, 216);
            this.command1.Name = "command1";
            this.command1.Size = new System.Drawing.Size(252, 19);
            this.command1.TabIndex = 13;
            this.command1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.command_inputed);
            // 
            // Command
            // 
            this.Command.AutoSize = true;
            this.Command.Location = new System.Drawing.Point(280, 198);
            this.Command.Name = "Command";
            this.Command.Size = new System.Drawing.Size(76, 12);
            this.Command.TabIndex = 14;
            this.Command.Text = "コマンド入力欄";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 262);
            this.Controls.Add(this.Command);
            this.Controls.Add(this.command1);
            this.Controls.Add(this.Console_Label);
            this.Controls.Add(this.Console);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.TempDelete);
            this.Controls.Add(this.Make);
            this.Controls.Add(this.SaveFileSelect);
            this.Controls.Add(this.SaveFile);
            this.Controls.Add(this.SaveFileLabel);
            this.Controls.Add(this.BaseROMFileSelect);
            this.Controls.Add(this.ProfileSelectLabel);
            this.Controls.Add(this.ProfileSelect);
            this.Controls.Add(this.BaseROMFileLabel);
            this.Controls.Add(this.BaseROMFile);
            this.Name = "Menu";
            this.Text = "カスタムROM改変一撃ツール ver2.1.0.0";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox BaseROMFile;
        private System.Windows.Forms.Label BaseROMFileLabel;
        private System.Windows.Forms.CheckedListBox ProfileSelect;
        private System.Windows.Forms.Label ProfileSelectLabel;
        private System.Windows.Forms.Button BaseROMFileSelect;
        private System.Windows.Forms.Label SaveFileLabel;
        private System.Windows.Forms.TextBox SaveFile;
        private System.Windows.Forms.Button SaveFileSelect;
        private System.Windows.Forms.Button Make;
        private System.Windows.Forms.CheckBox TempDelete;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.TextBox Console;
        private System.Windows.Forms.Label Console_Label;
        private System.Windows.Forms.TextBox command1;
        private System.Windows.Forms.Label Command;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}

