// GIMP# - A C# wrapper around the GIMP Library
// Copyright (C) 2004-2006 Maurits Rijk
//
// Rectangle.cs
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

namespace Gimp
{
  public class Rectangle
  {
    readonly Coordinate<int> _upperLeft = new Coordinate<int>();
    readonly Coordinate<int> _lowerRight = new Coordinate<int>();

    public Rectangle(int x1, int y1, int x2, int y2)
    {
      _upperLeft.X = x1;
      _upperLeft.Y = y1;
      _lowerRight.X = x2;
      _lowerRight.Y = y2;
    }

    public Rectangle(Coordinate<int> upperLeft, Coordinate<int> lowerRight)
    {
      _upperLeft = upperLeft;
      _lowerRight = lowerRight;
    }

    public int X1
    {
      get {return _upperLeft.X;}
    }

    public int Y1
    {
      get {return _upperLeft.Y;}
    }

    public int X2
    {
      get {return _lowerRight.X;}
    }

    public int Y2
    {
      get {return _lowerRight.Y;}
    }

    public Coordinate<int> UpperLeft
    {
      get {return _upperLeft;}
    }

    public Coordinate<int> LowerRight
    {
      get {return _lowerRight;}
    }

    public int Width
    {
      get {return _lowerRight.X - _upperLeft.X;}
    }

    public int Height
    {
      get {return _lowerRight.Y - _upperLeft.Y;}
    }

    public int Area
    {
      get {return Width * Height;}
    }
  }
}