using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface : MonoBehaviour
{
    public Material defaultMat;
    public Material prop1Mat, prop2Mat;

    public float bounceLevel = 10;

    int hasProperty = 0;

    public void Property1()
    {
        gameObject.GetComponent<MeshRenderer>().material = prop1Mat;
        hasProperty = 1;
    }
    public void Property2()
    {
        gameObject.GetComponent<MeshRenderer>().material = prop2Mat;
        hasProperty = 2;
    }

    public void RemoveProperty(int propertyNumber)
    {
        gameObject.GetComponent<MeshRenderer>().material = defaultMat;
        hasProperty = 0;
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
                        Stick(other.gameObject);
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
                        UnStick(other.gameObject);
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
                            other.GetComponent<Rigidbody>().useGravity = true;
                            break;
                        case 1:
                            Bounce(other.gameObject);
                            break;
                        case 2:
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
        player.GetComponent<Rigidbody>().AddForce(transform.up * bounceLevel - playerVel * 1.2f, ForceMode.Impulse);
    }

    void Stick(GameObject player)
    {
        player.GetComponent<PlayerMovement>().col.material = player.GetComponent<PlayerMovement>().stickMat;
        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    void UnStick(GameObject player)
    {
        player.GetComponent<PlayerMovement>().col.material = player.GetComponent<PlayerMovement>().defaultMat;
        player.GetComponent<Rigidbody>().useGravity = true;
    }
}
