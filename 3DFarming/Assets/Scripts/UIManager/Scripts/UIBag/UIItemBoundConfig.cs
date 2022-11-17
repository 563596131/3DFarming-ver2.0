using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/UIItemBoundConfig")]
public class UIItemBoundConfig : ScriptableObject
{
    public Sprite empty;
    public Sprite emptySelected;
    
    public Sprite filled;
    public Sprite filledSelected;

    public Sprite filledEqupped;
    public Sprite filledEquippedSelected;
}
