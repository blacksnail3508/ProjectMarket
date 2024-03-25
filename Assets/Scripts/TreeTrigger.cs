using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TreeTrigger : MonoBehaviour
{
    [SerializeField] GameConfig gameConfig;
    [SerializeField] TomatoTree tree;
    Player player;
    float timer = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<Player>();
            timer = 0;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
        }
    }

    private void Update()
    {
        if (player != null)
        {
            if(timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                player.GatherFruitFromTree(tree);
                timer = gameConfig.FruitGatherDelay;
            }
        }
    }

}
