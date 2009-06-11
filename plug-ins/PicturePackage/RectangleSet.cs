// The PicturePackage plug-in
// Copyright (C) 2004-2009 Maurits Rijk, Massimo Perga
//
// RectangleSet.cs
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.
//

using System;
using System.Collections;
using System.Collections.Generic;

namespace Gimp.PicturePackage
{
  public class RectangleSet 
  {
    readonly List<Rectangle> _set = new List<Rectangle>();

    public RectangleSet()
    {
    }

    public IEnumerator<Rectangle> GetEnumerator()
    {
      return _set.GetEnumerator();
    }

    public void Add(Rectangle rectangle)
    {
      _set.Add(rectangle);
    }

    public Rectangle this[int index]
    {
      get {return _set[index];}
    }

    public Rectangle Find(Coordinate<double> c)
    {
      return _set.Find(rectangle => rectangle.Inside(c));
    }

    public bool Render(ProviderFactory factory, Renderer renderer)
    {
      bool retVal = false;
      factory.Reset();
      foreach (Rectangle rectangle in _set)
	{
	  var provider = rectangle.Provider;

	  if (provider == null)
	    {
	      provider = factory.Provide();
	      if (provider == null)
		{
		  break;
		}
	      var image = provider.GetImage();
	      if (image == null)
		{
//		  Console.WriteLine("Couldn't load image!");
		}
	      else
		{
		  rectangle.Render(image, renderer);
		  retVal = true;
		}
	      factory.Cleanup(provider);
	    }
	  else
	    {
	      rectangle.Render(provider.GetImage(), renderer);
	      provider.Release();
	      retVal = true;
	    }
	}
      factory.Cleanup();
      renderer.Cleanup();
      return retVal;
    }

    public int Count
    {
      get {return _set.Count;}
    }
  }
}
