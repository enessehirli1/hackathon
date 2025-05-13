using UnityEngine;

public class DebugHitboxGizmos : MonoBehaviour
{
    public Color gizmoColor = Color.red; // Gizmo rengini belirleyebilirsiniz.

    private void OnDrawGizmos()
    {
        // Gizmo rengini ayarla
        Gizmos.color = gizmoColor;

        // Collider tipini kontrol et ve �izim yap
        var collider = GetComponent<Collider2D>();
        if (collider is BoxCollider2D box)
        {
            // BoxCollider2D i�in wireframe kutusu �iz
            Gizmos.DrawWireCube(transform.position + (Vector3)box.offset, box.size);
        }
        else if (collider is CircleCollider2D circle)
        {
            // CircleCollider2D i�in wireframe daire �iz
            Gizmos.DrawWireSphere(transform.position + (Vector3)circle.offset, circle.radius);
        }
    }
}
