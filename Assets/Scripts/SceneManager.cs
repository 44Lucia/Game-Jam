using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game{

    public class SceneManager : MonoBehaviour
{
    static SceneManager m_instance;
    [SerializeField] AudioSource m_background;
    [SerializeField] AudioSource m_effects;
    static public SceneManager Instance
    {
        get { return m_instance; }
        private set { }
    }

    private void Awake() {
        m_background.loop = true;
        m_background.volume = 1;
        m_effects.loop = false;
        m_effects.volume = 1;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene);
        Debug.Log(mode);
    }



}

}

