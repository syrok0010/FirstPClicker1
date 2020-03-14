namespace Clicker.Businesses
{
    public class Business2 : Singleton<Business2>, IBuyable
    {
        public int I { get; internal set; }
        public ulong Price { get; internal set; }
        public ulong Bonus { get; internal set; }

        public void Buy(int money)
        {
            var abusiness = new ABusiness(I, 2, Price, Bonus);
            abusiness.BuyBusiness();
            I = abusiness.I;
            Price = abusiness.Price;
            Bonus = abusiness.Bonus;
            MainController.Instance.GetBonus();
        }
    }
}