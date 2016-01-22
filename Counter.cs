using UnityEngine;
using System.Collections;

public class Counter : MonoBehaviour {

	int count = 0;

	// Update is called once per frame
	void Update () {
		Debug.Log (count);
	}

	public void increment(){
		count += 1;
	}
}
