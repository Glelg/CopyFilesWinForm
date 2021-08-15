namespace CopyFilesWinForm
{
  partial class Form1
  {
    /// <summary>
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.ProgressBar = new System.Windows.Forms.ProgressBar();
      this.TreeViewSelectFiles = new CopyFilesWinForm.ExtendetTreeView();
      this.SourceFolder = new System.Windows.Forms.TextBox();
      this.DestinationFolder = new System.Windows.Forms.TextBox();
      this.ChooseSourceFolder = new System.Windows.Forms.Button();
      this.SourceFolderLabel = new System.Windows.Forms.Label();
      this.DestinationFolderLabel = new System.Windows.Forms.Label();
      this.ChooseDestinationFolder = new System.Windows.Forms.Button();
      this.CopySelected = new System.Windows.Forms.Button();
      this.Copy = new System.Windows.Forms.Button();
      this.CompareFolders = new System.Windows.Forms.Button();
      this.Log = new System.Windows.Forms.ListBox();
      this.ExceptEmptyFolders = new System.Windows.Forms.CheckBox();
      this.TreeViewLabel = new System.Windows.Forms.Label();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 4;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.Controls.Add(this.ProgressBar, 0, 4);
      this.tableLayoutPanel1.Controls.Add(this.TreeViewSelectFiles, 0, 6);
      this.tableLayoutPanel1.Controls.Add(this.SourceFolder, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.DestinationFolder, 0, 3);
      this.tableLayoutPanel1.Controls.Add(this.ChooseSourceFolder, 3, 1);
      this.tableLayoutPanel1.Controls.Add(this.SourceFolderLabel, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.DestinationFolderLabel, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.ChooseDestinationFolder, 3, 3);
      this.tableLayoutPanel1.Controls.Add(this.CopySelected, 2, 7);
      this.tableLayoutPanel1.Controls.Add(this.Copy, 3, 7);
      this.tableLayoutPanel1.Controls.Add(this.CompareFolders, 0, 7);
      this.tableLayoutPanel1.Controls.Add(this.Log, 2, 6);
      this.tableLayoutPanel1.Controls.Add(this.ExceptEmptyFolders, 2, 5);
      this.tableLayoutPanel1.Controls.Add(this.TreeViewLabel, 0, 5);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 8;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(700, 400);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // ProgressBar
      // 
      this.ProgressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
      this.tableLayoutPanel1.SetColumnSpan(this.ProgressBar, 4);
      this.ProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ProgressBar.Location = new System.Drawing.Point(4, 140);
      this.ProgressBar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
      this.ProgressBar.Name = "ProgressBar";
      this.ProgressBar.Size = new System.Drawing.Size(692, 48);
      this.ProgressBar.TabIndex = 12;
      // 
      // TreeViewSelectFiles
      // 
      this.TreeViewSelectFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
      this.tableLayoutPanel1.SetColumnSpan(this.TreeViewSelectFiles, 2);
      this.TreeViewSelectFiles.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TreeViewSelectFiles.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.TreeViewSelectFiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
      this.TreeViewSelectFiles.ImageIndex = 0;
      this.TreeViewSelectFiles.Location = new System.Drawing.Point(4, 217);
      this.TreeViewSelectFiles.Margin = new System.Windows.Forms.Padding(4, 2, 2, 2);
      this.TreeViewSelectFiles.Name = "TreeViewSelectFiles";
      this.TreeViewSelectFiles.SelectedImageIndex = 0;
      this.TreeViewSelectFiles.Size = new System.Drawing.Size(344, 150);
      this.TreeViewSelectFiles.TabIndex = 1;
      this.TreeViewSelectFiles.UpdateAll = false;
      // 
      // SourceFolder
      // 
      this.SourceFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
      this.tableLayoutPanel1.SetColumnSpan(this.SourceFolder, 3);
      this.SourceFolder.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SourceFolder.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.SourceFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
      this.SourceFolder.Location = new System.Drawing.Point(4, 42);
      this.SourceFolder.Margin = new System.Windows.Forms.Padding(4, 2, 2, 2);
      this.SourceFolder.Name = "SourceFolder";
      this.SourceFolder.Size = new System.Drawing.Size(519, 25);
      this.SourceFolder.TabIndex = 4;
      // 
      // DestinationFolder
      // 
      this.DestinationFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
      this.tableLayoutPanel1.SetColumnSpan(this.DestinationFolder, 3);
      this.DestinationFolder.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DestinationFolder.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.DestinationFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
      this.DestinationFolder.Location = new System.Drawing.Point(4, 111);
      this.DestinationFolder.Margin = new System.Windows.Forms.Padding(4, 2, 2, 2);
      this.DestinationFolder.Name = "DestinationFolder";
      this.DestinationFolder.Size = new System.Drawing.Size(519, 25);
      this.DestinationFolder.TabIndex = 5;
      // 
      // ChooseSourceFolder
      // 
      this.ChooseSourceFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
      this.ChooseSourceFolder.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ChooseSourceFolder.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.ChooseSourceFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
      this.ChooseSourceFolder.Location = new System.Drawing.Point(527, 42);
      this.ChooseSourceFolder.Margin = new System.Windows.Forms.Padding(2, 2, 4, 2);
      this.ChooseSourceFolder.Name = "ChooseSourceFolder";
      this.ChooseSourceFolder.Size = new System.Drawing.Size(169, 25);
      this.ChooseSourceFolder.TabIndex = 0;
      this.ChooseSourceFolder.Text = "Обзор";
      this.ChooseSourceFolder.UseVisualStyleBackColor = false;
      this.ChooseSourceFolder.Click += new System.EventHandler(this.ChooseSourceFolder_Click);
      // 
      // SourceFolderLabel
      // 
      this.SourceFolderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.SourceFolderLabel.AutoSize = true;
      this.SourceFolderLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.SourceFolderLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
      this.SourceFolderLabel.Location = new System.Drawing.Point(3, 20);
      this.SourceFolderLabel.Name = "SourceFolderLabel";
      this.SourceFolderLabel.Size = new System.Drawing.Size(128, 20);
      this.SourceFolderLabel.TabIndex = 6;
      this.SourceFolderLabel.Text = "Папка источника";
      // 
      // DestinationFolderLabel
      // 
      this.DestinationFolderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.DestinationFolderLabel.AutoSize = true;
      this.DestinationFolderLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.DestinationFolderLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
      this.DestinationFolderLabel.Location = new System.Drawing.Point(3, 89);
      this.DestinationFolderLabel.Name = "DestinationFolderLabel";
      this.DestinationFolderLabel.Size = new System.Drawing.Size(139, 20);
      this.DestinationFolderLabel.TabIndex = 7;
      this.DestinationFolderLabel.Text = "Папка назначения";
      // 
      // ChooseDestinationFolder
      // 
      this.ChooseDestinationFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
      this.ChooseDestinationFolder.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ChooseDestinationFolder.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.ChooseDestinationFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
      this.ChooseDestinationFolder.Location = new System.Drawing.Point(527, 111);
      this.ChooseDestinationFolder.Margin = new System.Windows.Forms.Padding(2, 2, 4, 2);
      this.ChooseDestinationFolder.Name = "ChooseDestinationFolder";
      this.ChooseDestinationFolder.Size = new System.Drawing.Size(169, 25);
      this.ChooseDestinationFolder.TabIndex = 8;
      this.ChooseDestinationFolder.Text = "Обзор";
      this.ChooseDestinationFolder.UseVisualStyleBackColor = false;
      this.ChooseDestinationFolder.Click += new System.EventHandler(this.ChooseDestinationFolder_Click);
      // 
      // CopySelected
      // 
      this.CopySelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
      this.CopySelected.Dock = System.Windows.Forms.DockStyle.Fill;
      this.CopySelected.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.CopySelected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
      this.CopySelected.Location = new System.Drawing.Point(352, 371);
      this.CopySelected.Margin = new System.Windows.Forms.Padding(2, 2, 2, 4);
      this.CopySelected.Name = "CopySelected";
      this.CopySelected.Size = new System.Drawing.Size(171, 25);
      this.CopySelected.TabIndex = 10;
      this.CopySelected.Text = "Копировать выбранное";
      this.CopySelected.UseVisualStyleBackColor = false;
      this.CopySelected.Click += new System.EventHandler(this.CopySelected_Click);
      // 
      // Copy
      // 
      this.Copy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
      this.Copy.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Copy.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.Copy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
      this.Copy.Location = new System.Drawing.Point(527, 371);
      this.Copy.Margin = new System.Windows.Forms.Padding(2, 2, 4, 4);
      this.Copy.Name = "Copy";
      this.Copy.Size = new System.Drawing.Size(169, 25);
      this.Copy.TabIndex = 11;
      this.Copy.Text = "Копировать всё";
      this.Copy.UseVisualStyleBackColor = false;
      this.Copy.Click += new System.EventHandler(this.Copy_Click);
      // 
      // CompareFolders
      // 
      this.CompareFolders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
      this.tableLayoutPanel1.SetColumnSpan(this.CompareFolders, 2);
      this.CompareFolders.Dock = System.Windows.Forms.DockStyle.Fill;
      this.CompareFolders.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.CompareFolders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
      this.CompareFolders.Location = new System.Drawing.Point(4, 371);
      this.CompareFolders.Margin = new System.Windows.Forms.Padding(4, 2, 2, 4);
      this.CompareFolders.Name = "CompareFolders";
      this.CompareFolders.Size = new System.Drawing.Size(344, 25);
      this.CompareFolders.TabIndex = 9;
      this.CompareFolders.Text = "Сравнить папки";
      this.CompareFolders.UseVisualStyleBackColor = false;
      this.CompareFolders.Click += new System.EventHandler(this.CompareFolders_Click);
      // 
      // Log
      // 
      this.Log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
      this.tableLayoutPanel1.SetColumnSpan(this.Log, 2);
      this.Log.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Log.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.Log.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
      this.Log.FormattingEnabled = true;
      this.Log.Location = new System.Drawing.Point(352, 217);
      this.Log.Margin = new System.Windows.Forms.Padding(2, 2, 4, 2);
      this.Log.Name = "Log";
      this.Log.Size = new System.Drawing.Size(344, 150);
      this.Log.TabIndex = 13;
      // 
      // ExceptEmptyFolders
      // 
      this.ExceptEmptyFolders.AutoSize = true;
      this.tableLayoutPanel1.SetColumnSpan(this.ExceptEmptyFolders, 2);
      this.ExceptEmptyFolders.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.ExceptEmptyFolders.Location = new System.Drawing.Point(352, 192);
      this.ExceptEmptyFolders.Margin = new System.Windows.Forms.Padding(2);
      this.ExceptEmptyFolders.Name = "ExceptEmptyFolders";
      this.ExceptEmptyFolders.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.ExceptEmptyFolders.Size = new System.Drawing.Size(268, 21);
      this.ExceptEmptyFolders.TabIndex = 14;
      this.ExceptEmptyFolders.Text = "Исключать пустые папки при сравнении";
      this.ExceptEmptyFolders.UseVisualStyleBackColor = true;
      this.ExceptEmptyFolders.CheckedChanged += new System.EventHandler(this.ExceptEmptyFolders_CheckedChanged);
      // 
      // TreeViewLabel
      // 
      this.TreeViewLabel.AutoSize = true;
      this.TreeViewLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.TreeViewLabel.Location = new System.Drawing.Point(3, 192);
      this.TreeViewLabel.Margin = new System.Windows.Forms.Padding(3, 2, 0, 2);
      this.TreeViewLabel.Name = "TreeViewLabel";
      this.TreeViewLabel.Size = new System.Drawing.Size(93, 17);
      this.TreeViewLabel.TabIndex = 15;
      this.TreeViewLabel.Text = "Дерево папок";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(198)))), ((int)(((byte)(218)))));
      this.ClientSize = new System.Drawing.Size(700, 400);
      this.Controls.Add(this.tableLayoutPanel1);
      this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(716, 437);
      this.Name = "Form1";
      this.Text = "Астином 1.0";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClosed_Click);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Button ChooseSourceFolder;
    private ExtendetTreeView TreeViewSelectFiles;
    private System.Windows.Forms.TextBox SourceFolder;
    private System.Windows.Forms.TextBox DestinationFolder;
    private System.Windows.Forms.Label SourceFolderLabel;
    private System.Windows.Forms.Button ChooseDestinationFolder;
    private System.Windows.Forms.Button CopySelected;
    private System.Windows.Forms.Button Copy;
    private System.Windows.Forms.Button CompareFolders;
    private System.Windows.Forms.Label DestinationFolderLabel;
    private System.Windows.Forms.ProgressBar ProgressBar;
    private System.Windows.Forms.ListBox Log;
    private System.Windows.Forms.CheckBox ExceptEmptyFolders;
    private System.Windows.Forms.Label TreeViewLabel;
  }
}

