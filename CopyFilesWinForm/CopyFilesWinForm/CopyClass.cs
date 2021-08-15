//----------------------------------------------------------------------------
// СОДЕРЖАНИЕ:
// - Класс CopyClass - переменные и методы, используемые для связи элементов
// формы и алгоритмов. 
// - Подкласс ButtonState - переменные и методы для упрощения блокировки
// элементов формы.

// ПРОГРАММИСТ:
//   Карпухин Г.К.
//----------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;

namespace CopyFilesWinForm
{
  //Длительные процессы работают в параллельном потоке, для их корректного
  //выполнения, данные из формы дублируются в отдельные переменные. Данный класс
  //является контейнером для таких переменных и связанных с ними методами.
  static class CopyClass
  {
    static string _PathToSrcFolder;         //Путь к папке источнику.
    static string _PathToDestFolder;        //Путь к папке назначения.
    static Folder _Source;                  //Базовый объект Folder.
    static public List<string> _Log;        //Журнал выполнения программы и ошибок.
    static int _CurrentLog;                 //Номер текущей строки журнала.
    static public int _Progress = 0;        //Счётчик выполненных операций.
    static int _ProgressMax = 10000;        //Максимальное значение ProgressBar.
    static int _Step = 10000;               //Переменная определяет масштаб ProgressBar в процессах неопределенной продолжительности.
    static bool _UpdateTree = false;        //Статус необходимости обновления TreeView.
    static bool _ProgressType = false;      //Выбор типа ProgressBar неопределенной продолжительности или конечной длины.
    static bool _ExceptEmptyFolders = false;//Статус необходимости исключения пустых папок.
    static bool _TaskCompleted = false;     //Статус состояния выполнения процесса.
    static public List<File> _OlderFiles;   //Список файлов где источник содержит более старую версию.

    //Данный подкласс служит для упрощения блокировки элементов во время
    //выполнения процесса.
    public static class ButtonState
    {
      static bool _EnableSrcButton = true;
      static bool _EnableDestButton = true;
      static bool _EnableCompButton = true;
      static bool _EnableCopyButton = true;
      static bool _EnableCopySelectedButton = true;
      static bool _EnableOther = true;

      //Блокировка элементов формы.
      static public void SetFalse()
      {
        EnableSrcButton = false;
        EnableDestButton = false;
        EnableCompButton = false;
        EnableCopyButton = false;
        EnableOther = false;
      }

      //Разблокировка элементов формы.
      static public void SetTrue()
      {
        EnableSrcButton = true;
        EnableDestButton = true;
        EnableCompButton = true;
        EnableCopyButton = true;
        EnableOther = true;
      }

      //Свойства полей класса ButtonState.
      static public bool EnableSrcButton
      {
        get { return _EnableSrcButton; }
        set { _EnableSrcButton = value; }
      }

      static public bool EnableDestButton
      {
        get { return _EnableDestButton; }
        set { _EnableDestButton = value; }
      }

      static public bool EnableCompButton
      {
        get { return _EnableCompButton; }
        set { _EnableCompButton = value; }
      }

      static public bool EnableCopyButton
      {
        get { return _EnableCopyButton; }
        set { _EnableCopyButton = value; }
      }

      static public bool EnableCopySelectedButton
      {
        get { return _EnableCopySelectedButton; }
        set { _EnableCopySelectedButton = value; }
      }

      static public bool EnableOther
      {
        get { return _EnableOther; }
        set { _EnableOther = value; }
      }
    }

    //Свойства полей класса CopyClass
    static public string PathToSrcFolder
    {
      get { return _PathToSrcFolder; }
      set { _PathToSrcFolder = value; }
    }

    static public string PathToDestFolder
    {
      get { return _PathToDestFolder; }
      set { _PathToDestFolder = value; }
    }

    static public Folder Source
    {
      get { return _Source; }
      set { _Source = value; }
    }

    static public int CurrentLog
    {
      get { return _CurrentLog; }
      set { _CurrentLog = value; }
    }

    static public bool UpdateTree
    {
      get { return _UpdateTree; }
      set { _UpdateTree = value; }
    }

    static public bool ProgressType
    {
      get { return _ProgressType; }
      set { _ProgressType = value; }
    }

    static public int Progress
    {
      get { return _Progress; }
      set { _Progress = value; }
    }

    static public int ProgressMax
    {
      get { return _ProgressMax; }
      set { _ProgressMax = value; }
    }

    static public int Step
    {
      get { return _Step; }
      set { _Step = value; }
    }
    
    static public bool ExceptEmptyFolders
    {
      get { return _ExceptEmptyFolders; }
      set { _ExceptEmptyFolders = value; }
    }

    static public bool TaskCompleted
    {
      get { return _TaskCompleted; }
      set { _TaskCompleted = value; }
    }

    //Функция получает на вход папку, проверят доступ к ее содержимому и 
    //наличие папок и файлов в ней.
    static public bool[] CheckDirectory(DirectoryInfo tmp_dir, ref DirectoryInfo[] tmp_sub_dir, ref FileInfo[] tmp_files)
    {
      bool[] results = { true, false }; //Результаты проверки первое значение - наличие доступа, второе - наличие содержимого.
      try
      {
        tmp_sub_dir = tmp_dir.GetDirectories();
        if (tmp_sub_dir.Length > 0)
        {
          results[1] = true;
        }
      }
      catch
      {
        results[0] = false;
        return results;
      }

      try
      {
        tmp_files = tmp_dir.GetFiles();
        if (tmp_files.Length > 0)
        {
          results[1] = true;
          return results;
        }
      }
      catch
      {
        results[0] = false;
      }
      return results;
    }

    //Функция проверяет источник и запускает для него рекурсивный поиск вглубь.
    static public void SearchAllFiles()
    {
      ProgressType = true;
      DirectoryInfo tmp_dir = new DirectoryInfo(PathToSrcFolder);
      DirectoryInfo[] tmp_sub_dir = null;
      FileInfo[] tmp_files = null;
      bool[] flags = CheckDirectory(tmp_dir, ref tmp_sub_dir, ref tmp_files);
      if (flags[0] && flags[1])
      {
        _Source = new Folder("");
        _Source.SearchInDirectory(ref tmp_sub_dir, ref tmp_files, _Log, ref _Progress);
      }      
    }

    //Функция рекурсивно копирует все файлы и папки, находящиеся в списке на копирование.
    static public void CopySelectedFiles(Folder tmp_folder, ref List<string> log, ref int progress)
    {
      ProgressType = false;
      for (int i = 0; i < tmp_folder._FilesInFolder.Count; i++)
      {
        if (tmp_folder._FilesInFolder[i]._FileNode.Checked)
        {
          tmp_folder._FilesInFolder[i].FileInfo.CopyTo(PathToDestFolder + tmp_folder._FilesInFolder[i].PathToFile + @"\" + tmp_folder._FilesInFolder[i].FileInfo.Name, true);
        }
        progress++;
      }
      for (int i = 0; i < tmp_folder._FoldersInFolder.Count; i++)
      {
        if (tmp_folder._FoldersInFolder[i]._FolderNode.StateImageIndex != 0)
        {
          DirectoryInfo tmp_dir_info = new DirectoryInfo(PathToDestFolder + tmp_folder._FoldersInFolder[i].PathToFolder);
          if (!tmp_dir_info.Exists)
            tmp_dir_info.Create();
          CopySelectedFiles(tmp_folder._FoldersInFolder[i], ref log, ref progress);
        }
      }
    }

    //Функция рассчитывает размер шкалы ProgressBar для процесса 
    //неопределенной продолжительности.
    static public int GetCurrentInfinityProgress()
    {
      return (int)((double)_Progress / (_Step + _Progress + 1) * _ProgressMax) + 1;
    }
  }
}