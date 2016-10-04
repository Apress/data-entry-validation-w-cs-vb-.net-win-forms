Option Strict On

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Runtime.InteropServices
Imports System.IO

Public Class Form1
  Inherits System.Windows.Forms.Form

#Region "class local variables"

  <StructLayout(LayoutKind.Explicit)> _
  Public Structure UnionBenefits
    <FieldOffset(0)> Public VacationDays As Integer
    <FieldOffset(4)> Public SickDays As Integer
    <FieldOffset(0)> Public DaysOff As Double
  End Structure

  Public Structure SalaryBenefits
    Private mVacationDays As Integer
    Private mSickDays As Integer
    Public Property VacationDays() As Integer
      Get
        Return mVacationDays
      End Get
      Set(ByVal Value As Integer)
        mVacationDays = Value
      End Set
    End Property
    Public Property SickDays() As Integer
      Get
        Return mSickDays
      End Get
      Set(ByVal Value As Integer)
        mSickDays = Value
      End Set
    End Property
    Public ReadOnly Property DaysOff() As Integer
      Get
        Return mSickDays + mVacationDays
      End Get
    End Property
  End Structure

  Dim FS As FileStream
  Dim BR As BinaryReader
  Dim BW As BinaryWriter
  Dim SR As StreamReader
  Dim SW As StreamWriter

  Private Buffer(1000) As Byte

#End Region



#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'Add any initialization after the InitializeComponent() call

  End Sub

  'Form overrides dispose to clean up the component list.
  Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing Then
      If Not (components Is Nothing) Then
        components.Dispose()
      End If
    End If
    MyBase.Dispose(disposing)
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(292, 266)
    Me.Name = "Form1"
    Me.Text = "Form1"

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, _
                        ByVal e As System.EventArgs) Handles MyBase.Load

    WriteNormalBinary()
    ReadNormalBinary()

    WriteViaUnion()
    ReadViaUnion()

    WriteMemNormalBinary()
    ReadMemNormalBinary()

    WriteMemViaUnion()
    ReadMemViaUnion()

  End Sub

#Region "read/write to memory stream normal way"

  Private Sub WriteMemNormalBinary()
    Dim MS As MemoryStream = New MemoryStream(Buffer)
    BW = New BinaryWriter(MS)

    Dim x As SalaryBenefits = New SalaryBenefits()
    x.VacationDays = 36
    x.SickDays = 17
    BW.Write(x.VacationDays)
    BW.Write(x.SickDays)
    BW.Flush()
    BW.Close()

  End Sub

  Private Sub ReadMemNormalBinary()
    Dim MS As MemoryStream = New MemoryStream(Buffer)
    BR = New BinaryReader(MS)

    Dim y As SalaryBenefits = New SalaryBenefits()
    y.VacationDays = BR.ReadInt32()
    y.SickDays = BR.ReadInt32()
  End Sub

#End Region

#Region "Read/Write File via normal way"

  Private Sub WriteNormalBinary()
    FS = New FileStream("SalaryFile", FileMode.OpenOrCreate)
    BW = New BinaryWriter(FS)

    Dim x As SalaryBenefits = New SalaryBenefits()
    x.VacationDays = 82
    x.SickDays = 31
    BW.Write(x.VacationDays)
    BW.Write(x.SickDays)
    BW.Flush()
    BW.Close()

  End Sub

  Private Sub ReadNormalBinary()
    FS = New FileStream("SalaryFile", FileMode.Open)
    BR = New BinaryReader(FS)

    Dim y As SalaryBenefits = New SalaryBenefits()
    y.VacationDays = BR.ReadInt32()
    y.SickDays = BR.ReadInt32()
  End Sub

#End Region

#Region "Read/Write File via fake union"

  Private Sub WriteViaUnion()
    Dim x As UnionBenefits = New UnionBenefits()
    x.SickDays = 5
    x.VacationDays = 15

    FS = New FileStream("UnionFile", FileMode.OpenOrCreate)
    BW = New BinaryWriter(FS)
    BW.Write(x.DaysOff)
    BW.Flush()
    BW.Close()

  End Sub

  Private Sub ReadViaUnion()
    FS = New FileStream("UnionFile", FileMode.Open)

    Dim y As UnionBenefits = New UnionBenefits()
    BR = New BinaryReader(FS)
    y.DaysOff = BR.ReadDouble()

  End Sub

#End Region

#Region "read/write to memory stream via fake union"

  Private Sub WriteMemViaUnion()
    Dim x As UnionBenefits = New UnionBenefits()
    x.SickDays = 33
    x.VacationDays = 66

    Dim MS As MemoryStream = New MemoryStream(Buffer)
    BW = New BinaryWriter(MS)
    BW.Write(x.DaysOff)
    BW.Flush()
    BW.Close()

  End Sub

  Private Sub ReadMemViaUnion()
    Dim MS As MemoryStream = New MemoryStream(Buffer)

    Dim y As UnionBenefits = New UnionBenefits()
    BR = New BinaryReader(MS)
    y.DaysOff = BR.ReadDouble()

  End Sub

#End Region

End Class
