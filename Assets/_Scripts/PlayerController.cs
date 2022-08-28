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
    public GameObject player;
    public CinemachineVirtualCamera cb;

    public  SkinnedMeshRenderer skinnedMeshRenderer;
    public Mesh skinnedMesh;
    float blendOne = 0;
    float blendTwo = 0;
    public GameObject circleP;
    public GameObject boomP;
    public GameObject starP,batP;
    public GameObject fýckP,ruzgar;
    public Animator anim;
    public  Animator idleGhost;
    public int count;
    public Transform diamondTarget;
    public GameObject box;
    public GameObject humans;
    public GameObject bat,dino;

   
    
    
    //public TailAnimator2 sagTail, solTail;
   
    private void Start()
    {
        
        anim =player.GetComponent<Animator>();      
        
    }
    public void Ghost()
    {
        SwerveMovement.instance.isHuman = false;
        ghost.SetActive(true);
        gameObject.tag = "ghost";
        player.SetActive(false);
    }
    public void Human()
    {
        SwerveMovement.instance.isHuman = true;
        player.SetActive(true);
        gameObject.tag = "Player";
        anim.SetBool("run", true);
        ghost.SetActive(false);
    
    }
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
            batP.SetActive(true);
            ghost.SetActive(false);
            bat.SetActive(true);

            //gameObject.tag = "bat";
        }
        else if (other.CompareTag("dino"))
        {
            batP.SetActive(true);
            Destroy(other.gameObject);
            ghost.SetActive(false);
            dino.SetActive(true);

        }
        else if (other.CompareTag("deniz"))
        {
            dino.SetActive(false);
            ghost.SetActive(true);
        }
    
   
        else if (other.CompareTag("finish"))
        {

            PlayerMovement.instance.speed = 12f;
            ruzgar.SetActive(true);
        
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
        ruzgar.SetActive(false);
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
