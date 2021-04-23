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
            RemoveProperty(objectsWithProperty[0], 1);
            objectsWithProperty[0] = null;
            objectsWithProperty[0] = objectToAdd;
        }
        else
        {
            objectsWithProperty[0] = objectToAdd;
        }
    }
    public void AddToProperty2()
    {

    }
    public void AddToProperty3()
    {

    }
    public void AddToProperty4()
    {

    }

    void RemoveProperty(GameObject objectToClean, int propertyNumber)
    {
        objectToClean.GetComponent<Surface>().RemoveProperty(propertyNumber);
    }
}
