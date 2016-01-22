using UnityEngine;
using System.Collections;

public class ArrowButton : MonoBehaviour {

	private UnityEngine.UI.ColorBlock colors;
	// Use this for initialization
	void Start () {
		NetworkManager.GetInstance ().goOn = false;
		colors = this.GetComponent<UnityEngine.UI.Button> ().colors ;
	
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<UnityEngine.UI.Button>().interactable = NetworkManager.GetInstance().goOn;
		if(NetworkManager.GetInstance().goOn)
			this.GetComponent<UnityEngine.UI.Button> ().colors = colors;
	}
}
