using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pergunta1SceneBehavior : SceneBehaviorBase
{
    //public Button btnCliqueAqui;
    public GameObject obj;
    public bool bActive;

    Pergunta1SceneBehavior()
    {
        SetRightAnswerButton(eButton.eButtonA);
    }

    // Use this for initialization
    public override void Start ()
    {
        base.Start();
        bActive = false;
        obj.SetActive(bActive);
	}
	
	// Update is called once per frame
	public override void Update ()
    {
        obj.transform.Rotate(Vector3.right * Time.deltaTime * 100);
        obj.transform.Rotate(Vector3.up * Time.deltaTime * 100);
    }

    void eventoCliqueAqui()
    {
        bActive = !bActive;
        obj.SetActive(bActive);
    }

}
