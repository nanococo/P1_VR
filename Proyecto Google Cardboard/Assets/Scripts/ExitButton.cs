using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    private RawImage image;

    public Texture NormalTexture;
    public Texture ActiveTexture;
    
    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<RawImage>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectOption() {
        Application.Quit();
        UnityEngine.Debug.Log("Se cierra");
    }

    public void gazedAt() {
        image.texture = ActiveTexture;
    }

    public void notGazedAt() {
        image.texture = NormalTexture;
    }
}
