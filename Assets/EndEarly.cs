using UnityEngine;
using System.Collections;

//Script to have a scene exit early and go back to "Main Game Screen" scene
public class EndEarly : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (NetworkManager.GetInstance().game.Equals("Main Game Screen"))//script has an effect when game is set to main by UDP message
            NetworkManager.GetInstance().GoToMain();//goes to main
    }
}
