using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceContoller : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("a");
        if (other.CompareTag("bat"))
        {
            Debug.Log("selamm");
            other.GetComponent<Animator>().SetBool("fly", true);
        }
    }
}
