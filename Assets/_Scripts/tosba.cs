using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tosba : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("tosba"))
        {
            Debug.Log("tosba animasyonlar� falan filan");
       
        }
        else
        {
            //fail durumlar�
        }
    }
}
