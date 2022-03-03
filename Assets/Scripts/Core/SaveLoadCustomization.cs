using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
using Sirenix.OdinInspector;

public class SaveLoadCustomization : MonoBehaviour
{
    [SerializeField] BoolReference _customizationEnabled;
    private const string customizationKey = "Customization";

    // Start is called before the first frame update
    void Awake()
    {
        _customizationEnabled.Value = true;
        // if (PlayerPrefs.HasKey(customizationKey)) {
        //     _customizationEnabled.Value = PlayerPrefs.GetInt(customizationKey) == 1;
        // } else {
        //     _customizationEnabled.Value = Random.value > 0.5f;
        //     PlayerPrefs.SetInt(customizationKey, _customizationEnabled ? 1 : 0);
        //     PlayerPrefs.Save();
        // }
    }

    [Button]
    public void ResetCustomization() {
        Debug.Log("Reset");
        PlayerPrefs.DeleteKey(customizationKey);
    }
}
