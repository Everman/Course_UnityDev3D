using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [Tooltip("Delay in seconds")] [SerializeField] float delay = 5f;

    void Start()
    {
        Destroy(gameObject, delay);
    }
}
