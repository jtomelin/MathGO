using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneBehaviorWithGIF : SceneBehaviorBase
{
    public GameObject imageGIF;

    public SceneBehaviorWithGIF()
    {
    }

    protected override void Start()
    {
        base.Start();

        if (imageGIF != null)
            this.imageGIF.SetActive(false);
    }

    public override void OnFinaliza()
    {
        if (this.imageGIF != null)
        {
            this.imageGIF.SetActive(true);
            UnityEngine.Video.VideoPlayer videoPlayer = this.imageGIF.gameObject.GetComponentInChildren<UnityEngine.Video.VideoPlayer>();

            videoPlayer.loopPointReached += EndReached;

            videoPlayer.Play();
        }
        else
        {
            obj3D.SetActive(true);
        }

        Debug.Log("Caiu na classe filha");
    }

    public void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        this.imageGIF.SetActive(false);
        obj3D.SetActive(true);
    }

}
