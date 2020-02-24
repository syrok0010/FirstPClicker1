namespace Businesses
{
    public class Business1 : Singleton<Business1>, IBuyable
    {
        public int I { get; internal set; }
        public ulong Price { get; internal set; }
        public ulong Bonus { get; internal set; }

        public void Buy(ulong money)
        {
            var abusiness = new ABusiness( I, 1, Price, Bonus);
            abusiness.BuyBusiness();
            I = abusiness.I;
            Price = abusiness.Price;
            MainController.Instance.bonus1 = abusiness.Bonus;
            Bonus = abusiness.Bonus;
        }
    }
}