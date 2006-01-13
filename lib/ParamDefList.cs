// GIMP# - A C# wrapper around the GIMP Library
// Copyright (C) 2004-2006 Maurits Rijk
//
// ParamDefList.cs
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

namespace Gimp
  {
    public class ParamDefList
    {
      List<ParamDef> _set;

      public ParamDefList(params ParamDef[] list)
      {
	_set = new List<ParamDef>(list);
      }

      public void Add(ParamDef p)
      {
        _set.Add(p);
      }

      public ParamDef Lookup(string name)
      {
        foreach (ParamDef p in _set)
	{
	  if (p.Name == name)
	  {
	    return p;
	  }
	}
	return null;
      }

      public object GetValue(string name)
      {
        ParamDef p = Lookup(name);
        return (p == null) ? null : p.Value;
      }
    
      public void SetValue(string name, object value)
      {
        ParamDef p = Lookup(name);
	if (p != null)
	{
	  p.Value = value;
	}
      }
    }
  }
