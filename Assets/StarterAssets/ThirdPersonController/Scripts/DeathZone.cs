using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class DeathZone : MonoBehaviour
{
    private BoxCollider bcoll;

    private void Awake()
    {
        bcoll = GetComponent<BoxCollider>();
    }
    void Start()
    {
        bcoll.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (bcoll != null && other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
