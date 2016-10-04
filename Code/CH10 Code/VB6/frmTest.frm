VERSION 5.00
Object = "{6B7E6392-850A-101B-AFC0-4210102A8DA7}#1.3#0"; "COMCTL32.OCX"
Begin VB.Form frmTest 
   Caption         =   "Form1"
   ClientHeight    =   8055
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   5055
   LinkTopic       =   "Form1"
   ScaleHeight     =   8055
   ScaleWidth      =   5055
   StartUpPosition =   2  'CenterScreen
   Begin VB.TextBox txtMax 
      Height          =   285
      Left            =   240
      TabIndex        =   6
      Top             =   5280
      Width           =   1815
   End
   Begin VB.CommandButton cmdClear 
      Caption         =   "Clear"
      Height          =   375
      Left            =   240
      TabIndex        =   2
      Top             =   6960
      Width           =   4455
   End
   Begin VB.CommandButton cmdFill 
      Caption         =   "Fill"
      Height          =   375
      Left            =   240
      TabIndex        =   1
      Top             =   5760
      Width           =   4455
   End
   Begin ComctlLib.TreeView Tree 
      Height          =   4575
      Left            =   240
      TabIndex        =   0
      Top             =   240
      Width           =   4455
      _ExtentX        =   7858
      _ExtentY        =   8070
      _Version        =   327682
      Style           =   7
      Appearance      =   1
   End
   Begin VB.Label Label2 
      Caption         =   "Max Nodes to fill at one time"
      Height          =   255
      Left            =   240
      TabIndex        =   5
      Top             =   5040
      Width           =   3855
   End
   Begin VB.Label lblClear 
      BorderStyle     =   1  'Fixed Single
      Height          =   375
      Left            =   240
      TabIndex        =   4
      Top             =   7440
      Width           =   4455
   End
   Begin VB.Label lblFill 
      BorderStyle     =   1  'Fixed Single
      Height          =   375
      Left            =   240
      TabIndex        =   3
      Top             =   6240
      Width           =   4455
   End
End
Attribute VB_Name = "frmTest"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Dim tmr As Single

Private Sub cmdClear_Click()
  Dim Count As Long
  
  Count = Tree.Nodes.Count
  MousePointer = vbHourglass
  DoEvents
  tmr = Timer
  Tree.Nodes.Clear
  
  lblClear.Caption = (Timer - tmr) & " seconds to clear " & Count & " Nodes)"
  MousePointer = vbNormal
  
End Sub

Private Sub cmdFill_Click()
  Dim k     As Integer
  Dim Count As Long
  Dim max   As Long
  
  MousePointer = vbHourglass
  DoEvents
  max = Val(txtMax.Text)
  Count = Tree.Nodes.Count
  tmr = Timer
  For k = Count To Count + max
    Tree.Nodes.Add , , "Key" & k, "Node " & k
  Next
  
  lblFill.Caption = (Timer - tmr) & " seconds to fill " & max & " Nodes)"
  MousePointer = vbNormal
  
End Sub

Private Sub Form_Load()
  txtMax = 1000
End Sub

Private Sub txtMax_KeyPress(KeyAscii As Integer)

  If KeyAscii < 48 Or KeyAscii > 57 Then
    KeyAscii = 0
  End If
  
End Sub
