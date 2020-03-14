using System;

namespace Clicker
{
    public class ABusiness
    {
        private int BusinessIndex {get;}

        public int I { get; private set; }
        public ulong Price { get; private set; }
        public ulong Bonus { get; private set; }


        public ABusiness(int i, int businessIndex, ulong price, ulong bonus)
        {
            I = i;
            BusinessIndex = businessIndex;
            Price = price;
            Bonus = bonus;
            if (Bonus == 0) Bonus = 1;
        }
        private void Change()
        {
            I++;
            switch (BusinessIndex)
            {
                case 1:
                    Price *= (ulong)Math.Round(Math.Pow(Math.E, Math.PI) * 3 * I);
                    Bonus *= (ulong)Math.E;

                    break;
                case 2:
                    Price *= (ulong)Math.Round(Math.Pow(Math.E, Math.PI) * 5 * I);
                    Bonus *= (ulong)Math.E * 2;
                    break;
            }
        }

        private void Check()
        {
            if (Price == 0) Price = 1;
            if (Bonus == 0) Bonus = 1;
        }

        public void BuyBusiness()
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
