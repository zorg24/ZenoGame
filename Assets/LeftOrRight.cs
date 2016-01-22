using UnityEngine;
using System.Collections;

public class LeftOrRight : MonoBehaviour {

	public UnityEngine.UI.Button leftButton;
	public UnityEngine.UI.Button rightButton;
	public UnityEngine.UI.ColorBlock original;
	public bool clicked =false;
	// Use this for initialization
	void Start () {
		original = leftButton.colors;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void RightClicked()
	{
		NetworkManager.GetInstance ().SendUDPMessage ("right");
		var temp = leftButton.colors;
		//temp.disabledColor = new Color (.047f, .141f, .184f, .82f);
		temp.disabledColor = new Color(.75f,.75f,75f);
        //Diana wanted both arrows to be disabled so that the child is not encouraged to just click on the one that is disabled then.
		leftButton.colors = temp;
        rightButton.colors = temp;
		clicked = true;
		NetworkManager.GetInstance ().goOn = false;
	}
	public void LeftClicked()
	{
		NetworkManager.GetInstance ().SendUDPMessage ("left");
		var temp = rightButton.colors;
		//temp.disabledColor = new Color (.047f, .141f, .184f, .82f);
		temp.disabledColor = new Color(.75f,.75f,75f);
        //Diana wanted both arrows to be disabled so that the child is not encouraged to just click on the one that is disabled then.
		rightButton.colors = temp;
        leftButton.colors = temp;
		clicked = true;
		NetworkManager.GetInstance ().goOn = false;
	}


}
