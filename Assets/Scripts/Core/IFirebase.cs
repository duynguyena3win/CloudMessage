using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FirebaseType
{
	CloudMessage,
}

public interface IFirebase {
	FirebaseType GetFirebaseType ();
	void Init();
}
