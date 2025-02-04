using UnityEngine;

public class EatScript : MonoBehaviour
{
    private GameManager uiScript;
    [SerializeField] private AudioClip[] _eatSFX = new AudioClip[3];
    [SerializeField] private AudioSource audioSource;
    private int _randIndex;
    void Start()
    {
        uiScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _randIndex = Random.Range(0, _eatSFX.Length);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E) && other.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            uiScript.SumAte();
            audioSource.PlayOneShot(_eatSFX[_randIndex], 0.01f);
        }
    }



}
