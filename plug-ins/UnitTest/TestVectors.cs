// GIMP# - A C# wrapper around the GIMP Library
// Copyright (C) 2004-2009 Maurits Rijk
//
// TestVectors.cs
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

using NUnit.Framework;

namespace Gimp
{
  [TestFixture]
  public class TestVectors
  {
    int _width = 64;
    int _height = 128;
    Image _image;

    [SetUp]
    public void Init()
    {
      _image = new Image(_width, _height, ImageBaseType.Rgb);

      var layer = new Layer(_image, "test", _width, _height,
			    ImageType.Rgb, 100, 
			    LayerModeEffects.Normal);
      _image.AddLayer(layer, 0);
    }

    [TearDown]
    public void Exit()
    {
      _image.Delete();
    }

    [Test]
    public void Constructor()
    {
      var vectors = new Vectors(_image, "firstVector");
      Assert.AreEqual("firstVector", vectors.Name);
    }

    [Test]
    public void IsValid()
    {
      var vectors = new Vectors(_image, "firstVector");
      Assert.IsTrue(vectors.IsValid);
    }

    [Test]
    public void GetImage()
    {
      var vectors = new Vectors(_image, "firstVector");
      _image.AddVectors(vectors, -1);
      Assert.AreEqual(_image, vectors.Image);
    }    

    [Test]
    public void GetSetLinked()
    {
      var vectors = new Vectors(_image, "firstVector");
      Assert.IsFalse(vectors.Linked);
      vectors.Linked = true;
      Assert.IsTrue(vectors.Linked);
    }

    [Test]
    public void GetSetTattoo()
    {
      var vectors = new Vectors(_image, "firstVector");
      var tattoo = new Tattoo(13);
      vectors.Tattoo = tattoo;
      Assert.AreEqual(tattoo, vectors.Tattoo);
    }

    [Test]
    public void GetSetVisible()
    {
      var vectors = new Vectors(_image, "firstVector");
      Assert.IsFalse(vectors.Visible);
      vectors.Visible = true;
      Assert.IsTrue(vectors.Visible);
    }

    [Test]
    public void GetSetName()
    {
      var vectors = new Vectors(_image, "firstVector");
      vectors.Name = "renamedVector";
      Assert.AreEqual("renamedVector", vectors.Name);
    }

    [Test]
    public void ParasiteAttach()
    {
      var vectors = new Vectors(_image, "firstVector");
      var parasite = new Parasite("foo", 0, 13);
      vectors.ParasiteAttach(parasite);
      Assert.AreEqual(1, vectors.ParasiteList.Count);
    }

    [Test]
    public void ParasiteDetach()
    {
      var vectors = new Vectors(_image, "firstVector");
      var parasite = new Parasite("foo", 0, 13);
      vectors.ParasiteAttach(parasite);
      vectors.ParasiteDetach(parasite);
      Assert.AreEqual(0, vectors.ParasiteList.Count);
    }

    [Test]
    public void ParasiteFind()
    {
      var vectors = new Vectors(_image, "firstVector");
      var parasite = new Parasite("foo", 0, 13);
      vectors.ParasiteAttach(parasite);
      var found = vectors.ParasiteFind("foo");
      Assert.AreEqual(parasite, found);
      Assert.IsNull(vectors.ParasiteFind("bar"));
    }

    [Test]
    public void Add()
    {
      var vectors = new Vectors(_image, "firstVector");
      Assert.AreEqual(0, _image.Vectors.Count);
      _image.AddVectors(vectors, -1);
      Assert.AreEqual(1, _image.Vectors.Count);
      Assert.IsTrue(vectors.IsValid);
    }

    [Test]
    public void Remove()
    {
      var first = new Vectors(_image, "firstVector");
      _image.AddVectors(first, -1);
      _image.RemoveVectors(first);
    }

    [Test]
    public void PositionOne()
    {
      var first = new Vectors(_image, "firstVector");
      var second = new Vectors(_image, "secondVector");
      _image.AddVectors(first, -1);
      _image.AddVectors(second, -1);
      Assert.AreEqual(1, _image.GetVectorsPosition(first));
      Assert.AreEqual(0, _image.GetVectorsPosition(second));
    }

    [Test]
    public void PositionTwo()
    {
      var first = new Vectors(_image, "firstVector");
      var second = new Vectors(_image, "secondVector");
      _image.AddVectors(first, -1);
      _image.AddVectors(second, -1);
      Assert.AreEqual(1, first.Position);
      Assert.AreEqual(0, second.Position);
    }

    [Test]
    public void LowerVectors()
    {
      var first = new Vectors(_image, "firstVector");
      var second = new Vectors(_image, "secondVector");
      _image.AddVectors(first, -1);
      _image.AddVectors(second, -1);

      _image.LowerVectors(second);
      Assert.AreEqual(0, _image.GetVectorsPosition(first));
      Assert.AreEqual(1, _image.GetVectorsPosition(second));
    }

    [Test]
    public void RaiseVectors()
    {
      var first = new Vectors(_image, "firstVector");
      var second = new Vectors(_image, "secondVector");
      _image.AddVectors(first, -1);
      _image.AddVectors(second, -1);

      _image.RaiseVectors(first);
      Assert.AreEqual(0, _image.GetVectorsPosition(first));
      Assert.AreEqual(1, _image.GetVectorsPosition(second));
    }

    [Test]
    public void LowerVectorsToBottom()
    {
      var first = new Vectors(_image, "firstVector");
      var second = new Vectors(_image, "secondVector");
      _image.AddVectors(first, -1);
      _image.AddVectors(second, -1);

      _image.LowerVectorsToBottom(second);
      Assert.AreEqual(0, _image.GetVectorsPosition(first));
      Assert.AreEqual(1, _image.GetVectorsPosition(second));
    }

    [Test]
    public void RaiseVectorsToTop()
    {
      var first = new Vectors(_image, "firstVector");
      var second = new Vectors(_image, "secondVector");
      _image.AddVectors(first, -1);
      _image.AddVectors(second, -1);

      _image.RaiseVectorsToTop(first);
      Assert.AreEqual(0, _image.GetVectorsPosition(first));
      Assert.AreEqual(1, _image.GetVectorsPosition(second));
    }

    [Test]
    public void ExportToString()
    {
      var vector = new Vectors(_image, "firstVector");
      string s = vector.ExportToString();
      Assert.IsNotNull(s);
    }
  }
}
