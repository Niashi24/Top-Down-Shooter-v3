using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Sirenix.OdinInspector;

public class RuleTiler : MonoBehaviour
{
    [Header("Tilemap")]
    [SerializeField] Tilemap _bgTilemap;
    [SerializeField] Tilemap _fgTilemap;
    [SerializeField] TileBase _landTile;
    [Header("Tiles")]
    [SerializeField] TileBase _upLeft;
    [SerializeField] TileBase _up;
    [SerializeField] TileBase _upRight;
    [SerializeField] TileBase _right;
    [SerializeField] TileBase _left;
    [SerializeField] TileBase _downLeft;
    [SerializeField] TileBase _down;
    [SerializeField] TileBase _downRight;

    private RuleTile[] rules = new RuleTile[] {

    };

    [Button]
    void FormEdges() {

    }
}