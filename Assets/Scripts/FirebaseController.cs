using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseController : MonoBehaviour {

	public List<FirebaseType> Features;

	private List<IFirebase> ReferenceFeatures;

	public static Action<NotificationData> OnNotificationReceived;

	void Awake()
	{
		ReferenceFeatures = new List<IFirebase> ();
		foreach (var featureType in Features) {
			ReferenceFeatures.Add(createFeatures(featureType));
		}
	}

	private IFirebase createFeatures(FirebaseType type)
	{
		IFirebase feature = null;
		switch (type) {
		case FirebaseType.CloudMessage:
			feature = new CloudMessaging ();
			registerCloudMessage (feature as CloudMessaging);
			break;
		}
		feature.Init ();
		return feature;
	}

	private void registerCloudMessage(CloudMessaging feature)
	{
		feature.OnNotificationReceived += OnNotificationReceived;
	}

	public void SubscribleTopic(string nameTopic)
	{
		CloudMessaging messagingFeature = null;
		foreach (var feature in ReferenceFeatures) {
			if (feature.GetFirebaseType () == FirebaseType.CloudMessage)
				messagingFeature = feature as CloudMessaging;
		}

		if (messagingFeature == null)
			return;

		messagingFeature.SubscribleTopic (nameTopic);
	}

	public void UnsubscribleTopic(string nameTopic)
	{
		CloudMessaging messagingFeature = null;
		foreach (var feature in ReferenceFeatures) {
			if (feature.GetFirebaseType () == FirebaseType.CloudMessage)
				messagingFeature = feature as CloudMessaging;
		}

		if (messagingFeature == null)
			return;

		messagingFeature.UnsubscribleTopic (nameTopic);
	}
}
