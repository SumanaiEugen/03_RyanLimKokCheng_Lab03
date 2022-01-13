using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasketMovementScript : MonoBehaviour
{
    public float speed;

    [SerializeField] public Text score;
    [SerializeField] float Points;

    public AudioSource audiosource;
    public AudioClip[] audiocliparray;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {

      float horizontalInput = Input.GetAxis("Horizontal");
    
      transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Healthy"))
        {
            Destroy(collision.gameObject);
            audiosource.PlayOneShot(audiocliparray[0]);
            Points += 10;
            if(Points <= 100)
            {
                SceneManager.LoadScene("GamePlay_Level 2");
            }
            score.text = ("Score : " + Points);
        }
        else if (collision.gameObject.CompareTag("Unhealthy"))
        {
            Destroy(collision.gameObject);
            audiosource.PlayOneShot(audiocliparray[1]);
            SceneManager.LoadScene("GameLoseScene");
        }
    }



}
