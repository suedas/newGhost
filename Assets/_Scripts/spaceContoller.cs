using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceContoller : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("a");
        if (other.CompareTag("ghost"))
        {
            PlayerController.instance.bat.SetActive(false);
            PlayerController.instance.ghost.SetActive(true);
            PlayerController.instance.batP.SetActive(false); 


        }
    }
}
