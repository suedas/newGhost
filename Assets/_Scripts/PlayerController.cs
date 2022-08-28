using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
using FIMSpace.FTail;


public class PlayerController : MonoBehaviour
{
    #region Singleton
    public static PlayerController instance;
    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }
    #endregion

    public GameObject ghost;   
    public GameObject batP;
    public Animator anim;
    public  Animator idleGhost;
    public Transform diamondTarget; 
    public GameObject bat,dino,gary,gergedan,monkey,kertenkele,tospa,penguen;



    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("diamond"))
        {
          
                other.gameObject.transform.DOMove(diamondTarget.transform.position, .5f).OnComplete(() => { Destroy(other.gameObject); });
                other.gameObject.transform.DOScale(.25f, .2f);
                GameManager.instance.IncreaseScore();
            
        }      
        else if (other.CompareTag("bat"))
        {
            Destroy(other.gameObject);
            gameObject.tag = "bat";
            batP.SetActive(true);
            ghost.SetActive(false);
            bat.SetActive(true);

            //gameObject.tag = "bat";
        }
        else if (other.CompareTag("dino"))
        {
            batP.SetActive(true);
            gameObject.tag = "dino";
            Destroy(other.gameObject);
            ghost.SetActive(false);
            dino.SetActive(true);

        }
        else if (other.CompareTag("gary"))
        {
            gameObject.tag = "gary";
            Destroy(other.gameObject);
            gary.SetActive(true);
            ghost.SetActive(false);
            
        }
        else if (other.CompareTag("gergedan"))
        {
            gameObject.tag = "gergedan";
            Destroy(other.gameObject);
            gergedan.SetActive(true);
            ghost.SetActive(false);

        }
        else if (other.CompareTag("duvar"))
        {
            if (gameObject.tag == "gergedan")
            {
                Debug.Log("duvarlarý kýr");

            }
            else
            {
                Debug.Log("fail ");
            }
        }
        else if (other.CompareTag("demirduvar"))
        {
            if (gameObject.tag=="gergedan")
            {
                Debug.Log("gergedan yandý");
            }

        }
        else if (other.CompareTag("monkey"))
        {
            gameObject.tag = "monkey";
            Destroy(other.gameObject);
            monkey.SetActive(true);
            ghost.SetActive(false);

        }
        else if (other.CompareTag("kertenkele"))
        {
            gameObject.tag = "kertenkele";
            Destroy(other.gameObject);
            kertenkele.SetActive(true);
            ghost.SetActive(false);
        }
        else if (other.CompareTag("tosba"))
        {
            gameObject.tag = "tosba";
            Destroy(other.gameObject);
            tospa.SetActive(true);
            ghost.SetActive(false);
        }
        else if (other.CompareTag("penguen"))
        {
            gameObject.tag = "penguen";
            Destroy(other.gameObject);
            penguen.SetActive(true);
            ghost.SetActive(false);
        }
        
        else if (other.CompareTag("hayalet"))
        {
            int characters = transform.childCount;
            Debug.Log("sel");
            ghost.SetActive(true);
            gameObject.tag = "ghost";
            for (int i = 1; i < characters; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else if (other.CompareTag("buzul"))
        {
            if (gameObject.tag=="penguen")
            {
                Debug.Log("yandý");

            }
        }
        else if (other.CompareTag("finish"))
        {
            GameManager.instance.isContinue = false;
        }
        

          
    }
    
   
   
  
    /// <summary>
    /// next level veya restart level butonuna tiklayinca karakter sifir konumuna tekrar alinir. (baslangic konumu)
    /// varsa animasyonu ayarlanýr. varsa scale rotation gibi degerleri sifirlanir.. varsa ekipman collectible v.s. gibi seyler temizlenir
    /// score v.s. sifirlanir. bu gibi durumlar bu fonksiyon içinde yapilir.
    /// </summary>
    public void PreStartingEvents()
	{
        PlayerMovement.instance.speed = 10f;    
        PlayerMovement.instance.transform.position = Vector3.zero;
        transform.position = Vector3.zero;
        GameManager.instance.isContinue = false;
        SwerveMovement.instance.isSwipe = true;
        UiController.instance.gamePanel.SetActive(true);
    }

    /// <summary>
    /// taptostart butonuna týklanýnca (ya da oyun basi ilk dokunus) karakter kosmaya baslar, belki hizi ayarlanýr, animasyon scale rotate
    /// gibi degerleri degistirilecekse onlar bu fonksiyon icinde yapilir...
    /// </summary>
    public void PostStartingEvents()
    {
        GameManager.instance.levelScore = 0;
        GameManager.instance.isContinue = true;
        PlayerMovement.instance.speed = 10f;

	}
}
