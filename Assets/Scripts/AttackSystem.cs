using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    private Animator mAnimator;
    public GameObject attackHitbox; // AttackHitbox nesnesini Inspector'dan atayaca��z

    void Start()
    {
        mAnimator = GetComponent<Animator>();
        attackHitbox.SetActive(false); // Ba�lang��ta hitbox kapal�
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mAnimator.SetTrigger("Attack"); // Attack animasyonunu tetikle
        }
    }

    // Animasyon event'ten �a�r�lacak
    public void ActivateHitbox()
    {
        attackHitbox.SetActive(true); // Attack ba�lad���nda hitbox'� aktif yap
    }

    // Animasyon event'ten �a�r�lacak
    public void DeactivateHitbox()
    {

        attackHitbox.SetActive(false); // Attack bitti�inde hitbox'� pasif yap
    }
}
