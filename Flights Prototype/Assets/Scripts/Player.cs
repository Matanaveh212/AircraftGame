using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public Material blue;
    public Animator transition;
    public TMP_Text scoreText;

    public int ringsLeft = 3;
    int score = 0;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        scoreText.text = score.ToString();

        /// Give player boost at the start
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            GetComponent<Rigidbody>().velocity = transform.forward * 150;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        /// If touching the ground, restart
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ring") && other.gameObject.GetComponent<Ring>().isTaken == false)
        {
            score++;
            scoreText.text = score.ToString();

            ringsLeft--;
            other.gameObject.GetComponent<MeshRenderer>().material = blue;
        }
        else if(other.gameObject.CompareTag("SpecialRing") && other.gameObject.GetComponent<Ring>().isTaken == false)
        {
            if(ringsLeft == 1)
            {
                TransitionToNextLevel(other);
            }
        }
    }

    private void TransitionToNextLevel(Collider other)
    {
        score++;
        scoreText.text = score.ToString();

        ringsLeft--;
        other.gameObject.GetComponent<MeshRenderer>().material = blue;
        transition.SetTrigger("End");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
