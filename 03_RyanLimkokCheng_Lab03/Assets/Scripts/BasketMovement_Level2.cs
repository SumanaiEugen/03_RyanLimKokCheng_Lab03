using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BasketMovement_Level2 : MonoBehaviour
{
    public float speed;

    [SerializeField] public Text score;
    [SerializeField] public Text CountdownTimer;
    [SerializeField] float Points;

    float currentTime = 0f;
    float startingTime = 60f;

    public AudioSource audiosource;
    public AudioClip[] audiocliparray;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        CountdownTimer.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            SceneManager.LoadScene("GameWinScene");
        }
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Healthy"))
        {
            Destroy(collision.gameObject);
            Points += 10;
            score.text = ("Score : " + Points);
            audiosource.PlayOneShot(audiocliparray[0]);
        }
        else if (collision.gameObject.CompareTag("Unhealthy"))
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene("GameLoseScene");
            audiosource.PlayOneShot(audiocliparray[1]);
        }
    }
}
