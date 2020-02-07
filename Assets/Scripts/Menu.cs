using UnityEngine;

public class Menu : Singleton<Menu>
{
    

    public GameObject shopPanel;
    public GameObject errorPanel;
    public GameObject managersPanel;
    public GameObject offlineGotPanel;
    
    public void Start()
    {
        shopPanel.SetActive(false);
        managersPanel.SetActive(false);
        if (ManagersController.Instance.manager1 || ManagersController.Instance.manager2)
        {
            offlineGotPanel.SetActive(true);
        }
    }
    public void shopPanel_ShowAndHide()
    {
        shopPanel.SetActive(!shopPanel.activeSelf);
        if (managersPanel.activeSelf) managersPanel.SetActive(false);
        
    }
    public void managersPanel_ShowAndHide()
    {
        managersPanel.SetActive(!managersPanel.activeSelf);
        if (shopPanel.activeSelf) shopPanel.SetActive(false);
    }

    public void OnError()
    {
        errorPanel.SetActive(true);
    }

    public void CloseError()
    {
        errorPanel.SetActive(false);
    }

    public void CloseOfflineGotPanel()
    {
        offlineGotPanel.SetActive(false);
    }
}
