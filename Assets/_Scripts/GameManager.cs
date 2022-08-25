 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	#region Singleton
	public static GameManager instance;
	void Awake()
	{
		if (instance == null) instance = this;
		else Destroy(this);
	}
	#endregion

	public bool isContinue; // player hareket etmesi veya dokunmatik calismasi buna bagli
	public int scoreArtisMiktari; // bu de�er inspekt�r �zerinden ayarlanacak. her collectible a carpinca ne kadar score artisi olacagini bu sabit deger kontrol edecek
	[HideInInspector]public int score; // bu deger birikimli olarak gidecektir. Her level sonu birikecek �zerine eklenecek. para v.s. olabilir.
	[HideInInspector]public int levelScore; // bu deger her levelin kendi score'u olacak. Her level basinda sifirlanacak. Level sonunda score'a eklenecek

	private void Start()
	{
		//isContinue = true;
		score = PlayerPrefs.GetInt("score");
		//PlayerPrefs.DeleteAll();
	}


	/// <summary>
	/// Bu fonksiyon score de�erinin artirilmasi icin kullanilir. 
	/// Collectiblelara carpinca cagrilir.
	/// Farkli sekilde kullanmak icin developer kendisi fonksiyonu modifiye etmelidir.
	/// </summary>
	public void IncreaseScore()
	{
		score += scoreArtisMiktari;
		levelScore += scoreArtisMiktari;
		PlayerPrefs.SetInt("score", score);
		UiController.instance.SetScoreText();
	}
	public void oyunsonu()
    {
        if (PlayerController.instance.count>0)
        {
			int count = PlayerController.instance.count;
			Debug.Log("count"+count);
			Debug.Log("score"+score);
			score = score * count;
			levelScore = score * PlayerController.instance.count;
			PlayerPrefs.SetInt("score", score);
			UiController.instance.SetScoreText();

        }
	}


	/// <summary>
	/// Bu fonksiyon score de�erinin azaltilmasi icin kullanilir. 
	/// Obstaclelara carpinca cagrilir.
	/// Farkli sekilde kullanmak icin developer kendisi fonksiyonu modifiye etmelidir.
	/// </summary>
	public void DecreaseScore()
	{
		score -= scoreArtisMiktari;
		levelScore -= scoreArtisMiktari;
		PlayerPrefs.SetInt("score", score);
		UiController.instance.SetScoreText();
	}
}
