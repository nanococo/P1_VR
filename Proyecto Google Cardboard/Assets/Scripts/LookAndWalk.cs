using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAndWalk : MonoBehaviour
{
    public Transform vrCamera;
    public float puntolimite = 10.0f;

    public float puntolimiteatras = 350;

    public float speed = 0.5f;

    public bool moviendose;
    public bool moviendoseAtras;

    public CharacterController myPersonaje;

    public bool blocked = true;

    // Start is called before the first frame update
    void Start()
    {
        myPersonaje = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vrCamera.eulerAngles.x >= puntolimite && vrCamera.eulerAngles.x < 80.0f)
        {
            moviendoseAtras = false;
            moviendose = true;
        }
        //else if (vrCamera.eulerAngles.x <= puntolimiteatras && vrCamera.eulerAngles.x > 280)
        //{
        //    moviendose = false;
        //    moviendoseAtras = true;
        //}
        else{
            moviendose = false;
            moviendoseAtras = false;
        }

        if (moviendose && !blocked)
        {
            Vector3 forward = vrCamera.transform.forward;
            forward *= speed * Time.deltaTime;
            forward.y = 0f;
            //myPersonaje.SimpleMove(forward);
            transform.position += forward;
        }

        if (moviendoseAtras && !blocked)
        {
            Vector3 forward = vrCamera.transform.forward;
            forward *= speed * Time.deltaTime;
            forward.y = 0f;
            //myPersonaje.SimpleMove(forward);
            transform.position -= forward;
        }
    }

    public void block(){
        blocked = true;
    }

    public void unblock(){
        blocked = false;
    }
}
