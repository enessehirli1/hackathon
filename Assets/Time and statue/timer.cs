using UnityEngine;
using UnityEngine.UI;

public class SimpleTimerBar : MonoBehaviour
{
    public Image fillImage;
    private float maxTime = 120f;

    public float currentTime;

    void Start()
    {
        currentTime = maxTime;
        fillImage.fillAmount = 1f;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            fillImage.fillAmount = currentTime / maxTime;
        }
        else
        {
            fillImage.fillAmount = 0f;
        }

    }
}
