using UnityEngine;

public class CharacterVoices : MonoBehaviour
{
    public AudioSource attackSfx;
    public AudioSource jumpSfx;


    public void attackVoice()
    {
        attackSfx.Play();
    }

    public void jumpVoice()
    {
        jumpSfx.Play();
    }


}
