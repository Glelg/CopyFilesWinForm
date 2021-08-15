//----------------------------------------------------------------------------
// СОДЕРЖАНИЕ:
// - Класс Folder - описывает объект папку и метод рекурсивного поиска.

// ПРОГРАММИСТ:
//   Карпухин Г.К.
//----------------------------------------------------------------------------

using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CopyFilesWinForm
{
  public class Folder
  {
    string _PathToFolder;                 //Хранит относительный путь к папке.
    DirectoryInfo _DirInfo;               //Содержит данные о папке.
    public List<Folder> _FoldersInFolder; //Список папок в данной папке.
    public List<File> _FilesInFolder;     //Список файлов в данной папке.
    public TreeNode _FolderNode;          //Узел TreeNode для элемента TreeView.

    //Конструктор создает объект папку по относительному пути к ней.
    public Folder(string path_to_folder)
    {
      _PathToFolder = path_to_folder;
      _DirInfo = new DirectoryInfo(CopyClass.PathToSrcFolder + path_to_folder);
      _FoldersInFolder = new List<Folder>();
      _FilesInFolder = new List<File>();
      _FolderNode = new TreeNode { Text = _DirInfo.Name, ImageIndex = 0, SelectedImageIndex = 0, StateImageIndex = 1, Checked = true };
    }

    public string PathToFolder
    {
      get { return _PathToFolder; }
    }

    //Функция обходит все папки вглубь добавляя к списку файлов уникальные и к 
    //списку папок только те папки, которые содержат уникальные файлы. Функция
    //возвращает результат проверки пустоты текущей папки с учетом вложенных.
    public bool SearchInDirectory(ref DirectoryInfo[] sub_dir, ref FileInfo[] files, List<string> log, ref int progress)
    {
      bool not_empty = false;     //Результат проверки пустоты текущей папки
      bool tmp_not_empty = false; //Результат проверки пустоты текущей папки с учетом вложенных
      //Обход файлов в папке.
      for (int i = 0; i < files.Length; i++)
      {
        File tmp_file = new File(files[i], PathToFolder);
        if (!tmp_file.CompareFiles())
        {
          _FilesInFolder.Add(tmp_file);
          if (!tmp_file.Relevance)
          {
            tmp_file._FileNode.ImageIndex = 3;
            tmp_file._FileNode.SelectedImageIndex = 3;
          }
        }
        progress++;
      }

      if (_FilesInFolder.Count != 0)
        not_empty = true;

      //Обход папок в папке.
      for (int i = 0; i < sub_dir.Length; i++)
      {
        DirectoryInfo[] tmp_sub_dir = null;
        FileInfo[] tmp_files = null;
        bool[] flags = CopyClass.CheckDirectory(sub_dir[i], ref tmp_sub_dir, ref tmp_files); //Проверяем есть ли доступ к содержимому папки и не пуста ли папка
        if (flags[0] && (flags[1] || !CopyClass.ExceptEmptyFolders))
        {
          Folder tmp_folder = new Folder(_PathToFolder + sub_dir[i].Name + @"\");
          tmp_not_empty = tmp_folder.SearchInDirectory(ref tmp_sub_dir, ref tmp_files, log, ref progress);
          if (tmp_not_empty)
          {
            _FoldersInFolder.Add(tmp_folder);
          }
          else if (!CopyClass.ExceptEmptyFolders)
          {
            tmp_folder._FolderNode.SelectedImageIndex = 1;
            tmp_folder._FolderNode.ImageIndex = 1;
            _FoldersInFolder.Add(tmp_folder);
          }
        }
        else
        {
          if (flags[0])
            log.Add("Найдена пустая папка: " + sub_dir[i].FullName);
          else
            log.Add("Нет доступа к папке: " + sub_dir[i].FullName);
        }
      }
      return (tmp_not_empty || not_empty);
    }
  }
}