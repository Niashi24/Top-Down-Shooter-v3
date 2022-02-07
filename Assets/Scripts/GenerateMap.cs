using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Sirenix.OdinInspector;
using System;
using Random = UnityEngine.Random;

public class GenerateMap : MonoBehaviour
{
    [Header("Tilemap")]
    [SerializeField] Tilemap _bgTilemap;
    [SerializeField] Tilemap _fgTilemap;
    [SerializeField] TileBase _seaTile;
    [SerializeField] TileBase _landTile;
    [SerializeField] List<IntTypePair<TileBase>> _landDecorations;
    
    [Header("Tiles")]
    [SerializeField] TileBase _upLeft;
    [SerializeField] TileBase _up;
    [SerializeField] TileBase _upRight;
    [SerializeField] TileBase _right;
    [SerializeField] TileBase _left;
    [SerializeField] TileBase _downLeft;
    [SerializeField] TileBase _down;
    [SerializeField] TileBase _downRight;
    [SerializeField] TileBase _innerUpRight;
    [SerializeField] TileBase _innerUpLeft;
    [SerializeField] TileBase _innerDownRight;
    [SerializeField] TileBase _innerDownLeft;
    [SerializeField] TileBase _loneTile;


    [Header("Variables")]

    [SerializeField, Tooltip("Offset for Perlin Noise")] 
    Vector2 _offset;

    [SerializeField, Tooltip("Cutoff for land")] 
    [Range(0,1)]
    float _cutOff;

    [Header("Range")]
    [SerializeField] Vector2Int _xRange;
    [SerializeField] Vector2Int _yRange;

    [Button]
    void RandomizeLocation() {
        const float max = 1000f; 
        _offset.x = (int)(Random.value * max - max/2);
        _offset.y = (int)(Random.value * max - max/2);
    }

    [Button]
    void GenerateTiles() {
        GenerateBackground();
        GenerateEdges();
        GenerateForeground();
    }

    [Button]
    void GenerateBackground() {
        ResetBackground();
        for (int x = _xRange.x; x < _xRange.y; x++) {
            for (int y = _yRange.x; y < _yRange.y; y++) {
                var noise = GetNoise(x,y);
                if (noise > _cutOff)
                    _bgTilemap.SetTile(new Vector3Int(x,y,0), _landTile);
                else
                    _bgTilemap.SetTile(new Vector3Int(x,y,0), _seaTile);
            }
        }
    }

    void CleanseTiles() {
        var rules = new RuleTile[] {
            new UpPeninsulaTile(_seaTile),
            new DownPeninsulaTile(_seaTile),
            new RightPeninsulaTile(_seaTile),
            new LeftPeninsulaTile(_seaTile)
        };

        ApplyRules(rules);
    }

    void EdgeTiles() {
        var rules = new RuleTile[] {
            new InnerDownLeftTile(_innerDownLeft),
            new InnerDownRightTile(_innerDownRight),
            new InnerUpRightTile(_innerUpRight),
            new InnerUpLeftTile(_innerUpLeft),
            new LonelyTile(_loneTile),
            new UpLeftTile(_upLeft),
            new UpTile(_up),
            new UpRightTile(_upRight),
            new LeftTile(_left),
            new RightTile(_right),
            new DownLeftTile(_downLeft),
            new DownTile(_down),
            new DownRightTile(_downRight)
        };

        ApplyRules(rules);
    }

    void ApplyRules(RuleTile[] rules) {
        var landTiles = GetLandTiles();
        
        ForEachTile((tile, x, y) => {
            //On edge of tilemap
            if (x == _xRange.x || x == _xRange.y - 1 || y == _yRange.x || y == _yRange.y - 1)
                return;
            //if its a sea tile or an edge tile
            if (tile != _landTile) 
                return;
            foreach (var rule in rules) {
                if (rule.RuleApplies(x, y, landTiles)) {
                    _bgTilemap.SetTile(new Vector3Int(x, y, 0), rule.tile);
                    break;
                }
            }
        });
    }

    [Button]
    void GenerateEdges2() {
        CleanseTiles();
        EdgeTiles();
    }

    [Button]
    void GenerateEdges() {
        CleanseTiles();

        var rules = new RuleTile[] {
            new InnerDownLeftTile(_innerDownLeft),
            new InnerDownRightTile(_innerDownRight),
            new InnerUpRightTile(_innerUpRight),
            new InnerUpLeftTile(_innerUpLeft),
            new LonelyTile(_loneTile),
            new UpLeftTile(_upLeft),
            new UpTile(_up),
            new UpRightTile(_upRight),
            new LeftTile(_left),
            new RightTile(_right),
            new DownLeftTile(_downLeft),
            new DownTile(_down),
            new DownRightTile(_downRight)
        };

        var landTiles = GetLandTiles();
        
        ForEachTile((tile, x, y) => {
            //On edge of tilemap
            if (x == _xRange.x || x == _xRange.y - 1 || y == _yRange.x || y == _yRange.y - 1)
                return;
            //if its a sea tile or an edge tile
            if (tile != _landTile) 
                return;
            foreach (var rule in rules) {
                if (rule.RuleApplies(x, y, landTiles)) {
                    _bgTilemap.SetTile(new Vector3Int(x, y, 0), rule.tile);
                    break;
                }
            }
        });
        // for (int x = _xRange.x + 1; x < _xRange.y - 1; x++) {
        //     for (int y = _yRange.x + 1; y < _yRange.y - 1; y++) {
        //         var tile = _bgTilemap.GetTile(new Vector3Int(x,y,0));
        //         if (tile != _landTile) continue;
        //         foreach (var rule in rules) {
        //             if (rule.RuleApplies(x, y, landTiles)) {
        //                 _bgTilemap.SetTile(new Vector3Int(x, y, 0), rule.tile);
        //                 break;
        //             }
        //         }
        //     }
        // }
    }

    [Button]
    void GenerateForeground() {
        ResetForeground();
        if (_landDecorations.Count == 0) return;

        ForEachTile((tile, x, y) => {
            if (tile == _landTile) {
                var weights = GetNormalizedWeights();
                var fgTile = GetRandomTile(weights);

                if (fgTile != null)
                    _fgTilemap.SetTile(new Vector3Int(x,y,0), fgTile);
            }
        });
    }

    void ForEachTile(Action<TileBase, int, int> action) {
        for (int x = _xRange.x; x < _xRange.y; x++) {
            for (int y = _yRange.x; y < _yRange.y; y++) {
                var tile = _bgTilemap.GetTile(new Vector3Int(x,y,0));
                if (tile != null) action(tile, x, y);
            }
        }
    }

    Dictionary<(int, int), bool> GetLandTiles() {
        Dictionary<(int, int), bool> output = new Dictionary<(int, int), bool>();

        for (int x = _xRange.x; x < _xRange.y; x++) {
            for (int y = _yRange.x; y < _yRange.y; y++) {
                var tile = _bgTilemap.GetTile(new Vector3Int(x,y,0));
                output[(x,y)] = tile == _landTile;
            }
        }

        return output;
    }

    float[] GetNormalizedWeights() {
        int sum = 0;
        for (int i = 0; i < _landDecorations.Count; i++) {
            sum += _landDecorations[i].I;
        }

        float[] weights = new float[_landDecorations.Count];
        for (int i = 0; i < weights.Length; i++) {
            weights[i] = _landDecorations[i].I / (float)sum;
        }

        return weights;
    }

    TileBase GetRandomTile(float[] weights) {
        var random = Random.value;
        float sum = 0;
        for (int i = 0; i < weights.Length; i++) {
            sum += weights[i];
            if (random < sum)
                return _landDecorations[i].Value;
        }
        return _seaTile;
    }

    float GetNoise(float x, float y) {
        const float scalar = 0.15f;
        var noise = Mathf.PerlinNoise(scalar * (x + _offset.x), scalar * (y + _offset.y));
        //Debug.Log($"X:{x}, Y:{y}, N:{noise}");
        return noise;
    }

    [Button]
    void ResetBackground() {
        _bgTilemap.ClearAllTiles();
    }

    [Button]
    void ResetForeground() {
        _fgTilemap.ClearAllTiles();
    }


}
