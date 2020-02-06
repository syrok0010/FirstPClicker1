using System;

public class UpgradeController : Singleton<UpgradeController>
{
    public ulong money;
    public ulong bonus;
    public void Awake()
    {
        money = MainController.Instance.money;
    }
    
    public ulong price;
    
    public ulong upX2Bonus = 1;
    public ulong upX3Bonus = 1;
    public ulong upPBonus;
    public ulong priceX2;
    public ulong priceX3;
    public ulong priceP1;
    public ulong priceP5;

    private void GetPrice(int btnIndex)
    {
        switch (btnIndex)
        {
            case 2:
                if (priceX2 == 0) priceX2 = 20; 
                price = priceX2;
                break;
            case 3:
                if (priceX3 == 0) priceX3 = 30; 
                price = priceX3;
                break;
            case 11:
                if (priceP1 == 0) priceP1 = 1;
                price = priceP1;
                break;
            case 15:
                if (priceP5 == 0) priceP5 = 10; 
                price = priceP5;
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
                    upX2Bonus *= 2;
                    break;
                case 3:
                    price *= 100;
                    priceX3 = price;
                    upX3Bonus *= 3;
                    break;
                case 11:
                    price += 5;
                    priceP1 = price;
                    upPBonus += 1;
                    break;
                case 15:
                    price += 30;
                    priceP5 = price;
                    upPBonus += 5;
                    break;
            }

            price = 0;
            bonus = 1;
            bonus = (bonus + upPBonus) * upX3Bonus * upX2Bonus;
            MainController.Instance.GetMoney(money);
        }
        catch (Exception ex)
        {
            Exceptions.Exception(ex);
        }
    }

    #region MultiplyUpgrade

    

    

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
 
 #endregion
}
