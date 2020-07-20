using UnityEngine;

public class AutoDestroy : MonoBehaviour
{

    [Tooltip("Delay to wait before destruction in order to play Death FX")] [SerializeField] float delay = 5f;
    
    void Start()
    {
        Destroy(gameObject, delay);
    }
}
