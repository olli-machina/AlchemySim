using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MenuScript : MonoBehaviour
{
    public GameObject[] itemPanels;
    public Vector3[] positions;
    int menuSquare = 4;

    GraphicRaycaster raycaster;
    public RecipeManager recipeManager;
    public GameManager gameManager;


    void Start()
    {
        raycaster = GetComponent<GraphicRaycaster>();
    }

    public void InitMenu(int numItems)
    {
        //if I make the menu dynamic, implement functions here
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            SpawnItem();
        }
    }

    /*
     * Purpose: spawn corresponding item from menu click
     */
    void SpawnItem()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        List<RaycastResult> results = new List<RaycastResult>();

        pointerData.position = Input.mousePosition;
        raycaster.Raycast(pointerData, results);

        if (results.Count > 0 && results[0].gameObject.CompareTag("MenuButton"))
        {
            bool found = false;
            Item newItem = recipeManager.GetItem(results[0].gameObject.GetComponentInChildren<TMP_Text>().text);
            for(int i = 0; i < 4; i++)
            {
                if (results[0].gameObject == itemPanels[i])
                {
                    gameManager.CreateBaseItem(newItem);
                    found = true;
                    break;
                }
            }

            if(!found)
            {
                gameManager.CreateNewItem(newItem);
            }

            results.Clear();

        }
        else
        {
            results.Clear();
        }
    }

    /*
     * Purpose: add the item data to the menu slot
     */
    public void AddToMenu(Color color, string name)
    {
        for (int i = 0; i < itemPanels.Length; i++)
        {
            if (itemPanels[i].name == name)
                return;
        }

        itemPanels[menuSquare].name = name;
        itemPanels[menuSquare].GetComponentInChildren<TMP_Text>().text = name;
        itemPanels[menuSquare].GetComponent<Image>().color = color;

        itemPanels[menuSquare].SetActive(true);
        menuSquare++;
    }
}
