using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
    BoxCollider myCollider;
    
    public GameObject bot;

    public GameObject Option1;
    public GameObject Option2;
    public GameObject Option3;
    public GameObject Option4;

    public Animator DoorLeftAnimator;
    public Animator DoorRightAnimator;



    public AudioSource Question;

    public AudioSource CorrectAnswer;

    public AudioSource IncorrectAnswer;

    public GameObject player;

    private IEnumerator couroutine;
    private bool active;
    private bool talked;
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
            couroutine = askQuestion();
            StartCoroutine(couroutine);
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
        couroutine = correctAnswerCouroutine();
        StartCoroutine(couroutine);
    }

    private IEnumerator correctAnswerCouroutine(){
        Option1.SendMessage("deactivate");
        Option2.SendMessage("deactivate");
        Option3.SendMessage("deactivate");
        Option4.SendMessage("deactivate");
        bot.SendMessage("talking");
        CorrectAnswer.Play();
        yield return new WaitForSeconds(CorrectAnswer.clip.length);
        bot.SendMessage("finishedTalking");
        DoorLeftAnimator.SetBool("openDoor", true);
        DoorRightAnimator.SetBool("openDoor", true);
        myCollider.enabled = true;
        player.SendMessage("unblock");
    }

    public void incorrectAnswer(){
        couroutine = incorrectAnswerCouroutine();
        StartCoroutine(couroutine);
    }

    private IEnumerator incorrectAnswerCouroutine(){
        bot.SendMessage("talking");
        IncorrectAnswer.Play();
        yield return new WaitForSeconds(IncorrectAnswer.clip.length);
        bot.SendMessage("finishedTalking");
    }
}
