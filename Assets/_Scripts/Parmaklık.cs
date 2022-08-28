using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parmaklık : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("monkey"))
        {
            Debug.Log("mokey animasyonları falan filan");
        }
        else
        {
            //fail durumları
        }
    }
}
