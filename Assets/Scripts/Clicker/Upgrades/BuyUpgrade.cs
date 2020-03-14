using System;

namespace Clicker.Upgrades
{
    public class BuyUpgrade : IBuyable
    {
        public BuyUpgrade(ulong price, ulong bonus, int businessIndex)
        {
            Price = price;
            Bonus = bonus;
            BusinessIndex = businessIndex;
        }

        public ulong Bonus { get; private set; }
        public ulong Price { get; private set; }
        private int BusinessIndex { get; }

        private void Check()
        {
            switch (BusinessIndex)
            {
                case 2:
                    if (Price == 0) Price = 20;
                    break;
                case 3:
                    if (Price == 0) Price = 50;
                    break;
                case 11:
                    if (Price == 0) Price = 5;
                    break;
                case 15:
                    if (Price == 0) Price = 30;
                    break;
            }
        }

        private void Change()
        {
            switch (BusinessIndex)
            {
                case 2:
                    Bonus *= 2;
                    Price *= (ulong) Math.Pow(Math.PI, Math.E) * 3;
                    break;
                case 3:
                    Bonus *= 3;
                    Price *= (ulong) Math.Pow(Math.PI, Math.E) * 7;
                    break;
                case 11:
                    Bonus += 1;
                    Price += 100 * Bonus;
                    break;
                case 15:
                    Bonus += 5;
                    Price += 700 * Bonus;
                    break;
            }
        }
        
        public void Buy(int money)
        {
            try
            {
                Check();
                if (!AllUpgradeController.GetMoney(Price)) return;
                Change();
            }
            catch (Exception ex)
            {
                Menu.Instance.OnError();
                ShowText.Instance.OnError(ex.Message);
            }
        }
    }
}