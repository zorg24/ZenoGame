using UnityEngine;
using System.Collections;

public class SendToGame : MonoBehaviour {

	void Awake(){
	
	}

	public void LoadGame()
	{
		NetworkManager.GetInstance ().SendUDPMessage ("began game: "+NetworkManager.GetInstance().game);
		Application.LoadLevel (NetworkManager.GetInstance().game);
	}

}
