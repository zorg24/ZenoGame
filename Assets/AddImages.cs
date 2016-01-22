using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System;
//Script to add images to buttons in the "select" scene
public class AddImages : MonoBehaviour {

	//Arrays of imported images
	public Sprite[] AngryFaces;
	public Sprite[] HappyFaces;
	public Sprite[] SurprisedFaces;
	public Sprite[] SadFaces;
	public Sprite[] FearFaces;

	//Array of buttons to add the images to
	public UnityEngine.UI.Button[] images;

	// Use this for initialization
	void Awake() {
		int rand;
		List<int> nm = new List<int> ();//nm is used to add the images to the buttons randomly

		//Loop to add integers to use for randomization
		for(int i=0; i<images.Length; i++)
		{
			nm.Add (i);
		}

		//Loop to add emotions to the buttons, in the order that the emotions are given
		for (int i=0; i<images.Length; i++) {
			rand = nm[UnityEngine.Random.Range (0, images.Length-1-i)];//gets a random number, with a range of how many buttons there are, and decreases every iterations as one more button is being used

			images[rand].gameObject.GetComponent<selectScript>().answer=(i==0);//the first emotion given is the correct answer so sets the first buttton as the correct answer
			images[rand].gameObject.GetComponent<selectScript>().emotion=NetworkManager.GetInstance().pictures[i*2+1];//finds the string of the emotion in the array input
			images[rand].gameObject.GetComponent<selectScript>().number=Convert.ToInt32(NetworkManager.GetInstance().pictures[(i+1)*2]);// the string of the picture number in the input and parses it to an integer

			//Switch styatement to choose the correct picture for the emotion from one of the arrays of pictures
			switch(NetworkManager.GetInstance().pictures[i*2+1])
			{
			case "angry":
				images[rand].gameObject.GetComponent<UnityEngine.UI.Image> ().sprite = AngryFaces [Convert.ToInt32(NetworkManager.GetInstance().pictures[(i+1)*2])-1]; 
				break;
			case "happy":
				images[rand].gameObject.GetComponent<UnityEngine.UI.Image> ().sprite = HappyFaces [Convert.ToInt32(NetworkManager.GetInstance().pictures[(i+1)*2])-1]; 
				break;
			case "sad":
				images[rand].gameObject.GetComponent<UnityEngine.UI.Image> ().sprite = SadFaces [Convert.ToInt32(NetworkManager.GetInstance().pictures[(i+1)*2])-1]; 	
					break;
			case "surprised":
				images[rand].gameObject.GetComponent<UnityEngine.UI.Image> ().sprite = SurprisedFaces [Convert.ToInt32(NetworkManager.GetInstance().pictures[(i+1)*2])-1]; 
				break;
			case "fear":
				images[rand].gameObject.GetComponent<UnityEngine.UI.Image> ().sprite = FearFaces [Convert.ToInt32(NetworkManager.GetInstance().pictures[(i+1)*2])-1]; 
					break;
			default://defult case is activated when a non-recognized emotion is given
				Debug.Log ("This isn't working  "+NetworkManager.GetInstance().pictures[i*2+1]);
				break;
			}
			nm.Remove (rand);//removes the random number chosen so that button is not used for an image again
		}
	}
}
