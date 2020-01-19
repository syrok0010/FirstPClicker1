using System;
using UnityEngine.Serialization;

public class UpgradeController : Singleton<UpgradeController>
{
    public ulong money;
    public ulong bonus;
    public void Awake()
    {
        money = MainController.Instance.money;
    }
    
    public ulong price;
    public ulong priceX2X10;
    
    public ulong upX2Bonus = 1;
    public ulong upX3Bonus = 1;
    public ulong upPBonus;
    public ulong priceX2;
    public ulong priceX3;
    public ulong priceP1;
    public ulong priceP5;
    public ulong coef;
    public string result;
    [FormerlySerializedAs("Action")] public string action;

    private void GetPrice(int btnIndex)
    {
        switch (btnIndex)
        {
            case 2:
                action = "*";
                coef = 2;
                if (priceX2 == 0)
                {
                    priceX2 = 20;
                    price = priceX2;
                }
                else price = priceX2;
                break;
            case 3:
                action = "*";
                coef = 3;
                if (priceX3 == 0)
                {
                    priceX3 = 30;
                    price = priceX3;
                }
                else price = priceX3;
                break;
            case 11:
                action = "+";
                coef = 1;
                if (priceP1 == 0)
                {
                    priceP1 = 1;
                    price = priceP1;
                }
                else price = priceP1;
                break;
            case 15:
                action = "+";
                coef = 5;
                if (priceP5 == 0)
                {
                    priceP5 = 10;
                    price = priceP5;
                }
                else price = priceP5;
                break;
        }
    }
    public void ShopBtn(int btnIndex)
    {
        GetPrice(btnIndex);

        try
        {
            money = AllUpgradeController.GetMoney(price);

            switch (btnIndex)
            {
                case 2:
                    price *= 50;
                    priceX2 = price;
                    price = 0;
                    upX2Bonus *= coef;
                    break;
                case 3:
                    price *= 100;
                    priceX3 = price;
                    price = 0;
                    upX3Bonus *= coef;
                    break;
                case 11:
                    price += 5;
                    priceP1 = price;
                    price = 0;
                    upPBonus += coef;
                    break;
                case 15:
                    price += 30;
                    priceP5 = price;
                    price = 0;
                    upPBonus += coef;
                    break;
            }
            bonus = 1;
            bonus = (bonus + upPBonus) * upX3Bonus * upX2Bonus;
            MainController.Instance.GetMoney(money);
        }
        catch (Exception ex)
        {
            Menu.Instance.OnError();
            ShowText.Instance.OnError(ex.Message);
        }
    }

 //   public ulong MultiplyGetPrice(int multiplier)
 //   {
 //       for (int i = 1; i <= multiplier; i++)
 //       {
 //          price = 0;
 //           price += priceX2;
 //           price *= 2;
 //       }
 //
 //       return price;
 //   }

 //   public string MultiplyUpgrade(string multUpgrade)
 //   {
 //       var results = multUpgrade.Split(new char[] {'.'});
 //       var multiplier = Convert.ToInt32(results[0]);
 //       var btnIndex = Convert.ToInt32(results[1]);
 //       GetPrice(btnIndex);
 //       price = MultiplyGetPrice(multiplier);
 //       if (money >= price)
 //       {
 //           
 //           for (var i = 0; i < multiplier; i++)
 //           {
 //               ShopBtn(btnIndex);
 //           }
 //       }
 //       else
 //       {
 //           throw new Exception("Недостаточно средств");
 //       }
 //       return result;
 //   }
}
