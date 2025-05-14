using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public SimpleTimerBar timebar;
    public AudioSource mainMusic, lowHealthMusic;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timebar.currentTime < 50 && lowHealthMusic.isPlaying == false)
        {
            mainMusic.Stop();
            lowHealthMusic.Play();
        }
        else if(timebar.currentTime >= 50 && mainMusic.isPlaying ==false)
        {
            lowHealthMusic.Stop();
            mainMusic.Play();
        }

    }

}
