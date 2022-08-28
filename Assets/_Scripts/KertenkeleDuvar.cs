using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class KertenkeleDuvar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("kertenkele"))
        {
            Debug.Log("kertenkele animasyonlar� falan filan");
            GameManager.instance.isContinue = false;
            PlayerMovement.instance.transform.DOMoveY(14.4f, 2f).OnComplete(()=> {  GameManager.instance.isContinue = true; }) ;
        }
        else
        {
            //fail durumlar�
        }
    }
}
