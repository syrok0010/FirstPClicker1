using System;

public static class AllUpgradeController
{
    private static ulong _money;
    public static bool GetMoney(ulong price)
    {
        _money = MainController.Instance.money;
        if (price > _money)
        {
            throw new Exception("Недостаточно средств");
        }

        _money -= price;
        MainController.Instance.GetMoney(_money);
        return true;
    }
}
