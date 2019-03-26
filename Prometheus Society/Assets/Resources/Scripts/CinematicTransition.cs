using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinematicTransition : MonoBehaviour
{
    public float timeToStartFading = 0.5f;
    public float fadeSpeed = 1f;

    public GameObject[] SceneObjects_To_Clear;

    public int stage = 0;
 
    public RawImage overlay;

    public string FullText;
    public GameObject storyObject;
    public GameObject overlayObject;
    public Text story;

    void Update()
    {
        if (stage == 1) {
            fader ();
        }
        if (stage == 2) {
            ClearScene ();
            stage = 3;
        }
        if (stage == 3) {
            storyObject.SetActive(true);
            StartCoroutine( AnimateText() );
            stage = 4;
        }
        if (stage == 5) {
            DimmerStage ();
        }
        if (stage == 6) {
            RemoverStage ();
        }
 
     }


    void fader () {
        //Timer
        if (timeToStartFading > 0)
        {
            timeToStartFading -= Time.deltaTime;
            return;
        }
 
        //Modify the color by changing alpha value
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, overlay.color.a + (fadeSpeed * Time.deltaTime));

        //Reality Check
        if (overlay.color.a > 1) {
            stage = 2;
        }
    }
    
    void ClearScene () {
        for (int i = 0; i < SceneObjects_To_Clear.Length; i++) {
            Destroy(SceneObjects_To_Clear[i]);
        }
    }

    void DimmerStage () {
        //Timer
        if (!(story.color.a < 0))
        {
            story.color = new Color(story.color.r, story.color.g, story.color.b, story.color.a - (fadeSpeed * Time.deltaTime));
        }
        else {
            overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, overlay.color.a - (fadeSpeed * Time.deltaTime));
        }
 
        //Reality Check
        if (overlay.color.a < 0 && story.color.a < 0) {
            stage = 6;
        }
    }

    void RemoverStage () {
        Destroy(overlayObject);
        Destroy(storyObject);
        this.enabled = false;
    }


    IEnumerator AnimateText() {

        int i = 0;
        story.text = "";
        while( i < FullText.Length ) {
            story.text += FullText[i++];
            yield return new WaitForSeconds(0.1F);
        }
        stage = 5;
    }


    public void StageStrater () {
        if (stage == 0) {
            stage = 1;
        }
    }


}
