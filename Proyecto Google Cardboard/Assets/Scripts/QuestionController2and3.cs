using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionController2and3 : MonoBehaviour
{
    BoxCollider myCollider;
    
    public GameObject bot;

    public GameObject Option1;
    public GameObject Option2;
    public GameObject Option3;
    public GameObject Option4;

    public AudioSource Question;

      public AudioSource IncorrectAnswer;

    public GameObject FinalQuestionsController;

    private IEnumerator coroutine;
    private bool active;
    private bool talked;

    public int bot_number;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = gameObject.GetComponent<BoxCollider>();
        active = false;
        talked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(active && !talked){
            talked = true;
            coroutine = askQuestion();
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator askQuestion(){
        player.SendMessage("block");
        bot.SendMessage("talking");
        Question.Play();
        yield return new WaitForSeconds(Question.clip.length);
        bot.SendMessage("finishedTalking");
        myCollider.enabled = false;
        Option1.SendMessage("activate");
        Option2.SendMessage("activate");
        Option3.SendMessage("activate");
        Option4.SendMessage("activate");
    }

    

    public void CustomOnPointerEnter(){
        active = true;
    }

    public void CustomOnPointerExit(){
        active = false;
    }

    public void correctAnswer(){
        Option1.SendMessage("deactivate");
        Option2.SendMessage("deactivate");
        Option3.SendMessage("deactivate");
        Option4.SendMessage("deactivate");
        myCollider.enabled = true;
        FinalQuestionsController.SendMessage("QuestionAnswered", bot_number);
    }

    public void incorrectAnswer(){
        coroutine = incorrectAnswerCoroutine();
        StartCoroutine(coroutine);
    }

    private IEnumerator incorrectAnswerCoroutine(){
        bot.SendMessage("talking");
        IncorrectAnswer.Play();
        yield return new WaitForSeconds(IncorrectAnswer.clip.length);
        bot.SendMessage("finishedTalking");
    }
}
