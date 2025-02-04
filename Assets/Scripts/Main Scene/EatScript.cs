using UnityEngine;

public class EatScript : MonoBehaviour
{
    private GameManager uiScript;
    [SerializeField] private AudioClip[] _eatSFX = new AudioClip[3];
    [SerializeField] private AudioSource audioSource;
    private int _randIndex;

    private int fullnessScore = 5;
    void Start()
    {
        uiScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        _randIndex = Random.Range(0, _eatSFX.Length);//randomly choose eating audio

    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyUp(KeyCode.E) && other.CompareTag("LowCalFood"))
        {
            Destroy(other.gameObject);
            uiScript.SumAte(fullnessScore);
            audioSource.PlayOneShot(_eatSFX[_randIndex], 0.01f);
        }
        else if (Input.GetKeyUp(KeyCode.E) && other.CompareTag("HighCalFood"))
        {
            Destroy(other.gameObject);
            uiScript.SumAte(fullnessScore + 5);
            audioSource.PlayOneShot(_eatSFX[_randIndex], 0.01f);
        }
    }
    
}
