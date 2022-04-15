using System.Collections;
using UnityEngine;

public class SpaceShipQuestionController : MonoBehaviour {

    private BoxCollider _boxCollider;
    
    public GameObject Option1;
    public GameObject Option2;
    public GameObject Option3;
    public GameObject Option4;

    public GameObject bot;
    public GameObject player;

    public AudioSource question;
    public AudioSource _correctAnswer;
    public AudioSource wrongAnswer;
    public AudioSource nextBotIndications;
    public AudioSource finalIndications;

    public GameObject finalQuestionController;

    private IEnumerator coroutine;
    private bool active;
    private bool talked;

    // Start is called before the first frame update
    private void Start() {
        _boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    private void Update() {
        if (!active || talked) return;
        talked = true;
        coroutine = AskQuestion();
        StartCoroutine(coroutine);
    }
    
    private IEnumerator AskQuestion(){
        player.SendMessage("block");
        bot.SendMessage("talking");
        question.Play();
        yield return new WaitForSeconds(question.clip.length);
        bot.SendMessage("finishedTalking");
        _boxCollider.enabled = false;
        Option1.SendMessage("activate");
        Option2.SendMessage("activate");
        Option3.SendMessage("activate");
        Option4.SendMessage("activate");
    }
    
    public void correctAnswer(){
        Option1.SendMessage("deactivate");
        Option2.SendMessage("deactivate");
        Option3.SendMessage("deactivate");
        Option4.SendMessage("deactivate");
        _boxCollider.enabled = true;
        coroutine = NarrateCorrectAnswer();
        StartCoroutine(coroutine);
    }

    private IEnumerator NextSteps() {
        var finalQuestionControllerSpaceship = finalQuestionController.GetComponent<FinalQuestionControllerSpaceship>();
        if (finalQuestionControllerSpaceship.GetAnswersCount()>=3) {
            coroutine = NarrateFinalSteps();
        }
        else {
            finalQuestionController.GetComponent<FinalQuestionControllerSpaceship>().IncrementAnswer();
            coroutine = NarrateNextSteps();
        }

        return coroutine;
    }

    private IEnumerator NarrateCorrectAnswer() {
        bot.SendMessage("talking");
        _correctAnswer.Play();
        yield return new WaitForSeconds(_correctAnswer.clip.length);
        bot.SendMessage("finishedTalking");
        coroutine = NextSteps();
        StartCoroutine(coroutine);
    }

    private IEnumerator NarrateNextSteps() {
        bot.SendMessage("talking");
        nextBotIndications.Play();
        yield return new WaitForSeconds(nextBotIndications.clip.length);
        bot.SendMessage("finishedTalking");
        coroutine = NextSteps();
        StartCoroutine(coroutine);
    }

    private IEnumerator NarrateFinalSteps() {
        bot.SendMessage("talking");
        finalIndications.Play();
        yield return new WaitForSeconds(finalIndications.clip.length);
        bot.SendMessage("finishedTalking");
        coroutine = NextSteps();
        StartCoroutine(coroutine);
    }

    public void incorrectAnswer(){
        coroutine = incorrectAnswerCoroutine();
        StartCoroutine(coroutine);
    }

    private IEnumerator incorrectAnswerCoroutine(){
        bot.SendMessage("talking");
        wrongAnswer.Play();
        yield return new WaitForSeconds(wrongAnswer.clip.length);
        bot.SendMessage("finishedTalking");
    }
    
    public void CustomOnPointerEnter(){
        active = true;
    }

    public void CustomOnPointerExit(){
        active = false;
    }
}
