using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public string volumeParameter = "MasterVolume";
    public AudioMixer mixer;
    [SerializeField] private Slider slider;

    private float saveVolume;

    private void Awake()
    {
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void HandleSliderValueChanged(float value)
    {
        saveVolume = Mathf.Log10(value) * 20f;
        mixer.SetFloat(volumeParameter, saveVolume);
    }

    private void Start()
    {
        saveVolume = PlayerPrefs.GetFloat(volumeParameter, Mathf.Log10(slider.value) * 20f);
        slider.value = Mathf.Pow(10f, saveVolume / 20f);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeParameter, saveVolume);
    }
}
