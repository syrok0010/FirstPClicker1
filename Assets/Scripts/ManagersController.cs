using System.Collections;
using UnityEngine;

public class ManagersController : MonoBehaviour
{
    private ulong _money;
    private int _i1;
    private int _i2;
    public static float time; 
    public void Awake()
    {
        _money = MainController.Instance.money;
        _i1 = BuyBusiness.Instance.i1;
        _i2 = BuyBusiness.Instance.i2;
    }

    public void Update()
    {
        _i1 = BuyBusiness.Instance.i1;
    }

    private static float CountTime(int i)
    {
        if (i < 4) time = 1;
        else if (i >= 4 & i < 6) time = 0.5f;
        else if (i <= 6 & i < 8) time = 0.125f;
        else if (i >= 8 & i < 10) time = 0.015f;
        return time;
    }
    public void StartManager1()
    {
        StartCoroutine(Manager1( _i1)); 
        if (_money >= 1000) _money -= 1000;
    }

    public void StartManager2()
    {
        StartCoroutine(Manager2(_i2)); 
        if (_money >= 10000) _money -= 10000;
    }
    

    private static IEnumerator Manager1(int i)
    {
        while (true)
        {
            MainController.Instance.OnClick(1);
            var timeIn = CountTime(i);
            yield return new WaitForSeconds(timeIn);
        }
    }
    private static IEnumerator Manager2(int i)
    {
        while (true)
        {
            MainController.Instance.OnClick(2);
            var timeIn = CountTime(i);
            yield return new WaitForSeconds(time);
        }
    }
}
