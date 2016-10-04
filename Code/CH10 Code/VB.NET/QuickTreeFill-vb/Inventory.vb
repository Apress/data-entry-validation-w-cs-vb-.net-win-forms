Option Strict On

Imports System.Collections


Public Structure Brand
  Public Sub New(ByVal name As String)
    BrandName = name
  End Sub
  Public BrandName As String
End Structure

Public Class Toys
  Public BatteryPowered As Items = New Items(1000, "BatteryPowered")
  Public Electronic As Items = New Items(500, "Electronic")
  Public BoardGames As Items = New Items(1000, "BoardGames")
  Public Video As Items = New Items(2000, "Video")
  Public Models As Items = New Items(1000, "Models")
  Public Plush As Items = New Items(3000, "Plush")
  Public ActionFigures As Items = New Items(250, "ActionFigures")

  Public Structure Items
    Public Brands As ArrayList
    Public Sub New(ByVal amount As Int32, ByVal kind As String)
      Brands = New ArrayList()
      Dim k As Int32
      For k = 0 To amount
        Brands.Add(New Brand(kind + " Brand " + k.ToString()))
      Next
    End Sub
  End Structure
End Class

Public Class Clothing
  Public Footware As Items = New Items(500, "Footware")
  Public Jackets As Items = New Items(600, "Jackets")
  Public Tops As Items = New Items(4800, "Tops")
  Public Pants As Items = New Items(1000, "Pants")
  Public Underwear As Items = New Items(100, "Underwear")
  Public GlovesHats As Items = New Items(5000, "GlovesHats")
  Public Sweaters As Items = New Items(2000, "Sweaters")

  Public Structure Items
    Public Brands As ArrayList
    Public Sub New(ByVal amount As Int32, ByVal kind As String)
      Brands = New ArrayList()
      Dim k As Int32
      For k = 0 To amount
        Brands.Add(New Brand(kind + " Brand " + k.ToString()))
      Next
    End Sub
  End Structure
End Class
