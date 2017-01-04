using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RBPlayerController : MonoBehaviour {
	public float speed=10; //球的速度
	public Text countText;
	public Text winText;

	private Rigidbody rb;//剛性元件控制變數
	private int count; //紀錄目前PickUp的計數器
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();//取得剛性元件的控制權
		count = 0;
		SetCountText ();
		winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		//取得上下左右鍵的按鍵值
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		//根據方向鍵設定物件移動方向
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		//施予物件的力量進行移動
		rb.AddForce (movement * speed);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("PickUp"))
			//檢查是否與"PickUp"標籤同名的物件有碰撞
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}
	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12)
		{
			winText.text = "陳瑞樂 贏了!";
		}
	}

}
