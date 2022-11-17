using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseTools;
public class NpcAI : MonoBehaviour
{
    public float interactDistance;
    public int eventID = -1;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Click3D>().target = GameData.Instance.PlayerTsfm;
    }

    // Update is called once per frame
    void Update()
    {
          
    }
}
