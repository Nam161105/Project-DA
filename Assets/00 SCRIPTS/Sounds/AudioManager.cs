using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    protected static AudioManager instance;
    public static AudioManager Instance => instance;

    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioSource audioClip;

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
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }


    }

    public void PlaySFX(AudioClip clip)
    {
        audioClip.PlayOneShot(clip);
    }
}
