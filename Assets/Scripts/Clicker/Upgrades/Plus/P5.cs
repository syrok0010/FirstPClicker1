namespace Clicker.Upgrades.Plus
{
    public class P5 : Singleton<P5>, IBuyable
    {
        public ulong Bonus { get; internal set; }
        public ulong Price { get; internal set; }
        private void Awake()
        {
            if (Bonus == 0) Bonus = 1;
        }
        
        public void Buy(int money)
        {
            var buyUpgrade = new BuyUpgrade(Price, Bonus, 15);
            buyUpgrade.Buy(0);
            Bonus = buyUpgrade.Bonus;
            Price = buyUpgrade.Price;
            MainController.Instance.GetBonus();
        }
        
    }
}