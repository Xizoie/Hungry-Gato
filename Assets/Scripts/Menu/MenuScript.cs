using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] AudioMixer masterMixer;
    [SerializeField] Slider slider;

    
    public Button button;


    private void Awake()
    {
        MasterAudio();
    }
    


    public void LoadMainScene()//load scene
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("MainScene");

    }
    public void Quit()//quit game
    {
        Application.Quit();
    }

    public void MasterAudio()
    {
        float volume = slider.value;

        masterMixer.SetFloat("Audio", Mathf.Log10(volume) * 20);
    }

  
}
