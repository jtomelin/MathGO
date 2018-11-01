using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SceneBehaviorBase : MonoBehaviour
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

    public string enunciado;
    public string alternativaA;
    public string alternativaB;
    public string alternativaC;

    public eButton rightAnswerButton;

    // Use this for initialization
    public virtual void Start()
    {
        this.btnAlternativaA.onClick.AddListener(OnButtonAClick);
        this.btnAlternativaB.onClick.AddListener(OnButtonBClick);
        this.btnAlternativaC.onClick.AddListener(OnButtonCClick);

        this.btnAlternativaA.gameObject.GetComponentInChildren<Text>().text = this.alternativaA;
        this.btnAlternativaB.gameObject.GetComponentInChildren<Text>().text = this.alternativaB;
        this.btnAlternativaC.gameObject.GetComponentInChildren<Text>().text = this.alternativaC;

        GameObject.Find("borda_pergunta").GetComponentInChildren<Text>().text = this.enunciado;
    }

    // Update is called once per frame
    public virtual void Update()
    {
    }

    void OnGenericButtonClick(eButton buttonClicked)
    {
        if (GameObject.FindGameObjectWithTag("Resultado") != null)
            return;

        Debug.Log("Entrou");

        AfterResultClick(true);

        if (buttonClicked == rightAnswerButton)
        {
            //
        }
        else
        {
            //EditorUtility.DisplayDialog("Math GO", "Resposta incorreta", "OK");
        }
    }

    void OnButtonAClick() { OnGenericButtonClick(eButton.eButtonA); }
    void OnButtonBClick() { OnGenericButtonClick(eButton.eButtonB); }
    void OnButtonCClick() { OnGenericButtonClick(eButton.eButtonC); }

    public void SetRightAnswerButton(eButton rightAnswerButton) { this.rightAnswerButton = rightAnswerButton; }


    public void AfterResultClick(bool bRespostaCorreto)
    {
        OnDestroyWithGIF();
    }

    public virtual void OnDestroyWithGIF()
    {
        Debug.Log("Caiu na classe pai");
    }

}
