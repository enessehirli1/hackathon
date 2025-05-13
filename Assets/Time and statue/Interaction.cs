using TMPro;
using UnityEngine;

public class InteractionZone : MonoBehaviour
{

    public TextMeshProUGUI interactPrompt;
    private bool playerInRange = false;

    SimpleTimerBar simpleTimerBar = new SimpleTimerBar();

    void Start()
    {
        if (interactPrompt != null)
            interactPrompt.gameObject.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            simpleTimerBar.currentTime += 10;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && interactPrompt != null)
        {
            interactPrompt.gameObject.SetActive(true);  // Show prompt
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && interactPrompt != null)
        {
            interactPrompt.gameObject.SetActive(false);  // Hide prompt
            playerInRange = false;
        }
    }
}