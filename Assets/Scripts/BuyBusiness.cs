using System;

public class BuyBusiness : Singleton<BuyBusiness>
{
    public ulong bonus1 = 1;
    public ulong bonus2 = 1;
    public ulong price1 = 1;
    public ulong price2 = 1;
    private ulong _money;
    private int _i;
    public ulong moneyMain;
    public ulong pricePrevious;
    public int i1 = 1;
    public int i2 = 1;
    public ulong price = 1;

    public void BuyBusinesses(int businessIndex)
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
                    bonus1 *= 2;
                    price1 = price;
                    break;
                case 2:
                    i2 = _i;
                    _i = 0;
                    bonus2 *= 3;
                    price2 = price;
                    break;
            }

            pricePrevious = price;
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
