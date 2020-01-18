using System;
using UnityEngine;
using UnityEngine.Serialization;

public class BuyBusiness : Singleton<BuyBusiness>
{
    public ulong bonus = 1;
    private ulong _money;
    private int _i;
    public ulong moneyMain;
    public ulong pricePrevious;
    public int i1 = 1;
    public ulong price = 1;

    public void BuyBusinesses(int businessIndex)
    {
        
        switch (businessIndex)
        {
            case 1:
                _i = i1;
                break;
        }

        pricePrevious = price;
        moneyMain = MainController.Instance.money;
        if (moneyMain == _money) price = pricePrevious;
        try
        {
            _money = AllUpgradeController.GetMoney(price);
            _i++;
            price = Convert.ToUInt64(Math.Round(price * (Math.E * _i)));
            Debug.Log(businessIndex);
            switch (businessIndex)
            {
                case 1:
                    i1 = _i;
                    _i = 0;
                    bonus *= 2;

                    break;
            }

            pricePrevious = price;
            MainController.Instance.GetBonus();
            MainController.Instance.GetMoney(_money);
        }
        catch (Exception ex)
        {
            Menu.Instance.OnError();
            ShowText.Instance.OnError(ex.Message);
        }
    }
}
