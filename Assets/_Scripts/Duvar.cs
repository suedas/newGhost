using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duvar : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("gergedan"))
        {
            Debug.Log("gergedan animasyonları falan filan");
        }
        else
        {
            //fail durumları
        }
    }
}
