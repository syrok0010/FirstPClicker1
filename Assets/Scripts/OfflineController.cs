using System;
using UnityEngine;

public class OfflineController : Singleton<OfflineController>
{
    public DateTime datetime;
    private static TimeSpan _toEarnTime;
    public int days = _toEarnTime.Seconds;

    public void GetMoney()
    {
        _toEarnTime = DateTime.Now.Subtract(datetime);
        Debug.Log(_toEarnTime.Days);
        Debug.Log(_toEarnTime.Hours);
        Debug.Log(_toEarnTime.Minutes);
        Debug.Log(_toEarnTime.Seconds);
    }
}
