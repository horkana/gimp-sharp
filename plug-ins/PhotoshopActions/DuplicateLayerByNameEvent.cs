// The PhotoshopActions plug-in
// Copyright (C) 2006-2012 Maurits Rijk
//
// DuplicateLayerByNameEvent.cs
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

namespace Gimp.PhotoshopActions
{
  public class DuplicateLayerByNameEvent : DuplicateEvent
  {
    string _name;

    public DuplicateLayerByNameEvent(DuplicateEvent srcEvent, string name) : 
      base(srcEvent) 
    {
      _name = name;
    }

    public override string EventForDisplay
    {
      get 
	{
	  if (_name == "Bckg")
	    {
	      _name = "Background";
	      return base.EventForDisplay + " " + _name;
	    }
	  else
	    {
	      return base.EventForDisplay + " layer \"" + _name + "\"";
	    }
	}
    }

    override public bool Execute()
    {
      var layer = ActiveImage.Layers[_name];
      var newLayer = new Layer(layer);
      ActiveImage.InsertLayer(newLayer, layer.Position);
      SelectedLayer = newLayer;
      return true;
    }
  }
}
