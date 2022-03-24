using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{

    Animator myAnimator;
    public AudioSource myAudio;
    private IEnumerator couroutine;
    private bool activateTalking;
    private bool talked;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = gameObject.GetComponent<Animator>();
        activateTalking = false;
        talked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (activateTalking){
            couroutine = startTalking();
            StartCoroutine(couroutine);
        }
    }

    private IEnumerator startTalking(){
        if (!talked){
            talked = true;
            setAnimationTalking();
            myAudio.Play();
            yield return new WaitForSeconds(20f);
            setAnimationIdle();
        }
        else
            yield return new WaitForSeconds(0f);
    }

    void setAnimationTalking(){
        myAnimator.SetBool("LookingAtBot", true);
    }

    void setAnimationIdle(){
        myAnimator.SetBool("LookingAtBot", false);
    }

    public void OnPointerEnter(){
        activateTalking = true;
    }

    public void OnPointerExit(){
        activateTalking = false;
    }
}
