using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Ctrl : MonoBehaviour
{
    [SerializeField] private AudioSource m_Source;
    [SerializeField] private AudioSource b_Source;

    public GameObject buttonP_On;
    public GameObject buttonP_Off;

    public AudioClip background;
    public AudioClip move;
    public AudioClip win;

    private int isPlay;

    void Start()
    {
        // Lấy trạng thái từ lần trước (mặc định là bật)
        isPlay = PlayerPrefs.GetInt("isplay", 1);

        if (m_Source != null)
        {
            m_Source.clip = background;

            if (isPlay == 1)
                m_Source.Play();
        }

        UpdateButtonUI();
    }

    public void StopP()
    {
        if (m_Source.isPlaying)
        {
            m_Source.Stop();
        }

        isPlay = 0;
        PlayerPrefs.SetInt("isplay", isPlay);
        PlayerPrefs.Save();

        UpdateButtonUI();
    }

    public void PlayP()
    {
        if (!m_Source.isPlaying)
        {
            m_Source.Play();
        }

        isPlay = 1;
        PlayerPrefs.SetInt("isplay", isPlay);
        PlayerPrefs.Save();

        UpdateButtonUI();
    }

    private void UpdateButtonUI()
    {
        buttonP_On.SetActive(isPlay == 1);
        buttonP_Off.SetActive(isPlay == 0);
    }
}
