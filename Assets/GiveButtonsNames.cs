using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Script to put emotions on buttons (randomly), used in the scenes "recognize" and "identify"
public class GiveButtonsNames : MonoBehaviour
{

    public UnityEngine.UI.Button[] buttons;//array of buttons to put the text on

    public string[] names;//array of emotions for the buttons (angry, sad, happy, fear)

    void Start()
    {
        int rand;
        List<string> nm = new List<string>(names);//liso that after a name is added it can be removed

        for (int i = 0; i < buttons.Length; i++)
        {
            rand = Random.Range(0, buttons.Length - 1 - i);//gets a random number for one of the exisiting names
            buttons[i].GetComponentsInChildren<UnityEngine.UI.Text>()[0].text = nm[rand];//sets a button to have the random chosen name
            nm.RemoveAt(rand);//removes the name so that it will not be used again
        }
    }

}
