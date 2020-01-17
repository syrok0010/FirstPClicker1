using System;

public static class AllUpgradeController
{
    static ulong money;
    public static ulong GetMoney(ulong price)
    {
        money = MainController.Instance.money;
        if (price > money) throw new Exception("Недостаточно средств");
        money -= price;
        return money;
    }
}
