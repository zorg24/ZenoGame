using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Script for what to do after child presses two incorrect answers in the scnees "recognize" and "identify"
public class EndGame : MonoBehaviour
{

    string emotion = NetworkManager.GetInstance().emotion;//gets the correct emotion from the NetworkManager
    public UnityEngine.UI.Button[] buttons;//array of buttons to turn either red or green

    public void CloseWrongButtons()
    {
        foreach (Button b in buttons)
        {
            if (!(b.GetComponentsInChildren<UnityEngine.UI.Text>()[0].text.Equals(emotion)))
            {
                //case for all of the incorrect buttons

                b.interactable = false; 
                //b.onClick.RemoveAllListeners();//makes the button non-clickable
                //b.GetComponent<recognizeScript>().done = true;//this line of code may not be nessasary, leaving for now to be safe

                //sets the color of the button to be red
                var temp = b.colors;
                temp.normalColor = Color.red;
                temp.highlightedColor = Color.red;
                temp.disabledColor = new Color(.812f, .561f, .561f);//gives the button a different shade of red when they need to wait before pressing the green button
                temp.pressedColor = Color.red;
                b.colors = temp;

            }
            else//case for the correct button
            {

                //sets the button to have the color green
                var temp = b.colors;
                temp.normalColor = new Color(.459f, .737f, .286f);
				temp.highlightedColor = new Color(.459f, .737f, .286f);//gives different shade of green when button is highlighted
                temp.disabledColor = new Color(.459f, .737f, .286f);
				temp.pressedColor = new Color(.459f, .737f, .286f);
                b.colors = temp;
            }
        }
    }

}
