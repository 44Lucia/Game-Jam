using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioClipName
{
    PLAYER_WALK, INSPECTION , TASTE , HEARTSOUND ,LAST_NO_USE
}

public class SoundManager : MonoBehaviour
{
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_playerWalk = 1;
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_inspection = 1;
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_backgroundSound = 1;
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_backgroundSoundMenu = 1;
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_taste = 1;
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_heartSound = 1;

    static SoundManager m_instance;
    [SerializeField] AudioSource m_effects;
    [SerializeField] AudioSource m_background;
    AudioClip[] m_audioClips;
    float[] m_volumeEffects;
    float m_generalVolumeEffects = 1;

    AudioClip[] m_backgroundMusic;
    float[] m_volumeBackground;
    float m_generalVolumeBackground = 1;
    
    // Start is called before the first frame update
    private void Awake()
    {
        if (m_instance == null) {
            m_instance = this;
            Initiate(); 
            DontDestroyOnLoad(this.gameObject);    
        }
        else { Destroy(this.gameObject); }
    }

    private void Start()
    {
        m_background.loop = true;
        m_effects.loop = false;
    }

    public static SoundManager Instance { get { return m_instance; } private set { } }

    void Initiate()
    {

        m_background.loop = true;
        m_background.volume = 0.5f;
        m_effects.loop = false;
        m_effects.volume = 1;
        

        // LOAD THE EFFECT CLIPS
        m_audioClips = new AudioClip[(int)AudioClipName.LAST_NO_USE];
        m_audioClips[(int)AudioClipName.PLAYER_WALK] = Resources.Load<AudioClip>("Sound/Walk2SFX");
        m_audioClips[(int)AudioClipName.INSPECTION] = Resources.Load<AudioClip>("Sound/InpectionSFX");
        m_audioClips[(int)AudioClipName.TASTE] = Resources.Load<AudioClip>("Sound/taste");
        m_audioClips[(int)AudioClipName.HEARTSOUND] = Resources.Load<AudioClip>("Sound/heartSound");

        // SAVE ALL THE VOLUMES SET IN THE INSPECTOR TO AN ARRAY
        m_volumeEffects = new float[(int)AudioClipName.LAST_NO_USE];
        m_volumeEffects[(int)AudioClipName.PLAYER_WALK] = m_playerWalk;
        m_volumeEffects[(int)AudioClipName.INSPECTION] = m_inspection;
        m_volumeEffects[(int)AudioClipName.TASTE] = m_taste;
        m_volumeEffects[(int)AudioClipName.HEARTSOUND] = m_heartSound;

        // LOAD ALL THE MUSIC CLIPS
        m_backgroundMusic = new AudioClip[(int)BackGroundClipName.LAST_NO_USE];
        m_backgroundMusic[(int)BackGroundClipName.MUSIC_1] = Resources.Load<AudioClip>("Sound/BackgroundSound");
        m_backgroundMusic[(int)BackGroundClipName.MUSIC_2] = Resources.Load<AudioClip>("Sound/awesomeness");
        // SAVE ALL THE VOLUMES SET IN THE INSPECTOR TO AN ARRAY
        m_volumeBackground = new float[(int)SCENE.LAST_NO_USE];
        m_volumeBackground[(int)BackGroundClipName.MUSIC_1] = m_backgroundSound;
        m_volumeBackground[(int)BackGroundClipName.MUSIC_2] = m_backgroundSoundMenu;
    }

    public void PlayOnce(AudioClipName p_name)
    {
        if(m_audioClips[(int)p_name] == null) { return ;}
        m_effects.volume = m_generalVolumeEffects * m_volumeEffects[(int)p_name];
        m_effects.PlayOneShot(m_audioClips[(int)p_name]);
    }

    public void PlayBackground(BackGroundClipName p_name)
    {
        if(m_backgroundMusic[(int)p_name] == null) { return ;}
        m_background.volume = m_generalVolumeBackground * m_volumeBackground[(int)p_name];
        m_background.clip = m_backgroundMusic[(int)p_name];
        m_background.Play();
        
    }

    public float GetAudioClipDuration(AudioClipName p_name)
    {
        if(m_audioClips[(int)p_name] == null) { return -1;}
        return m_audioClips[(int)p_name].length;
    }

    public void SetBackgroundVolume(float p_value){
        float volumeValue;
        if(p_value < 0){ volumeValue = 0; }
        else if(p_value > 1){ volumeValue = 1; }
        else { volumeValue = p_value; }
        m_generalVolumeBackground = volumeValue;
        m_background.volume = m_generalVolumeBackground;
    }

    public void SetEffectsVolume(float p_value){
        float volumeValue;
        if(p_value < 0){ volumeValue = 0; }
        else if(p_value > 1){ volumeValue = 1; }
        else { volumeValue = p_value; }
        m_generalVolumeEffects = volumeValue;
    }

    public float EffectVolume{ get { return m_generalVolumeEffects;}}
    public float BackgroundVolume{ get { return m_generalVolumeBackground;}}

    public void SetBeatVolume(float p_value){
        float value = p_value;
        if(p_value < 0) { value =0; }
        else if(p_value > 1) { value = 1;}
        m_heartSound = p_value;
    }

}

