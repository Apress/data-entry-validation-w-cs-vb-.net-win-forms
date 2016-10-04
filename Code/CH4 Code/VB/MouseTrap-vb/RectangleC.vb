Option Strict On

Imports System.Drawing

Public Class RectangleC

  Public Shared Function Convert(ByVal rect As Rectangle) As Rectangle

    rect.X = rect.X - CInt((Math.Abs(rect.Width) - rect.Width) / 2)
    rect.Y = rect.Y - CInt((Math.Abs(rect.Height) - rect.Height) / 2)
    rect.Size = New Size(Math.Abs(rect.Width), Math.Abs(rect.Height))

    Return rect
  End Function

End Class
