using System;
using System.Linq;
using Clicker.Businesses;

namespace Clicker
{
    public class OfflineController
    {
        private readonly bool _manager1;
        private readonly bool _manager2;
        private readonly string _dateTimeString;
        private DateTime _savedDateTime;
        private readonly DateTime _now = DateTime.Now;
        public TimeSpan offline;

        public OfflineController(string dateTimeString, bool manager1, bool manager2)
        {
            _dateTimeString = dateTimeString;
            _manager1 = manager1;
            _manager2 = manager2;
        }

        public void CountTime()
        {
            if (string.IsNullOrWhiteSpace(_dateTimeString)) return;
            var a = _dateTimeString.Split(':').Select(int.Parse).ToArray();
            _savedDateTime = new DateTime(a[0], a[1], a[2], a[3], a[4], a[5], a[6]);
        }

        public ulong GetMoney()
        {
            CountTime();
            offline = _now.Subtract(_savedDateTime);
            var timeToEarn = offline.TotalSeconds;
            MainController.Instance.GetBonus();
            var money1 = timeToEarn / ManagersController.CountTime(Business1.Instance.I) *
                         MainController.Instance.bonus1;
            var money2 = timeToEarn / ManagersController.CountTime(Business2.Instance.I) *
                         MainController.Instance.bonus2;
            if (_manager1 && _manager2)
            {
                return (ulong) (money1 + money2);
            }

            if (_manager1)
            {
                return (ulong) money1;
            }
            if (_manager2)
            {
                return (ulong) money2;
            }

            return 0;
        }
    }
}
