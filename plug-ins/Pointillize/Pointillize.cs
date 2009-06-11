// The Pointillize plug-in
// Copyright (C) 2006-2009 Maurits Rijk
//
// Pointillize.cs
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

using Gtk;

namespace Gimp.Pointillize
{
  class Pointillize : PluginWithPreview
  {
    [SaveAttribute("cell_size")]
    int _cellSize = 30;

    ColorCoordinateSet _coordinates;

    static void Main(string[] args)
    {
      new Pointillize(args);
    }

    public Pointillize(string[] args) : base(args, "Pointillize")
    {
    }

    override protected IEnumerable<Procedure> ListProcedures()
    {
      var inParams = new ParamDefList()
	{
	  new ParamDef("cell_size", 30, typeof(int), "Cell size")
	};

      yield return new Procedure("plug_in_pointillize",
				 _("Create pointillist paintings"),
				 _("Create pointillist paintings"),
				 "Maurits Rijk",
				 "(C) Maurits Rijk",
				 "2006-2009",
				 _("Pointillize..."),
				 "RGB*, GRAY*",
				 inParams)
	{
	  MenuPath = "<Image>/Filters/Artistic",
	  IconFile = "Pointillize.png"
	};
    }

    override protected GimpDialog CreateDialog()
    {
      var dialog = DialogNew(_("Pointillize"), _("Pointillize"), 
			     IntPtr.Zero, 0, Gimp.StandardHelpFunc, 
			     _("Pointillize"));

      var table = new GimpTable(1, 3, false);

      var entry = new ScaleEntry(table, 0, 1, _("Cell _Size:"), 150, 3,
				 _cellSize, 3.0, 300.0, 1.0, 8.0, 0);
      entry.ValueChanged += delegate
	{
	  _cellSize = entry.ValueAsInt;
	  InvalidatePreview();
	};

      Vbox.PackStart(table, false, false, 0);
      
      return dialog;
    }

    override protected void UpdatePreview(AspectPreview preview)
    {
      Initialize(_drawable);
      preview.Update(DoPointillize);
    }

    override protected void Render(Drawable drawable)
    {
      Initialize(drawable);

      var iter = new RgnIterator(drawable, _("Pointillize"));
      iter.IterateDest(DoPointillize);
    }

    void Initialize(Drawable drawable)
    {
      _coordinates = new ColorCoordinateSet(drawable, _cellSize);
    }

    Pixel DoPointillize(int x, int y)
    {
      return _coordinates.GetColor(new Coordinate<int>(x, y));
    }
  }
}
