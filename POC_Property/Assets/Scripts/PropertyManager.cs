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
            ChekIfAlreadyInList(objectToAdd);
            RemoveProperty(objectsWithProperty[0], 1);
            objectsWithProperty[0] = null;
            objectsWithProperty[0] = objectToAdd;
        }
        else
        {
            objectsWithProperty[0] = objectToAdd;
        }
    }
    public void AddToProperty2(GameObject objectToAdd)
    {
        if (objectsWithProperty[1] != null)
        {
            ChekIfAlreadyInList(objectToAdd);
            RemoveProperty(objectsWithProperty[1], 2);
            objectsWithProperty[1] = null;
            objectsWithProperty[1] = objectToAdd;
        }
        else
        {
            objectsWithProperty[1] = objectToAdd;
        }
    }
    public void AddToProperty3(GameObject objectToAdd)
    {
        if (objectsWithProperty[2] != null)
        {
            ChekIfAlreadyInList(objectToAdd);
            RemoveProperty(objectsWithProperty[2], 3);
            objectsWithProperty[2] = null;
            objectsWithProperty[2] = objectToAdd;
        }
        else
        {
            objectsWithProperty[2] = objectToAdd;
        }
    }
    public void AddToProperty4(GameObject objectToAdd)
    {
        if (objectsWithProperty[3] != null)
        {
            ChekIfAlreadyInList(objectToAdd);
            RemoveProperty(objectsWithProperty[3], 4);
            objectsWithProperty[3] = null;
            objectsWithProperty[3] = objectToAdd;
        }
        else
        {
            objectsWithProperty[3] = objectToAdd;
        }
    }

    void ChekIfAlreadyInList(GameObject objectToCheck)
    {
        for (int i = 0; i < objectsWithProperty.Length; i++)
        {
            if(objectsWithProperty[i] == objectToCheck)
            {
                objectsWithProperty[i] = null;
                RemoveProperty(objectToCheck, i);
            }
        }
    }

    void RemoveProperty(GameObject objectToClean, int propertyNumber)
    {
        objectToClean.GetComponent<Surface>().RemoveProperty(propertyNumber);
    }
}
