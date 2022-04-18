using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public Beaker_Script beaker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            if(Input.GetMouseButtonDown(0))
            {
                if (hit.collider.tag == "Item")
                {
                    print("Pressed");
                    hit.transform.position = beaker.transform.position;
                }
            }
        }
    }
}
