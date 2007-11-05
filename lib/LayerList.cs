// GIMP# - A C# wrapper around the GIMP Library
// Copyright (C) 2004-2007 Maurits Rijk
//
// LayerList.cs
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2 of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the
// Free Software Foundation, Inc., 59 Temple Place - Suite 330,
// Boston, MA 02111-1307, USA.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Gimp
{
  public sealed class LayerList
  {
    readonly List<Layer> _list;

    public LayerList(Image image)
    {
      int num_layers;
      IntPtr list = gimp_image_get_layers(image.ID, out num_layers);
      _list = LayerListFromPtr(list, num_layers);
    }

    internal LayerList(IntPtr ptr, int numLayers)
    {
      _list = LayerListFromPtr(ptr, numLayers);
    }

    List<Layer> LayerListFromPtr(IntPtr ptr, int numLayers)
    {
      List<Layer> list = new List<Layer>();

      if (numLayers != 0)
	{
	  int[] dest = new int[numLayers];
	  Marshal.Copy(ptr, dest, 0, numLayers);
	  
	  foreach (int layerID in dest)
	    {
	      list.Add(new Layer(layerID));
	    }
	}
      return list;
    }

    public IEnumerator<Layer> GetEnumerator()
    {
      return _list.GetEnumerator();
    }

    public int Count
    {
      get {return _list.Count;}
    }

    public Layer this[int index]
    {
      get {return _list[index];}
    }

    public Layer this[string name]
    {
      get 
	{
	  foreach (Layer layer in _list)
	    {
	      if (layer.Name == name)
		{
		  return layer;
		}
	    }
	  return null;
	}
    }

    public int GetIndex(Layer layer)
    {
      int index = 0;
      foreach (Layer l in _list)
	{
	  if (l.Name == layer.Name)
	    {
	      break;
	    }
	  index++;
	}
      return index;
    }

    [DllImport("libgimp-2.0-0.dll")]
    static extern IntPtr gimp_image_get_layers(Int32 image_ID, 
                                               out int num_layers);
  }
}
