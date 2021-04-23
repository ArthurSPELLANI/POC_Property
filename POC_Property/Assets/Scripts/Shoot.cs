using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera fpsCam;
    public PropertyManager propertyManager;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot1();
        }

        void Shoot1()
        {
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
            {
                if (hit.transform.gameObject.GetComponent<Surface>())
                {
                    hit.transform.gameObject.GetComponent<Surface>().Property1();
                }                
            }
        }
    }
}
