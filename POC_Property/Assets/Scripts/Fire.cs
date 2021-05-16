using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fire : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Scene active;

        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            active = SceneManager.GetActiveScene();
            SceneManager.LoadScene(active.buildIndex);
        }
    }
}
