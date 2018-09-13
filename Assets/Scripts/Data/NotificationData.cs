using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NotificationType
{
	Broadcast,
	Topic,
	Single,
};

public class NotificationData {

	public NotificationType Type;
	public string Title;
	public string Message;

	public System.Uri Link;
	public string From;
	public string To;

	public void ShowLog()
	{
		string logText = "";
		logText += string.Format ("Type: {0}, ", Type.ToString ());
		logText += string.Format ("Title: {0}, ", Title.ToString ());
		logText += string.Format ("Message: {0}, ", Message.ToString ());
		if(Link != null)
			logText += string.Format ("Link: {0}, ", Link.ToString ());
		logText += string.Format ("From: {0}, ", From.ToString ());
		logText += string.Format ("To: {0}", To.ToString ());
		Debug.Log ("DUYNGUYEN: " + logText);
	}
}
