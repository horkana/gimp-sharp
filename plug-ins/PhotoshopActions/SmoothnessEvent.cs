// The PhotoshopActions plug-in
// Copyright (C) 2006-2012 Maurits Rijk
//
// SmoothnessEvent.cs
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
  public class SmoothnessEvent : ActionEvent
  {
    [Parameter("Rds")]
    double _radius;

    override public bool Execute()
    {
      Image image = ActiveImage;

      Layer layer = new Layer(image, "tmpLayer", ImageType.Rgba);
      image.InsertLayer(layer, 0);
      layer.EditFill(FillType.Foreground);

      Selection selection = image.Selection;
      selection.None();

      RunProcedure("plug_in_gauss", image, layer, _radius, _radius, 1);
      RunProcedure("plug_in_threshold_alpha", image, layer, 127);
      selection.LayerAlpha(layer);
      image.RemoveLayer(layer);

      return true;
    }
  }
}
