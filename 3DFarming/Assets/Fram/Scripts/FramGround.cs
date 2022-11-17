using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramGround : MonoBehaviour
{
    public int initId;
    public Transform initPoint;
    public int xCellCount;
    public int zCellCount;
    public Vector2 cellSize;
    public List<FramGroundItem> itemList = new List<FramGroundItem>();

    // Start is called before the first frame update
    void Start()
    {
        Vector3 init_pos = initPoint.position;
        for (int i = 0; i < xCellCount; i++)
        {
            for (int j = 0; j < zCellCount; j++)
            {
                FramGroundItem item = new FramGroundItem();
                item.pos = init_pos + new Vector3(cellSize.x * i, 0,cellSize.y * j);
                item.framGroundItemId = initId++;
                itemList.Add(item);
            }
        }
    }
}


public class FramGroundItem
{
    public int framGroundItemId;
    public Vector3 pos;
    public FramRes framRes;
}