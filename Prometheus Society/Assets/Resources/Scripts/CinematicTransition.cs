using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinematicTransition : MonoBehaviour
{
    public float timeToStartFading = 2f;
    public float fadeSpeed = 1f;

    public GameObject[] SceneObjects_To_Clear;

    public int stage = 0;
 
    public RawImage overlay;

    void Update()
    {
        if (stage == 1) {
            fader ();
        }
        if (stage == 2) {
            ClearScene ();
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

    public void StageStrater () {
        if (stage == 0) {
            stage = 1;
        }
    }

}
