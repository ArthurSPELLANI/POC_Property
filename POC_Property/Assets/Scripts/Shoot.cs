using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera fpsCam;
    public PropertyManager propertyManager;
    public PlayerMovement move;
    public GameObject ld;

    Vector3 playerPos;

    bool rtInUse = false;
    bool ltInUse = false;

    public bool canTurn = true;

    private void Update()
    {
        playerPos = transform.position;

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
        if (Input.GetButtonDown("Fire3") && canTurn)
        {
            StartCoroutine(TurnLeft());
        }
        if (Input.GetButtonDown("Fire4") && canTurn)
        {
            StartCoroutine(TurnRight());
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
                propertyManager.AddToProperty1(hit.transform.gameObject);
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
                propertyManager.AddToProperty2(hit.transform.gameObject);
            }
        }
    }

    Quaternion previousRot;
    Vector3 playerVel;
    
    private IEnumerator TurnLeft()
    {
        canTurn = false;
        playerVel = GetComponent<Rigidbody>().velocity;
        move.isTurning = true;
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().useGravity = false;
        previousRot = ld.transform.rotation;
        for (int i = 0; i < 180; i++)
        {
            ld.transform.RotateAround(playerPos, ld.transform.right, -0.5f);
            //ld.transform.rotation = ld.transform.rotation * Quaternion.Euler(0.5f, 0, 0);
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.2f);
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().velocity = playerVel;
        move.isTurning = false;
        canTurn = true;
    }

    private IEnumerator TurnRight()
    {
        canTurn = false;
        playerVel = GetComponent<Rigidbody>().velocity;
        move.isTurning = true;
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().useGravity = false;
        previousRot = ld.transform.rotation;
        for (int i = 0; i < 180; i++)
        {
            ld.transform.RotateAround(playerPos, ld.transform.right, -0.5f);
            //ld.transform.rotation = ld.transform.rotation * Quaternion.Euler(-0.5f, 0, 0);
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.2f);
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().velocity = playerVel;
        move.isTurning = false;
        canTurn = true;
    }
}
