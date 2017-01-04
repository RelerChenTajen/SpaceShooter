using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public float speed=10; //行進速度
	Rigidbody rb; //取得 Rigidbody 控制變數
	

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> (); //取得 Rigidbody 控制權
		rb.velocity = transform.forward * speed; //設定前進速度
	}
	
	// Update is called once per frame
	void Update () {

		
	}
}
