using System;
using Businesses;
using UnityEngine;
using Upgrades;

public class MainController : Singleton<MainController>
{
    public ulong money;
    public ulong bonus1 = 1;
    public ulong bonus2 = 3;

    public GameObject prefabParent1;
    public GameObject prefab;

    public GameObject prefabParent2;
    
    public PrefabText[] prefabText = new PrefabText[15];
    public PrefabText[] prefabText2 = new PrefabText[15];

    private int _prefabNum1;
    private int _prefabNum2;

    [HideInInspector]public bool toSave = true;

    public bool manager1;
    public bool manager2;

    [NonSerialized] public string datetime;
    [NonSerialized] public string pMoney;
    [NonSerialized] public string offline;
    public OfflineController offlineController;

    public void Awake()
    {
        SaveLoad.Load();
        for (var i = 0; i < prefabText.Length; i++)
        {
            prefabText[i] = Instantiate(prefab, prefabParent1.transform).GetComponent<PrefabText>();
            prefabText2[i] = Instantiate(prefab, prefabParent2.transform).GetComponent<PrefabText>();
        }
    }

    private void Start()
    {
        if (Business1.Instance.Bonus == 0 || Business1.Instance.I == 0)
        {
            Business1.Instance.Bonus = 1;
            Business1.Instance.I = 1;
        }

        UpgradeController.Instance.CountBonus();
        if (!manager1 && !manager2) return;
        CountOffline();
        GetBonus();
    }

    private void CountOffline()
    {
        offlineController = new OfflineController(datetime, manager1, manager2);
        offlineController.CountTime();
        Menu.Instance.OnError();
        ShowText.Instance.OnError("Ваши менеджеры отработали, вы можете купить новых");
        pMoney = offlineController.GetMoney().ToString();
        offline = offlineController.offline.ToString();
    }

    public void OfflineGot(int x)
    {
        money += (Convert.ToUInt64(pMoney)) * (ulong) x;
    }

    public void OnApplicationPause(bool pauseStatus)
    {
        if (toSave)
        {
            SaveLoad.Save();
        }
    }
    public void OnApplicationQuit()
    {
        if (toSave)
        {
            SaveLoad.Save();
        }
    }

    public void GetMoney(ulong moneyGet)
    {
        money = moneyGet;
    }

    internal void GetBonus()
    {
        Debug.Log("It worked!");
        bonus1 = (P1.Instance.Bonus + P5.Instance.Bonus) * X2.Instance.Bonus * X3.Instance.Bonus * Business1.Instance.Bonus;
        bonus2 = (P1.Instance.Bonus + P5.Instance.Bonus) * X2.Instance.Bonus * X3.Instance.Bonus * Business2.Instance.Bonus;
    }
    public static void BonusCount(int btnIndex)
    {
        UpgradeController.Instance.ShopBtn(btnIndex);
    }

    #region InDevelopment

    //public void MultiplyUpgrade(string multUpgrade)
    // {
    //var results = UpgradeController.Instance.MultiplyUpgrade(multUpgrade).Split(new char[] { '/' });
    //  bonus = Convert.ToUInt64(results[0]);
    //     money = Convert.ToUInt64(results[1]);
    //  }

    #endregion
   

    public void OnClick(int businessIndex)
    {
        switch (businessIndex)
        {
            case 1:
                money += bonus1;
                prefabText[_prefabNum1].Motion(bonus1);
                _prefabNum1++;
                if (_prefabNum1 > 14) _prefabNum1 = 0;
                break;
            case 2:
                money += bonus2;
                prefabText2[_prefabNum2].Motion(bonus2);
                _prefabNum2++;
                if (_prefabNum2 > 14) _prefabNum2 = 0;
                break;
        }
    }
}
