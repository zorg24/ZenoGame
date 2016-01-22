using UnityEngine;
using System.Collections;


//Script to give buttons functionality in the scenes "recognize" and "identify", both  use five (5) buttons
public class recognizeScript : MonoBehaviour
{

    string emotion = NetworkManager.GetInstance().emotion;
    public Trial numTrials;
    public EndGame wrongtwice;
    bool end = false;
    public bool done = false;
    //Use this for initialization
    void Start()
    {
        NetworkManager.GetInstance().goOn = false;
    }

    // Update is called once per frame
    void Update()
    {

        this.GetComponent<UnityEngine.UI.Button>().interactable = NetworkManager.GetInstance().goOn ;//|| NetworkManager.GetInstance().reset;
       // this.GetComponent<UnityEngine.UI.Button>().

        if (end && NetworkManager.GetInstance().goOn)
            NetworkManager.GetInstance().GoToMain();

    }

    public void interact()
    {
        Debug.Log("numTrials: " + numTrials.timesTried);
        if (done)
            return;
        NetworkManager.GetInstance().goOn = false;
        //NetworkManager.GetInstance().reset = false;
        if (emotion.Equals(GetComponentsInChildren<UnityEngine.UI.Text>()[0].text))
            correct();
        else
        {
            NetworkManager.GetInstance().SendUDPMessage("wrong " + GetComponentsInChildren<UnityEngine.UI.Text>()[0].text);
            this.GetComponentInChildren<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
            done = true;

            //Changes button color to red with red shade of disabled color
            var temp = this.GetComponent<UnityEngine.UI.Button>().colors;
            temp.normalColor = Color.red;
            temp.highlightedColor = Color.red;
            temp.pressedColor = Color.red;
            temp.disabledColor = new Color(.812f, .561f, .561f);
            this.GetComponent<UnityEngine.UI.Button>().colors = temp;

            if (numTrials.timesTried == 3)
            {
                Debug.Log("hi");
                wrongtwice.CloseWrongButtons();
            }



        }
    }

    void correct()
    {
        var temp = this.GetComponent<UnityEngine.UI.Button>().colors;
        temp.normalColor = new Color(.459f, .737f, .286f);
		temp.highlightedColor = new Color(.459f, .737f, .286f);
        temp.disabledColor = new Color(.5f, .7f, .4f);
		temp.pressedColor = new Color(.459f, .737f, .286f);
        this.GetComponent<UnityEngine.UI.Button>().colors = temp;

        NetworkManager.GetInstance().SendUDPMessage("right");

        if (numTrials.timesTried < 4)
        {
            NetworkManager.GetInstance().goOn  = false;
            //NetworkManager.GetInstance().reset = false;
            Debug.Log("not going to continue");
        }
        end = true;
    }

}