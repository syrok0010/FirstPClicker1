using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    public Text balanceText;
    public Text x2Text;
    public Text x3Text;
    public Text P1Text;
    public Text P5Text;

    public void Update()
    {
        balanceText.text = $"Ваш баланс\n {MainController.Instance.money}$";
        x2Text.text = UpgradeController.Instance.priceX2 == 0 ? "X2 за клик 20$" : $"X2 за клик {UpgradeController.Instance.priceX2}$";
        x3Text.text = UpgradeController.Instance.priceX3 == 0 ? "X3 за клик 30$" : $"X3 за клик {UpgradeController.Instance.priceX3}$";
        P5Text.text = UpgradeController.Instance.priceP5 == 0 ? "+5 за клик 10$" : $"+5 за клик {UpgradeController.Instance.priceP5}$";
        P1Text.text = UpgradeController.Instance.priceP1 == 0 ? "+1 за клик 1$" : $"+1 за клик {UpgradeController.Instance.priceP1}$";
    }
}
