using UnityEngine;
using System.Collections;

public class BtnController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void RollABallBtn(){
		Application.LoadLevel (1);
	}
	public void SpaceShooterBtn(){
		Application.LoadLevel (2);
	}
}
