using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeamMarkerBehaviour : DefaultTrackableEventHandler
{

	// Use this for initialization
	protected override void Start ()
    {
        base.Start();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();

        if (MathGOUtils.ReadyToChooseTeam == false || MathGOUtils.EquipeSelecionada != null)
            return;

        if (MathGOUtils.FindTeamByMarkerName(mTrackableBehaviour.TrackableName))
        {
            MathGOUtils.ReadyToChooseTeam = false;
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
