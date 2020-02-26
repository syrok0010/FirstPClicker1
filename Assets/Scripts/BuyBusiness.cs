using Businesses;

public class BuyBusiness : Singleton<BuyBusiness>
{
    public void BuyBusinessNew(int businessIndex)
    {
        switch (businessIndex)
        {
            case 1:
                Business1.Instance.Buy(0);
                break;
            case 2:
                Business2.Instance.Buy(0);
                break;
        }

    }
}
