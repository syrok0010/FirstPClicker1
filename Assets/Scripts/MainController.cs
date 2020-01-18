using System;

public class MainController : Singleton<MainController>
{
    public ulong money;
    public ulong bonus = 1;

    public void GetMoney(ulong money)
    {
        this.money = money;
    }
    public void GetBonus()
    {
        this.bonus = BuyBusiness.Instance.bonus * UpgradeController.Instance.bonus;
    }
    public void BonusCount(int btnIndex)
    {
        UpgradeController.Instance.ShopBtn(btnIndex);
    }

    public void MultiplyUpgrade(string multUpgrade)
    {
        var results = UpgradeController.Instance.MultiplyUpgrade(multUpgrade).Split(new char[] { '/' });
        bonus = Convert.ToUInt64(results[0]);
        money = Convert.ToUInt64(results[1]);
    }

    public void OnClick()
    {
        money += bonus;
    }
}
