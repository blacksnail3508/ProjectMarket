using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class FruitShelfTrigger : MonoBehaviour
{
    [SerializeField] FruitShelf shelf;
    Vector3 originScale;
    Player player;
    Transform transformCache;
    private void Awake()
    {
        transformCache = transform;
        originScale = transform.localScale;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player=other.GetComponent<Player>();
            transformCache.DOScale(originScale*1.2f , 0.2f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
            transformCache.DOScale(originScale , 0.2f);
        }
    }
    private void Update()
    {
        if (player!=null)
        {
            player.PutFruitOnShelf(shelf);
        }
    }
}
