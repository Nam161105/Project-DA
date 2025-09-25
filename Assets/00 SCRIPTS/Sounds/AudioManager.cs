using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    protected static AudioManager instance;
    public static AudioManager Instance => instance;

    [SerializeField] protected AudioSource _musicSource;
    [SerializeField] protected AudioSource _sfxSource;

    public AudioClip _bgClip;
    public AudioClip _normalAtk1;
    public AudioClip _normalAtk2;
    public AudioClip _normalAtk3;
    public AudioClip _jumpSound;
    public AudioClip _dashSound;
    public AudioClip _explosionSkill1;
    public AudioClip _cannonFire;
    public AudioClip _explosionSkill2;
    public AudioClip _batClip;
    public AudioClip _shotEnemy;
    public AudioClip _enemyPunch;
    public AudioClip _itemPicked;
    public AudioClip _playerDead;
    public AudioClip _monster;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }

    //private void Start()
    //{
    //    _musicSource.clip = _bgClip;
    //    _musicSource.loop = true;
    //    _musicSource.Play();
    //}

    public void PlaySFX(AudioClip clip)
    {
        _sfxSource.PlayOneShot(clip);
    }
}
