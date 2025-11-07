

using UnityEngine;


public class enemyController : MonoBehaviour //Måste ha samma namn som scriptet

{

    //private Animator anim; //refererar till animator

    public Transform target; //refererar till target som i detta fall är Player

    public Transform homePos; //refererar till Enemy's hemposition, dit vi vill att den gå tillbaka till. 

    public float speed; //refererar till hur snabbt enemy får gå

    public float maxRange; //refererar till enemy's max range, så långt som den får gå

    public float minRange; //referarer till enemy's minimum range, så nära den får gå, så den inte kan knuffa vår player 

    void Start()

    {

      

    }

    void Update()

    {

        if (Vector2.Distance(target.position, transform.position) <= maxRange && Vector2.Distance(target.position, transform.position) >= minRange)

        {

            FollowPlayer(); //om player är inom max range så följ efter player, när du kommit tillräckligt nära "minRange" sluta följa - Rasmus 

        }

        else if (Vector2.Distance(target.position, transform.position) >= maxRange)

        {

            GoHome(); //om player lämnar max range, sluta följa och gå till hempositionen - Rasmus

        }

    }

    public void FollowPlayer()

    {


        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); //härma players rörelser -Rasmus


    }

    public void GoHome()

    {

       
        transform.position = Vector2.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime); //player härmar vilken position hem har - Rasmus

        if (Vector2.Distance(transform.position, homePos.position) == 0)

        {

          

        }

    }

    //Om vi vill att enemy inte ska putta player

    public void OnCollisionEnter2D(Collision2D other)

    {

        if (other.collider.CompareTag("Player"))

        {

            speed = 0f;

        }

    }

    public void OnCollisionExit2D(Collision2D other)

    {

        if (other.collider.CompareTag("Player"))

        {

            speed = 2f;

        }

    }

}

