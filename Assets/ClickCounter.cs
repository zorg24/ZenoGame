using UnityEngine;
using System.Collections;

//Script to count the number of times "play" and "noplay" are pressed in the scene "play"
public class ClickCounter : MonoBehaviour {

	public int timesNoPlayClicked=0;//counter for times noPlay is clicked, is broadcasted when scene is left

	//Called when the play button is clicked
	public void PlayClicked()
	{

		NetworkManager.GetInstance ().SendUDPMessage ("playpressed");
	}
	//Called when noplay is clicked
	public void NoPlayClicked()
	{
		NetworkManager.GetInstance ().SendUDPMessage ("noplaypressed");
		timesNoPlayClicked++;
	}

}
