Option Strict On

Imports System
Imports System.Collections
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Text.RegularExpressions

<ProvideProperty("Required", GetType(Control)), _
 ProvideProperty("RegularExpression", GetType(Control))> _
Public Class RegxValidate
  Inherits Component
  Implements IExtenderProvider

#Region "locals"

  ' holds Key - value pair for efficient retrieval
  'Holds all properties of all controls that use this extender.
  Private CustomProps As System.Collections.Hashtable = _
                                 New System.Collections.Hashtable()

  Private er As ErrorProvider = New ErrorProvider()
  Private tp As ToolTip = New ToolTip()

  'Holds all the custom properties of a control
  Private Class Props
    Public Required As Boolean = False
    Public Regx As String = ".*"
  End Class

#End Region

  Public Sub New()

  End Sub

  Function CanExtend(ByVal target As Object) As _
                     Boolean Implements IExtenderProvider.CanExtend
    'Target can be anything; like a ComboBox if needed
    'Target can be multiple things also
    If TypeOf target Is TextBox Then
      Return True
    Else
      Return False
    End If
  End Function

#Region "Required property"

  Public Function GetRequired(ByVal ctl As Control) As Boolean
    If CustomProps.Contains(ctl) Then
      Dim p As Props = CType(CustomProps(ctl), Props)
      SetToolTip(ctl)
      Return p.Required
    End If
    Return False
  End Function

  Public Sub SetRequired(ByVal ctl As Control, ByVal val As Boolean)
    If CustomProps.Contains(ctl) Then
      Dim p As Props = CType(CustomProps(ctl), Props)
      If val = p.Required Then
        Return
      End If

      p.Required = val
      CustomProps(ctl) = p
      SetToolTip(ctl)
      If val Then
        AddHandler ctl.Validating, _
                  New CancelEventHandler(AddressOf ValidateProp)
      Else
        RemoveHandler ctl.Validating, _
                  New CancelEventHandler(AddressOf ValidateProp)
      End If
    Else
      Dim p As Props = New Props()
      p.Required = val

      CustomProps.Add(ctl, p)
      SetToolTip(ctl)
      AddHandler ctl.Validating, New CancelEventHandler(AddressOf ValidateProp)
    End If
  End Sub

#End Region

#Region "Regular Expression property"

  Public Function GetRegularExpression(ByVal ctl As Control) As String
    If CustomProps.Contains(ctl) Then
      Dim p As Props = CType(CustomProps(ctl), Props)
      SetToolTip(ctl)
      Return p.Regx
    Else
      Return ".*"
    End If
  End Function

  <DefaultValue("")> _
  Public Sub SetRegularExpression(ByVal ctl As Control, ByVal val As String)
    'Put something here to verify that regular expression is valid
    Try
      Regex.IsMatch("abcdefg", val)
    Catch e As Exception
      Dim err As String = "Invalid Regular Expression on:" + vbCrLf
      err += ctl.Name + vbCrLf + vbCrLf + e.Message
      MessageBox.Show(err)
      er.SetError(ctl, "Invalid Regular Expression!!")
      Return
    End Try

    If CustomProps.Contains(ctl) Then
      Dim p As Props = CType(CustomProps(ctl), Props)
      p.Regx = val
      CustomProps(ctl) = p
    Else
      Dim p As Props = New Props()
      p.Regx = val
      CustomProps.Add(ctl, p)
    End If
    SetToolTip(ctl)
  End Sub

#End Region

#Region "events"

  Private Sub ValidateProp(ByVal sender As Object, ByVal e As CancelEventArgs)
    Dim ctl As Control = CType(sender, Control)

    'Reset the error
    er.SetError(ctl, "")

    If GetRequired(ctl) Then
      Dim p As Props = CType(CustomProps(ctl), Props)
      If Not Regex.IsMatch(ctl.Text, p.Regx) Then
        er.SetError(ctl, "Value did not match input restrictions")
      End If
      Return
    End If
  End Sub

#End Region

#Region "other stuff"

  Private Sub SetToolTip(ByVal ctl As Control)
    Dim tip As String = String.Empty
    tp.Active = False
    SetTooltipActive()
    Dim p As Props = CType(CustomProps(ctl), Props)
    If p.Required Then
      tip = "Regular Expression validation: " + p.Regx
    End If
    tp.SetToolTip(ctl, tip)
  End Sub

  <Conditional("DEBUG")> _
  Private Sub SetTooltipActive()
    tp.Active = True
  End Sub

#End Region

End Class
