using UnityEngine;

public class DebugHitboxGizmos : MonoBehaviour
{
    public Color gizmoColor = Color.red; // Gizmo rengini belirleyebilirsiniz.

    private void OnDrawGizmos()
    {
        // Gizmo rengini ayarla
        Gizmos.color = gizmoColor;

        // Collider tipini kontrol et ve çizim yap
        var collider = GetComponent<Collider2D>();
        if (collider is BoxCollider2D box)
        {
            // BoxCollider2D için wireframe kutusu çiz
            Gizmos.DrawWireCube(transform.position + (Vector3)box.offset, box.size);
        }
        else if (collider is CircleCollider2D circle)
        {
            // CircleCollider2D için wireframe daire çiz
            Gizmos.DrawWireSphere(transform.position + (Vector3)circle.offset, circle.radius);
        }
    }
}
