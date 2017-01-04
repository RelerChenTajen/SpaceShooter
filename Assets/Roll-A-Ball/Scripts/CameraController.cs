using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject player; //Player控制變數
	
	private Vector3 offset; //camera與player的距離變數
	// Use this for initialization
	void Start () {
		//計算camera與player之間的距離
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//將目前camera的位置設定為player位置+offset
		transform.position = player.transform.position + offset;
	}
}
