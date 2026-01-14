using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]private float speed;
    [SerializeField]private Transform player;
    [SerializeField]private float aheadDistance;
    private float lookAhead;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), speed * Time.deltaTime);
        Vector3 viewPos = Camera.main.WorldToViewportPoint(player.position);
    }
}
