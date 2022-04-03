using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioClipName
{
    ENEMY_HIT, ENEMY_KILL, PLAYER_MACHINE_1, PLAYER_MACHINE_2, PLAYER_MACHINE_3, PLAYER_MACHINE_4, PLAYER_WALK, PLAYER_GROUNDPOUND, PLAYER_DASH, PLAYER_JUMP, MINE_COAL,
    RECOLECT_WATTER, SHOOTSOUND, PLAYER_WALLJUMP, CLICK_MENU, SOUND_LAVA, LAST_NO_USE
}

public class SoundManager : MonoBehaviour
{
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_generalVolume = 1;
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_enemyHit = 1;
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_enemyDeath = 1;
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_machine1 = 1;
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_machine2 = 1;
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_machine3 = 1;
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_machine4 = 1;
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_playerWalk = 1;
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_playerGroundpound = 1;
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_playerDash = 1;
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_playerJump = 1;
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_mineCoal = 1;
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_recolectWatter = 1;
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_shootSound = 1;
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_playerWallJump = 1;
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_clickMenu = 1;
    [Range(0.0F, 1.0F)]
    [SerializeField] float m_soundLava = 1;

    static SoundManager m_instance;
    [SerializeField] AudioSource m_audioSource;
    [SerializeField] AudioSource m_backgroundSource;
    AudioClip[] m_audioClips;
    float[] m_volumeClips;

    // Start is called before the first frame update
    private void Awake()
    {
        if (m_instance == null) { m_instance = this; Initiate(); }
        else { Destroy(this.gameObject); }
    }

    private void Start()
    {
        m_backgroundSource.loop = true;
        m_audioSource.loop = false;
    }

    public static SoundManager Instance { get { return m_instance; } private set { } }

    void Initiate()
    {
        m_audioClips = new AudioClip[(int)AudioClipName.LAST_NO_USE];
        m_audioClips[(int)AudioClipName.ENEMY_HIT] = Resources.Load<AudioClip>("Sound/EnemyDamagedSFX");
        m_audioClips[(int)AudioClipName.ENEMY_KILL] = Resources.Load<AudioClip>("Sound/EnemyKilledSFX");
        m_audioClips[(int)AudioClipName.PLAYER_MACHINE_1] = Resources.Load<AudioClip>("Sound/PlayerMachine1SFX");
        m_audioClips[(int)AudioClipName.PLAYER_MACHINE_2] = Resources.Load<AudioClip>("Sound/PlayerMachine2SFX");
        m_audioClips[(int)AudioClipName.PLAYER_MACHINE_3] = Resources.Load<AudioClip>("Sound/PlayerMachine3SFX");
        m_audioClips[(int)AudioClipName.PLAYER_MACHINE_4] = Resources.Load<AudioClip>("Sound/PlayerMachine4SFX");
        m_audioClips[(int)AudioClipName.PLAYER_WALK] = Resources.Load<AudioClip>("Sound/Walk2SFX");
        m_audioClips[(int)AudioClipName.PLAYER_GROUNDPOUND] = Resources.Load<AudioClip>("Sound/GroundpoundSFX");
        m_audioClips[(int)AudioClipName.PLAYER_DASH] = Resources.Load<AudioClip>("Sound/DashSFX");
        m_audioClips[(int)AudioClipName.PLAYER_JUMP] = Resources.Load<AudioClip>("Sound/JumpSFX");
        m_audioClips[(int)AudioClipName.MINE_COAL] = Resources.Load<AudioClip>("Sound/MineCoalSFX");
        m_audioClips[(int)AudioClipName.RECOLECT_WATTER] = Resources.Load<AudioClip>("Sound/RecollectWatterSFX");
        m_audioClips[(int)AudioClipName.SHOOTSOUND] = Resources.Load<AudioClip>("Sound/ShootSoundSFX");
        m_audioClips[(int)AudioClipName.PLAYER_WALLJUMP] = Resources.Load<AudioClip>("Sound/PlayerWallJumpSFX");
        m_audioClips[(int)AudioClipName.CLICK_MENU] = Resources.Load<AudioClip>("Sound/ClickMenuSFX");
        m_audioClips[(int)AudioClipName.SOUND_LAVA] = Resources.Load<AudioClip>("Sound/SoundLavaSFX");

        m_volumeClips = new float[(int)AudioClipName.LAST_NO_USE];
        m_volumeClips[(int)AudioClipName.ENEMY_HIT] = m_enemyHit;
        m_volumeClips[(int)AudioClipName.ENEMY_KILL] = m_enemyDeath;
        m_volumeClips[(int)AudioClipName.RECOLECT_WATTER] = m_recolectWatter;
        m_volumeClips[(int)AudioClipName.PLAYER_DASH] = m_playerDash;
        m_volumeClips[(int)AudioClipName.ENEMY_KILL] = m_enemyDeath;
        m_volumeClips[(int)AudioClipName.MINE_COAL] = m_mineCoal;
        m_volumeClips[(int)AudioClipName.PLAYER_GROUNDPOUND] = m_playerGroundpound;
        m_volumeClips[(int)AudioClipName.PLAYER_MACHINE_1] = m_machine1;
        m_volumeClips[(int)AudioClipName.PLAYER_MACHINE_2] = m_machine2;
        m_volumeClips[(int)AudioClipName.PLAYER_MACHINE_3] = m_machine3;
        m_volumeClips[(int)AudioClipName.PLAYER_MACHINE_4] = m_machine4;
        m_volumeClips[(int)AudioClipName.PLAYER_WALK] = m_playerWalk;
        m_volumeClips[(int)AudioClipName.PLAYER_JUMP] = m_playerJump;
        m_volumeClips[(int)AudioClipName.SHOOTSOUND] = m_shootSound;
        m_volumeClips[(int)AudioClipName.PLAYER_WALLJUMP] = m_playerWallJump;
        m_volumeClips[(int)AudioClipName.CLICK_MENU] = m_clickMenu;
        m_volumeClips[(int)AudioClipName.SOUND_LAVA] = m_soundLava;
    }

    public void PlayOnce(AudioClipName p_name)
    {
        m_audioSource.volume = m_generalVolume * m_volumeClips[(int)p_name];
        m_audioSource.PlayOneShot(m_audioClips[(int)p_name]);
    }

    public void PlayBackground(AudioClipName p_name, float p_volumeLevel)
    {
        m_audioSource.volume = p_volumeLevel;
        m_audioSource.Play();
    }

    public float GetAudioClipDuration(AudioClipName p_name)
    {
        return m_audioClips[(int)p_name].length;
    }
}

