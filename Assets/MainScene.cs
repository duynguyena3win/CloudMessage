using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainScene : MonoBehaviour {

	public FirebaseController FirebaseInstance;

	public UI.XToggle BtnSport;
	public UI.XToggle BtnGame;
	public UI.XToggle BtnTourism;

	void Start()
	{
		this.transform.DOScale (1.0f, 2.0f).OnComplete (() => InitMain ());
	}

	public void InitMain()
	{
		BtnSport.IsOn = LocalData.Instance.IsEnableSport ();
		BtnSport.OnChange += OnChanged_Sport;

		BtnGame.IsOn = LocalData.Instance.IsEnableGame ();
		BtnGame.OnChange += OnChanged_Game;

		BtnTourism.IsOn = LocalData.Instance.IsEnableTourism ();
		BtnTourism.OnChange += OnChanged_Toursim;
	}

	public void OnChanged_Sport(bool isOn)
	{
		LocalData.Instance.SetEnableSport (isOn);

		if(isOn)
			FirebaseInstance.SubscribleTopic("/topics/sport");
		else
			FirebaseInstance.UnsubscribleTopic("/topics/sport");
	}

	public void OnChanged_Game(bool isOn)
	{
		LocalData.Instance.SetEnableGame (isOn);

		if(isOn)
			FirebaseInstance.SubscribleTopic("/topics/game");
		else
			FirebaseInstance.UnsubscribleTopic("/topics/game");
	}

	public void OnChanged_Toursim(bool isOn)
	{
		BtnTourism.IsOn = isOn;
		LocalData.Instance.SetEnableToursim (isOn);

		if(isOn)
			FirebaseInstance.SubscribleTopic("/topics/toursim");
		else
			FirebaseInstance.UnsubscribleTopic("/topics/toursim");
	}
}
