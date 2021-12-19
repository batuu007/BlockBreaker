using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
     [SerializeField] int breakableBlock;


    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    public void CountBreakableBlocks()
    {
        breakableBlock++;
    }
    public void BlockDestroyed()
    {
        breakableBlock--;
        if (breakableBlock==0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
