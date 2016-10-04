Option Strict On

Public Class Movie

  Private mName As String
  Private mSalePrice As Decimal
  Private mRentalPrice As Decimal

  Public Sub New(ByVal name As String)
    mName = name
    mSalePrice = 12.95D
    mRentalPrice = 3.4D
  End Sub

  Public ReadOnly Property Name() As String
    Get
      Return mName
    End Get
  End Property

  Public ReadOnly Property SalePrice() As Decimal
    Get
      Return mSalePrice
    End Get
  End Property

  Public ReadOnly Property RentalPrice() As Decimal
    Get
      Return mRentalPrice
    End Get
  End Property


End Class
