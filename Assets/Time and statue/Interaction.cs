using UnityEngine;

public class InteractionZone : MonoBehaviour
{
    private bool playerInRange = false;
    private bool usable = true;
    public SimpleTimerBar currentTime;
    public float addedHealth = 80f;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && usable)
        {
            if(currentTime.currentTime >= 100)
            {
                addedHealth = currentTime.maxTime - currentTime.currentTime;
            }
            currentTime.currentTime += addedHealth;
            usable = false;
            Debug.Log("Interacted with object");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}