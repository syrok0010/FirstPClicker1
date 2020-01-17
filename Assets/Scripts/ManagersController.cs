using System.Collections;
using UnityEngine;

public class ManagersController : MonoBehaviour
{
    private ulong _money = MainController.Instance.money;
    public void StartManager1()
    {
        StartCoroutine(Manager(1)); 
        if (_money >= 200) _money -= 200;
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
    
    IEnumerator Manager(float time)
    {
        while (true)
        {
            _money += MainController.Instance.bonus;
            MainController.Instance.GetMoney(_money);
            yield return new WaitForSeconds(time);
        }
    }
    
}
