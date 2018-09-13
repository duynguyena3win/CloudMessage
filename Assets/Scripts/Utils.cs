using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils {
	public static Sprite GetSprite(string path)
	{
		return Resources.Load<Sprite> (System.IO.Path.ChangeExtension (path, null));
	}
}
