using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera fpsCam;
    public PropertyManager propertyManager;

    bool rtInUse = false;
    bool ltInUse = false;

    private void Update()
    {
        if (Input.GetAxisRaw("Fire1") != 0 && rtInUse == false)
        {
            Shoot1();
            rtInUse = true;
        }
        if (Input.GetAxisRaw("Fire2") != 0 && ltInUse == false)
        {
            Shoot2();
            ltInUse = true;
        }
        if (Input.GetButtonDown("Fire3"))
        {
            Shoot3();
        }
        if (Input.GetButtonDown("Fire4"))
        {
            Shoot4();
        }

        if(Input.GetAxisRaw("Fire1") == 0 && rtInUse == true)
        {
            rtInUse = false;
        }
        if(Input.GetAxisRaw("Fire2") == 0 && ltInUse == true)
        {
            ltInUse = false;
        }
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

    void Shoot2()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            if (hit.transform.gameObject.GetComponent<Surface>())
            {
                hit.transform.gameObject.GetComponent<Surface>().Property2();
            }
        }
    }

    void Shoot3()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            if (hit.transform.gameObject.GetComponent<Surface>())
            {
                hit.transform.gameObject.GetComponent<Surface>().Property3();
            }
        }
    }

    void Shoot4()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            if (hit.transform.gameObject.GetComponent<Surface>())
            {
                hit.transform.gameObject.GetComponent<Surface>().Property4();
            }
        }
    }
}
