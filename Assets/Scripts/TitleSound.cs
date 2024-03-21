using UnityEngine;
using UnityEngine.UI;

public class TitleSound : MonoBehaviour
{
    public AudioClip soundClip;
    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource audioSource;

    public void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundClip;
        button.onClick.AddListener(PlaySound);
    }

    public void PlaySound()
    {
        audioSource.Play();
    }
}
