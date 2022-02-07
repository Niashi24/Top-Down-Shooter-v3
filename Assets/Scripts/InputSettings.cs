using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Input Settings")]
public class InputSettings : ScriptableObject
{
    [SerializeField] KeyCode up;
    public KeyCode Up => up;
    [SerializeField] KeyCode down;
    public KeyCode Down => down;
    [SerializeField] KeyCode left;
    public KeyCode Left => left;
    [SerializeField] KeyCode right;
    public KeyCode Right => right;

    [SerializeField] KeyCode confirm;
    public KeyCode Confirm => confirm;
    [SerializeField] KeyCode cancel;
    public KeyCode Cancel => confirm;
}
