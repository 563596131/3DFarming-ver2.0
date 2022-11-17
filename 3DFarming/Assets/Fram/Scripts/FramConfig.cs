using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/FarmConfig")]
public class FramConfig : ScriptableObject
{
    public GameObject seedObj;
    public FramRes[] framResList;
}
