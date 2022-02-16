using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityAtoms.SceneMgmt;

public class MoveToScene : MonoBehaviour
{
    [SerializeField] SceneField _scene;
    public void Move() {
        SceneManager.LoadScene(_scene);
    }
}
