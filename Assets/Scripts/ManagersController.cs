using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class ManagersController : MonoBehaviour
{
    private ulong _money;
    public int i1;
    public void Awake()
    {
        _money = MainController.Instance.money;
        i1 = BuyBusiness.Instance.i1;
    }

    public void Update()
    {
        i1 = BuyBusiness.Instance.i1;
    }

    private static float CountTime(int i)
    {
        float time = 1;
        if (i < 4) time = 1;
        else if (i >= 4 & i < 6) time = 0.5f;
        else if (6 <= i & i < 8) time /= 0.125f;
        else if (i >= 8 & i < 10) time /= 0.015f;
        return time;
    }
    public void StartManager1()
    {
        StartCoroutine(Manager(CountTime(i1))); 
        if (_money >= 1000) _money -= 1000;
    }

    public void StartManager2()
    {
        StartCoroutine(Manager(0.5f)); 
        if (_money >= 1000) _money -= 1000;
    }
    public void StartManager3()
    {
        StartCoroutine(Manager(0.2f)); 
        if (_money >= 10000) _money -= 10000;
    }
    public void StartManager4()
    {
        StartCoroutine(Manager(0.01f)); 
        if (_money >= 1000000) _money -= 1000000;
    }

    private IEnumerator Manager(float time)
    {
        while (true)
        {
            _money += MainController.Instance.bonus;
            MainController.Instance.GetMoney(_money);
            yield return new WaitForSeconds(time);
        }
    }
    
}
