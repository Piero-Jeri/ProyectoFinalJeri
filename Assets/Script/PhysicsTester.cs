using UnityEngine;

public class PhysicsTester : MonoBehaviour
{
    private Rigidbody2D rb;
    public LayerMask layer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3.up * 2), Vector2.up, 20, layer);

        if(hit.collider != null)
        {
            Debug.Log("Hit: " + hit.collider.name);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Vector2.up * 20);
    }
}
