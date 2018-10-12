using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneBehavior : MonoBehaviour {

    public Button btnCliqueAqui;
    public GameObject obj;
    public bool bActive;

	// Use this for initialization
	void Start () {
        bActive = false;
        obj.SetActive(bActive);
        btnCliqueAqui.onClick.AddListener(eventoCliqueAqui);
	}
	
	// Update is called once per frame
	void Update () {

        obj.transform.Rotate(Vector3.right * Time.deltaTime * 20);

        obj.transform.Rotate(Vector3.up * Time.deltaTime * 20);
    }

    void eventoCliqueAqui() {

        bActive = !bActive;

        obj.SetActive(bActive);
    }

}
