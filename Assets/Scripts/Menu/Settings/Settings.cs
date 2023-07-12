using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;
    public Toggle fullScreenToggle;
    public Slider sound;
    bool isFullScreen = true;
    Resolution[] resolutions;
    void Awake()
    {
        if (Screen.fullScreenMode == FullScreenMode.ExclusiveFullScreen)
        {
            isFullScreen = true;
            fullScreenToggle.isOn=true;

        }
        else
        {
            isFullScreen = false;
            fullScreenToggle.isOn=false;
        }
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        qualityDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " " + resolutions[i].refreshRate + "hz";
            options.Add(option);
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        List<string> qualityOptions = new List<string>();
        foreach (var item in QualitySettings.names)
        {
            qualityOptions.Add(item);
        }
        qualityDropdown.AddOptions(qualityOptions);
        qualityDropdown.value = QualitySettings.GetQualityLevel();
        qualityDropdown.RefreshShownValue();
        sound.value = PlayerPrefs.GetFloat("volume", sound.value);
        SetVolume(sound.value);
    }
    public void SetVolume(float volume)
    {
        AudioManager.audioManager.musicAudioSourcer.volume = volume;
        AudioManager.audioManager.SFXAudioSourcer.volume = volume;
        AudioManager.audioManager.backgroundAudioSourcer.volume = volume;
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void SetQuality(int QualityIndex)
    {
        QualitySettings.SetQualityLevel(QualityIndex, true);
    }
    public void SetFullScreen(bool fullScreen)
    {
        isFullScreen = !isFullScreen;
        if (isFullScreen)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }

    }
    public void SetResolutions(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }
}
