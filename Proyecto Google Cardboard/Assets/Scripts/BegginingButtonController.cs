using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BegginingButtonController : MonoBehaviour
{
    public GameObject begginingController;

    private bool active;
    private bool selected;

    private RawImage image;

    public Texture NormalTexture;
    public Texture ActiveTexture;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        selected = false;
        image = gameObject.GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectOption() {
        if(active && !selected){
            selected = true;
            begginingController.SendMessage("explain");
        }
    }

    public void activate(){
        active = true;
    }

    public void deactivate(){
        active = false;
    }

    public void gazedAt() {
        if(active && !selected){
            image.texture = ActiveTexture;
        }
    }

    public void notGazedAt() {
        image.texture = NormalTexture;
    }
}
