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

    //private bool    respondido       ;
    public  eButton rightAnswerButton;

    private GameObject imgCorreta  ;
    private GameObject imgIncorreta;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        imgCorreta   = GameObject.Find("RespostaCorreta");
        imgIncorreta = GameObject.Find("RespostaIncorreta");

        //respondido = false; //ler essa info do Banco (Tu nem vem o banco)

        this.btnAlternativaA.onClick.AddListener(OnButtonAClick);
        this.btnAlternativaB.onClick.AddListener(OnButtonBClick);
        this.btnAlternativaC.onClick.AddListener(OnButtonCClick);

        if (telaResultado != null)
        {
            Button btnOK = telaResultado.GetComponentInChildren<Button>();
            if (btnOK != null)
                btnOK.onClick.AddListener(OnButtonOK);

            telaResultado.enabled = false;
        }

        if (obj3D != null)
            obj3D.SetActive(false);

        canvas.enabled = false;
    }

    // Update is called once per frame
    public virtual void Update()
    {
    }

    void OnGenericButtonClick(eButton buttonClicked)
    {
        if (mTrackableBehaviour.CurrentStatus != TrackableBehaviour.Status.TRACKED || MathGOUtils.MarcadorRespondido(mTrackableBehaviour.TrackableName))
            return;

        MathGOUtils.LastTrackableName = mTrackableBehaviour.TrackableName;

        Marcador marcador = new Marcador();
        marcador.MarkerName = mTrackableBehaviour.TrackableName;
        marcador.Respondido = true;

        MathGOUtils.EquipeSelecionada.Marcadores.Add(marcador);
        MathGOUtils.ModificaEquipe(MathGOUtils.EquipeSelecionada);

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
    }

    protected override void OnTrackingFound() 
    {
        base.OnTrackingFound();

        if (MathGOUtils.EquipeSelecionada == null)
            return;

        if (MathGOUtils.MarcadorRespondido(mTrackableBehaviour.TrackableName) && !telaResultado.isActiveAndEnabled)
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

        if (!MathGOUtils.MarcadorRespondido(mTrackableBehaviour.TrackableName))
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

            Text txtResultado = telaResultado.GetComponentInChildren<Text>();

            if (bCorreta)
            {
                txtResultado.text = "Parabéns, você acertou!";
                imgCorreta.SetActive(true);
                imgIncorreta.SetActive(false);
            }
            else
            {
                txtResultado.text = "Que pena, você errou.\n" + respostaCorreta;
                imgCorreta.SetActive(false);
                imgIncorreta.SetActive(true);
            }
        }
    }

    void OnButtonOK()
    {
        if (MathGOUtils.LastTrackableName != mTrackableBehaviour.TrackableName)
            return;

        if (telaResultado != null)
            telaResultado.enabled = false;

        canvas.enabled = false;

        AfterResultClick(true);
    }
}
