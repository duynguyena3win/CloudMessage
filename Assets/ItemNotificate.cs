using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public enum TopicType
{
	Topic_Default,
	Topic_Game,
	Topic_Sport,
	Topic_Toursim,
}

public class ItemNotificate : MonoBehaviour {

	public Image Icon;
	public Text Title;
	public Text Message;

	public void Set(NotificationData messageData)
	{
		string icon = "default";
		if (messageData.Type == NotificationType.Topic) {
			if (messageData.From.Contains ("game")) {
				icon = "game";
			} else if (messageData.From.Contains ("sport")) {
				icon = "sport";
			} else if (messageData.From.Contains ("toursim")) {
				icon = "toursim";
			}
		}

		Icon.sprite = Utils.GetSprite ("Sprites/" + string.Format("{0}_icon", icon));
		Title.text = messageData.Title;
		Message.text = messageData.Message;

		Sequence seq = DOTween.Sequence ();
		seq.Append (this.transform.DOLocalMoveY (0, 1.0f));
		seq.AppendInterval (3.0f);
		seq.OnComplete (() => Hide ());
	}

	public void ShowMessage(NotificationData messageData)
	{
		Set (messageData);
	}

	public void Hide()
	{
		this.transform.DOLocalMoveY (150, 1.0f);
	}
}
