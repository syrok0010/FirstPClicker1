using System;
using UnityEngine.UI;

public class ShowText : Singleton<ShowText>
{
    public Text balanceText;
    public Text x2Text;
    public Text x3Text;
    public Text p1Text;
    public Text p5Text;
    public Text busOne;
    public Text busTwo;
    public Text busOnePrice;
    public Text busTwoPrice;
    public Text errorText;
    public Text offlineTime;
    public Text offlineMoney;

    public void Update()
    {
        balanceText.text = $"{MainController.Instance.money}$";
        busOne.text = Convert.ToString(BuyBusiness.Instance.i1);
        busTwo.text = Convert.ToString(BuyBusiness.Instance.i2);
        busOnePrice.text = BuyBusiness.Instance.price1 == 0 ? "Buy" : $"Buy\n\r for {BuyBusiness.Instance.price1}$";
        busTwoPrice.text = BuyBusiness.Instance.price2 == 0 ? "Buy" : $"Buy\n\r for {BuyBusiness.Instance.price2}$";
        x2Text.text = UpgradeController.Instance.priceX2 == 0 ? "X2 за клик 20$" : $"X2 за клик {UpgradeController.Instance.priceX2}$";
        x3Text.text = UpgradeController.Instance.priceX3 == 0 ? "X3 за клик 30$" : $"X3 за клик {UpgradeController.Instance.priceX3}$";
        p5Text.text = UpgradeController.Instance.priceP5 == 0 ? "+5 за клик 10$" : $"+5 за клик {UpgradeController.Instance.priceP5}$";
        p1Text.text = UpgradeController.Instance.priceP1 == 0 ? "+1 за клик 1$" : $"+1 за клик {UpgradeController.Instance.priceP1}$";
        offlineTime.text = "Вас не было:\n\r" + OfflineController.Instance.offline;
        offlineMoney.text = "Ваши менеджеры заработали:\n\r" + OfflineController.Instance.GetMoney().ToString();
    }

    public void OnError(string text)
    {
        errorText.text = text;
    }
}
