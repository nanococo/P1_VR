using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBotController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator myAnimator;

    public AudioSource Question;

    public AudioSource CorrectAnswer;

    private IEnumerator coroutine;

    void Start()
    {
        myAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void talking(){
        myAnimator.SetBool("talking", true);
    }

    public void finishedTalking(){
        myAnimator.SetBool("talking", false);
    }
}
