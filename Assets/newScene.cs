using UnityEngine;
using System.Collections;

//Loads a scene
public class newScene : MonoBehaviour {

	public void LoadLevel(string s){
		Application.LoadLevel (s);//goes to scene based on string input
	}
}
