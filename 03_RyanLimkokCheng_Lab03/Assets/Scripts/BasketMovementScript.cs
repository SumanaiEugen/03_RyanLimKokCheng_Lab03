using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketMovementScript : MonoBehaviour
{
    public float speed;

    [SerializeField] public Text score;
    [SerializeField] float Points;
    // Start is called before the first frame update
    void Start()
    {
        
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
            Points += 10;
            score.text = ("Score : " + Points);
        }
        else if (collision.gameObject.CompareTag("Unhealthy"))
        {
            Destroy(collision.gameObject);
        }
    }



}
