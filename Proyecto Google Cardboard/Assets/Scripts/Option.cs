using UnityEngine;

public class Option : MonoBehaviour
{

    public bool isCorrect;

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
}
