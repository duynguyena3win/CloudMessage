using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Messaging;

public class CloudMessaging : IFirebase {

	public Action<string> OnTokenReceived;
	public Action<NotificationData> OnNotificationReceived;
	public static Action<Firebase.Messaging.FirebaseMessage> OnMessageReceived;

	public FirebaseType GetFirebaseType ()
	{
		return FirebaseType.CloudMessage;
	}

	public void Init()
	{
		FirebaseApp.CheckAndFixDependenciesAsync ().ContinueWith (task => {
			var dependencyStatus = task.Result;
			if (dependencyStatus == Firebase.DependencyStatus.Available) {
				FirebaseMessaging.TokenReceived += onTokenReceived;
				FirebaseMessaging.MessageReceived += onMessageReceived;
			} else {
				Debug.LogError(System.String.Format("Could not resolve all Firebase dependencies: {0}", dependencyStatus));
			}
		});
	}

	public void SubscribleTopic(string nameTopic)
	{
		FirebaseMessaging.SubscribeAsync (nameTopic);
	}

	public void UnsubscribleTopic(string nameTopic)
	{
		FirebaseMessaging.UnsubscribeAsync (nameTopic);
	}

	public void onTokenReceived(object sender, Firebase.Messaging.TokenReceivedEventArgs token) {
		Debug.LogError("OnTokenReceived = " + token.Token);
		if (OnTokenReceived != null)
			OnTokenReceived (token.Token);
	}

	public void onMessageReceived(object sender, Firebase.Messaging.MessageReceivedEventArgs e) {
		Debug.Log ("DUYNGUYEN: onMessageReceived");

		NotificationData newData = new NotificationData ();
		newData.From = e.Message.From;
		newData.Link = e.Message.Link;
		newData.To = e.Message.To;
		if (e.Message.From.Contains ("topic"))
			newData.Type = NotificationType.Topic;
		else
			newData.Type = NotificationType.Broadcast;
		
		newData.Title = e.Message.Data ["title"];
		newData.Message = e.Message.Data ["message"];

		newData.ShowLog ();
		if (OnNotificationReceived != null)
			OnNotificationReceived (newData);
	}
}