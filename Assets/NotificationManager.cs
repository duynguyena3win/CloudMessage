using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour {

	private static NotificationManager instance;
	public static NotificationManager Instance
	{
		get { return instance; }
	}

	public ItemNotificate Notification;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this);
			init();
		}
		else if (instance != this)
		{
			Destroy(this.gameObject);
		}
	}

	private void init()
	{
		FirebaseController.OnNotificationReceived = OnNotificationReceived; 
	}

	public void OnNotificationReceived(NotificationData messageData)
	{
		Notification.ShowMessage (messageData);
	}
}
