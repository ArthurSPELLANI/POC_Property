using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public GameObject rotateObj;

    private void Update()
    {
        transform.rotation = rotateObj.transform.rotation;
    }
}
