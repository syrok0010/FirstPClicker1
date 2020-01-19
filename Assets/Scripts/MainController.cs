using System;

public class MainController : Singleton<MainController>
{
    public ulong money;
    public ulong bonus1 = 1;
    public ulong bonus2 = 3;

    public void GetMoney(ulong money)
    {
        this.money = money;
    }
    public ulong GetBonus(int businessIndex)
    {
        switch (businessIndex)
        {
            case 1:
                bonus1 = UpgradeController.Instance.bonus * BuyBusiness.Instance.bonus1;
                return bonus1;
            case 2:
                bonus2 = UpgradeController.Instance.bonus * BuyBusiness.Instance.bonus2;
                return bonus2;
        }

        return 0;
    }
    public void BonusCount(int btnIndex)
    {
        UpgradeController.Instance.ShopBtn(btnIndex);
    }

    //public void MultiplyUpgrade(string multUpgrade)
   // {
        //var results = UpgradeController.Instance.MultiplyUpgrade(multUpgrade).Split(new char[] { '/' });
      //  bonus = Convert.ToUInt64(results[0]);
    //    money = Convert.ToUInt64(results[1]);
  //  }

    public void OnClick(int businessIndex)
    {
        switch (businessIndex)
        {
            case 1:
                
                money += GetBonus(1);;
                break;
            case 2:
                money += GetBonus(2);;
                break;
        }
    }
}
