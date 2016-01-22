using UnityEngine;
using System.Collections;

//Script to set the sprite of the image in the "identify" scene
public class PictureMaker : MonoBehaviour
{

    //Arrays of images
    public Sprite[] AngryFaces;
    public Sprite[] HappyFaces;
    public Sprite[] SurprisedFaces;
    public Sprite[] SadFaces;
    public Sprite[] FearFaces;


    string emotion = NetworkManager.GetInstance().emotion;//uses the emotion set in NetworkManager
    int number = NetworkManager.GetInstance().number;//uses the picture number set in NetworkManager

    // Use this for initialization
    void Start()
    {
        //Switch statement that chooses from image array based on what emotion is being found
        switch (emotion)
        {
            case "angry":
                this.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = AngryFaces[number - 1];
                break;
            case "happy":
                this.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = HappyFaces[number - 1];
                break;
            case "sad":
                this.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = SadFaces[number - 1];
                break;
            case "surprised":
                this.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = SurprisedFaces[number - 1];
                break;
            case "fear":
                this.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = FearFaces[number - 1];
                break;
            default://called when the input is an incorrect emotion
                Debug.Log("This isn't working  " + emotion + "  g");
                break;
        }
    }
}
