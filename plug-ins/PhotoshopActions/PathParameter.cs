// The PhotoshopActions plug-in
// Copyright (C) 2006-2007 Maurits Rijk
//
// PathParameter.cs
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
using System.Reflection;

namespace Gimp.PhotoshopActions
{
  public class PathParameter : Parameter
  {
    string _path;

    public string Path
    {
      get {return _path;}
    }

    public override void Parse(ActionParser parser)
    {
      int nr1 = parser.ReadInt32();

      string txt = parser.ReadFourByteString();

      int nr2 = parser.ReadByte();

      int length = parser.ReadInt32();

      for (int i = 0; i < 2; i++)
	parser.ReadByte();

      _path = parser.ReadUnicodeString(length);
      parser.ReadByte();
    }

    public override void Fill(Object obj, FieldInfo field)
    {
      field.SetValue(obj, _path);
    }
  }
}
