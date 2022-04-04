using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RecipeManager : MonoBehaviour
{
    List<Combination> recipeList;
    List<Item> itemList;
    string[] itemNames;
    List<string> combos;

    private string dataPath = "Assets/ItemList.txt";

    void Start()
    {
        combos = new List<string>();
        recipeList = new List<Combination>();
        itemList = new List<Item>();
        Init();
    }

    private void Init()
    {
        StreamReader sReader = new StreamReader(dataPath);
        string[] dataLines = sReader.ReadToEnd().Split('\n');
        itemNames = new string[dataLines.Length];

        for (int i = 0; i < dataLines.Length; i++) //get all ingredients in list
        {
            string[] splitLine = dataLines[i].Split(char.Parse(","));

            if (splitLine[0] == "")
                continue;

            itemNames[i] = splitLine[0].Trim("\"".ToCharArray()); //get all items names
            Debug.Log(splitLine[1].Trim("\"".ToCharArray()));

            if(splitLine[1] == "0")
            {
                Item newItem = (Item)ScriptableObject.CreateInstance("Item") as Item;
                newItem.setName = splitLine[0].Trim("\"".ToCharArray());
                itemList.Add(newItem);
            }
            else
            {
                combos.Add(splitLine[2].Trim("\"".ToCharArray()));
            }
        }

        for(int j = 0; j < combos.Count; j++)
        {
            Item newItem1 = (Item)ScriptableObject.CreateInstance("Item") as Item;
            newItem1.setName = combos[j].Split('/')[0];
            itemList.Add(newItem1);

            Item newItem2 = (Item)ScriptableObject.CreateInstance("Item") as Item;
            newItem2.setName = combos[j].Split('/')[1];
            itemList.Add(newItem2);

            Combination newCombo = ScriptableObject.CreateInstance<Combination>();
            newCombo.addObj1 = newItem1;
            newCombo.addObj2 = newItem2;

            recipeList.Add(newCombo);
        }

        debugPrint();
    }

    void debugPrint()
    {
        for(int i = 0; i < combos.Count; i++)
        {
            Debug.Log(recipeList[i]);
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
