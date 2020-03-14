using System;
using Clicker.Businesses;
using Clicker.Upgrades.Multiply;
using Clicker.Upgrades.Plus;
using UnityEngine.UI;

namespace Clicker
{
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
        public Text confirm;

        public void Update()
        {
            balanceText.text = $"{MainController.Instance.money}$";
            busOne.text = Convert.ToString(Business1.Instance.I);
            busTwo.text = Convert.ToString(Business2.Instance.I);
            busOnePrice.text = Business1.Instance.Price == 0 ? "Buy" : $"Buy\n\r for {Business1.Instance.Price}$";
            busTwoPrice.text = Business2.Instance.Price == 0 ? "Buy" : $"Buy\n\r for {Business2.Instance.Price}$";
            x2Text.text = X2.Instance.Price == 0 ? "X2 за клик 20$" : $"X2 за клик {X2.Instance.Price}$";
            x3Text.text = X3.Instance.Price == 0 ? "X3 за клик 50$" : $"X3 за клик {X3.Instance.Price}$";
            p5Text.text = P5.Instance.Price == 0 ? "+5 за клик 30$" : $"+5 за клик {P5.Instance.Price}$";
            p1Text.text = P1.Instance.Price == 0 ? "+1 за клик 5$" : $"+1 за клик {P1.Instance.Price}$";
            offlineTime.text = "Вас не было:\n\r" + MainController.Instance.offline;
            offlineMoney.text = "Ваши менеджеры заработали:\n\r" + MainController.Instance.pMoney;
        }

        public void ConfirmRestart()
        {
            confirm.text = "Вы уверены,\n\r что хотите сбросить весь прогресс?";
        }

        public void OnError(string text)
        {
            errorText.text = text;
        }
    }
}
