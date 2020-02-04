public class MainController : Singleton<MainController>
{
    public ulong money;
    public ulong bonus1 = 1;
    public ulong bonus2 = 3;

    public void OnApplicationPause(bool pauseStatus)
    {
        var saveLoad = new SaveLoad();
        saveLoad.Save();
    }

    public void GetMoney(ulong moneyGet)
    {
        money = moneyGet;
    }

    private ulong GetBonus(int businessIndex)
    {
        switch (businessIndex)
        {
            case 1:
                bonus1 = UpgradeController.Instance.bonus * BuyBusiness.Instance.Bonus1;
                return bonus1;
            case 2:
                bonus2 = UpgradeController.Instance.bonus * BuyBusiness.Instance.Bonus2;
                return bonus2;
        }

        return 0;
    }
    public void BonusCount(int btnIndex)
    {
        UpgradeController.Instance.ShopBtn(btnIndex);
    }

    #region InDevelopment

    //public void MultiplyUpgrade(string multUpgrade)
    // {
    //var results = UpgradeController.Instance.MultiplyUpgrade(multUpgrade).Split(new char[] { '/' });
    //  bonus = Convert.ToUInt64(results[0]);
    //     money = Convert.ToUInt64(results[1]);
    //  }

    #endregion
   

    public void OnClick(int businessIndex)
    {
        switch (businessIndex)
        {
            case 1:
                
                money += GetBonus(1);
                break;
            case 2:
                money += GetBonus(2);
                break;
        }
    }
}
