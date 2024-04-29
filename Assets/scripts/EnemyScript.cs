using UnityEngine;
using UnityEngine.UIElements;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    GameObject Explosionprefab;

    [SerializeField]
    float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        float x =Random.Range(-5f,5f);
        Vector2 pos = new Vector2 (x , Camera.main.orthographicSize+1);

        transform.position = pos ;

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 movement = new Vector2(0, -1)*speed * Time.deltaTime;

        
        transform.Translate(movement);

        if (transform.position.y < -Camera.main.orthographicSize - 1)
        {
            GameObject.Destroy(this.gameObject);
            GameObject.Find("Ship").GetComponent<ShipControler>().TakeDamage();
        }

    }
 

    private void OnTriggerEnter2D(Collider2D other) 
  {
    //Debug.Log(other.gameObject.tag);
    
      if(other.gameObject.tag=="bolt"||other.gameObject.tag== "ship")
    {

     Destroy(this.gameObject);

     GameObject explosion = Instantiate (Explosionprefab, transform.position, Quaternion.identity);

      Destroy(explosion, 0.3f);
     
    }


  }
}
