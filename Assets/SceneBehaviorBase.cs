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

    public Image imageComponent;

    private Sprite greenButton;

    public Button btnAlternativaA;
    public Button btnAlternativaB;
    public Button btnAlternativaC;

    private eButton rightAnswerButton;

    // Use this for initialization
    public virtual void Start()
    {
        greenButton = Resources.Load<Sprite>("botao-alternativa-correta");

        imageComponent        = GetComponent<Image>();
        imageComponent.sprite = greenButton;

        btnAlternativaA.onClick.AddListener(OnButtonAClick);
        btnAlternativaB.onClick.AddListener(OnButtonBClick);
        btnAlternativaC.onClick.AddListener(OnButtonCClick);
    }

    // Update is called once per frame
    public virtual void Update()
    {
    }

    void OnGenericButtonClick(eButton buttonClicked)
    {
        if (buttonClicked == rightAnswerButton)
        {
            //do something
        }
        else
        {
            // do another thing
        }
    }

    void OnButtonAClick() { OnGenericButtonClick(eButton.eButtonA); }
    void OnButtonBClick() { OnGenericButtonClick(eButton.eButtonB); }
    void OnButtonCClick() { OnGenericButtonClick(eButton.eButtonC); }

    public void SetRightAnswerButton(eButton rightAnswerButton) { this.rightAnswerButton = rightAnswerButton; }
}
