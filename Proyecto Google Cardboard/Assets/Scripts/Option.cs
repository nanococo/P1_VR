using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{

    public bool isCorrect;
    public GameObject txt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CustomOnPointerEnter() {
        if (isCorrect) {
            Debug.Log("Correct");
        }
        else {
            Debug.Log("Incorrect");
        }

    }

    public void CustomOnPointerExit() {
    }

    public void SelectOption() {
        txt.GetComponent<Text>().color = isCorrect ? Color.green : Color.red;
    }
}
