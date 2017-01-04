using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject hazard; //隕石物件變數
	public Vector3 spawnValues; //隕石出現時的指定位置
	public int hazardCount = 10; //每一波隕石產生的數量
	public float spawnWait = 0.5f; //每一個隕石產生時要等待的時間
	public float startWait = 1.0f; //遊戲開始時需要等待時間
	public float waveWait=4; //每一波隕石之間停頓的時間
	public Text scoreText; //ScoreText UI元件變數
	private int score;        //分數
	public Text restartText; //Restart UI元件變數
	public Text gameOverText;//GameOver UI元件變數
	
	private bool gameOver;//紀錄GameOver的狀態
	private bool restart; //紀錄Restart的狀態


	// Use this for initialization
	void Start () {
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";

		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ()); //執行產生隕石的程序
	}
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

	//產生隕石的方法
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait); //遊戲開始等待一下
		while (true) //無窮盡的產生隕石
		{
			for (int i = 0; i < hazardCount; i++) //每一波隕石依序產生
			{
				Vector3 spawnPosition = new Vector3 (
					Random.Range (-spawnValues.x, spawnValues.x), 
					spawnValues.y, 
					spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait); //停頓一下
			}
			yield return new WaitForSeconds (waveWait); //等待一下
			if (gameOver) //gameOver == true,
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}

		}
	}


	
	// Update is called once per frame
	void Update () {
		if (restart)//restart == true,
		{
			if (Input.GetKeyDown (KeyCode.R)) //使用者按下"R"鍵
			{
				Application.LoadLevel (Application.loadedLevel); //系統重新載入目前的場景
			}
		}

	}

	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
		Debug.Log ("Game Over!");
	}

}
