using UnityEngine;

public class fİST : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator fist;
    public GameObject player;
    public AudioSource fistSource;

    void Start()
    {
        fist = player.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = fist.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("Left_Punch") || stateInfo.IsName("Left_Punch 0") || stateInfo.IsName("Left_Punch 1"))
        {
            fistSource.Play();
        }
    }
}
