using UnityEngine;
using System.Collections;

public class selectScript : MonoBehaviour
{

    bool end = false;
    public bool goGreen = false;
    public bool done = false;
    public string emotion;
    public int number;
    public bool answer;
    public AnswersCounted attempts;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (done)
            this.GetComponent<UnityEngine.UI.Image>().color = Color.red;

        else
        {
            if (goGreen)
                this.GetComponent<UnityEngine.UI.Image>().color = new Color(.459f, .737f, .286f);
            else
                this.GetComponent<UnityEngine.UI.Image>().color = Color.white;
        }

        this.GetComponent<UnityEngine.UI.Button>().interactable = NetworkManager.GetInstance().goOn;// || NetworkManager.GetInstance().reset;
        if (end && NetworkManager.GetInstance().goOn)
            NetworkManager.GetInstance().GoToMain();

    }

    public void interact()
    {
        if (done)
            return;
        NetworkManager.GetInstance().goOn = false;
        //NetworkManager.GetInstance().reset = false;
        if (answer)
            correct();
        else
        {
            NetworkManager.GetInstance().SendUDPMessage("wrong " + emotion + " " + number);
            this.GetComponentInChildren<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
            //if (!NetworkManager.GetInstance().reset)
            done = true;
            if (attempts.attempted)
                attempts.SetLastGreen();
            //Changes button color to red with red shade of disabled color
        }
    }

    void reset()
    {
        //this.
    }

    void correct()
    {
        NetworkManager.GetInstance().SendUDPMessage("right");
        NetworkManager.GetInstance().goOn = false;
        //NetworkManager.GetInstance().reset = false;
        goGreen = true;
        end = true;
    }

}
