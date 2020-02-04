using System;

public static class AllUpgradeController
{
    private static ulong _money;
    public static ulong GetMoney(ulong price)
    {
        _money = MainController.Instance.money;
        if (price > _money) throw new Exception("Недостаточно средств");
        _money -= price;
        return _money;
    }
}
