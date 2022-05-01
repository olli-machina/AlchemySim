using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beaker_Script : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField]
    GameObject combine1, combine2;

    public void ResetCombo()
    {
        combine1 = null;
        combine2 = null;
    }

    public void DestroyObj()
    {
        Destroy(combine1);
        Destroy(combine2);
        ResetCombo();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Item"))
        {
            if (combine1 == null)
            {
                combine1 = other.gameObject;
                gameManager.ClearPositions(combine1);
            }
            else
            {
                combine2 = other.gameObject;
                gameManager.ClearPositions(combine2);
                gameManager.CheckForRecipe(combine1.GetComponent<ItemObjScript>().GetData(), combine2.GetComponent<ItemObjScript>().GetData());
            }

        }
    }
}
