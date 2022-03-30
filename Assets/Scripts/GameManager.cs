using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject baseItem;
    //RecipeManager recipeManager;
    public Mesh testMesh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkForRecipe(/*Item obj1, Item obj2*/)
    {
        //recipeManager.CheckItems(obj1, obj2);
        Item test = new Item();
        test.setName = "magic";
        test.mesh = testMesh;

        createNewItem(test);
    }

    public void createNewItem(Item data)
    {
        GameObject newItem = Instantiate(baseItem);
        newItem.GetComponent<ItemObjScript>().itemData = data;
        newItem.transform.position = new Vector3(0, 0.7f, 0);
        //change mesh when we get there

    }
}
