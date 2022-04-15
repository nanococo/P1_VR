using UnityEngine;

public class FinalQuestionControllerSpaceship : MonoBehaviour {
    // Start is called before the first frame update

    public GameObject teleport;
    private int _answersCount;

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementAnswer() {
        _answersCount++;
        if (_answersCount >= 3) {
            teleport.GetComponent<CustomTeleporter>().teleportPadOn = true;
        }
    }

    public int GetAnswersCount() {
        return _answersCount;
    }


}