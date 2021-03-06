// The PhotoshopActions plug-in
// Copyright (C) 2006-2007 Maurits Rijk
//
// GradientMapEvent.cs
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

using System.Collections;

namespace Gimp.PhotoshopActions
{
  public class GradientMapEvent : ActionEvent
  {
    [Parameter("Grad")]
    ObjcParameter _gradient;
    [Parameter("Nm")]
    string _name;

    protected override IEnumerable ListParameters()
    {
      _gradient.Fill(this);
      yield return "Name: " + _name;
    }

    override public bool Execute()
    {
      Gradient gradient = _gradient.GetGradient();

      Context.Push();
      Context.Gradient = gradient;
      RunProcedure("plug_in_gradmap");
      Context.Pop();

      gradient.Delete();

      return true;
    }
  }
}
