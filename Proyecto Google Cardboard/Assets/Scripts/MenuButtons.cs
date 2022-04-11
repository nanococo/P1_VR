using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuButtons : MonoBehaviour
{

    public GameObject menu;

    public GameObject secondCanvas;

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
        menu.SetActive(false);
        secondCanvas.SetActive(true);
    }

    public void gazedAt() {
        image.texture = ActiveTexture;
    }

    public void notGazedAt() {
        image.texture = NormalTexture;
    }
}
