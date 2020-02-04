using System.IO;
using UnityEngine;

public class SaveLoad
{
    private static ulong _money;
    private static ulong _upX2Bonus;
    private static ulong _upX3Bonus;
    private static ulong _upPBonus;
    private static ulong _priceX2;
    private static ulong _priceX3;
    private static ulong _priceP1;
    private static ulong _priceP5;
    private static ulong _bonus1;
    private static ulong _bonus2;
    private static ulong _price1;
    private static ulong _price2;
    private static int _i1;
    private static int _i2;

    private static void GetData()
    {
        _money = MainController.Instance.money;
        _upX2Bonus = UpgradeController.Instance.upX2Bonus;
        _upX3Bonus = UpgradeController.Instance.upX3Bonus;
        _upPBonus = UpgradeController.Instance.upPBonus;
        _priceX2 = UpgradeController.Instance.priceX2;
        _priceX3 = UpgradeController.Instance.priceX3;
        _priceP1 = UpgradeController.Instance.priceP1;
        _priceP5 = UpgradeController.Instance.priceP5;
        _bonus1 = BuyBusiness.Instance.Bonus1;
        _bonus2 = BuyBusiness.Instance.Bonus2;
        _price1 = BuyBusiness.Instance.price1;
        _price2 = BuyBusiness.Instance.price2;
        _i1 = BuyBusiness.Instance.i1;
        _i2 = BuyBusiness.Instance.i2;
    }

    public void Save()
    {
        GetData();
        var dataForSaving = new DataForSaving(_priceP5, _priceP1, _priceX3, _priceX2, _upPBonus, _upX3Bonus, _upX2Bonus, _money, _bonus1, _bonus2, _price1, _price2, _i1, _i2);
        var inJson = JsonUtility.ToJson(dataForSaving);
        using (var write = new StreamWriter("save.json", false))
        {
            write.Write(inJson);
        }
        Debug.Log("Wrote");
    }
    
    
}