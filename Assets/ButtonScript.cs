using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    public Button btnOK;

	// Use this for initialization
	void Start () 
    {
        btnOK.onClick.AddListener(OnClickOK);	
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void OnClickOK()
    {
        Debug.Log("Clicou OK");
        GameObject.Find("RawImage").SetActive(false);
    }

}
