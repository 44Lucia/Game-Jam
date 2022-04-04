using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdrenalineBoost : MonoBehaviour
{
    [SerializeField] HidingSpotInside isEnemyInside;
    [SerializeField] PlayerManager playerVelocity;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnemyInside.isEnemyInside() == true && timer == 5)
        {
            playerVelocity.velocityPlayer(50);
            timer -= Time.deltaTime;
        }
        if (timer < 5)
        {
            timer -= Time.deltaTime;
        }
        

        if (timer <= 0)
        {
            playerVelocity.velocityPlayer(-50);
            timer = 5;
        }
    }
}
