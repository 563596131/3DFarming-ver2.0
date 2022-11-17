using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInfo : MonoBehaviour
{
    public static UIInfo Instance;
    public Text infoText;
    public GameObject root;
    private void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }
    
    public void ShowUI(string infoStr, Transform sender, Vector3 offset)
    {
        infoText.text = infoStr;
        root.transform.position = sender.position + offset;
        root.SetActive(true);
    }

    public void HideUI()
    {
        root.SetActive(false);
    }
}
