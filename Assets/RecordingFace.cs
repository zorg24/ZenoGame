using UnityEngine;
using System.Collections;

public class RecordingFace : MonoBehaviour
{
    NetworkManager nm = NetworkManager.GetInstance();
    // Use this for initialization
    void Start()
    {
        this.GetComponent<UnityEngine.UI.Button>().interactable = false;
        nm.end = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (nm.goOn)// || nm.reset)
        {
            this.GetComponent<UnityEngine.UI.Button>().interactable = true;
            nm.goOn = false;
            //nm.reset = false;
        }
        if (nm.end)
            nm.GoToMain();
    }

    public void ButtonPressed()
    {
        this.GetComponent<UnityEngine.UI.Button>().interactable = false;
        nm.SendUDPMessage("pressed");
    }

}
