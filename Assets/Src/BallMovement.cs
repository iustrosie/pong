using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    private Rigidbody2D _rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        float x = Random.Range (0, 2) == 0 ? -1 : 1;
        float y = Random.Range (0, 2) == 0 ? -1 : 1;
        _rb.linearVelocity = new Vector2(x, y) * _speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
