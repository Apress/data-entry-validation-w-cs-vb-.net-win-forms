using System;
using System.Drawing;

namespace MouseTrap_c
{
  /// <summary>
  /// Converts a rectangle that starts at any corner into one that can be drawn by 
  /// the Graphics object.
  /// </summary>
	public class RectangleC
	{
    public static Rectangle Convert(Rectangle rect)
    {
      rect.X = rect.X - (Math.Abs(rect.Width) - rect.Width)/2;
      rect.Y = rect.Y - (Math.Abs(rect.Height) - rect.Height)/2;
      rect.Size = new Size(Math.Abs(rect.Width), Math.Abs(rect.Height));

      return rect;
    }
	}
}
