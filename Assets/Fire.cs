using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{

    GameObject prefab;
    public float timer = 1f;
    public Vector3 bulletOffset = new Vector3(0f, 0f, 0f);
    public Vector3 bulletOffset2 = new Vector3(0f, 1f, 1f);
    public Vector3 bulletOffset3 = new Vector3(0f, -1f, 1f);
    public Vector3 bulletOffset4 = new Vector3(-1f, 0.5f, 1f);
    public Vector3 bulletOffset5 = new Vector3(-1f, -0.5f, 1f);
    public Vector3 bulletOffset6 = new Vector3(1f, .5f, 1f);

    public float damage = 10;

    public void fire(GameObject Box, bool selector)
    {
        Debug.Log("FIST");

        if (selector == false)
        {
            Debug.Log(selector);
            prefab = Resources.Load("projectile") as GameObject;

            bulletOffset = GameObject.FindGameObjectWithTag("Box").transform.position;

            GameObject projectile = Instantiate(prefab, bulletOffset, Quaternion.Euler(0, 0, 0)) as GameObject;

            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = GameObject.FindGameObjectWithTag("Box").transform.forward * 100;
        }
        else {
            Debug.Log(selector);
            prefab = Resources.Load("projectile") as GameObject;

            bulletOffset += GameObject.FindGameObjectWithTag("Box").transform.position;
            bulletOffset2 += GameObject.FindGameObjectWithTag("Box").transform.position;
            bulletOffset3 += GameObject.FindGameObjectWithTag("Box").transform.position;
            bulletOffset4 += GameObject.FindGameObjectWithTag("Box").transform.position;
            bulletOffset5 += GameObject.FindGameObjectWithTag("Box").transform.position;
            bulletOffset6 += GameObject.FindGameObjectWithTag("Box").transform.position;

            GameObject projectile = Instantiate(prefab, bulletOffset, Quaternion.Euler(0, 0, 0)) as GameObject;
            GameObject projectile2 = Instantiate(prefab, bulletOffset2, Quaternion.Euler(0, 0, 0)) as GameObject;
            GameObject projectile3 = Instantiate(prefab, bulletOffset3, Quaternion.Euler(0, 0, 0)) as GameObject;
            GameObject projectile4 = Instantiate(prefab, bulletOffset, Quaternion.Euler(0, 0, 0)) as GameObject;
            GameObject projectile5 = Instantiate(prefab, bulletOffset2, Quaternion.Euler(0, 0, 0)) as GameObject;
            GameObject projectile6 = Instantiate(prefab, bulletOffset3, Quaternion.Euler(0, 0, 0)) as GameObject;

            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            Rigidbody rb2 = projectile2.GetComponent<Rigidbody>();
            Rigidbody rb3 = projectile3.GetComponent<Rigidbody>();
            Rigidbody rb4 = projectile4.GetComponent<Rigidbody>();
            Rigidbody rb5 = projectile5.GetComponent<Rigidbody>();
            Rigidbody rb6 = projectile6.GetComponent<Rigidbody>();

            rb.velocity = GameObject.FindGameObjectWithTag("Box").transform.forward * 100;
            rb2.velocity = GameObject.FindGameObjectWithTag("Box").transform.forward * 100;
            rb3.velocity = GameObject.FindGameObjectWithTag("Box").transform.forward * 100;
            rb4.velocity = GameObject.FindGameObjectWithTag("Box").transform.forward * 100;
            rb5.velocity = GameObject.FindGameObjectWithTag("Box").transform.forward * 100;
            rb6.velocity = GameObject.FindGameObjectWithTag("Box").transform.forward * 100;


            //RaycastHit2D hit = Physics2D.Raycast(firePointPos, mousePosition - firePointPos, 100, whatToHit);

            /*if (projectile.GetComponent<Collider>() != null)
            {
                //GetComponent<AudioSource>().Play();
                //Debug.DrawLine(firePointPos, hit.point, Color.red);

                Enemy enemy = projectile.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.Hurt();
                }

            }*/
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //Enemy enemy = new Enemy();
            //enemy.Hurt();
            //Destroy(col.gameObject);
            //add an explosion or something
            //destroy the projectile that just caused the trigger collision
            //Destroy(gameObject);
        }

        if(col.gameObject.tag == "RestartCube")
        {
            GameManager.gameOver = true;
        }
    }
}
