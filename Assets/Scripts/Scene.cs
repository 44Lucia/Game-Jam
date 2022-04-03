using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game{

    public class Scene : MonoBehaviour
{
    [SerializeField] BackGroundClipName m_backgroundMusic;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.Instance.SetCurrentScene(this);
    }

    public BackGroundClipName BackgroundMusic{ get { return m_backgroundMusic;}}

}

}


