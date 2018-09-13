using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalData : MonoBehaviour {

	private static LocalData instance;
	public static LocalData Instance
	{
		get {
			if (instance == null)
				instance = new LocalData ();
			return instance;
		}
	}

	private LocalData()
	{
		
	}

	// USERKEY_ENABLED_SPORT
	public void SetEnableSport(bool enabled)
	{
		PlayerPrefs.SetInt ("USERKEY_ENABLED_SPORT", enabled ? 1 : 0);
	}

	public bool IsEnableSport()
	{
		int defaultValue = 0;
		int value = PlayerPrefs.GetInt ("USERKEY_ENABLED_SPORT", defaultValue);
		return value > defaultValue;
	}

	// USERKEY_ENABLED_GAME
	public void SetEnableGame(bool enabled)
	{
		PlayerPrefs.SetInt ("USERKEY_ENABLED_GAME", enabled ? 1 : 0);
	}

	public bool IsEnableGame()
	{
		int defaultValue = 0;
		int value = PlayerPrefs.GetInt ("USERKEY_ENABLED_GAME", defaultValue);
		return value > defaultValue;
	}

	// USERKEY_ENABLED_TOURISM
	public void SetEnableToursim(bool enabled)
	{
		PlayerPrefs.SetInt ("USERKEY_ENABLED_TOURISM", enabled ? 1 : 0);
	}

	public bool IsEnableTourism()
	{
		int defaultValue = 0;
		int value = PlayerPrefs.GetInt ("USERKEY_ENABLED_TOURISM", defaultValue);
		return value > defaultValue;
	}


}
