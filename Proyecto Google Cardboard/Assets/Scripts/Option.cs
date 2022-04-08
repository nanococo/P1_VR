using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{

    public bool isCorrect;
    public GameObject txt;
    public GameObject questionController;

    private bool active;
    private bool selected;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        selected = false;
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
                txt.GetComponent<Text>().color = Color.green;
                questionController.SendMessage("correctAnswer");
            }
            else{
                txt.GetComponent<Text>().color = Color.red;
                questionController.SendMessage("incorrectAnswer");
            }
            selected = true;
        }
    }

    public void activate(){
        active = true;
    }
}
