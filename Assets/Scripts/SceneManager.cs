using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game{

    public class SceneManager : MonoBehaviour
{
    static SceneManager m_instance;
    Scene m_currentScene = null;
    int m_numberOfTotalScenes;


    static public SceneManager Instance
    {
        get { return m_instance; }
        private set { }
        
    }

    private void Awake() {

        if(m_instance == null) {
            m_instance = this;
                Initialize();
                DontDestroyOnLoad(this.gameObject);
        }
        else{
            Destroy(this.gameObject);
        }
        
    }

        private void Start()
        {
            
        }

        void Initialize(){
        m_numberOfTotalScenes = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
    }

    public void SetCurrentScene(Scene p_scene){
        m_currentScene = p_scene;
        SoundManager.Instance.PlayBackground(m_currentScene.BackgroundMusic);

    }

    public void LoadScene(int p_scene){
        if(p_scene >= m_numberOfTotalScenes){ 
            Debug.LogError("Scene index not found. Check if all the scenes have been added to Unity Scene Manager (File -> Build Settings).");
            return ;
         }
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)p_scene);
        if(p_scene == 2){
            SoundManager.Instance.SetBeatVolume(1f);
        }
    }

    public BackGroundClipName GetCurrentBackgroudClipName() { return m_currentScene.GetCurrentBackgroudClipName(); }

    public void ExitGame(){
        Application.Quit();
    }

    }

}

