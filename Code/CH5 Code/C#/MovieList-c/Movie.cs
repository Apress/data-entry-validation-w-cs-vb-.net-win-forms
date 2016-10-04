using System;

namespace MovieList_c
{
  /// <summary>
  /// Summary description for Movie.
  /// </summary>
  public class Movie
  {
    private string  mName;
    private Decimal mSalePrice;
    private Decimal mRentalPrice;

    public Movie(string name)
    {
      mName  = name;
      mSalePrice = 12.95m;
      mRentalPrice = 3.40m;
    }

    public string  Name        { get { return mName; } }
    public Decimal SalePrice   { get { return mSalePrice; } }
    public Decimal RentalPrice { get { return mRentalPrice; } }
  }
}
