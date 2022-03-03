using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
using Sirenix.OdinInspector;

public class SaveLoadCustomization : MonoBehaviour
{
    [SerializeField] BoolReference _customizationEnabled;
    private const string customizationKey = "Customization";

    [SerializeField, Range(0,1)] float _percentCustomization = .5f;

    // Start is called before the first frame update
    void Awake()
    {
        if (HasPlayedGame) {
            _customizationEnabled.Value = GetCustomizationValueFromPlayerPrefs();
        } else {
            _customizationEnabled.Value = RandomBool(_percentCustomization);
            SaveCustomizationValue(_customizationEnabled.Value);
        }
    }

    bool HasPlayedGame => PlayerPrefs.HasKey(customizationKey);

    bool GetCustomizationValueFromPlayerPrefs() => PlayerPrefs.GetInt(customizationKey) == 1;

    void SaveCustomizationValue(bool customizationEnabled) {
        PlayerPrefs.SetInt(customizationKey, customizationEnabled ? 1 : 0);
        PlayerPrefs.Save();
    }
    
    bool RandomBool(float percentTrue) => Random.value < percentTrue;

    #if UNITY_EDITOR
    [UnityEditor.MenuItem("Tools/SkyShooter/Reset Customization")]
    public static void ResetCustomization() {
        Debug.Log("Reset");
        PlayerPrefs.DeleteKey(customizationKey);
    }
    #endif
}
