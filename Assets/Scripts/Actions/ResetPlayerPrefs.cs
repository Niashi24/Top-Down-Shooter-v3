using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ResetPlayerPrefs : MonoBehaviour, IResettable
{
    [Button]
    public void Reset() {
        PlayerPrefs.DeleteAll();
        print("Cleared PlayerPrefs");
    }
}
