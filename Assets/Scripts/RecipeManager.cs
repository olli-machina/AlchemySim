using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RecipeManager : MonoBehaviour
{
    List<Combination> recipeList;

    private string dataPath = "Assets/ItemList.txt";

    void Start()
    {
        //load txt and library
    }

    void LoadTxtData()
    {
        StreamReader sReader = new StreamReader(dataPath);
        string[] dataLines = sReader.ReadToEnd().Split('\n');
        
        for(int i = 0; i < dataLines.Length; i++)
        {
            string[] splitLine = dataLines[i].Split(char.Parse(","));

            if (splitLine[0] == "")
                continue;

            Item newItem = (Item)ScriptableObject.CreateInstance("Item") as Item;

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isExist(Item obj1, Item obj2)
    {
        return recipeList.Exists(searchingCombo => searchingCombo.addObj1 == obj1 && searchingCombo.addObj2 == obj2); //make sure this works correctly
    }

    public void CheckItems(Item obj1, Item obj2)
    {
        if (isExist(obj1, obj2))
        {  
            //create recipe
        }

        else
            return;
    }
}
