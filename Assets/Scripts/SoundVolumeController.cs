using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Slider slider;
    [SerializeField] private Text text;

    [Header("Keys")]
    [SerializeField] private string saveVolumeKey;

    [Header("Tags")]
    [SerializeField] private string sliderTag;
    [SerializeField] private string textVolumeTag;

    [Header("Parameters")]
    [SerializeField] private float volume;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(saveVolumeKey))
        {
            volume = PlayerPrefs.GetFloat(saveVolumeKey);
            audioSource.volume = volume;

            GameObject sliderObj = GameObject.FindWithTag(sliderTag);
            if (sliderObj != null)
            {
                slider = sliderObj.GetComponent<Slider>();
                slider.value = volume;
            }
        }
        else
        {
            volume = 0.5f;
            PlayerPrefs.SetFloat(saveVolumeKey, volume);
            audioSource.volume = volume;
        }
    }

    private void LateUpdate()
    {
        GameObject sliderObj = GameObject.FindWithTag(sliderTag);

        if (sliderObj != null )
        {
            slider = sliderObj.GetComponent<Slider>();
            volume = slider.value;

            if (audioSource.volume != volume)
            {
                PlayerPrefs.SetFloat(saveVolumeKey, volume);
            }

            GameObject textObj = GameObject.FindWithTag(textVolumeTag);
            if (textObj != null)
            {
                text = textObj.GetComponent<Text>();
                text.text = $"Music volume\n{Mathf.Round(volume * 100)} %";
            }
        }
        audioSource.volume = volume;
    }
}
