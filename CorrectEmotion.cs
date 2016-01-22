using UnityEngine;
using System.Collections;

public class CorrectEmotion : MonoBehaviour {

	public string emotion;
	void Start()
	{
		emotion = NetworkManager.GetInstance().emotion;
	}

		
}
