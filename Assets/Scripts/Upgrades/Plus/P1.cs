using UnityEngine;

namespace Upgrades
{
    public class P1 : Singleton<P1>, IBuyable
    {
        public ulong Bonus { get; internal set; }
        public ulong Price { get; internal set; }
        
        private void Awake()
        {
            if (Bonus == 0) Bonus = 1;
        }
        
        public void Buy(int money)
        {
            var buyUpgrade = new BuyUpgrade(Price, Bonus, 11);
            buyUpgrade.Buy(0);
            Bonus = buyUpgrade.Bonus;
            Price = buyUpgrade.Price;
            MainController.Instance.GetBonus();
            Debug.Log(Price);
            Debug.Log(Bonus);
        }
    }
}