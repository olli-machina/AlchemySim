using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    List<Combination> recipeList;

    void Start()
    {
        //load txt and library
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
