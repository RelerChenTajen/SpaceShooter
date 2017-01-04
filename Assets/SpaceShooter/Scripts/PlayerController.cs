using UnityEngine;
using System.Collections;
[System.Serializable] //執行系統重新整理,  將新的類別載入系統中
//建立新的類別,  作為上下左右邊界
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	public int speed=10; //速度
	public float tilt;	//側傾曲率
	public Boundary boundary;	//設定上下左右邊界的物件
	Rigidbody rb;  //取得 Rigidbody 控制變數
	public GameObject shot;	//設定雷射物件
	public Transform shotSpawn;//設定彈匣
	public float fireRate;	//設定發射間隔時間
	private float nextFire; //設定下一次允許發射時間

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> (); //取得控制權
		nextFire = Time.time + fireRate; //設定下一次允許發射的時間
	}
	
	// Update is called once per frame
	void Update () {
		//取得鍵盤按鍵的資訊輸入
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		//形成移動的三軸座標
		Vector3 movement = new Vector3 (moveHorizontal,
		                                0, moveVertical);

		//計算加速度
		rb.velocity = movement * speed;
		rb.position = new Vector3 //若位移超過邊界則以左右邊界為界線
			(
				
				Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
				0.0f,
				Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
				);
		//左右傾斜曲率
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);


		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate; //緊接著設定下次發射時間
			//動態產生雷射物件(物件來源, 出現位置, 出現的空間角度
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}

	}
}





