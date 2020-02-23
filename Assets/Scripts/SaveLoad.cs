using System.IO;
using Businesses;
using UnityEngine;
using File = System.IO.File;

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
    private static string DateTime { get; set; }

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
        Bonus1 = Business1.Instance.Bonus;
        Bonus2 = Business2.Instance.Bonus;
        Price1 = Business1.Instance.Price;
        Price2 = Business2.Instance.Price;
        I1 = Business1.Instance.I;
        I2 = Business2.Instance.I;
        Manager1 = ManagersController.Instance.manager1;
        Manager2 = ManagersController.Instance.manager2;
        var saveDateTime = new SaveDateTime(System.DateTime.Now.Year,System.DateTime.Now.Month, System.DateTime.Now.Day,System.DateTime.Now.Hour,System.DateTime.Now.Minute, System.DateTime.Now.Second,System.DateTime.Now.Millisecond);
        DateTime = saveDateTime.DateTimeGet();
    }

    public static void Save()
    {
        
        GetData();
        var dataForSaving = new DataForSaving(PriceP5, PriceP1, PriceX3, PriceX2, UpPBonus, UpX3Bonus, UpX2Bonus, Money, Bonus1, Bonus2, Price1, Price2, I1, I2, Manager1, Manager2, DateTime);
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
            Business1.Instance.Bonus = data.bonus1;
            Business2.Instance.Bonus = data.bonus2;
            Business1.Instance.Price = data.price1;
            Business2.Instance.Price = data.price2;
            Business1.Instance.I = data.i1;
            Business2.Instance.I = data.i2;
            OfflineController.Instance.dateTimeString = data.dateTime;

            if (!data.manager1) return;
            MainController.Instance.manager1 = true;
            Menu.Instance.manager1 = true;
            OfflineController.Instance.manager1 = true;

            if (!data.manager2) return;
            MainController.Instance.manager2 = true;
            Menu.Instance.manager2 = true;
            OfflineController.Instance.manager2 = true;
        }
    }
}