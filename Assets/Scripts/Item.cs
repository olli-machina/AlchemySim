using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 1)]
public class Item : ScriptableObject
{
    public string setName;
    Image icon; //change to mesh later
    public Mesh mesh;
}

public class Combination
{
    public Item addObj1, addObj2;

    public Combination(Item obj1, Item obj2) { addObj1 = obj1; addObj2 = obj2; }
    public Combination(string obj1, string obj2) {/*search through data for strings*/ }
}


