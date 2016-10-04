Option Strict On

Imports System
Imports System.Collections
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Text.RegularExpressions

<ProvideProperty("Required", GetType(Control)), _
 ProvideProperty("RangeValueRequired", GetType(Control)), _
 ProvideProperty("MinValue", GetType(Control)), _
 ProvideProperty("MaxValue", GetType(Control))> _
Public Class NumberValidate
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
    Public RangeRequired As Boolean = False
    Public MinVal As Decimal = 0
    Public MaxVal As Decimal = 999
  End Class

#End Region

  Public Sub New()

  End Sub

  Function CanExtend(ByVal target As Object) As Boolean _
                     Implements IExtenderProvider.CanExtend
    If TypeOf target Is TextBox Then
      Dim t As TextBox = CType(target, TextBox)
      tp.Active = True
      Return True
    Else
      Return False
    End If
  End Function

  Private Sub SetToolTip(ByVal ctl As Control)
    Dim tip As String = String.Empty
    Dim p As Props = CType(CustomProps(ctl), Props)
    If p.Required Then
      tip = "Validation of numbers required"
    End If
    If p.RangeRequired Then
      tip += " / Number range required"
      tip += " / Min value = " + p.MinVal.ToString()
      tip += " / Max value = " + p.MaxVal.ToString()
    End If
    tp.SetToolTip(ctl, tip)
  End Sub


#Region "RangeValue required"

  'Get method for range required
  Public Function GetRangeValueRequired(ByVal ctl As Control) As Boolean
    'This makes best use of a hashtable for quick retrieval
    If CustomProps.Contains(ctl) Then
      Dim p As Props = CType(CustomProps(ctl), Props)
      SetToolTip(ctl)
      Return p.RangeRequired
    End If
    Return False
  End Function

  'Set method for Range required
  Public Sub SetRangeValueRequired(ByVal ctl As Control, ByVal val As Boolean)
    If CustomProps.Contains(ctl) Then
      'See if this property is already correctly set
      Dim p As Props = CType(CustomProps(ctl), Props)
      If val = p.RangeRequired Then
        Return
      End If

      'Set this property and add it back to the list
      p.RangeRequired = val
      CustomProps(ctl) = p
      If val Then
        AddHandler ctl.KeyPress, _
                  New KeyPressEventHandler(AddressOf KeyPress)
        AddHandler ctl.Validating, _
                  New CancelEventHandler(AddressOf ValidateProp)
      Else
        RemoveHandler ctl.KeyPress, _
                  New KeyPressEventHandler(AddressOf KeyPress)
        RemoveHandler ctl.Validating, _
                  New CancelEventHandler(AddressOf ValidateProp)
      End If
      SetToolTip(ctl)
    Else
      'Set this property and add it to the list
      Dim p As Props = New Props()
      p.RangeRequired = val
      CustomProps.Add(ctl, p)
      If val Then
        AddHandler ctl.KeyPress, New KeyPressEventHandler(AddressOf KeyPress)
      End If
      SetToolTip(ctl)
    End If
  End Sub

#End Region

#Region "Min and Max Values"

  Public Function GetMinValue(ByVal ctl As Control) As Decimal
    If CustomProps.Contains(ctl) Then
      Dim p As Props = CType(CustomProps(ctl), Props)
      SetToolTip(ctl)
      Return p.MinVal
    End If
    Return 0
  End Function

  '   <DefaultValue(0)>_
  Public Sub SetMinValue(ByVal ctl As Control, ByVal val As Decimal)
    If val < 0 Then val = 0

    If CustomProps.Contains(ctl) Then
      Dim p As Props = CType(CustomProps(ctl), Props)
      p.MinVal = val
      CustomProps(ctl) = p
      SetToolTip(ctl)
    Else
      Dim p As Props = New Props()
      p.MinVal = val
      CustomProps.Add(ctl, p)
      SetToolTip(ctl)
    End If
  End Sub

  Public Function GetMaxValue(ByVal ctl As Control) As Decimal
    If (CustomProps.Contains(ctl)) Then
      Dim p As Props = CType(CustomProps(ctl), Props)
      SetToolTip(ctl)
      Return p.MaxVal
    End If
    Return 999
  End Function

  ' [DefaultValue(999)]
  Public Sub SetMaxValue(ByVal ctl As Control, ByVal val As Decimal)
    If val > 999 Then val = 999

    If CustomProps.Contains(ctl) Then
      Dim p As Props = CType(CustomProps(ctl), Props)
      p.MaxVal = val
      CustomProps(ctl) = p
      SetToolTip(ctl)
    Else
      Dim p As Props = New Props()
      p.MaxVal = val
      CustomProps.Add(ctl, p)
      SetToolTip(ctl)
    End If
  End Sub

#End Region

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
        AddHandler ctl.KeyPress, _
                  New KeyPressEventHandler(AddressOf KeyPress)
        AddHandler ctl.Validating, _
                  New CancelEventHandler(AddressOf ValidateProp)
      Else
        RemoveHandler ctl.KeyPress, _
                  New KeyPressEventHandler(AddressOf KeyPress)
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

#Region "events"

  Private Sub KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
    'Allow backspace
    If e.KeyChar = Chr(8) Then
      Return
    End If

    'Allow 0-9
    If Not Regex.IsMatch(e.KeyChar.ToString(), "[0-9]") Then
      e.Handled = True
    End If
  End Sub

  Private Sub ValidateProp(ByVal sender As Object, ByVal e As CancelEventArgs)
    Dim ctl As Control = CType(sender, Control)

    'Reset the error
    er.SetError(ctl, "")

    If GetRequired(ctl) Then
      If ctl.Text = String.Empty Then
        er.SetError(ctl, "No value was entered when one was required")
        Return
      End If

      If GetRangeValueRequired(ctl) Then
        Dim p As Props = CType(CustomProps(ctl), Props)
        If Decimal.Parse(ctl.Text) < p.MinVal Then
          er.SetError(ctl, "Value entered is less than minimum value")
        End If
        If Decimal.Parse(ctl.Text) > p.MaxVal Then
          er.SetError(ctl, "Value entered is greater than minimum value")
        End If
      End If
    End If
  End Sub

#End Region

End Class
