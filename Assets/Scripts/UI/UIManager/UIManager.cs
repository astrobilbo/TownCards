using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cards.UI;
using Manager.UI;
namespace Manager
{
    public class UIManager : MonoBehaviour
    {
        private static UIManager _instance;
        public static UIManager instance
        {
            get
            {
                if (_instance is null)
                    Debug.LogError("UIManager is NULL");

                return _instance;
            }
        }

        void Awake()
        {
            _instance = this;
            if (updateUI == null)
                updateUI = new UnityEvent();
                updateUI.AddListener(UpdateUICommand);
        }

        UnityEvent updateUI;
        public List<CardDisplay> cards;


        public void UpdateUI()
        {
            if (updateUI == null) { Debug.Log("failed :::( " + updateUI); return; }

            updateUI.Invoke();
        }

        void UpdateUICommand()
        {
            ResourcesUI.instance.UpdateUI();
            UIBackground.instance.UpdateUI();
            foreach (CardDisplay item in cards)
            {
                item.UpdateUI();
            }
        }
    }
}
