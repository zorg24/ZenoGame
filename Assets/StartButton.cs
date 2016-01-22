using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StartButton : MonoBehaviour
{

    public Button b;
    // Use this for initialization
    void Start()
    {
        NetworkManager.GetInstance().game = "Main Game Screen";
        b.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (NetworkManager.GetInstance().game)
        {
            case "play":
            case "recognize":
            case "select":
            case "identify":
            case "copy":
		case "eye":
                Debug.Log(NetworkManager.GetInstance().game.Split(" ".ToCharArray())[0]);
                b.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }
}
