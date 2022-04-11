using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BegginingController : MonoBehaviour
{
    public GameObject ExplanationCanvas;

    public GameObject ButtonCanvas;

    public GameObject Button;

    public GameObject Bot;

    public AudioSource Introduction;

    public AudioSource Explanation;

    public AudioSource PostExplanation;

    private IEnumerator coroutine;
    private bool active;
    private bool talked; 

    private BoxCollider myCollider;

    public Animator DoorLeftAnimator;
    public Animator DoorRightAnimator;

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
            coroutine = introduce();
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator introduce(){
        DoorLeftAnimator.SetBool("openDoor", true);
        DoorRightAnimator.SetBool("openDoor", true);
        Bot.SendMessage("talking");
        Introduction.Play();
        yield return new WaitForSeconds(Introduction.clip.length);
        Bot.SendMessage("finishedTalking");
        myCollider.enabled = false;
        Button.SendMessage("activate");
    }

    public void explain(){
        coroutine = explainCoroutine();
        StartCoroutine(coroutine);
    }

    private IEnumerator explainCoroutine(){
        ButtonCanvas.SetActive(false);
        ExplanationCanvas.SetActive(true);
        Bot.SendMessage("talking");
        Explanation.Play();
        yield return new WaitForSeconds(Explanation.clip.length);
        PostExplanation.Play();
        yield return new WaitForSeconds(PostExplanation.clip.length);
        Bot.SendMessage("finishedTalking");
    }

    public void CustomOnPointerEnter(){
        active = true;
    }

    public void CustomOnPointerExit(){
        active = false;
    }
}
