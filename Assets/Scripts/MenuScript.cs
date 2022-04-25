using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MenuScript : MonoBehaviour
{
    public GameObject[] itemPanels;
    GameObject singlePanel;
    public Vector3[] positions;
    int currentPos = 0;
    int menuSquare = 4;

    GraphicRaycaster raycaster;
    public RecipeManager recipeManager;
    public GameManager gameManager;

    public void InitMenu(int numItems)
    {
       // itemPanels = new GameObject[numItems];
    }

    // Start is called before the first frame update
    void Start()
    {
        this.raycaster = GetComponent<GraphicRaycaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            spawnItem();
        }
    }

    void spawnItem()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        List<RaycastResult> results = new List<RaycastResult>();

        pointerData.position = Input.mousePosition;
        this.raycaster.Raycast(pointerData, results);

        if (results.Count > 0 && results[0].gameObject.tag == "MenuButton")
        {
            if(currentPos > positions.Length-1)
                currentPos = 0;
            
            Item newItem = recipeManager.getItem(results[0].gameObject.GetComponentInChildren<TMP_Text>().text);
            Debug.Log(newItem.setName);
            gameManager.createNewItem(newItem, positions[currentPos]);
            currentPos++;
            results.Clear();

        }
        else
        {
            results.Clear();
        }
    }

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
