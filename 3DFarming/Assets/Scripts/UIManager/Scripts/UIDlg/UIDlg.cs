using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIDlg : MonoBehaviour
{
    public static UIDlg Instance;
    public GameObject root;

    public Text titleText;

    public Text contentText;
    public Button sureBtn;
    public Button cancelBtn;

    private UnityAction<bool> onClickEvent;

    private void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    private void Start()
    {
        sureBtn.onClick.AddListener(OnClickSure);
        cancelBtn.onClick.AddListener(OnClickCancel);
    }

    private void OnClickSure()
    {
        if (onClickEvent != null)
        {
            onClickEvent.Invoke(true);
        }
        root.SetActive(false);
    }

    private void OnClickCancel()
    {
        if (onClickEvent != null)
        {
            onClickEvent.Invoke(false);
        }
        root.SetActive(false);
    }

    public void ShowUI(string title, string content, int btnCount, UnityAction<bool> clickEvent)
    {
        titleText.text = title;
        contentText.text = content;
        onClickEvent = clickEvent;
        if (btnCount == 1)
        {
            cancelBtn.gameObject.SetActive(false);
        }
        else
        {
            cancelBtn.gameObject.SetActive(true);
        }
        root.SetActive(true);
    }
    public void ShowUI(string content, int btnCount, UnityAction<bool> clickEvent)
    {
        ShowUI("confirm", content, btnCount, clickEvent);
    }
}
