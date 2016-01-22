using UnityEngine;
using System.Collections;

public class GotoMainMenu : MonoBehaviour {

	public UnityEngine.UI.Button button;
	public Counter count_thing;

	public void disable(){
		count_thing.increment ();
		button.enabled = false;
		button.GetComponentsInChildren<UnityEngine.UI.Text> () [0].text = "Disabled";
	}

	public void LoadLevel(string s){
		Application.LoadLevel (s);
	}

	public void FixedUpdate(){
		this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x, 
		                                              this.gameObject.transform.position.y + 10 * Mathf.Sin (Time.fixedTime), 
		                                              this.gameObject.transform.position.z);
	}
}
