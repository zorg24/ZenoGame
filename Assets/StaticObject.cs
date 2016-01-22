using UnityEngine;
using System.Collections;

public class StaticObject : MonoBehaviour {
	
	// Use this for initialization
	void Awake(){
		if (GameObject.FindGameObjectsWithTag("nm").Length > 1){
			Destroy (this.gameObject);
		}
		DontDestroyOnLoad (transform.gameObject);
	}
}
