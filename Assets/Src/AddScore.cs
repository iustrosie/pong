using UnityEngine;
using UnityEngine.SceneManagement;

public class AddScore : MonoBehaviour
{
    [SerializeField] private Transform _ball;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var whoScores = _ball.position.x > 0 ? "Player" : "Computer";
        Debug.Log($"Point for {whoScores}");
        SceneManager.LoadScene(0);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
