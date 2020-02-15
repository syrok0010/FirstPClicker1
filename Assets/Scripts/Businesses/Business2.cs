namespace Assets.Scripts.Businesses
{
    public class Business2 : IBuyable
    {
        public int I2 { get; private set; }
        public ulong Price2 { get; private set; }
        public ulong Bonus2 { get; private set; }
        public ulong Money { get; private set; }

        public Business2(ulong money)
        {
            Money = money;
        }
        public void Buy()
        {
            ABusiness abusiness = new ABusiness(Money, I2, 1, Price2, Bonus2);
            abusiness.BuyBusiness();
            I2 = abusiness.I;
            Price2 = abusiness.Price;
            MainController.Instance.GetMoney(abusiness.Money);
            MainController.Instance.bonus1 = abusiness.Bonus;
            Bonus2 = abusiness.Bonus;
        }
    }
}