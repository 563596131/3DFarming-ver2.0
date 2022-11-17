using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBagMgr : MonoBehaviour
{
    public static UIBagMgr Instance;
    public UIItemBoundConfig uiItemBoundConfig;

    private void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
