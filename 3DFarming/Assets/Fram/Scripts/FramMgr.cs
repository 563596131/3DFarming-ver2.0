using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using BaseTools;
using UnityEngine;
using UnityEngine.UI;

public class FramMgr : MonoBehaviour
{
    public static FramMgr Instance;
    public float distance;
    public FramGround[] groundList;
    public FramConfig framConfig;
    private Vector3 playerPos;
    public int currIndex;
    public GameObject toggleTemp;
    public List<ItemData> itemList = new List<ItemData>();
    public List<UIUseSkilllItem> uiItemList = new List<UIUseSkilllItem>(); 
    
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        EventMgr.Register<ItemEventData>(EventID.ADD_ITEM, OnSeedItemEvent);
        EventMgr.Register<ItemEventData>(EventID.REMOVE_ITEM, OnSeedItemEvent);
    }

    private void OnSeedItemEvent(ItemEventData eventData)
    {
        ItemData data = eventData.param;
        if (data.itemType == ItemType.Seed)
        {
            int idx = GetIndex(data);
        
            if (eventData.eventID == EventID.ADD_ITEM)
            {
                if (idx == -1)
                {
                    GameObject go = GameObject.Instantiate(toggleTemp, toggleTemp.transform.parent);
                    UIUseSkilllItem uiitem = go.GetComponent<UIUseSkilllItem>();
                    uiitem.SetIcon(data.itemIcon);
                    uiitem.SetNum(data.itemCount);
                    uiitem.SetKeyTips(KeyCode.Alpha1 + uiItemList.Count);
                    if (itemList.Count == 0)
                    {
                        currIndex = 0;
                        uiitem.SetToggle(true);   
                    }
                    uiItemList.Add(uiitem);
                    go.SetActive(true);
                    itemList.Add(data);
                }
                else
                {
                    UIUseSkilllItem uiitem = uiItemList[idx];
                    uiitem.SetNum(data.itemCount);
                }
            }else if (eventData.eventID == EventID.REMOVE_ITEM)
            {
                if (idx == -1) return;
                UIUseSkilllItem uiitem = uiItemList[idx];
                if (data.itemCount == 0)
                {
                    itemList.Remove(data);
                    Destroy(uiitem.gameObject);
                    uiItemList.RemoveAt(idx);

                    for (int i = 0; i < uiItemList.Count; i++)
                    {
                        uiitem = uiItemList[i];
                        uiitem.SetKeyTips(KeyCode.Alpha1+i);
                        if (i == 0)
                        {
                            currIndex = 0;
                            uiitem.SetToggle(true);
                        }
                    }
                }
                else
                {
                    uiitem.SetNum(data.itemCount);
                }
            }
        }
    }

    private int GetIndex(ItemData data)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].itemId == data.itemId)
            {
                return i;
            }
        }

        return -1;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSeed(0);
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSeed(1);
        }else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectSeed(2);
        }else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectSeed(3);
        }else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectSeed(4);
        }else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SelectSeed(5);
        }else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SelectSeed(6);
        }else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SelectSeed(7);
        }else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SelectSeed(8);
        }
        
        // if (Input.anyKeyDown)
        // {
        //     Debug.Log(Event.current.keyCode);
        //     for (int i = 48; i <= 57; i++)
        //     {
        //         //Debug.Log("keyCode:"+i);
        //         if (Input.GetKeyDown((KeyCode)i))
        //         {
        //             SelectSeed((int)(i-KeyCode.Alpha0));
        //         }
        //     }
        // }
        // if (Input.GetKeyDown(KeyCode.Alpha0))
        // {
        //     
        // }else if (Input.GetKeyDown(KeyCode.Alpha1))
        // {
        //     SelectSeed(1);
        // }else if (Input.GetKeyDown(KeyCode.Alpha2))
        // {
        //     SelectSeed(2);
        // }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!RangeTool.InRangeExcludMax(currIndex,0, uiItemList.Count))
            {
                return;
            }

            ItemData data = itemList[currIndex];
            if (data.itemCount <= 0)
            {
                string str = string.Format("no more {0}.", data.itemName);
                UITips.CreateTips(data.itemIcon, str);
                return;
            }
            
            playerPos = GameData.Instance.PlayerTsfm.position;
            
            FramGround framGround;
            for (int i = 0; i < groundList.Length; i++)
            {
                framGround = groundList[i];
                if (framGround == null) continue;

                FramGroundItem item = GetNearFramGroundItem(framGround);
                if (item == null) continue;
                
                // found item, do it
                GameObject res = GetPlantOjb(data.itemId);
                if (res != null)
                {
                    GameObject seed = GameObject.Instantiate(framConfig.seedObj);
                    seed.transform.position = item.pos;
                    GameObject go = GameObject.Instantiate(res);
                    go.transform.position = item.pos;
                    FramRes framRes = go.GetComponent<FramRes>();
                    framRes.InitItem(seed,item);
                    item.framRes = framRes;
                    ItemMgr.Instance.SubItem(data.itemId, 1);
                }
                else
                {
                    Debug.Log("pls check FramRes, itemId: " + data.itemId);   
                }
                break;
            }
        }
    }

    private GameObject GetPlantOjb(int itemId)
    {
        for (int i = 0; i < framConfig.framResList.Length; i++)
        {
            FramRes fr = framConfig.framResList[i];
            if (fr.seedItemId == itemId)
            {
                return fr.gameObject;
            }
        }

        return null;
    }

    private FramGroundItem GetNearFramGroundItem(FramGround framGround)
    {
        for (int j = 0; j < framGround.itemList.Count; j++)
        {
            FramGroundItem item = framGround.itemList[j];
            if (item.framRes == null)
            {
                if (Util.GetHorizontalDistance(playerPos, item.pos) <= distance)
                {
                    return item;
                }    
            }
        }

        return null;
    }

    private void SelectSeed(int index)
    {
        if (RangeTool.InRangeExcludMax(index,0, uiItemList.Count))
        {
            this.currIndex = index;
            uiItemList[index].SetToggle(true);
        }
    }
}
