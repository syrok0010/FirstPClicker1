using System;

public class BuyBusiness : Singleton<BuyBusiness>
{
    public ulong Bonus1 { get; private set; }
    public ulong Bonus2 { get; private set; }
    public ulong price1 = 1;
    public ulong price2 = 1;
    private ulong _money;
    private int _i;
    public int i1 = 1;
    public int i2 = 1;
    public ulong price = 1;

    public BuyBusiness()
    {
        Bonus1 = 1;
        Bonus2 = 1;
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
                    _i = 0;
                    Bonus1 *= 2;
                    price1 = price;
                    break;
                case 2:
                    i2 = _i;
                    _i = 0;
                    Bonus2 *= 3;
                    price2 = price;
                    break;
            }

            MainController.Instance.GetMoney(_money);
            price = 0;
        }
        catch (Exception ex)
        {
            Menu.Instance.OnError();
            ShowText.Instance.OnError(ex.Message);
        }
    }
}
