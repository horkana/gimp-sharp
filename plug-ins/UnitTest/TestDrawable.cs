// GIMP# - A C# wrapper around the GIMP Library
// Copyright (C) 2004-2007 Maurits Rijk
//
// TestDrawable.cs
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

using NUnit.Framework;

namespace Gimp
{
  [TestFixture]
  public class TestDrawable
  {
    int _width = 64;
    int _height = 128;
    Image _image;
    Drawable _drawable;

    [SetUp]
    public void Init()
    {
      _image = new Image(_width, _height, ImageBaseType.Rgb);

      Layer layer = new Layer(_image, "test", _width, _height,
			      ImageType.Rgb, 100, 
			      LayerModeEffects.Normal);
      _image.AddLayer(layer, 0);

      _drawable = _image.ActiveDrawable;
    }

    [TearDown]
    public void Exit()
    {
      _image.Delete();
    }

    [Test]
    public void NewDrawable()
    {
      Assert.IsNotNull(_drawable);
      Assert.AreEqual(_image, _drawable.Image);
    }

    [Test]
    public void WidthAndHeight()
    {
      Assert.AreEqual(_drawable.Width, _width);
      Assert.AreEqual(_drawable.Height, _height);
    }

    [Test]
    public void IsColorType()
    {
      Assert.IsTrue(_drawable.IsRGB);
      Assert.IsFalse(_drawable.IsGray);
      Assert.IsFalse(_drawable.IsIndexed);
    }

    [Test]
    public void Name()
    {
      Assert.AreEqual(_drawable.Name, "test");
    }

    [Test]
    public void HasAlpha()
    {
      Assert.IsFalse(_drawable.HasAlpha);
    }

    [Test]
    public void Offsets()
    {
      Offset offset = _drawable.Offsets;
      Assert.AreEqual(0, offset.X);
      Assert.AreEqual(0, offset.Y);      
    }

    [Test]
    public void Fill()
    {
      // Fill with some color
      RGB foreground = new RGB(22, 55, 77);
      Context.Push();
      Context.Foreground = foreground;
      _drawable.Fill(FillType.Foreground);
      Context.Pop();

      using (PixelFetcher pf = new PixelFetcher(_drawable, false))
	{
	  Pixel pixel = pf[_height / 2, _width / 2];
	  Assert.AreEqual(foreground, pixel.Color);
	}
    }
  }
}
