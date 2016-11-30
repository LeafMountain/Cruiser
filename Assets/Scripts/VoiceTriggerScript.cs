using UnityEngine;

public class VoiceTriggerScript : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;
    private bool isPlaying;
    private GameObject noiseTrigger;

    private void Start()
    {
        isPlaying = false;
        noiseTrigger = this.gameObject;
        if (noiseTrigger.GetComponent<AudioSource>() == null)
        {
            noiseTrigger.AddComponent<AudioSource>();
        }
        audioSource = noiseTrigger.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.spatialBlend = 1;
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.transform.tag == "Player" && isPlaying == false)
        {
            audioSource.Play();
            isPlaying = true;
        }
    }

    private void Update()
    {
        if (isPlaying == true && audioSource.isPlaying == false)
        {
            Destroy(noiseTrigger);
        }
    }
}