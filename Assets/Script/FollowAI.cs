using UnityEngine;

public class FollowAI : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float minDistance;
    [SerializeField] private GameObject player;

    private bool isFacingRight = true;

    void Start()
    {
        player = GameManager.instance.Player;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < minDistance && Vector2.Distance(transform.position, player.transform.position) > 0.6f)
        {
            Vector3 dir = (player.transform.position - transform.position).normalized;
            transform.position += dir *  speed * Time.deltaTime;
        }

        bool isPlayerRight = transform.position.x < player.transform.position.x;
        Flip(isPlayerRight);
    }

    private void Flip(bool isPlayerRight)
    {
        if (isFacingRight && !isPlayerRight || !isFacingRight && isPlayerRight)
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
