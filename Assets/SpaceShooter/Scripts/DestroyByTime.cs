using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {
	public float lifetime = 2.0f; //設定自動移除時間
	// Use this for initialization
	void Start () {
		Destroy (gameObject, lifetime); //時間到, 自動移除物件本身
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
