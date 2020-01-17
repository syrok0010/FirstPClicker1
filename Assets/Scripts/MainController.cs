using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : Singleton<MainController>
{
    public ulong money;
    public ulong bonus = 1;
    public ulong bonusUpgrade = UpgradeController.Instance.bonus;

    public void GetMoney(ulong money)
    {
        this.money = money;
    }
    public void BonusCount(int btnIndex)
    {
        var results = UpgradeController.Instance.ShopBtn(btnIndex).Split(new char[] { '/' });
        bonus = Convert.ToUInt64(results[0]);
        money = Convert.ToUInt64(results[1]);
    }

    public void MultiplyUpgrade(string multUpgrade)
    {
        var results = UpgradeController.Instance.MultiplyUpgrade(multUpgrade).Split(new char[] { '/' });
        bonus = Convert.ToUInt64(results[0]);
        money = Convert.ToUInt64(results[1]);
    }

    public void OnClick()
    {
        money += bonus;
    }
}
