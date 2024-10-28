using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    public float moveSpeed; // predkosc playera
    Rigidbody2D rigb;
    private AudioSource hitSound;
    // Start is called before the first frame update
    void Start()
    {
        rigb = GetComponent<Rigidbody2D>(); // namy dostep do rigidbod
        hitSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // sprawdzamy gdzie klikamy lewo/prawo
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(touchPos.x < 0)
            {
                rigb.AddForce(Vector2.left * moveSpeed);
            }
            else
            {
                rigb.AddForce(Vector2.right * moveSpeed);
            }
        }
        else // jak niczego nie klikamy to velocity = 0
        {
            rigb.velocity = Vector2.zero; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Falling_Object")
        {
            StartCoroutine(HitSoundAndRestart());
        }
    }
    private IEnumerator HitSoundAndRestart()
    {
  
        Time.timeScale = 0;

        // Play the collision sound
        if (hitSound != null && !hitSound.isPlaying)
        {
            hitSound.Play();
        }

        // Wait for the sound to finish playing
        yield return new WaitForSecondsRealtime(hitSound.clip.length);

        // Resume the game
        Time.timeScale = 1;

        // Restart the scene
        SceneManager.LoadScene(0);
    }
}