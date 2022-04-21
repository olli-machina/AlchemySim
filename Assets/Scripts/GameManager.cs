using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject baseItem;
    public RecipeManager recipeManager;
    public GameObject[] starting;//temp
    public Beaker_Script beaker;
    public MenuScript menu;

    // Start is called before the first frame update
    void Start()
    { //all temporary
        starting[0].GetComponent<Renderer>().material.color = new Color(51f/255f,51f/255f,1f);
        starting[1].GetComponent<Renderer>().material.color = new Color(1f,128f/255f,0f);
        starting[2].GetComponent<Renderer>().material.color = new Color(76f/255f,153f/255f,0f);
        starting[3].GetComponent<Renderer>().material.color = new Color(153f/255f,1f,1f);
        //water,fire,earth,air
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void checkForRecipe(Item obj1, Item obj2)
    {
        recipeManager.checkItems(obj1, obj2);
    }

    public GameObject createNewItem(Item data)
    {
        GameObject newItem = Instantiate(baseItem);
        newItem.GetComponent<ItemObjScript>().setData(data);

        newItem.GetComponent<Renderer>().material.color = data.matColor;
        newItem.transform.position = new Vector3(0, 0.7f, 0);

        beaker.DestroyObj();

        return newItem;
    }

    public void createNewItem(Item data, Vector3 position)
    {
        GameObject createItem = createNewItem(data);
        createItem.transform.position = position;
    }

    public void setMenu(int numItems)
    {
        menu.InitMenu(numItems);
    }
}
