using System;
using System.Collections;
using UnityEngine;

public class ManagersController : Singleton<ManagersController>
{
    private ulong _money;
    private int _i1;
    private int _i2;
    private static float _time;
    public bool manager1 = false;
    public bool manager2 = false;
    public void Awake()
    {
        _money = MainController.Instance.money;
        _i1 = BuyBusiness.Instance.i1;
        _i2 = BuyBusiness.Instance.i2;
    }

    public void Update()
    {
        _i1 = BuyBusiness.Instance.i1;
        _i2 = BuyBusiness.Instance.i2;
    }

    private static float CountTime(int i)
    {
        if (i < 4) _time = 1;
        else if (i >= 4 & i < 6) _time = 0.5f;
        else if (i <= 6 & i < 8) _time = 0.125f;
        else if (i >= 8 & i < 10) _time = 0.015f;
        return _time;
    }
    public void StartManager1()
    {
        try
        {
            Check(1000, 1);
            StartCoroutine(Manager1(_i1));
            manager1 = true;
        }
        catch (Exception ex)
        {
            Exceptions.Exception(ex);
            throw;
        }
    }

    private void Check(ulong price, int managerNum)
    {
        switch (managerNum)
        {
            case 1:
                if (manager1) throw new Exception("Менеджер уже куплен");
                break;
            case 2:
                if (manager2) throw new Exception("Менеджер уже куплен");
                break;
        }
        _money = AllUpgradeController.GetMoney(price);
    }
    
    public void StartManager2()
    {
        try
        {
            Check(10000, 2);
            StartCoroutine(Manager2(_i2));
            manager2 = true;
        }
        catch (Exception ex)
        {
            Exceptions.Exception(ex);
            throw;
        }
    }

    public void StartFromSave(int i)
    {
        switch (i)
        {
            case 1:
                StartCoroutine(Manager1(_i1));
                break;
            case 2:
                StartCoroutine(Manager2(_i2));
                break;
        }
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
            yield return new WaitForSeconds(timeIn);
        }
    }
}
