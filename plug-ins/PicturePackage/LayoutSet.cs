using System;
using System.Collections;

namespace Gimp.PicturePackage
{
  public class LayoutSet : IEnumerable
  {
    ArrayList _set = new ArrayList();
    
    public LayoutSet()
    {
    }
    
    public void Add(Layout layout)
    {
      _set.Add(layout);
    }
    
    public IEnumerator GetEnumerator()
    {
      return _set.GetEnumerator();
    }
    
    public Layout this[int index]
    {
      get {return (Layout) _set[index];}
    }
  }
  }
