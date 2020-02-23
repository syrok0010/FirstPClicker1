using Businesses;

public class BuyBusiness : Singleton<BuyBusiness>
{

    private ulong _money;
    public void Awake()
    {
        _money = MainController.Instance.money;
    }

    public void BuyBusinessNew(int businessIndex)
    {
        switch (businessIndex)
        {
            case 1:
                Business1.Instance.Buy(_money);
                break;
            case 2:
                Business2.Instance.Buy(_money);
                break;
        }

    }
}
