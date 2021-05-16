using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyManager : MonoBehaviour
{
    public GameObject[] objectsWithProperty;

    private void Start()
    {
        
    }

    public void AddToProperty1(GameObject objectToAdd)
    {
        if(objectsWithProperty[0] != null)
        {
            if (objectToAdd == objectsWithProperty[1])
            {
                objectsWithProperty[1] = null;
                RemoveProperty(objectsWithProperty[1]);
            }
            RemoveProperty(objectsWithProperty[0]);
            objectsWithProperty[0] = null;
            objectsWithProperty[0] = objectToAdd;
            objectToAdd.GetComponent<Surface>().Property1();
        }
        else
        {
            if (objectToAdd == objectsWithProperty[1])
            {
                RemoveProperty(objectsWithProperty[1]);
                objectsWithProperty[1] = null;
            }
            objectsWithProperty[0] = objectToAdd;
            objectToAdd.GetComponent<Surface>().Property1();
            
        }
    }
    public void AddToProperty2(GameObject objectToAdd)
    {
        if (objectsWithProperty[1] != null)
        {
            if (objectToAdd == objectsWithProperty[0])
            {
                objectsWithProperty[0] = null;
            }
            RemoveProperty(objectsWithProperty[1]);
            objectsWithProperty[1] = null;
            objectsWithProperty[1] = objectToAdd;
            objectToAdd.GetComponent<Surface>().Property2();
        }
        else
        {
            objectsWithProperty[1] = objectToAdd;
            objectToAdd.GetComponent<Surface>().Property2();
            if (objectToAdd == objectsWithProperty[0])
            {
                objectsWithProperty[0] = null;
            }
        }
    }

    /*void ChekIfAlreadyInList(GameObject objectToCheck)
    {
        for (int i = 0; i < objectsWithProperty.Length; i++)
        {
            if(objectsWithProperty[i] == objectToCheck)
            {
                objectsWithProperty[i] = null;
                RemoveProperty(objectToCheck, i);
            }
        }
    }*/

    void RemoveProperty(GameObject objectToClean)
    {
        objectToClean.GetComponent<Surface>().RemoveProperty();
    }
}
