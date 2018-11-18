using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public Button     btnAlternativaA;
    public Button     btnAlternativaB;
    public Button     btnAlternativaC;
    public RawImage   image          ;
    public GameObject obj3D          ;
    public Canvas     canvas         ;
    public Canvas     telaResultado  ;

    public string enunciado   ;
    public string alternativaA;
    public string alternativaB;
    public string alternativaC;

    private bool    respondido       ;
    public  eButton rightAnswerButton;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        respondido = false; //ler essa info do Banco (Tu nem vem o banco)

        this.btnAlternativaA.onClick.AddListener(OnButtonAClick);
        this.btnAlternativaB.onClick.AddListener(OnButtonBClick);
        this.btnAlternativaC.onClick.AddListener(OnButtonCClick);

        if (telaResultado != null)
        {
            Button btnOK = telaResultado.GetComponentInChildren<Button>();
            if (btnOK != null)
            {
                btnOK.onClick.AddListener(OnButtonOK);
                Debug.Log("Encontrou botao");
            }

            Debug.Log("Encontrou resultado");
            telaResultado.enabled = false;
        }

        if (obj3D != null)
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

        respondido = true;

        ShowMessage(buttonClicked == rightAnswerButton);
    }

    void OnButtonAClick() { OnGenericButtonClick(eButton.eButtonA); }
    void OnButtonBClick() { OnGenericButtonClick(eButton.eButtonB); }
    void OnButtonCClick() { OnGenericButtonClick(eButton.eButtonC); }

    public void AfterResultClick(bool bRespostaCorreto)
    {
        if (image != null)
            image.enabled = false;

        OnAfterEffects();
    }

    public virtual void OnAfterEffects()
    {
        if (obj3D != null)
            obj3D.SetActive(true);

        Debug.Log("Caiu na classe pai");
    }

    protected override void OnTrackingFound() 
    {
        base.OnTrackingFound();
        Debug.Log("Encontrei o marcador");

        if (respondido)
        {
            if (obj3D != null)
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

    void ShowMessage(bool bCorreta)
    {
        if (telaResultado != null)
        {
            string respostaCorreta = "";

            switch (rightAnswerButton)
            {
                case eButton.eButtonA: respostaCorreta = "A resposta correta era a letra A."; break;
                case eButton.eButtonB: respostaCorreta = "A resposta correta era a letra B."; break;
                case eButton.eButtonC: respostaCorreta = "A resposta correta era a letra C."; break;
            }

            telaResultado.enabled = true;

            GameObject imgCorreta = GameObject.Find("RespostaCorreta");
            GameObject imgIncorreta = GameObject.Find("RespostaIncorreta");

            Text txtResultado = telaResultado.GetComponentInChildren<Text>();

            if (bCorreta)
            {
                txtResultado.text = "Parabéns, você acertou!";
                imgIncorreta.SetActive(false);
            }
            else
            {
                txtResultado.text = "Que pena, você errou. " + respostaCorreta;
                imgCorreta.SetActive(false);
            }
        }
    }

    void OnButtonOK()
    {
        Debug.Log("Clicou OK");

        if (telaResultado != null)
            telaResultado.enabled = false;

        canvas.enabled = false;

        AfterResultClick(true);
    }
}
