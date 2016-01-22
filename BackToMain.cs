using UnityEngine;
using System.Collections;

//Script called my any scene to go back to main
public class BackToMain : MonoBehaviour {


	// Use this for initialization
	
	// Update is called once per frame
	void Update () 
	{
		if (NetworkManager.GetInstance().game != null)
			if (NetworkManager.GetInstance().game == "Main Game Screen") {
				NetworkManager.GetInstance().GoToMain();
		}
	}
}
