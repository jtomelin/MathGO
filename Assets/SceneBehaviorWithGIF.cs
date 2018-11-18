using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

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

    public override void OnAfterEffects()
    {
        if (this.imageGIF != null)
        {
            this.imageGIF.SetActive(true);
            VideoPlayer videoPlayer = this.imageGIF.gameObject.GetComponentInChildren<VideoPlayer>();

            videoPlayer.loopPointReached += EndReached;

            videoPlayer.Play();
        }
        else
        {
            if (obj3D != null)
                obj3D.SetActive(true);
        }

        Debug.Log("Caiu na classe filha");
    }

    public void EndReached(VideoPlayer videoPlayer)
    {
        this.imageGIF.SetActive(false);

        if (obj3D != null)
            obj3D.SetActive(true);
    }

}
