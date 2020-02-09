using System;
using System.Linq;

public class OfflineController : Singleton<OfflineController>
{
    public bool manager1;
    public bool manager2;
    public string dateTimeString;
    private DateTime _savedDateTime;
    private DateTime _now = DateTime.Now;
    public TimeSpan offline;

    public void Awake()
    {
        CountTime();
        offline = _now.Subtract(_savedDateTime);
    }

    private void CountTime()
    {
        var a = dateTimeString.Split(new char[] { ':' }).Select(int.Parse).ToArray();
        _savedDateTime = new DateTime(a[0], a[1], a[2], a[3], a[4], a[5], a[6]);
    }

    public ulong GetMoney()
    {
        CountTime();
        var timeToEarn = _now.Subtract(_savedDateTime).TotalSeconds;
        MainController.Instance.GetBonus();
        var money1 = (timeToEarn / ManagersController.CountTime(BuyBusiness.Instance.i1)) *
                     MainController.Instance.bonus1;
        var money2 = (timeToEarn / ManagersController.CountTime(BuyBusiness.Instance.i2)) *
                     MainController.Instance.bonus2;
        if (manager1 && manager2)
        {
            return (ulong) (money1 + money2);
        }
        else if (manager1)
        {
            return (ulong) money1;
        }
        else if (manager2)
        {
            return (ulong) money2;
        }
        return 0;
    }
}
