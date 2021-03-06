// The PhotoshopActions plug-in
// Copyright (C) 2006-2013 Maurits Rijk
//
// PhotoshopActions.cs
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

namespace Gimp.PhotoshopActions
{
  public class PhotoshopActions : Plugin
  {
    static void Main(string[] args)
    {
      GimpMain<PhotoshopActions>(args);
    }

    override protected Procedure GetProcedure()
    {
      var inParams = new ParamDefList();

      return new Procedure("plug_in_photoshop_actions",
			   "Play Photoshop action files",
			   "Play Photoshop action files",
			   "Maurits Rijk",
			   "(C) Maurits Rijk",
			   "2006-2013",
			   "Photoshop Actions...",
			   "",
			   inParams)
	{
	  MenuPath = "<Toolbox>/Xtns/Extensions",
	  IconFile = "PhotoshopActions.png"
	};
    }

    override protected GimpDialog CreateDialog()
    {
      gimp_ui_init("PhotoshopActions", true);
      return new Dialog(_image, _drawable, Variables);
    }

    override protected void Render(Image image, Drawable drawable)
    {
    }
  }
}
