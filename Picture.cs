using UnityEngine;
using System.Collections;

public class Picture : MonoBehaviour {

	public int number;
	void Start()
	{
		number = NetworkManager.GetInstance().number;
	}
}
