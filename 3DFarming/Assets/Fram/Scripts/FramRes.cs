using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FramRes : MonoBehaviour
{
    [HideInInspector]public int framGroundItemId;
    // seeds seedlings mature
    public float duration1;
    public GameObject res1; 
    
    public float duration2;
    public GameObject res2;

    public int minHarvestCount;
    public int maxHarvestCount;
    
    //public int
    public int seedItemId;
    public int harvestItemId;
    [HideInInspector]public GameObject seedObj;
    private FramGroundItem framGroundItem;
    private bool canHarvest;
    public void InitItem(GameObject seedObj, FramGroundItem framGroundItem)
    {
        this.seedObj = seedObj;
        this.framGroundItem = framGroundItem;
        
        res1.SetActive(false);
        res2.SetActive(false);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Util.DelayAction(this, duration1, OnGrow1);
    }

    private void OnGrow1()
    {
        Destroy(seedObj);
        res1.SetActive(true);
        Util.DelayAction(this, duration2, OnGrow2);
    }

    private void OnGrow2()
    {
        res1.SetActive(false);
        res2.SetActive(true);
        canHarvest = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if (canHarvest)
        // {
        //     if (collision.transform.CompareTag("Player"))
        //     {
        //         int count = Random.Range(minHarvestCount, maxHarvestCount);
        //         ItemMgr.Instance.AddItem(itemId, count);
        //         framGroundItem.framRes = null;
        //         Destroy(gameObject);
        //     }    
        // }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canHarvest)
        {
            if (other.transform.CompareTag("Player"))
            {
                int count = Random.Range(minHarvestCount, maxHarvestCount);
                ItemMgr.Instance.AddItem(harvestItemId, count);
                framGroundItem.framRes = null;
                Destroy(gameObject);
            }    
        }
    }
}
