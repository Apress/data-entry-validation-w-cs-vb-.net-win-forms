Option Strict On

Imports System.ComponentModel
Imports System.Windows.Forms

<ProvideProperty("Required", GetType(Control))> _
Public Class Validator
  Inherits Component
  Implements IExtenderProvider

  Private Props As Hashtable = New Hashtable()


  Function CanExtend(ByVal target As Object) As Boolean Implements IExtenderProvider.CanExtend
    If TypeOf target Is TextBox Or TypeOf target Is ComboBox Then
      Return True
    Else
      Return False
    End If
  End Function

  Function GetRequired(ByVal ctl As Control) As Boolean
    If Props.Contains(ctl) Then
      Return CBool(Props.Item(ctl))
    Else
      Return False
    End If
  End Function


End Class
