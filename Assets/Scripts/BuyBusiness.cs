using System;
using Assets.Scripts.Businesses;

public class BuyBusiness : Singleton<BuyBusiness>
{
    public ulong Bonus1 { get; internal set; }
    public ulong Bonus2 { get; internal set; }
    public ulong price1 = 1;
    public ulong price2 = 1;
    private ulong _money;
    private int _i;
    public int i1 = 1;
    public int i2 = 0;
    public ulong price = 1;

    public BuyBusiness()
    {
        Bonus1 = 1;
        Bonus2 = 0;
    }

    private void GetPrice(int businessIndex)
    {
        switch (businessIndex)
        {
            case 1:
                _i = i1;
                price = price1;
                break;
            case 2:
                _i = i2;
                price = price2;
                break;
        }
    }
    
    public void BuyBusinesses(int businessIndex)
    {
        GetPrice(businessIndex);
        
        try
        {
            _money = AllUpgradeController.GetMoney(price);
            _i++;
            price = Convert.ToUInt64(Math.Round(price * (Math.E * _i)));
            switch (businessIndex)
            {
                case 1:
                    i1 = _i;
                    Bonus1 *= 2;
                    price1 = price;
                    break;
                case 2:
                    i2 = _i;
                    if (Bonus2 == 0) Bonus2 = 1;
                    Bonus2 *= 3;
                    price2 = price;
                    break;
            }

            _i = 0;

            MainController.Instance.GetMoney(_money);
            price = 0;
        }
        catch (Exception ex)
        {
            Menu.Instance.OnError();
            ShowText.Instance.OnError(ex.Message);
        }
    }

    public void BuyBusinessNew(int businessIndex)
    {
        switch (businessIndex)
        {
            case 1:
                var business = new Business1(_money);
                business.Buy();
                break;
            case 2:
                var business1 = new Business2(_money);
                business1.Buy();
                break;
        }

    }
}
