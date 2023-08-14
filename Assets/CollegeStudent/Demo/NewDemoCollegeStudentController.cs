using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClearSky
{
    public class NewDemoCollegeStudentController : MonoBehaviour
    {
        public float movePower = 10f;
        public float KickBoardMovePower = 15f;
        public float jumpPower = 20f; //Set Gravity Scale in Rigidbody2D Component to 5

        private Rigidbody2D rb;
        private Animator anim;

        Vector3 movement;
        private int direction = 1;
        bool isJumping = false;
        private bool alive = true;
        private bool isKickboard = false;

        public RandomAudioPlayer punchAudioPlayer;
        public RandomAudioPlayer footstepAudioPlayer;
        public RandomAudioPlayer hurtAudioPlayer;
        public RandomAudioPlayer pickupAudioPlayer;

        public Transform flashlight;

        [SerializeField]private FloatValue health;
        private float currentHealth;


        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();

            currentHealth = health.Value;
        }

        private void Update()
        {
            HandleMenuButton();
            Restart();
            if (alive)
            {
                Hurt();
                Die();
                Attack();
                Jump();
                KickBoard();
                Run();
                Light();

            }
        }

        private void HandleMenuButton()
        {
            if (InputManager.GetInstance().GetMenuPressed()) 
            {
                // save the game anytime before loading a new scene
                DataPersistenceManager.instance.SaveGame();
                // load the main menu scene
                SceneManager.LoadSceneAsync("MainMenu");
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            anim.SetBool("isJump", false);
            PlayFloortouchSound();
        }
        void KickBoard()
        {   bool KickBoardPressed = InputManager.GetInstance().GetTabPressed();
            if (KickBoardPressed && isKickboard)
            {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
            }
            else if (KickBoardPressed && !isKickboard )
            {
                isKickboard = true;
                anim.SetBool("isKickBoard", true);
            }

        }

        void Run()
        {
            Vector2 moveDirection = InputManager.GetInstance().GetMoveDirection();

            if (!isKickboard)
            {

                Vector3 moveVelocity = Vector3.zero;
                anim.SetBool("isRun", false);


                if (moveDirection.x < 0)
                {
                    direction = -1;
                    moveVelocity = Vector3.left;

                    transform.localScale = new Vector3(direction, 1, 1);
                    if (!anim.GetBool("isJump"))
                        anim.SetBool("isRun", true);

                }
                if (moveDirection.x > 0)
                {
                    direction = 1;
                    moveVelocity = Vector3.right;

                    transform.localScale = new Vector3(direction, 1, 1);
                    if (!anim.GetBool("isJump"))
                        anim.SetBool("isRun", true);

                }
                transform.position += moveVelocity * movePower * Time.deltaTime;

            }
            if (isKickboard)
            {

                Vector3 moveVelocity = Vector3.zero;
                if (moveDirection.x < 0)
                {
                    direction = -1;
                    moveVelocity = Vector3.left;

                    transform.localScale = new Vector3(direction, 1, 1);
                }
                if (moveDirection.x > 0)
                {
                    direction = 1;
                    moveVelocity = Vector3.right;

                    transform.localScale = new Vector3(direction, 1, 1);
                }
                transform.position += moveVelocity * KickBoardMovePower * Time.deltaTime;
            }
        }
        void Jump()
        {

            bool jumpPressed = InputManager.GetInstance().GetJumpPressed();

            //if ((jumpPressed || Input.GetAxisRaw("Vertical") > 0)
            if ((jumpPressed)
            && !anim.GetBool("isJump"))
            {
                isJumping = true;
                anim.SetBool("isJump", true);
            }
            if (!isJumping)
            {
                return;
            }

            rb.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

            isJumping = false;
        }
        void Attack()
        {
            if (InputManager.GetInstance().GetInteractPressed())
            {
                anim.SetTrigger("attack");
            }
        }
        void Hurt()
        {
            if (InputManager.GetInstance().GetCrouchPressed())
            {
                PlayHurtAnim();
            }
        }
        void PlayHurtAnim()
        {
            anim.SetTrigger("hurt");
            if (direction == 1)
                rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
            else
                rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
        }
        void Die()
        {
            if (InputManager.GetInstance().GetSpecialPressed())
            {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
                anim.SetTrigger("die");
                alive = false;
            }
        }
        void Restart()
        {
            if (InputManager.GetInstance().GetReloadPressed())
            {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
                anim.SetTrigger("idle");
                alive = true;
            }
        }

        void Light()
        {
            if (InputManager.GetInstance().GetLightPressed())
            {
                flashlight.gameObject.SetActive(!flashlight.gameObject.activeSelf);
            }
        }

        public void PlayFootstepSound()
        {
            footstepAudioPlayer.PlayRandomSound();
        }
        public void PlayFloortouchSound()
        {
            PlayFootstepSound();
        }
        public void PlayPunchSound()
        {
            punchAudioPlayer.PlayRandomSound();
        }
        public void PlayHurtSound()
        {
            hurtAudioPlayer.PlayRandomSound();
        }
        public void PlayPickupSound()
        {
            pickupAudioPlayer.PlayRandomSound();
        }

        public void CheckHealth()
        {
            if(currentHealth > health.Value)
            {
                PlayHurtSound();
                PlayHurtAnim();
            }
            else
            {
                PlayPickupSound();
            }
            currentHealth = health.Value;
        }
    }

}