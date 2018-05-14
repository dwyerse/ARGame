using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public GameObject centerGoal;
    private Vector3 spawnPoint;
    public float speed;
    private int state;
    Material m_Material;
    float initDist;

    // Use this for initialization
    void Start () {        
        spawnPoint = transform.position;
        state = 0;
        m_Material = GetComponent<Renderer>().material;
        m_Material.color = Color.green;
        initDist = Vector3.Distance(transform.position, centerGoal.transform.position);
    }
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        if (state==0)
        {
            transform.position = Vector3.MoveTowards(transform.position, centerGoal.transform.position, step);
            float dist = Vector3.Distance(transform.position, centerGoal.transform.position);
            m_Material.color = Color.Lerp(Color.red,Color.green,dist/initDist);           
        }
        else if (state == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, spawnPoint, step);
            if (transform.position==spawnPoint)
            {                
                state = 0;
            }
        }
    }
        

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.name == "Player"||other.collider.name=="Well")
        {
            state = 1;
            m_Material.color = Color.grey;
        }
    }
}
