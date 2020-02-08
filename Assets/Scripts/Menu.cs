using UnityEngine;
using UnityEngine.Serialization;

public class Menu : Singleton<Menu>
{
    

    public GameObject shopPanel;
    public GameObject errorPanel;
    public GameObject managersPanel;
    public GameObject offlineGotPanel;
    public Animator animator;
    public bool manager1;
    public bool manager2;
    
    public void Start()
    {
        shopPanel.SetActive(false);
        managersPanel.SetActive(false);
        if (manager1 || manager2)
        {
            offlineGotPanel.SetActive(true);
        }

        
    }
    public void shopPanel_ShowAndHide()
    {
        animator = shopPanel.GetComponent<Animator>();
        if (shopPanel.transform.localPosition.x == 0) animator.SetTrigger("Exit");
        else
        {
            shopPanel.SetActive(!shopPanel.activeSelf);
        }

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
