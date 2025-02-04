using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{

    private RotateScript _rotateScriptP;
    private RotateScript _rotateScriptC;

    public TextMeshProUGUI fullnessText;
    public TextMeshProUGUI timeLimitText;

    [SerializeField] private GameObject loseUI;
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject interfaceUI;

    public int fullness = 0;

    private float timeLimit = 30;

    public bool _isGameOver;


    private void Awake()
    {

    }
    void Start()
    {
        _isGameOver = false;

        _rotateScriptP = GameObject.Find("Player").GetComponent<RotateScript>();
        _rotateScriptC = GameObject.Find("Cam 1").GetComponent<RotateScript>();
    }

    // Update is called once per frame
    void Update()
    {
        TimeCountdown();
        GameOver();
        Win();
    }


    //calculate how much food did player ate, 5% each food
    public void SumAte()
    {
        fullness += 5;
        fullnessText.text = "Satiation Level : " + fullness + "%";
    }

    //30 sec countdown
    private void TimeCountdown()
    {
        if (timeLimit > 1 && !_isGameOver)
        {
            timeLimit -= Time.deltaTime;
            //Time.deltatime is using float type varialble so we convert it in Int
            timeLimitText.text = $"Master Will Be Back In : {Mathf.FloorToInt(timeLimit)} Sec";
        }
    }

    private void Win()
    {
        if ( fullness >= 100 && !_isGameOver) 
        {
            _isGameOver = true;
            DisableControls();
            winUI.SetActive(true);

        }
    }

    private void GameOver()
    {
        if (timeLimit < 1 && !_isGameOver)
        {
            _isGameOver = true;
            DisableControls();
            loseUI.SetActive(true);
        }
    }
    private void DisableControls()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        _rotateScriptP.sensitivity = 0;
        _rotateScriptC.sensitivity = 0;
        interfaceUI.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
    }public void MenuExit()
    {
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1;
    }

    
}
