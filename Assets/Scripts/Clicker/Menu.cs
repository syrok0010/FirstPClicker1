using UnityEngine;
using File = System.IO.File;

namespace Clicker
{
    public class Menu : Singleton<Menu>
    {
        public GameObject shopPanel;
        public GameObject errorPanel;
        public GameObject managersPanel;
        public GameObject offlineGotPanel;
        public GameObject confirm;
        public Animator animator;
        public bool manager1;
        public bool manager2;
        private int _type;
    
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
            animator = managersPanel.GetComponent<Animator>();
            if (managersPanel.transform.localPosition.x == 0) animator.SetTrigger("Exit");
            else
            {
                managersPanel.SetActive(!managersPanel.activeSelf);
            }

            if (shopPanel.activeSelf) shopPanel.SetActive(false);
        }

        public void Close()
        {
            confirm.SetActive(true);
            _type = 1;
        }

        public void CloseAfterConfirm()
        {
            if (_type == 2)
            {
                RestartConfirmed();
            }
            Application.Quit();
        }

        public void CloseNotConfirmed()
        {
            confirm.SetActive(false);
        }

        public void Restart()
        {
            confirm.SetActive(true);
            _type = 2;
            ShowText.Instance.ConfirmRestart();
        }

        private void RestartConfirmed()
        {
            var path = Application.persistentDataPath + "save.json";
            if (File.Exists(path)) File.Delete(path);
            MainController.Instance.toSave = false;
        }
        #region Error
        public void OnError()
        {
            errorPanel.SetActive(true);
        }

        public void CloseError()
        {
            errorPanel.SetActive(false);
        }
        #endregion

        public void CloseOfflineGotPanel()
        {
            offlineGotPanel.SetActive(false);
        }
    
    }
}
