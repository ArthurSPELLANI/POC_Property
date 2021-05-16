using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface : MonoBehaviour
{
    public Material defaultMat;
    public Material prop1Mat, prop2Mat;

    public GameObject FX;
    GameObject activeFX;

    public float bounceLevel = 10;
    public float pullRadius = 1;
    public float pullForce = 600;

    int hasProperty = 0;

    public void Property1()
    {
        gameObject.GetComponent<MeshRenderer>().material = prop1Mat;
        hasProperty = 1;
    }
    public void Property2()
    {
        gameObject.GetComponent<MeshRenderer>().material = prop2Mat;
        activeFX = Instantiate(FX, transform.position, Quaternion.identity);
        hasProperty = 2;
    }

    public void RemoveProperty()
    {
        gameObject.GetComponent<MeshRenderer>().material = defaultMat;
        if(activeFX != null)
        {
            Destroy(activeFX);
        }
        hasProperty = 0;
    }

    private void FixedUpdate()
    {
        if (hasProperty == 2)
        {
            foreach (Collider collider in Physics.OverlapSphere(transform.position, pullRadius))
            {
                if(collider.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    Vector3 forceDirection = transform.position - collider.transform.position;
                    collider.GetComponent<Rigidbody>().AddForce(forceDirection.normalized * pullForce * Time.deltaTime);
                }                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(other.GetComponent<Shoot>().canTurn == true)
            {
                switch (hasProperty)
                {
                    case 0:
                        break;
                    case 1:
                        Bounce(other.gameObject);
                        break;
                    case 2:
                        //Stick(other.gameObject);
                        break;
                }
            }            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(other.GetComponent<Shoot>().canTurn == true)
            {
                switch (hasProperty)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        //UnStick(other.gameObject);
                        break;
                }
            }            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(other.GetComponent<Rigidbody>().useGravity == false)
            {
                if(other.GetComponent<Shoot>().canTurn == true)
                {
                    switch (hasProperty)
                    {
                        case 0:
                            //other.GetComponent<PlayerMovement>().AddGravity();
                            break;
                        case 1:
                            Bounce(other.gameObject);
                            break;
                        case 2:
                            //Stick(other.gameObject);
                            break;
                    }
                }                
            }
        }
    }

    Vector3 playerVel; 

    void Bounce(GameObject player)
    {
        playerVel = new Vector3(0,player.GetComponent<Rigidbody>().velocity.y,0);
        player.GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        player.GetComponent<Rigidbody>().AddForce(transform.up * bounceLevel - playerVel * 1.2f, ForceMode.Impulse);
    }

    void Stick(GameObject player)
    {
        player.GetComponent<PlayerMovement>().canGrav = false;
        player.GetComponent<PlayerMovement>().col.material = player.GetComponent<PlayerMovement>().stickMat;
        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    void UnStick(GameObject player)
    {
        player.GetComponent<PlayerMovement>().canGrav = true;
        player.GetComponent<PlayerMovement>().col.material = player.GetComponent<PlayerMovement>().defaultMat;
        player.GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }
}
