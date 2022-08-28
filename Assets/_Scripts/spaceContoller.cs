using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceContoller : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("fail durumu kodla ");
        //if (other.CompareTag("bat"))
        //{
        //    //yarasa ise devamkeee deðilse fail durumu

        //    //PlayerController.instance.bat.SetActive(false);
        //    //PlayerController.instance.ghost.SetActive(true);
        //    //PlayerController.instance.batP.SetActive(false);
        //}
    }
  
}
