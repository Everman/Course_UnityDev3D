using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketScript : MonoBehaviour
{
    // Component references
    private Rigidbody rigidBody;

    // Modifiable variables
    [SerializeField] private float rotationSpeed = 0;
    [SerializeField] private float thrustPower = 0;
    [SerializeField] private float levelLoadDelay = 2f;

    private AudioSource audioSource;
    [SerializeField] private AudioClip EngineSound = null;
    [SerializeField] private AudioClip DeathSound = null;
    [SerializeField] private AudioClip VictorySound = null;

    [SerializeField] private ParticleSystem PS_Victory = null;
    [SerializeField] private ParticleSystem PS_Death = null;
    [SerializeField] private ParticleSystem PS_RocketBooster = null;

    [SerializeField] private bool collisionDisabled = false;

    enum State {Alive, Dying, Transcending};
    State state = State.Alive;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (state == State.Alive) {
            Thrust();
            Rotation();
        }
        if (Debug.isDebugBuild) {
            DebugModeCheck();
        }
    }

    private void DebugModeCheck() {
        if (Input.GetKeyDown(KeyCode.C)) {
            collisionDisabled = !collisionDisabled;
        }
        if (Input.GetKeyDown(KeyCode.L)) {
            LoadNextScene();
        }
    }

    private void Thrust() {
        if (Input.GetKey(KeyCode.Space)) {
            rigidBody.AddRelativeForce(Vector3.up * thrustPower * Time.deltaTime);
            if (!audioSource.isPlaying) {
                audioSource.PlayOneShot(EngineSound);
                PS_RocketBooster.Play();
            }
        } else {
            if (state != State.Transcending) {
                audioSource.Stop();
                PS_RocketBooster.Stop();
            }
        }
    }

    private void Rotation() {
        rigidBody.freezeRotation = true;
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) {
        } else if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
        } else if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(-Vector3.forward * Time.deltaTime * rotationSpeed);
        }
        rigidBody.freezeRotation = false;
    }

    void OnCollisionEnter(Collision collision) {

        if (collisionDisabled && collision.gameObject.tag != "Finish") { return; } // Debug mode
        if (state != State.Alive) { return; }

        switch (collision.gameObject.tag) {
            case "Friendly":
                // does nothing yet
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            case "Fuel":
                // does nothing yet
                break;
            default:
                StartDeathSequence();
                break;
        }
    }

    private void StartSuccessSequence() {
        state = State.Transcending;
        audioSource.Stop();
        audioSource.PlayOneShot(VictorySound);
        PS_Victory.Play();
        Invoke("LoadNextScene", levelLoadDelay);
    }
    private void StartDeathSequence() {
        state = State.Dying;
        audioSource.Stop();
        audioSource.PlayOneShot(DeathSound);
        PS_Death.Play();
        Invoke("ReloadScene", levelLoadDelay);
    }

    private void LoadNextScene() {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int totalNumberOfScenes = SceneManager.sceneCountInBuildSettings - 1; // -1 to equal it with the index

        if (currentScene > 0 && currentScene % totalNumberOfScenes == 0) {
            SceneManager.LoadScene(0);
        } else {
            SceneManager.LoadScene(currentScene + 1);
        }
    }

    private void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
