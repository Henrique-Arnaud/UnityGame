using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private float speed = 0.07f;
    private float speedRotate = 0.5f;
    public Camera camera;
    public float life;
    public Text txtLife;
    public Rigidbody rb;
    private bool inFloor = false;

    // Start is called before the first frame update
    void Start()
    {
        txtLife.text = "Vidas: " + life;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * speed;
        }
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += transform.forward * -speed;
        }
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0.0f, speedRotate, 0.0f);
        }
        if(Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0.0f, -speedRotate, 0.0f);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(inFloor == true)
            {
                rb.AddForce(new Vector3(0.0f, 8.0f, 0.0f), ForceMode.Impulse);
                inFloor = false;
            }
            
        }
        camera.transform.position = transform.position + new Vector3(0.0f, 2.0f, -5.9f);
        camera.transform.rotation = transform.rotation;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Terrain")
        {
            Debug.Log("Colidiu");
            transform.position = new Vector3(0.0f, 0.6f, -19.5f);
            life--;
            txtLife.text = "Vidas: " + life;
            if (life == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        if(collision.gameObject.tag == "Floor")
        {
            inFloor = true;
        }
        if(collision.gameObject.tag == "Win"){
            SceneManager.LoadScene("WinScene");
        }
        
    }
}
