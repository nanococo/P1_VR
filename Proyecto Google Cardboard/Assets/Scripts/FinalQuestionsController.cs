using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalQuestionsController : MonoBehaviour
{

    private int answered;

    public GameObject fourth_bot;

    public GameObject fifth_bot;

    public AudioSource CorrectAnswerFourth;

    public AudioSource CorrectAnswerFifth;

    public AudioSource CorrectAnswerFinalFourth;

    public AudioSource CorrectAnswerFinalFifth;

    private int last_answer;

    private bool talkedCorrectAnswer;
    private bool talkedCorrectAnswerFinal;

    public Animator DoorLeftAnimator;
    public Animator DoorRightAnimator;

    public GameObject player;

    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        answered = 0;
        talkedCorrectAnswer = false;
        talkedCorrectAnswerFinal = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(answered==1){
            coroutine = correctAnswer();
            StartCoroutine(coroutine);
        } else if(answered==2){
            coroutine = correctAnswerFinal();
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator correctAnswer(){
        if(!talkedCorrectAnswer){
            if(last_answer == 4){
                talkedCorrectAnswer = true;
                fourth_bot.SendMessage("talking");
                CorrectAnswerFourth.Play();
                yield return new WaitForSeconds(CorrectAnswerFourth.clip.length);
                fourth_bot.SendMessage("finishedTalking");
                player.SendMessage("unblock");
            }
            else if(last_answer == 5){
                talkedCorrectAnswer = true;
                fifth_bot.SendMessage("talking");
                CorrectAnswerFifth.Play();
                yield return new WaitForSeconds(CorrectAnswerFifth.clip.length);
                fifth_bot.SendMessage("finishedTalking");
                player.SendMessage("unblock");
            }
        }
    }

    private IEnumerator correctAnswerFinal(){
        if(!talkedCorrectAnswerFinal){
            if(last_answer == 4){
                DoorLeftAnimator.SetBool("openDoor", true);
            DoorRightAnimator.SetBool("openDoor", true);
                talkedCorrectAnswerFinal = true;
                fourth_bot.SendMessage("talking");
                CorrectAnswerFinalFourth.Play();
                yield return new WaitForSeconds(CorrectAnswerFinalFourth.clip.length);
                fourth_bot.SendMessage("finishedTalking");
                player.SendMessage("unblock");
            }
            else if(last_answer == 5){
                DoorLeftAnimator.SetBool("openDoor", true);
                DoorRightAnimator.SetBool("openDoor", true);
                talkedCorrectAnswerFinal = true;
                fifth_bot.SendMessage("talking");
                CorrectAnswerFinalFifth.Play();
                yield return new WaitForSeconds(CorrectAnswerFinalFifth.clip.length);
                fifth_bot.SendMessage("finishedTalking");
                player.SendMessage("unblock");
            }
        }
    }

    public void QuestionAnswered(int bot_number){
        last_answer = bot_number;
        answered += 1;
    }
}
