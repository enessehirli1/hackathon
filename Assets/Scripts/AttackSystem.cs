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
        Debug.Log("Hitbox activated!"); // Hitbox aktif oldu�unda konsola mesaj yazd�r
        attackHitbox.SetActive(true); // Attack ba�lad���nda hitbox'� aktif yap
    }

    // Animasyon event'ten �a�r�lacak
    public void DeactivateHitbox()
    {
        Debug.Log("Hitbox deactivated!"); // Hitbox aktif oldu�unda konsola mesaj yazd�r

        attackHitbox.SetActive(false); // Attack bitti�inde hitbox'� pasif yap
    }
}
