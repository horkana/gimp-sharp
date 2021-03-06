// The PhotoshopActions plug-in
// Copyright (C) 2006-2008 Maurits Rijk
//
// Parameter.cs
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
using System.Collections.Generic;
using System.Reflection;

namespace Gimp.PhotoshopActions
{
  public abstract class Parameter
  {
    public string Name {get; set;}
    
    public abstract void Parse(ActionParser parser);
    public virtual void Fill(Object obj, FieldInfo field) {}
    public abstract IEnumerable<string> Format();

    protected string UppercaseName
    {
      get {return Abbreviations.GetUppercased(Name);}
    }

    protected bool CheckFillType(FieldInfo field)
    {
      if (field.FieldType == GetType() || 
	  GetType().IsSubclassOf(field.FieldType)) {
	return true;
      } else {
	Console.WriteLine("Parameter.Fill: " + GetType());
	Console.WriteLine("Parameter.Fill: " + field.FieldType);
	return false;
      }
    }
  }
}
