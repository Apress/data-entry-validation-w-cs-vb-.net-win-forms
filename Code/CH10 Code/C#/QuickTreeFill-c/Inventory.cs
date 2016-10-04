using System;
using System.Collections;

namespace QuickTreeFill_c
{
	/// <summary>
	/// Summary description for Inventory.
	/// </summary>
	/// 

  public struct Brand
  {
    public Brand(string name)
    {
      BrandName = name;
    }
    public string BrandName;
  }

  public class Toys
  {
    public Items BatteryPowered  = new Items(1000, "BatteryPowered");
    public Items Electronic      = new Items(500,  "Electronic");
    public Items BoardGames      = new Items(1000,  "BoardGames");
    public Items Video           = new Items(2000, "Video");
    public Items Models          = new Items(1000,  "Models");
    public Items Plush           = new Items(3000, "Plush");
    public Items ActionFigures   = new Items(250,  "ActionFigures");

    public struct Items
    {
      public ArrayList Brands;
      public Items(int amount, string kind)
      {
        Brands = new ArrayList();
        for(int k=0; k<amount; k++)
          Brands.Add(new Brand(kind + " Brand " + k.ToString()));
      }
    }
  }

  public class Clothing
  {
    public Items Footware   = new Items(500,  "Footware");
    public Items Jackets    = new Items(600,   "Jackets");
    public Items Tops       = new Items(4800,  "Tops");
    public Items Pants      = new Items(1000, "Pants");
    public Items Underwear  = new Items(100,   "Underwear");
    public Items GlovesHats = new Items(5000,  "GlovesHats");
    public Items Sweaters   = new Items(2000,  "Sweaters");

    public struct Items
    {
      public ArrayList Brands;
      public Items(int amount, string kind)
      {
        Brands = new ArrayList();
        for(int k=0; k<amount; k++)
          Brands.Add(new Brand(kind + " Brand " + k.ToString()));
      }
    }
  }

}
