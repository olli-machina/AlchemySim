using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 1)]
public class Item : ScriptableObject
{
    public string setName;
    public int positionIndex;
    public Color matColor;
}

public class Combination : ScriptableObject
{
    public Item addObj1, addObj2;

    public Combination(Item obj1, Item obj2) { addObj1 = obj1; addObj2 = obj2; }
}


