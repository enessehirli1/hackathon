using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    private Animator mAnimator;
    public GameObject attackHitbox; // AttackHitbox nesnesini Inspector'dan atayacaðýz

    void Start()
    {
        mAnimator = GetComponent<Animator>();
        attackHitbox.SetActive(false); // Baþlangýçta hitbox kapalý
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mAnimator.SetTrigger("Attack"); // Attack animasyonunu tetikle
        }
    }

    // Animasyon event'ten çaðrýlacak
    public void ActivateHitbox()
    {
        Debug.Log("Hitbox activated!"); // Hitbox aktif olduðunda konsola mesaj yazdýr
        attackHitbox.SetActive(true); // Attack baþladýðýnda hitbox'ý aktif yap
    }

    // Animasyon event'ten çaðrýlacak
    public void DeactivateHitbox()
    {
        Debug.Log("Hitbox deactivated!"); // Hitbox aktif olduðunda konsola mesaj yazdýr

        attackHitbox.SetActive(false); // Attack bittiðinde hitbox'ý pasif yap
    }
}
