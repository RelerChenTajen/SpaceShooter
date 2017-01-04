using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//設定各軸旋轉角度,  角度大則旋轉速度快
		//Time.deltaTime:  每一個 frame 的執行時間,  用來調控角度大小
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);

	}
}
