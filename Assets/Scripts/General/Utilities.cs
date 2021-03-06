using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Utilities : MonoBehaviour
{
	public static void ToggleChildrenRenderersAndColliders(Transform target, bool toggle)
	{
		if (!target)
			return;
		if (target.GetComponent<Renderer>())
			target.GetComponent<Renderer>().enabled = toggle;
		if (target.GetComponent<Collider>())
			target.GetComponent<Collider>().enabled = toggle;
		for (int index = 0; index < target.childCount; index++)
			ToggleChildrenRenderersAndColliders(target.GetChild(index), toggle);
	}

	public static void DestroyChildren(Transform transform)
	{
		for (int index = transform.childCount - 1; index >= 0; index--)
			GameObject.Destroy(transform.GetChild(index).gameObject);
	}
	
	public static int RoundToNearestMultiple(float numberToRound, int multipleOf)
	{
		int wholeNumber = (int)numberToRound / multipleOf;
		float remander = numberToRound % multipleOf;
		if (remander >= multipleOf / 2f)
			return (wholeNumber + 1) * multipleOf;
		else
			return wholeNumber * multipleOf;
	}
	
	public static void RecursivelySetChildrensRenderersColor(Transform target, Color color)
	{
		if (!target)
			return;
		if (target.GetComponent<Renderer>())
			foreach (Material material in target.GetComponent<Renderer>().materials)
				material.color = color;
		for (int index = 0; index < target.childCount; index++)
			RecursivelySetChildrensRenderersColor(target.GetChild(index), color);
	}

    public static T GetObjectOfType<T>(GameObject gameObjectToCheck)
    {
        T component = gameObjectToCheck.GetComponent<T>();

        if (component != null)
        {
            return component;
        } else
        {
            ScriptReferencer<T> scriptReferencer = gameObjectToCheck.GetComponent<ScriptReferencer<T>>();

            if(scriptReferencer != null)
            {
                return scriptReferencer.ScriptReference;
            }
        }

        return default(T);
    }

    #region PlayerPrefs
    public static void SetPlayerPrefsBool(string name, bool booleanValue) 
	{
		PlayerPrefs.SetInt(name, booleanValue ? 1 : 0);
	}
	
	public static bool GetPlayerPrefsBool(string name)  
	{
		return PlayerPrefs.GetInt(name) == 1 ? true : false;
	}
	
	public static bool GetPlayerPrefsBool(string name, bool defaultValue)
	{
		if(PlayerPrefs.HasKey(name)) 
			return GetPlayerPrefsBool(name);
		return defaultValue;
	}
	#endregion
}

public static class IListExtensions
{
    public static void Shuffle<T>(this IList<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}
