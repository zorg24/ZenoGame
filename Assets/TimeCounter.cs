using UnityEngine;
using System.Collections;

public class TimeCounter : MonoBehaviour {

	public float time;
	float lastTime;
	bool paused=false;
	public ClickCounter noPlayCount;
	public UnityEngine.UI.Button[] buttons;
	void Start () {
		NetworkManager.GetInstance ().goOn = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(!paused)
			time +=(Time.timeSinceLevelLoad-lastTime);
		lastTime = Time.timeSinceLevelLoad;
		GetComponentsInChildren<UnityEngine.UI.Text>()[0].text=(60.000001-time).ToString().Substring(0,4);
		if (NetworkManager.GetInstance ().goOn) {
			NetworkManager.GetInstance ().goOn = false;
			UnPause ();
		}

		if (time >= 60) {
			NetworkManager.GetInstance().game="Main Game Screen";
			NetworkManager.GetInstance().SendUDPMessage("noplay "+ noPlayCount.timesNoPlayClicked);
			NetworkManager.GetInstance().GoToMain();
			Debug.Log(time);
		}
	}
	public void Pause()
	{
		paused = true;
		foreach (UnityEngine.UI.Button b in buttons)
			b.interactable = false;
	}
	void UnPause()
	{
		paused = false;
		foreach (UnityEngine.UI.Button b in buttons)
			b.interactable = true;
		
	}

}
