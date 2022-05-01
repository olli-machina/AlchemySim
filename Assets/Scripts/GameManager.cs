using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject baseItem;
    public RecipeManager recipeManager;
    public Beaker_Script beaker;
    public MenuScript menu;

    public Vector3[] spawnPositions;
    ItemSlots[] startingPositions;


    struct ItemSlots
    {
        public Vector3 position;
        public bool filled;
    }

    void Start()
    {
        startingPositions = new ItemSlots[spawnPositions.Length];
        for(int i = 0; i < spawnPositions.Length; i++)
        {
            startingPositions[i].position = spawnPositions[i];
            startingPositions[i].filled = false;
        }
    }

    /*
     * Purpose: spawn base 4 items
     */
    void SpawnStartItems()
    {
        CreateBaseItem(recipeManager.GetItem("Water"));
        CreateBaseItem(recipeManager.GetItem("Fire"));
        CreateBaseItem(recipeManager.GetItem("Earth"));
        CreateBaseItem(recipeManager.GetItem("Air"));
    }

    /*
     * Purpose: communicate this function between beaker and reicpe manager
     */
    public void CheckForRecipe(Item obj1, Item obj2)
    {
        recipeManager.CheckItems(obj1, obj2);
    }

    /*
     * Purpose: spawn an item that is part of the base 4
     */
    public void CreateBaseItem(Item data)
    {
        Vector3 openPosition = Vector3.zero;
        for (int i = 0; i < 4; i++)
        {
            if (!startingPositions[i].filled)
            {
                openPosition = startingPositions[i].position;
                startingPositions[i].filled = true;
                data.positionIndex = i;
                break;
            }
        }

        InstantiateObj(data, openPosition);
    }

    /*
     * Purpose: spawn an item that is not part of the base 4
     */
    public void CreateNewItem(Item data)
    {
        Vector3 openPosition = Vector3.zero;
        for (int i = 4; i < startingPositions.Length; i++)
        {
            if (!startingPositions[i].filled)
            {
                openPosition = startingPositions[i].position;
                startingPositions[i].filled = true;
                data.positionIndex = i;
                break;
            }
        }

        InstantiateObj(data, openPosition);
        beaker.DestroyObj();
        menu.AddToMenu(data.matColor, data.setName);
    }

    /*
     * Purpose: instantiate the new item obj in specified position
     */
    public GameObject InstantiateObj(Item data, Vector3 position)
    {
        GameObject newItem = Instantiate(baseItem);
        newItem.GetComponent<ItemObjScript>().SetData(data);

        newItem.GetComponent<Renderer>().material.color = data.matColor;

        newItem.transform.position = position;

        return newItem;
    }

    /*
     * Purpose: once an item is removed, mark that position as open
     */
    public void ClearPositions(GameObject obj)
    {
        int index = obj.GetComponent<ItemObjScript>().GetIndex();

        startingPositions[index].filled = false;
    }

    /*
     * Purpose: init the menu and create the 4 base items
     */
    public void SetMenu(int numItems)
    {
        menu.InitMenu(numItems);
        SpawnStartItems();
    }
}
