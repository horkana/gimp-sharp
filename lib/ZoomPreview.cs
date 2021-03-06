// GIMP# - A C# wrapper around the GIMP Library
// Copyright (C) 2004-2013 Maurits Rijk
//
// ZoomPreview.cs
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
using System.Runtime.InteropServices;

namespace Gimp
{
  public class ZoomPreview : ScrolledPreview
  {
    public Drawable Drawable {get; private set;}

    public ZoomPreview(Drawable drawable) : 
      base(gimp_zoom_preview_new(drawable.Ptr))
    {
      Drawable = drawable;
    }

    public ZoomPreview(Drawable drawable, ZoomModel model) : 
      base(gimp_zoom_preview_new_with_model(drawable.Ptr, model.Ptr))
    {
      Drawable = drawable;
    }

    // Fix me: implement GetSource

    public double Factor
    {
      get {return gimp_zoom_preview_get_factor(Handle);}
    }

    public ZoomModel Model
    {
      get {return new ZoomModel(gimp_zoom_preview_get_model(Handle));}
    }

    [DllImport("libgimpui-2.0-0.dll")]
      extern static IntPtr gimp_zoom_preview_new(IntPtr drawable);
    [DllImport("libgimpui-2.0-0.dll")]
      extern static IntPtr gimp_zoom_preview_new_with_model(IntPtr drawable,
							    IntPtr model);
    [DllImport("libgimpui-2.0-0.dll")]
      extern static double gimp_zoom_preview_get_factor(IntPtr preview);
    [DllImport("libgimpui-2.0-0.dll")]
      extern static IntPtr gimp_zoom_preview_get_source(IntPtr preview,
							out int width,
							out int height,
							out int bpp);
    [DllImport("libgimpui-2.0-0.dll")]
      extern static IntPtr gimp_zoom_preview_get_model(IntPtr preview);
  }
}
