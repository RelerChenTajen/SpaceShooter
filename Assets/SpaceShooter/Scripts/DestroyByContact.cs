using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion; //隕石爆炸特效物件
	public GameObject playerExplosion; //太空船爆炸特效物件
	private GameController gameController; //宣告控制變數
	public int scoreValue=10;
	// Use this for initialization
	void Start () {
		//找到GameController 物件, 取得控制權
		GameObject gameControllerObject = 
			GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = 
				gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			return;
		}
		gameController.AddScore (scoreValue);
		//產生隕石爆炸特效於場景之上
		Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Player")
		{  //產生太空船爆炸特效於場景之上
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver (); //進行程式中止的程序
		}

		Destroy(other.gameObject);
		Destroy(gameObject);
	}

}
