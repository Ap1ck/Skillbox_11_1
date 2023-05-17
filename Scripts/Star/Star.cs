using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Star", menuName = "ScriptableObjects/StarScriptableObject")]

public class Star : ScriptableObject
{
    private  int _coin=0;

    public  int AddStar(int value)
    {
        _coin += value;
        return _coin;
    }

}
