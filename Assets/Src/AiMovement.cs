using UnityEngine;

public class AiMovement : MonoBehaviour
{
    [SerializeField] private Transform _ball;
    [SerializeField] private float _speed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_ball.position.y > transform.position.y)
        {
            transform.Translate(new Vector2(0, 1) * _speed * Time.deltaTime);
        }
        else if (_ball.position.y < transform.position.y)
        {
            transform.Translate(new Vector2(0, -1) * _speed * Time.deltaTime);
        }
    }
}
