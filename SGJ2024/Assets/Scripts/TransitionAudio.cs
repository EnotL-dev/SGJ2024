using System.Collections;
using UnityEngine;

public class TransitionAudio : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool fade;
    [SerializeField] private bool appear;
    [SerializeField] private float max_volume = 0.7f;
    [SerializeField] private AudioSource audioSource;

    private void OnEnable()
    {
        StopAllCoroutines();

        if(fade)
        {
            StartCoroutine(startFade());
        }
        else if(appear)
        {
            StartCoroutine(startAppear());
        }
    }

    private IEnumerator startAppear()
    {
        while (true)
        {
            if (audioSource.volume >= max_volume)
            {
                break;
            }

            audioSource.volume += 0.01f;
            yield return new WaitForSeconds(speed);
        }
        gameObject.SetActive(false);
        yield return null;
    }

    private IEnumerator startFade()
    {
        while (true)
        {
            if(audioSource.volume <= 0)
            {
                break;
            }

            audioSource.volume -= 0.01f;
            yield return new WaitForSeconds(speed);
        }
        gameObject.SetActive(false);
        yield return null;
    }
}
