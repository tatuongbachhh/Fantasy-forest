using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource m_Audio;
    public List<AudioClip> m_Clip;

    public void AnCoin()
    {
        m_Audio.PlayOneShot(m_Clip[0]);
    }

    public void JumpSound()
    {
        m_Audio.PlayOneShot(m_Clip[2]);
    }

    public void DeadSound()
    {
        m_Audio.PlayOneShot(m_Clip[1]);
    }
}
