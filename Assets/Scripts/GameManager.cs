using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject baseItem;
    public RecipeManager recipeManager;
    public Beaker_Script beaker;
    public MenuScript menu;

    public GameObject[] starting;//temp
    public Vector3[] spawnPositions;
    ItemSlots[] startingPositions;
    int currentPos = 0;


    struct ItemSlots
    {
        public Vector3 position;
        public bool filled;
    }

    // Start is called before the first frame update
    void Start()
    {
        startingPositions = new ItemSlots[spawnPositions.Length];
        for(int i = 0; i < spawnPositions.Length; i++)
        {
            startingPositions[i].position = spawnPositions[i];
            startingPositions[i].filled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnStartItems()
    {
        createBaseItem(recipeManager.getItem("Water"));
        createBaseItem(recipeManager.getItem("Fire"));
        createBaseItem(recipeManager.getItem("Earth"));
        createBaseItem(recipeManager.getItem("Air"));
    }

    public void checkForRecipe(Item obj1, Item obj2)
    {
        recipeManager.checkItems(obj1, obj2);
    }

    public void createNewItem(Item data)
    {
        instantiateObj(data);

        beaker.DestroyObj();

        menu.AddToMenu(data.matColor, data.setName);
    }

    public GameObject instantiateObj(Item data)
    {
        GameObject newItem = Instantiate(baseItem);
        newItem.GetComponent<ItemObjScript>().setData(data);

        newItem.GetComponent<Renderer>().material.color = data.matColor;
        newItem.transform.position = spawnPositions[currentPos];

        return newItem;
    }

    public void createBaseItem(Item data)
    {
        Vector3 openPosition = Vector3.zero;
        for (int i = 0; i < startingPositions.Length; i++)
        {
            if (!startingPositions[i].filled)
            {
                openPosition = startingPositions[i].position;
                startingPositions[i].filled = true;
                break;
            }
        }

        createNewItem(data, openPosition);
    }

    public void createNewItem(Item data, Vector3 position)
    {
        GameObject createItem = instantiateObj(data);
        createItem.transform.position = position;
    }

    public void setMenu(int numItems)
    {
        menu.InitMenu(numItems);
        SpawnStartItems();
    }
}
