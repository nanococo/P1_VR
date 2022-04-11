using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour {
    
    public GameObject menu;

    public GameObject player;

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
        player.SendMessage("unblock");
    }

    public void gazedAt() {
        image.texture = ActiveTexture;
    }

    public void notGazedAt() {
        image.texture = NormalTexture;
    }

}
