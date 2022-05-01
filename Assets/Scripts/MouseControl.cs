using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public Beaker_Script beaker; //to add clicked obj to the beaker

    /*
     * Purpose: get mouse inputs when clicking on game objects
     */
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            if(Input.GetMouseButtonDown(0))
            {
                if (hit.collider.CompareTag("Item"))
                {
                    hit.transform.position = beaker.transform.position;
                }
            }
        }
    }
}
