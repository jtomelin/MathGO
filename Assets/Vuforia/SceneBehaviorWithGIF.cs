using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneBehaviorWithGIF : SceneBehaviorBase
{
    public SceneBehaviorWithGIF()
    {

    }

    public override void OnDestroyWithGIF()
    {
        Debug.Log("Caiu na classe filha");
    }

}
