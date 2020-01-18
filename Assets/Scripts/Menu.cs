using UnityEngine;

public class Menu : Singleton<Menu>
{
    public GameObject shopPanel;
    public GameObject errorPanel;
    public GameObject managersPanel;
    public void shopPanel_ShowAndHide()
    {
        shopPanel.SetActive(!shopPanel.activeSelf);
    }
    public void managersPanel_ShowAndHide()
    {
        managersPanel.SetActive(!managersPanel.activeSelf);
    }

    public void OnError()
    {
        errorPanel.SetActive(true);
    }

    public void CloseError()
    {
        errorPanel.SetActive(false);
    }
}
