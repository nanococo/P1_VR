using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{

    public bool isCorrect;
    public GameObject txt;
    public GameObject questionController;

    private bool active;
    private bool selected;
    
    private RawImage image;

    public Texture NormalTexture;
    public Texture ActiveTexture;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        selected = false;
        image = gameObject.GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CustomOnPointerEnter() {
        if(active){
            if (isCorrect) {
                Debug.Log("Correct");
            }
            else {
                Debug.Log("Incorrect");
            }
       }
    }

    public void CustomOnPointerExit() {
    }

    public void SelectOption() {
        if(active && !selected){
            if(isCorrect){
                image.texture = NormalTexture;
                image.color = Color.green;
                questionController.SendMessage("correctAnswer");
            }
            else{
                image.texture = NormalTexture;
                image.color = Color.red;
                questionController.SendMessage("incorrectAnswer");
            }
            selected = true;
        }
    }

    public void activate(){
        active = true;
    }

    public void deactivate(){
        active = false;
    }

    public void gazedAt() {
        if(active && !selected){
            image.texture = ActiveTexture;
        }
    }

    public void notGazedAt() {
        image.texture = NormalTexture;
    }
}
