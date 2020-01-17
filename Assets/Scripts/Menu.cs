using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject managersPanel;
    public void shopPanel_ShowAndHide()
    {
        shopPanel.SetActive(!shopPanel.activeSelf);
    }
    public void managersPanel_ShowAndHide()
    {
        managersPanel.SetActive(!managersPanel.activeSelf);
    }
}
