using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUseSkilllItem : MonoBehaviour
{
    public Image icon;

    public Text keyTips;

    public Text numText;

    public Toggle toggle;

    public KeyCode keycode;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetIcon(Sprite spr)
    {
        icon.sprite = spr;
    }

    public void SetKeyTips(KeyCode keycode)
    {
        this.keycode = keycode;
        keyTips.text = keycode.ToString();
    }

    public void SetNum(int num)
    {
        numText.text = num.ToString();
        numText.color = num == 0 ? Color.red : Color.white;
    }

    public void SetToggle(bool isOn)
    {
        toggle.isOn = isOn;
    }
}
