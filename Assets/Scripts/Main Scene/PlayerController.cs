using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;

    private Rigidbody _playerRB;
    private Animator _animator;

    private float _walkSpeed = 1;
    private float _runSpeed = 2;
    public float _moveSpeed;
    private float _runTime = 2;
    private float _runCooldown = 3;

    public Image staminaBar;
    public float stamina = 100, maxStamina = 100;
    public float chargeRate = 33, sprintCost = 50;

    private bool _isRunning = false;


    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _moveSpeed = _walkSpeed;
        _playerRB = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

    }

    void Update()
    {
        Stamina();
        Movenemt(gameManager._isGameOver);
    }

    private void Movenemt(bool gameOver)
    {
        if (!gameOver)
        {
            float forwardInput = Input.GetAxis("Vertical");
            _playerRB.transform.Translate(Vector3.forward * forwardInput * Time.deltaTime * _moveSpeed);//move forward
            bool keyLShift = Input.GetKey(KeyCode.LeftShift);
            bool keyW = Input.GetKey(KeyCode.W);
            bool keyS = Input.GetKey(KeyCode.S);

            //If player moves forward and pressed leftShit, object will run twice faster for 2 seconds, after that he will get 3 sec run cooldown
            if (keyLShift && forwardInput > 0 && !_isRunning)
            {
                _moveSpeed = _runSpeed;
                _isRunning = true;
                _animator.SetFloat("Speed", 2);//running animation
                StartCoroutine(RunLimit());

            }
            //if player doesn't run or walk backward play walking animation
            else if ((keyW && !_isRunning) || keyS)
            {
                _animator.SetFloat("Speed", 1);
                _moveSpeed = _walkSpeed;// set walking speed
            }
            //if player isn't moving play animation
            else if (forwardInput == 0)
            {
                _animator.SetFloat("Speed", 0);
            }
            //running time 
            IEnumerator RunLimit()
            {
                yield return new WaitForSeconds(_runTime);
                _moveSpeed = _walkSpeed;
                _animator.SetFloat("Speed", 1);//set to walking anim after run limit is over
                StartCoroutine(RunFrequency());
            }
            //cooldown time
            IEnumerator RunFrequency()
            {
                yield return new WaitForSeconds(_runCooldown);
                _isRunning = false;
            }
        }

    }
    private void Stamina()//hold Lshift to reduce stamina bar
    {
        if (Input.GetKey(KeyCode.LeftShift) && _isRunning)
        {
            stamina -= sprintCost * Time.deltaTime;
            if (stamina < 0)
                stamina = 0;
            staminaBar.fillAmount = stamina / maxStamina;

            StartCoroutine(RechargeStamina());
        }
    }
    private IEnumerator RechargeStamina()
    {
        yield return new WaitForSeconds(2f);

        while (stamina < maxStamina)
            stamina += chargeRate / 10f;
        if (stamina > maxStamina)
            stamina = maxStamina;
        staminaBar.fillAmount = stamina / maxStamina;
        yield return new WaitForSeconds(.1f);

    }
}
