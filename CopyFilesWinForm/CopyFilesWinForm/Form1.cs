//----------------------------------------------------------------------------
// СОДЕРЖАНИЕ:
// - Класс Form1 - события вызываемые при взаимодествии с элементами формы,
// таймеры для обновления формы в процессе выполнения задач.

// ПРОГРАММИСТ:
//   Карпухин Г.К.
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CopyFilesWinForm
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      ExceptEmptyFolders.Checked = Properties.Settings.Default.ExceptEmptyFolders;
      SourceFolder.Text = Properties.Settings.Default.SourceFolder;
      DestinationFolder.Text = Properties.Settings.Default.DestinationFolder;
      ProgressBar.Maximum = CopyClass.Step;
      CopyClass._Log = new List<string>();
      CopyClass._OlderFiles = new List<File>();
      Timer lazy_timer = new Timer();
      lazy_timer.Tick += new EventHandler(lazy_timer_Tick);
      lazy_timer.Interval = 400;
      lazy_timer.Start();
      CopyClass.ButtonState.EnableCopySelectedButton = false;
      SwitchElements();
    }

    //Проверка пути источника и папки назначения на существование и наличие доступа.
    private bool CheckSource()
    {
      if (SourceFolder.Text != string.Empty)
      {
        DirectoryInfo tmp_directiry_info = null;
        try
        {
          tmp_directiry_info = new DirectoryInfo(SourceFolder.Text);
        }
        catch
        {
          MessageBox.Show("Не удалось получить доступ к папке источника", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          SourceFolder.Focus();
          return false;
        }
        if (tmp_directiry_info.Exists)
        {
          CopyClass.PathToSrcFolder = SourceFolder.Text;
          if (CopyClass.PathToSrcFolder[CopyClass.PathToSrcFolder.Length - 1] != '\\')
            CopyClass.PathToSrcFolder += @"\";
        }
        else
        {
          MessageBox.Show("Путь папки источника указан неверно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          SourceFolder.Focus();
          return false;
        }
      }
      else
      {
        MessageBox.Show("Не указан путь к папке источника", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        SourceFolder.Focus();
        return false;
      }

      if (DestinationFolder.Text != string.Empty)
      {
        DirectoryInfo tmp_directiry_info = null;
        try
        {
          tmp_directiry_info = new DirectoryInfo(DestinationFolder.Text);
        }
        catch
        {
          MessageBox.Show("Не удалось получить доступ к папке назначения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          DestinationFolder.Focus();
          return false;
        }
        if (tmp_directiry_info.Exists)
        {
          CopyClass.PathToDestFolder = DestinationFolder.Text;
          if (CopyClass.PathToDestFolder[CopyClass.PathToDestFolder.Length - 1] != '\\')
            CopyClass.PathToDestFolder += @"\";
        }
        else
        {
          MessageBox.Show("Путь папки назначения указан неверно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          DestinationFolder.Focus();
          return false;
        }
      }
      else
      {
        MessageBox.Show("Не указан путь к папке назначения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        DestinationFolder.Focus();
        return false;
      }
      return true;
    }

    //Актуализирует состояние элементов (их активность)
    private void SwitchElements()
    {
      CompareFolders.Enabled = CopyClass.ButtonState.EnableCompButton;
      CopySelected.Enabled = CopyClass.ButtonState.EnableCopySelectedButton;
      Copy.Enabled = CopyClass.ButtonState.EnableCopyButton;
      ChooseSourceFolder.Enabled = CopyClass.ButtonState.EnableSrcButton;
      ChooseDestinationFolder.Enabled = CopyClass.ButtonState.EnableDestButton;
      TreeViewSelectFiles.Enabled = CopyClass.ButtonState.EnableOther;
      SourceFolder.Enabled = CopyClass.ButtonState.EnableOther;
      DestinationFolder.Enabled = CopyClass.ButtonState.EnableOther;
    }

    //Выбор пути папки источника.
    private void ChooseSourceFolder_Click(object sender, EventArgs e)
    { 
      FolderBrowserDialog choose_src = new FolderBrowserDialog();
      choose_src.ShowNewFolderButton = false;
      choose_src.Description = "Выберите папку источник";
      choose_src.ShowDialog();
      if (choose_src.SelectedPath.Length != 0)
      {
        SourceFolder.Text = choose_src.SelectedPath;
      }
    }

    //Выбор пути папки назначения.
    private void ChooseDestinationFolder_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog choose_dest = new FolderBrowserDialog();
      choose_dest.ShowNewFolderButton = true;
      choose_dest.Description = "Выберите папку назначения";
      choose_dest.ShowDialog();
      if (choose_dest.SelectedPath.Length != 0)
      {
        DestinationFolder.Text = choose_dest.SelectedPath;
      }
    }

    //Уведомление о закрытие приложения.
    private void FormClosed_Click(object sender, FormClosingEventArgs e)
    {
      e.Cancel = MessageBox.Show(this, "Закрыть приложение?", "Закрытие приложения", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes;
      Properties.Settings.Default.ExceptEmptyFolders = ExceptEmptyFolders.Checked;
      Properties.Settings.Default.SourceFolder = SourceFolder.Text;
      Properties.Settings.Default.DestinationFolder = DestinationFolder.Text;
      Properties.Settings.Default.Save();
    }

    //Таймер работающий с запуска программы. Обновляет редко изменяющиеся
    //элементы интерфейса.
    private void lazy_timer_Tick(object Sender, EventArgs e)
    {
      SwitchElements();
      if (CopyClass.UpdateTree)
      {
        CopyClass.UpdateTree = false;
        if (CopyClass.Source._FilesInFolder.Count + CopyClass.Source._FoldersInFolder.Count > 0)
        {
          BuildTreeView();
          TreeViewSelectFiles.ExpandAll();
        }
        else
          CopyClass._Log.Add("Указаный источник не содержит уникальных файлов.");
        CopyClass.Progress = CopyClass.ProgressMax;
        ProgressBar.Value = ProgressBar.Maximum;
        MessageBox.Show("Сравнение папок завершено", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        CopyClass.ButtonState.SetTrue();
        CopyClass.ButtonState.EnableCopySelectedButton = true;
      }
      if (CopyClass.TaskCompleted)
      {
        CopyClass.TaskCompleted = false;
        MessageBox.Show("Копирование завершено", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      Update_Log();
    }

    //Таймер работающий в процессе выполнения поиска/копирования.
    private void progress_timer_Tick(object Sender, EventArgs e)
    {
      if (CopyClass.ProgressType)
      {
        ProgressBar.Value = CopyClass.GetCurrentInfinityProgress();
      }
      else
      {
        ProgressBar.Value = (int)((double)CopyClass.Progress / CopyClass.ProgressMax * ProgressBar.Maximum);
      }
      Update_Log();
    }

    //Обновление журнала с учетом уже выведенных.
    private void Update_Log()
    {
      if (CopyClass._Log.Count > 0)
      {
        int tmp_current_log = CopyClass.CurrentLog;
        CopyClass.CurrentLog = CopyClass._Log.Count;
        for (int i = tmp_current_log; i < CopyClass.CurrentLog; i++)
        {
          Log.Items.Add(CopyClass._Log[i]);
          Log.TopIndex = Log.Items.Count - 1;
        }
      }
    }

    //Создание корневого узла дерева и вызов рекурсивного создания всего дерева.
    private void BuildTreeView()
    {
      DirectoryInfo tmp_dir = new DirectoryInfo(CopyClass.PathToSrcFolder);
      CopyClass.Source._FolderNode = new TreeNode { Text = tmp_dir.Name, ImageIndex = 0, SelectedImageIndex = 0, StateImageIndex = 1, Checked = true };
      CopyClass.Source._FolderNode.Checked = true;
      UpdateTreeView(CopyClass.Source._FolderNode, CopyClass.Source);
      TreeViewSelectFiles.Nodes.Add(CopyClass.Source._FolderNode);
      CopyClass._Log.Add("Создание дерева файлов завершено.");
    }

    //Рекурсивное создание всего дерева.
    private void UpdateTreeView(TreeNode tmp_tree_node, Folder tmp_folder)
    {
      for (int i = 0; i < tmp_folder._FoldersInFolder.Count; i++)
      {
        tmp_tree_node.Nodes.Add(tmp_folder._FoldersInFolder[i]._FolderNode);
        UpdateTreeView(tmp_folder._FoldersInFolder[i]._FolderNode, tmp_folder._FoldersInFolder[i]);
      }
      for (int j = 0; j < tmp_folder._FilesInFolder.Count; j++)
      {
        tmp_tree_node.Nodes.Add(tmp_folder._FilesInFolder[j]._FileNode);
      }
      return;
    }

    //Событие при нажатии на кнопку "Сравнить папки".
    private void CompareFolders_Click(object sender, EventArgs e)
    {
      if (CheckSource())
      {
        CopyClass.ButtonState.SetFalse();
        CopyClass.ButtonState.EnableCopySelectedButton = false;
        CopyClass._Log.Add("Запуск сравнения папок.");
        SwitchElements();
        TreeViewSelectFiles.Nodes.Clear();
        CopyClass.Progress = 0;
        CopyClass.Step = 50000;
        CopyClass.ProgressMax = CopyClass.Step;
        ProgressBar.Maximum = CopyClass.ProgressMax;
        Timer progress_timer = new Timer();
        progress_timer.Tick += new EventHandler(progress_timer_Tick);
        progress_timer.Interval = 40;
        progress_timer.Start();
        Task.Run(() =>
        {
          CopyClass.SearchAllFiles();
          while (CopyClass.Step != 0)
          {
            CopyClass.Step -= 100;
            System.Threading.Thread.Sleep(1);
          }
          CopyClass._Log.Add("Сравнение папок завершено.");
          CopyClass._Log.Add("Создается дерево файлов.");
          CopyClass.UpdateTree = true;
          System.Threading.Thread.Sleep(500);
          progress_timer.Stop();
        });
      }
      System.Threading.Thread.Sleep(5);
    }

    //Событие при изменении CheckBox "Исключать пустые папки".
    private void ExceptEmptyFolders_CheckedChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.ExceptEmptyFolders = ExceptEmptyFolders.Checked;
      CopyClass.ExceptEmptyFolders = ExceptEmptyFolders.Checked;
    }

    //Событие при нажатии на кнопку "Копировать выбранное".
    private void CopySelected_Click(object sender, EventArgs e)
    {
      CopyClass.ButtonState.SetFalse();
      CopyClass.ButtonState.EnableCopySelectedButton = false;
      SwitchElements();
      ProgressBar.Value = 0;
      CopyClass.Step = 0;
      CopyClass.ProgressMax = CopyClass.Progress;
      ProgressBar.Maximum = CopyClass.ProgressMax;
      CopyClass.Progress = 0;
      CopyClass._Log.Add("Проверка дерева файлов.");
      TreeViewSelectFiles.UpdateAllTree();
      CopyClass._Log.Add("Запуск копирования выбранных файлов.");
      Timer progress_timer = new Timer();
      progress_timer.Tick += new EventHandler(progress_timer_Tick);
      progress_timer.Interval = 40;
      progress_timer.Start();
      Task.Run(() =>
      {
        CopyClass.CopySelectedFiles(CopyClass.Source, ref CopyClass._Log, ref CopyClass._Progress);
        CopyClass.Progress = CopyClass.ProgressMax;
        CopyClass._Log.Add("Копирование файлов завершено.");
        CopyClass.TaskCompleted = true;
        CopyClass.ButtonState.SetTrue();
        System.Threading.Thread.Sleep(500);
        progress_timer.Stop();
      });
      System.Threading.Thread.Sleep(5);
    }

    //Событие при нажатии на кнопку "Копировать всё".
    private void Copy_Click(object sender, EventArgs e)
    {
      if (CheckSource())
      {
        CopyClass.ButtonState.SetFalse();
        CopyClass.ButtonState.EnableCopySelectedButton = false;
        CopyClass._Log.Add("Запуск сравнения папок.");
        SwitchElements();
        ProgressBar.Value = 0;
        CopyClass.Step = 50000;
        CopyClass.ProgressMax = CopyClass.Step;
        ProgressBar.Maximum = CopyClass.ProgressMax * 4;
        CopyClass.Progress = 0;

        Timer progress_timer = new Timer();
        progress_timer.Tick += new EventHandler(progress_timer_Tick);
        progress_timer.Interval = 40;
        progress_timer.Start();
        Task.Run(() =>
        {
          CopyClass.SearchAllFiles();
          while (CopyClass.Step != 0)
          {
            CopyClass.Step -= 500;
            System.Threading.Thread.Sleep(1);
          }
          CopyClass._Log.Add("Сравнение папок завершено.");
          CopyClass.ProgressMax = CopyClass.Progress * 4;
          CopyClass._Log.Add("Запуск копирования файлов.");
          CopyClass.CopySelectedFiles(CopyClass.Source, ref CopyClass._Log, ref CopyClass._Progress);
          CopyClass.Progress = CopyClass.ProgressMax;
          CopyClass._Log.Add("Копирование файлов завершено.");
          CopyClass.TaskCompleted = true;
          CopyClass.ButtonState.SetTrue();
          System.Threading.Thread.Sleep(500);
          progress_timer.Stop();
        });
        System.Threading.Thread.Sleep(5);
      }
    }
  }
}