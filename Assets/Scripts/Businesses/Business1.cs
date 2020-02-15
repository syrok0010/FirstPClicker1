namespace Assets.Scripts.Businesses
{
    public class Business1 : IBuyable
    {
        public int I1 { get; private set; }
        public ulong Price1 { get; private set; }
        public ulong Bonus1 { get; private set; }
        public ulong Money { get; private set; }

        public Business1(ulong money)
        {
            Money = money;
        }
        public void Buy()
        {
            var abusiness = new ABusiness(Money, I1, 1, Price1, Bonus1);
            abusiness.BuyBusiness();
            I1 = abusiness.I;
            Price1 = abusiness.Price;
            MainController.Instance.GetMoney(abusiness.Money);
            MainController.Instance.bonus1 = abusiness.Bonus;
            Bonus1 = abusiness.Bonus;
        }
    }
}