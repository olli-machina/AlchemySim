using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Purpose: get and set functions for item class
 */
public class ItemObjScript : MonoBehaviour
{
    public Item itemData;

    void Start()
    {
        name = itemData.setName;
    }

    public void SetData(Item data)
    {
        itemData = data;
    }

    public Item GetData()
    {
        return itemData;
    }

    public void SetIndex(int index)
    {
        itemData.positionIndex = index;   
    }
    
    public int GetIndex()
    {
        return itemData.positionIndex;
    }
}
