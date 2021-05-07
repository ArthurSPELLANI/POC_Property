using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface : MonoBehaviour
{
    public Material defaultMat;
    public Material prop1Mat, prop2Mat, prop3Mat, prop4Mat;
    public PropertyManager manager;

    public void Property1()
    {
        gameObject.GetComponent<MeshRenderer>().material = prop1Mat;
        manager.AddToProperty1(gameObject);
    }
    public void Property2()
    {
        gameObject.GetComponent<MeshRenderer>().material = prop2Mat;
        manager.AddToProperty2(gameObject);
    }
    public void Property3()
    {
        gameObject.GetComponent<MeshRenderer>().material = prop3Mat;
        manager.AddToProperty3(gameObject);
    }

    public void Property4()
    {
        gameObject.GetComponent<MeshRenderer>().material = prop4Mat;
        manager.AddToProperty4(gameObject);
    }

    public void RemoveProperty(int propertyNumber)
    {
        gameObject.GetComponent<MeshRenderer>().material = defaultMat;
    }
}
