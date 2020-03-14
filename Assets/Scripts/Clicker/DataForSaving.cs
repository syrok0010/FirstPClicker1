namespace Clicker
{
    [System.Serializable]
    public class DataForSaving
    {
        public DataForSaving(ulong priceP5, ulong priceP1, ulong priceX3, ulong priceX2, ulong upP1Bonus, ulong upP5Bonus, ulong upX3Bonus, ulong upX2Bonus,
            ulong money,
            ulong bonus1, ulong bonus2, ulong price1, ulong price2, int i1, int i2, bool manager1, bool manager2, string dateTime)
        {
            this.priceP5 = priceP5;
            this.priceP1 = priceP1;
            this.priceX3 = priceX3;
            this.priceX2 = priceX2;
            this.upP1Bonus = upP1Bonus;
            this.upX3Bonus = upX3Bonus;
            this.upX2Bonus = upX2Bonus;
            this.money = money;
            this.bonus1 = bonus1;
            this.bonus2 = bonus2;
            this.price1 = price1;
            this.price2 = price2;
            this.i1 = i1;
            this.i2 = i2;
            this.manager1 = manager1;
            this.manager2 = manager2;
            this.dateTime = dateTime;

        }

        public ulong money;
        public ulong upX2Bonus;
        public ulong upX3Bonus;
        public ulong upP1Bonus;
        public ulong upP5Bonus;
        public ulong priceX2;
        public ulong priceX3;
        public ulong priceP1;
        public ulong priceP5;
        public ulong bonus1;
        public ulong bonus2;
        public ulong price1;
        public ulong price2;
        public int i1;
        public int i2;
        public bool manager1;
        public bool manager2;
        public string dateTime;
    }
}
