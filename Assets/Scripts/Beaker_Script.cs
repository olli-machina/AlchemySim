using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beaker_Script : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField]
    GameObject combine1, combine2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetCombo()
    {
        combine1 = null;
        combine2 = null;
    }

    public void DestroyObj()
    {
        Destroy(combine1);
        Destroy(combine2);
        resetCombo();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            if (combine1 == null)
                combine1 = other.gameObject;
            else
            {
                combine2 = other.gameObject;
                gameManager.checkForRecipe(combine1.GetComponent<ItemObjScript>().getData(), combine2.GetComponent<ItemObjScript>().getData());
            }

        }
    }
}
