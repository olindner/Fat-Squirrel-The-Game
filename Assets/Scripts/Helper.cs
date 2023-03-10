using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Helper : ScriptableObject {

    public static void SetAllTF(List<GameObject> objs, bool val)
    {
        foreach (var obj in objs)
        {
            obj.SetActive(val);
        }
    }
}