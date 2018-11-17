using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
using Vuforia;
public class SceneBehaviorBase : DefaultTrackableEventHandler
{
    public enum eButton
    {
        eNotImpl = 0,
        eButtonA    ,
        eButtonB    ,
        eButtonC    ,
    }

    public Button btnAlternativaA;
    public Button btnAlternativaB;
    public Button btnAlternativaC;
    public UnityEngine.UI.RawImage image;
    public GameObject obj3D;

    public string enunciado;
    public string alternativaA;
    public string alternativaB;
    public string alternativaC;

    public eButton rightAnswerButton;

    public Canvas canvas;

    private bool respondido;


    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        respondido = false; //ler essa info do Banco (Tu nem vem o banco)

        this.btnAlternativaA.onClick.AddListener(OnButtonAClick);
        this.btnAlternativaB.onClick.AddListener(OnButtonBClick);
        this.btnAlternativaC.onClick.AddListener(OnButtonCClick);

        obj3D.SetActive(false);
    }

    // Update is called once per frame
    public virtual void Update()
    {
    }

    void OnGenericButtonClick(eButton buttonClicked)
    {
        if (mTrackableBehaviour.CurrentStatus != TrackableBehaviour.Status.TRACKED)
            return;

        if (obj3D == null)
            return;

        if (GameObject.FindGameObjectWithTag("Resultado") != null)
            return;

        Debug.Log("Clicou");

        if (buttonClicked == rightAnswerButton)
        {
        }
        else
        {
        }

        AfterResultClick(true);

        

        respondido = true;
    }

    void OnButtonAClick() { OnGenericButtonClick(eButton.eButtonA); }
    void OnButtonBClick() { OnGenericButtonClick(eButton.eButtonB); }
    void OnButtonCClick() { OnGenericButtonClick(eButton.eButtonC); }

    public void AfterResultClick(bool bRespostaCorreto)
    {
        canvas.enabled = false;

        if (image != null)
            image.enabled = false;

        OnFinaliza();
    }

    public virtual void OnFinaliza()
    {
        obj3D.SetActive(true);
        Debug.Log("Caiu na classe pai");
    }

    protected override void OnTrackingFound() 
    {
        base.OnTrackingFound();
        Debug.Log("Encontrei o marcador");

        if (respondido)
        {
            obj3D.SetActive(true);
            return;
        }

        this.btnAlternativaA.gameObject.GetComponentInChildren<Text>().text = this.alternativaA;
        this.btnAlternativaB.gameObject.GetComponentInChildren<Text>().text = this.alternativaB;
        this.btnAlternativaC.gameObject.GetComponentInChildren<Text>().text = this.alternativaC;

        GameObject.Find("borda_pergunta").GetComponentInChildren<Text>().text = this.enunciado;

        canvas.enabled = true;

        if (image != null)
            image.enabled = true;
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        Debug.Log("Tchau marcador");

        canvas.enabled = false;

        if (obj3D != null)
            obj3D.SetActive(false);

        if (image != null)
            image.enabled = false;
    }

}
