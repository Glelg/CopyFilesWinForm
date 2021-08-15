//----------------------------------------------------------------------------
// СОДЕРЖАНИЕ:
// - Расширение класса TreeView классом ExtendetTreeView.

// ПРОГРАММИСТ:
//   Карпухин Г.К.
//----------------------------------------------------------------------------

using System.Windows.Forms;


namespace CopyFilesWinForm
{
  //Класс ExtendetTreeView является расширение класса System.Windows.Forms.TreeView
  //Класс содержит логику трех состояний checkbox и методы для автоматического 
  //изменения статуса дочерних и родительских узлов
  public class ExtendetTreeView : TreeView
  {
    bool _IgnoreChange = false; //Переменная запрещает вызов OnAfterCheck если он вызван не пользователем
    bool _UpdateAll = false;    //Переменная отвечает за принудительной обновление всех нераскрытых узлов

    public bool UpdateAll
    {
      get { return _UpdateAll; }
      set { _UpdateAll = value; }
    }

    public ExtendetTreeView() : base()
    {
      ImageList icons = new ImageList();
      icons.Images.Add(Properties.Resources.FullFolder);
      icons.Images.Add(Properties.Resources.EmptyFolder);
      icons.Images.Add(Properties.Resources.File);
      icons.Images.Add(Properties.Resources.FileOld);
      ImageList checkbox = new ImageList();
      checkbox.Images.Add(Properties.Resources.CheckBoxFalse);
      checkbox.Images.Add(Properties.Resources.CheckBoxTrue);
      checkbox.Images.Add(Properties.Resources.CheckBoxMiddle);
      ImageList = icons;
      StateImageList = checkbox;
    }

    protected override void OnCreateControl()
    {
      base.OnCreateControl();
      CheckBoxes = false;
    }

    protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
    {
      base.OnNodeMouseClick(e);
      TreeViewHitTestInfo info = HitTest(e.X, e.Y);
      if (info == null || info.Location != System.Windows.Forms.TreeViewHitTestLocations.StateImage)
      {
        return;
      }
      _IgnoreChange = false;
      e.Node.Checked = !e.Node.Checked;
    }

    protected override void OnAfterCheck(System.Windows.Forms.TreeViewEventArgs e)
    {
      base.OnAfterCheck(e);
      System.Windows.Forms.TreeNode tn = e.Node;
      if (!_IgnoreChange) //Если изменение узла вызванно не пользователем, оно не запускает обход детей и родителей узла.
      {
        _IgnoreChange = true;
        e.Node.StateImageIndex = e.Node.Checked ? 1 : 0; //Изменение картинки у измененного пользователем узла.
        UpdateChild(e.Node);
        UpdateParent(e.Node);
      }
    }

    protected override void OnAfterExpand(System.Windows.Forms.TreeViewEventArgs e)
    {
      base.OnAfterExpand(e);
      if (!_IgnoreChange)
      {
        _IgnoreChange = true;
        UpdateChild(e.Node);
        _IgnoreChange = false;
      }
    }

    //Устанавливает всем потомкам значение checked родителя
    private void UpdateChild(TreeNode current) 
    {
      if (current.Nodes != null)
      {
        for (int i = 0; i < current.Nodes.Count; i++)
        {
          if (current.StateImageIndex != 2)
          {
            current.Nodes[i].Checked = current.Checked;
            current.Nodes[i].StateImageIndex = current.StateImageIndex;
          }
          if ((current.Nodes[i].IsExpanded) || (UpdateAll))
            UpdateChild(current.Nodes[i]);
        }
      }
    }

    //Устанавливает родителям значение checked текущего узла
    private void UpdateParent(TreeNode current)
    {
      if (current.Parent != null)
      {
        bool check = current.Parent.Nodes[0].Checked;
        current.Parent.Checked = check;
        current.Parent.StateImageIndex = current.Parent.Checked ? 1 : 0;
        for (int i = 0; i < current.Parent.Nodes.Count; i++)
        {
          if ((current.Parent.Nodes[i].StateImageIndex == 2) || (check ^ current.Parent.Nodes[i].Checked))
          {
            current.Parent.Checked = true;
            current.Parent.StateImageIndex = 2;
            break;
          }
        }
        UpdateParent(current.Parent);
      }
    }

    //Обновляет все дерево
    public void UpdateAllTree()
    {
      UpdateAll = true;
      UpdateChild(Nodes[0]);
      UpdateAll = false;
    }
  }
}
