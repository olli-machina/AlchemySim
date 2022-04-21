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
    public GameManager manager;
    Item objFirst, objSecond;
    int index;

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
        float r = 0, g=0, b=0;

        for (int i = 0; i < dataLines.Length; i++) //get all ingredients in list
        {
            string[] splitLine = dataLines[i].Split(char.Parse(","));

            if (splitLine[0] == "")
                continue;

            Item newItem = (Item)ScriptableObject.CreateInstance("Item") as Item;
            newItem.setName = splitLine[0].Trim("\"".ToCharArray());
            string[] colorStr = splitLine[3].Split(char.Parse("/"));

            r = float.Parse(colorStr[0].Trim("|".ToCharArray())) / 255f;
            g = float.Parse(colorStr[1]) / 255f;
            b = float.Parse(colorStr[2].Trim("|\r".ToCharArray())) / 255f;
           // Debug.Log(r + " " + g + " " + b);
            newItem.matColor = new Color(r,g,b);

            itemList.Add(newItem);

            if (splitLine[1] != "0") //make this work with spaces~~~
            {
                itemNames[i] = splitLine[0].Trim("\"".ToCharArray()); //get all items names
                combos.Add(splitLine[2].Trim("\"".ToCharArray()));
            }
        }

        for(int j = 0; j < combos.Count; j++)
        {
            Item newItem1 = (Item)ScriptableObject.CreateInstance("Item") as Item;
            string trimmed = combos[j].Split('|')[1];
            string name = trimmed.Split('/')[0];
            newItem1.setName = name;
            itemList.Add(newItem1);

            Item newItem2 = (Item)ScriptableObject.CreateInstance("Item") as Item;
            name = trimmed.Split('/')[1];
            newItem2.setName = name;
            itemList.Add(newItem2);

            Combination newCombo = ScriptableObject.CreateInstance<Combination>();
            newCombo.addObj1 = newItem1;
            newCombo.addObj2 = newItem2;

            recipeList.Add(newCombo);
        }

        manager.setMenu(itemList.Count);
    }

    void debugPrint()
    {
        for(int i = 0; i < combos.Count; i++)
        {
            Debug.Log(recipeList[i].addObj1.setName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isExist(Item obj1, Item obj2)
    {
        if (recipeList.Exists(searchingCombo => searchingCombo.addObj1.setName == obj1.setName && searchingCombo.addObj2.setName == obj2.setName))
        {
            index = recipeList.FindIndex(searchingCombo => searchingCombo.addObj1.setName == obj1.setName && searchingCombo.addObj2.setName == obj2.setName);
            objFirst = obj1;
            objSecond = obj2;
            return true;
        }
        if (recipeList.Exists(searchingCombo => searchingCombo.addObj1.setName == obj2.setName && searchingCombo.addObj2.setName == obj1.setName))
        {
            index = recipeList.FindIndex(searchingCombo => searchingCombo.addObj1.setName == obj2.setName && searchingCombo.addObj2.setName == obj1.setName);
            objFirst = obj2;
            objSecond = obj1;
            return true;
        }

        else
            return false;
    }

    public void checkItems(Item obj1, Item obj2)
    {
        if (isExist(obj1, obj2))
        {
            manager.createNewItem(itemList[index + 4]);
        }

        else
            return;
    }

    public Item getItem(string name)
    {
        for( int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].setName == name)
                return itemList[i];
        }

        return null;
    }
}
