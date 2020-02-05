using System;

public class MainController : Singleton<MainController>
{
    public ulong money;
    public ulong bonus1 = 1;
    public ulong bonus2 = 3;

    public void Update()
    {
        GetBonus();
    }

    public void Awake()
    {
        SaveLoad.Load();
    }

    public void OnApplicationPause(bool pauseStatus)
    {
        SaveLoad.Save();
    }

    public void OnApplicationQuit()
    {
        SaveLoad.Save();
    }

    public void GetMoney(ulong moneyGet)
    {
        money = moneyGet;
    }

    private void GetBonus()
    {
        bonus1 = UpgradeController.Instance.bonus * BuyBusiness.Instance.Bonus1;
        bonus2 = UpgradeController.Instance.bonus * BuyBusiness.Instance.Bonus2 * 3;
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
                money += bonus1;
                break;
            case 2:
                money += bonus2;
                break;
        }
    }
}
