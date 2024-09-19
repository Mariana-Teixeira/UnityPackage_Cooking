using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource m_audioSource;
    [SerializeField]
    private AudioClip[] m_clip;
 
    public static Action<int> PlaySound;

    private void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        PlaySound += OnPlaySound;
    }

    private void OnDisable()
    {
        PlaySound -= OnPlaySound;
    }

    private void OnPlaySound(int i)
    {
        m_audioSource.clip = m_clip[i];
        m_audioSource.Play();
    }
}
