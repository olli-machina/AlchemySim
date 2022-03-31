using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObjScript : MonoBehaviour
{
    public Item itemData;
    // Start is called before the first frame update
    void Start()
    {
        name = itemData.setName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Beaker")
            //add to mix and then destroy
            {}
    }
}
