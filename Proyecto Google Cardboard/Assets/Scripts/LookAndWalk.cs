using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAndWalk : MonoBehaviour
{
    public Transform vrCamera;
    public float puntolimite = 10.0f;

    public float speed = 0.5f;

    public bool moviendose;

    public CharacterController myPersonaje;

    private bool blocked;

    // Start is called before the first frame update
    void Start()
    {
        myPersonaje = GetComponent<CharacterController>();
        blocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (vrCamera.eulerAngles.x >= puntolimite && vrCamera.eulerAngles.x < 90.0f)
        {
            moviendose = true;
        }
        else
        {
            moviendose = false;
        }

        if (moviendose && !blocked)
        {
            Vector3 forward = vrCamera.transform.forward;
            forward *= speed * Time.deltaTime;
            forward.y = 0f;
            //myPersonaje.SimpleMove(forward);
            transform.position += forward;
        }
    }

    public void block(){
        blocked = true;
    }

    public void unblock(){
        blocked = false;
    }
}
