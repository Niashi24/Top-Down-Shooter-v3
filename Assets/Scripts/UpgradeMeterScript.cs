using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class UpgradeMeterScript : MonoBehaviour
{
    [SerializeField]
    List<GameObject> MeterPieces;

    public void UpdateUI(int upgradeLevel) {
        for (int i = 0; i < MeterPieces.Count; i++) {
            MeterPieces[i].SetActive(i < upgradeLevel);
        }
    }
}