using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {
	Rigidbody rb; //取得Rigidbody控制變數 
	public float tumble=5; //滾動參數

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> (); //取得Rigidbody控制權
		//設定滾動速度為亂數取值乘以滾動參數
		rb.angularVelocity = Random.insideUnitSphere * tumble; 


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
