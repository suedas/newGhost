using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timsah : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("dino"))
        {
            Debug.Log("timsah animasyonlarý falan filan");
        }
        else
        {
            //fail durumlarý
        }
    }
}
