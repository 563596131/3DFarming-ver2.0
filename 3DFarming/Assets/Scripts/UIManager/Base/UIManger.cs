using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaseTools
{
    public class UIManger : MonoBehaviour
    {
        public static UIManger Instance;

        public List<BasePanel> panels = new List<BasePanel>();

        private void Awake()
        {
            Instance = this;

            // 隐藏得界面也加入列表
            panels.AddRange(GetComponentsInChildren<BasePanel>(true));
            // 隐藏得界面不加入列表
            //panels.AddRange(GetComponentsInChildren<BasePanel>());
        }

        private void OnDestroy()
        {
            Instance = null;
        }

        private void Start()
        {
            for (int i = 1; i < panels.Count; i++)
            {
                panels[i].Hide();
            }
        }

        public T ShowPanel<T>() where T : BasePanel 
        {
            T panel = panels.Find(p => p is T) as T;
            panel.Show();

            return panel;
        }

        public T HidePanel<T>() where T : BasePanel
        {
            T panel = panels.Find(p => p is T) as T;
            panel.Hide();

            return panel;
        }
    }
}