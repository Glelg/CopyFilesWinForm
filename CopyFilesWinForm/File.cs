//----------------------------------------------------------------------------
// СОДЕРЖАНИЕ:
// - Класс File - описывает объект файл и метод сравнения файлов.
// ПРОГРАММИСТ:
//   Карпухин Г.К.
//----------------------------------------------------------------------------

using System;
using System.IO;
using System.Windows.Forms;

namespace CopyFilesWinForm
{
  public class File
  {
    string _PathToFile;       //Относительный путь к файлу.
    public TreeNode _FileNode;//Узел TreeNode для TreeView.
    FileInfo _FileInfo;       //Содержит данные о файле.
    bool _Existence;          //Статус существование файла с таким же названием в папке назначения
    bool _Relevance;          //Статус актуальности файла в источнике.

    //Конструктор создает объект File по объекту FileInfo и относительному пути.
    
    //Выделение относительного пути необходима для сравнения файла из источника
    //с файлом из папки назначения. 
    //Объект FileInfo создается до вызова конструктора File. Поэтому, чтобы 
    //не повторять создание FileInfo того же файла, конструктор принимает 
    //как параметр объект FileInfo.
    public File(FileInfo tmp_file_info, string path_to_file)
    {
      _FileInfo = tmp_file_info;
      _PathToFile = path_to_file;
      _Existence = true;
      _Relevance = true;
      _FileNode = new TreeNode { Text = _FileInfo.Name, ImageIndex = 2, SelectedImageIndex = 2, StateImageIndex = 1, Checked = true };
      _FileNode.Checked = true;
    }

    public string PathToFile
    {
      get { return _PathToFile; }
      set { _PathToFile = value; }
    }

    public bool Existence
    {
      get { return _Existence; }
      set { _Existence = value; }
    }

    public bool Relevance
    {
      get { return _Relevance; }
      set { _Relevance = value; }
    }

    public FileInfo FileInfo
    {
      get { return _FileInfo; }
    }

    //Функция сравнивает файлы и возвращает true если они равны и false если различны
    public bool CompareFiles()
    {
      FileInfo tmp_file_info = null;
      try
      {
        tmp_file_info = new FileInfo(CopyClass.PathToDestFolder + _PathToFile + @"\" + _FileInfo.Name);
      }
      catch 
      { 
        return false; 
      }
      if (!tmp_file_info.Exists)
      {
        Existence = false;
        return false;
      }
      if (_FileInfo.Length != tmp_file_info.Length)
        return false;
      if (_FileInfo.LastWriteTime != tmp_file_info.LastWriteTime)
      {
        if (_FileInfo.LastWriteTime < tmp_file_info.LastWriteTime)
          Relevance = false;
        return false;
      }
        
      return true;
    }
  }
}