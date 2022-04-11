using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassagewayBotController : MonoBehaviour
{

    Animator myAnimator;
    public AudioSource audio;
    private bool talked;
    private bool gazedAt;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = gameObject.GetComponent<Animator>();
        talked = false;
        gazedAt = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gazedAt && !talked){
            talked = true;
            coroutine = talk();
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator talk(){
        talked = true;
        setAnimationTalking();
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        setAnimationIdle();
    }


    void setAnimationTalking(){
        myAnimator.SetBool("LookingAtBot", true);
    }

    void setAnimationIdle(){
        myAnimator.SetBool("LookingAtBot", false);
    }
    public void CustomOnPointerEnter(){
        gazedAt = true;
    }

    public void CustomOnPointerExit(){
        gazedAt = false;
    }
}
