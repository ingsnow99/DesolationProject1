using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer master;
    public Dropdown rDropdown;

    Resolution[] resolutions;
    int currentIndex;
    List<string> options;
    string option;

    private void Start()
    {
        resolutions = Screen.resolutions;
        rDropdown.ClearOptions();
        options = new List<string>();
        currentIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentIndex = i;
            }
        }
        rDropdown.AddOptions(options);
        rDropdown.value = currentIndex;
        rDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        master.SetFloat("volume", volume);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool fullscreenMode)
    {
        Screen.fullScreen = fullscreenMode;
    }
}
