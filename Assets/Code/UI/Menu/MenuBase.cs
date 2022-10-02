using System;
using UnityEngine;

namespace UI.Menu
{
    public abstract class MenuBase: MonoBehaviour
    {
        public bool IsShown { get; private set; }

        private void Awake()
        {
            IsShown = gameObject.activeSelf;
        }

        public void Show()
        {
            if(IsShown)
                return;
            
            IsShown = true;
            OnShow();
        }

        public void Hide()
        {
            if(!IsShown)
                return;
            
            IsShown = false;
            OnHide();
        }

        protected virtual void OnShow()
        {
            gameObject.SetActive(true);
        }
        
        protected virtual void OnHide()
        {
            gameObject.SetActive(false);
        }
    }
}