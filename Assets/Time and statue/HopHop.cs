using UnityEngine;

public class MoveUpDown : MonoBehaviour
{
    public float moveRange = 10f;   // The range of movement (in pixels or units)
    public float moveSpeed = 2f;    // The speed of the movement

    private RectTransform rectTransform;
    private float startY;

    void Start()
    {
        // Get the RectTransform of the image
        rectTransform = GetComponent<RectTransform>();

        // Store the starting Y position
        startY = rectTransform.anchoredPosition.y;
    }

    void Update()
    {
        // Use sine wave for smooth up and down movement
        float newY = startY + Mathf.Sin(Time.time * moveSpeed) * moveRange;

        // Apply the new Y position to the RectTransform
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, newY);
    }
}
