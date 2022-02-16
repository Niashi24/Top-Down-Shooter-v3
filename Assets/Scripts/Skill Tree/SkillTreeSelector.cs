using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillTreeSelector : MonoBehaviour
{
    [SerializeField] BoolReference _customizationEnabled;
    [SerializeField] SkillTreeReference _reference;

    [SerializeField]
    TypeTriplet<Button, Text, SkillTree>[] selections;

    [SerializeField] Text description;

    [SerializeField] Color _selectedColor;
    [SerializeField] Color _unselectedColor;

    public int selected = 0;

    [SerializeField] UnityEvent OnFinishSelection;

    void Start() {
        for (int i = 0; i < selections.Length; i++) {
            int ii = i;
            selections[i].Value1.onClick.AddListener(() => SetReference(ii));
        }
        SetReference(selected);
        if (!_customizationEnabled.Value) FinishSelection();
    }

    void SetReference(int index) {
        _reference.Value = selections[index].Value3;
        selected = index;
        UpdateColors();
        UpdateDescription();
    }

    void UpdateDescription()
    {
        description.text = selections[selected].Value3.Description;
    }

    void UpdateColors() {
        for (int i = 0; i < selections.Length; i++) {
            selections[i].Value2.color = 
                selected == i ?
                _selectedColor :
                _unselectedColor;
        }
    }
    
    //Called by either confirm button unityevent
    //or by this if customization is enabled
    public void FinishSelection() {
        OnFinishSelection?.Invoke();
        gameObject.SetActive(false);
    }
}
