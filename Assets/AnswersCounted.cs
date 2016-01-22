using UnityEngine;
using System.Collections;

//Script to decide if the third button must be set to green early in "select" scene
public class AnswersCounted : MonoBehaviour {

	public bool attempted;//variable that is used if one correct answer is chosen

	public UnityEngine.UI.Button[] buttons;
	// Use this for initialization
	void Start () {
		attempted = false;//to begin scene no button has been chosen to attempted is false
	
	}

	//Called when a button is clicked, sets attempted to true
	public void choose()
	{
		attempted = true;
	}

	//Called when attempted is true so there has been one incorrect attempt, and then anouther incorrect attempt is made
	public void SetLastGreen()
	{
		//For each loop to go through buttons and find the correct answer
		foreach (UnityEngine.UI.Button b in buttons)
			b.GetComponent<selectScript>().goGreen = b.GetComponent<selectScript>().answer;//makes the button turn green when it is the correct answer
	}


}
