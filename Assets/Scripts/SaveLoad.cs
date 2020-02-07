using System.IO;
using UnityEngine;
using File = UnityEngine.Windows.File;

public static class SaveLoad
{
    private static ulong Money { get; set; }
    private static ulong UpX2Bonus{ get; set; }
    private static ulong UpX3Bonus{ get; set; }
    private static ulong UpPBonus{ get; set; }
    private static ulong PriceX2{ get; set; }
    private static ulong PriceX3{ get; set; }
    private static ulong PriceP1{ get; set; }
    private static ulong PriceP5{ get; set; }
    private static ulong Bonus1{ get; set; }
    private static ulong Bonus2{ get; set; }
    private static ulong Price1{ get; set; }
    private static ulong Price2{ get; set; }
    private static int I1{ get; set; }
    private static int I2{ get; set; }
    private static bool Manager1 { get; set; }
    private static bool Manager2 { get; set; }

    private static void GetData()
    {
        Money = MainController.Instance.money;
        UpX2Bonus = UpgradeController.Instance.upX2Bonus;
        UpX3Bonus = UpgradeController.Instance.upX3Bonus;
        UpPBonus = UpgradeController.Instance.upPBonus;
        PriceX2 = UpgradeController.Instance.priceX2;
        PriceX3 = UpgradeController.Instance.priceX3;
        PriceP1 = UpgradeController.Instance.priceP1;
        PriceP5 = UpgradeController.Instance.priceP5;
        Bonus1 = BuyBusiness.Instance.Bonus1;
        Bonus2 = BuyBusiness.Instance.Bonus2;
        Price1 = BuyBusiness.Instance.price1;
        Price2 = BuyBusiness.Instance.price2;
        I1 = BuyBusiness.Instance.i1;
        I2 = BuyBusiness.Instance.i2;
        Manager1 = ManagersController.Instance.manager1;
        Manager2 = ManagersController.Instance.manager2;

    }

    public static void Save()
    {
        GetData();
        var dataForSaving = new DataForSaving(PriceP5, PriceP1, PriceX3, PriceX2, UpPBonus, UpX3Bonus, UpX2Bonus, Money, Bonus1, Bonus2, Price1, Price2, I1, I2, Manager1, Manager2);
        var inJson = JsonUtility.ToJson(dataForSaving);
        using (var write = new StreamWriter( Application.persistentDataPath + "save.json", false))
        {
            write.Write(inJson);
        }
    }

    public static void Load()
    {
        if (!File.Exists(Application.persistentDataPath + "save.json")) return;
        using (var reader = new StreamReader(Application.persistentDataPath + "save.json"))
        {
            var inJson = reader.ReadToEnd();
            var data = JsonUtility.FromJson<DataForSaving>(inJson);
            MainController.Instance.money = data.money;
            UpgradeController.Instance.upX2Bonus = data.upX2Bonus;
            UpgradeController.Instance.upX3Bonus = data.upX3Bonus;
            UpgradeController.Instance.upPBonus = data.upPBonus;
            UpgradeController.Instance.priceX2 = data.priceX2;
            UpgradeController.Instance.priceX3 = data.priceX3;
            UpgradeController.Instance.priceP1 = data.priceP1;
            UpgradeController.Instance.priceP5 = data.priceP5;
            BuyBusiness.Instance.Bonus1 = data.bonus1;
            BuyBusiness.Instance.Bonus2 = data.bonus2;
            BuyBusiness.Instance.price1 = data.price1;
            BuyBusiness.Instance.price2 = data.price2;
            BuyBusiness.Instance.i1 = data.i1;
            BuyBusiness.Instance.i2 = data.i2;

            if (data.manager1)
            {
                ManagersController.Instance.StartManager1();
            }
            if (data.manager2)
            {
                ManagersController.Instance.StartManager2();
            }
        }
    }
}