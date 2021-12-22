using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private string[] volumeParameters;
    [SerializeField] private Slider[] sliders;
    [SerializeField] private Toggle[] toggles;

    [SerializeField] private float multiplier = 30f;

    private int index;
    private bool disableToggleEvent;

    private void Awake()
    {
        for (int i = 0; i < sliders.Length; i++)
        {
            index = i;
            sliders[i].onValueChanged.AddListener(HandleSliderValueChanged);
            toggles[i].onValueChanged.AddListener(HandleToggleValueChanged);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < volumeParameters.Length; i++)
        {
            PlayerPrefs.SetFloat(volumeParameters[i], sliders[i].value);
        }
    }

    private void Start()
    {
        for (int i = 0; i < sliders.Length; i++)
        {
            sliders[i].value = PlayerPrefs.GetFloat(volumeParameters[i], sliders[i].value);
        }
    }

    private void HandleSliderValueChanged(float value)
    {
        mixer.SetFloat(volumeParameters[index], Mathf.Log10(value) * multiplier);
        disableToggleEvent = true;
        toggles[index].isOn = sliders[index].value > sliders[index].minValue;
        disableToggleEvent = false;
    }

    private void HandleToggleValueChanged(bool enableSound)
    {
        if (disableToggleEvent)
            return;

        if (enableSound)
            sliders[index].value = sliders[index].maxValue;
        else
            sliders[index].value = sliders[index].minValue;
    }
}
