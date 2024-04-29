    using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ShipControler : MonoBehaviour
{

    [SerializeField]
    int maxHp =100;
    int currentHp;
    [SerializeField]
    Slider heatlthSlider;

    [SerializeField]
    TMP_Text healthText;

    [SerializeField]
    float speed = 10;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    Transform gunPosition;
    [SerializeField]
    
    AudioClip shootSound;

    [SerializeField]
    float timeBetweenShots = 0.5f;
     [SerializeField]
    float timeBetweenShots2 = 1.5f;
    float shotTimer = 0;
    float shotTimer2 = 0;

    void Start()
    {

    }

    void Awake() {

        currentHp = maxHp;
        UpdateHealthSlider();
        
    }





    // Update is called once per frame
    void Update()
    {
        

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY);
        movement = movement.normalized * speed * Time.deltaTime;

        transform.Translate(movement);
        shotTimer += Time.deltaTime;
        shotTimer2 += Time.deltaTime;

        
        if (Input.GetAxisRaw("Fire1") > 0 && shotTimer > timeBetweenShots)
        {   
            GetComponent<AudioSource>().Play();
            Instantiate(bulletPrefab, gunPosition.position,Quaternion.identity);
            shotTimer = 0;

        }

         if (Input.GetAxisRaw("Fire3") > 0 && shotTimer2 > timeBetweenShots2)
        {   
            GetComponent<AudioSource>().Play();
            Instantiate(bulletPrefab, gunPosition.position+Vector3.left ,Quaternion.identity);
            Instantiate(bulletPrefab, gunPosition.position+Vector3.right ,Quaternion.identity);
            Instantiate(bulletPrefab, gunPosition.position ,Quaternion.identity);
            shotTimer2 = 0;

        }





    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "enemy")
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    { 
         currentHp -=10;
            UpdateHealthSlider();
            if (currentHp <= 0)
            {
                SceneManager.LoadScene(1);
            }
            

    }

    
    void UpdateHealthSlider()
    {
        heatlthSlider.maxValue = maxHp;
        heatlthSlider.value = currentHp;
        healthText.text = currentHp + "/" + maxHp;

        
    }
}





/*
-Fiender
    -Röra sig
    -Fienden kan dö(kollision med skott)
    -spawnas
-Begränsa så man inte kan åka utanför skärmen
-något sätt att avsluta spelet

*/