using DG.Tweening;
using System;
using UnityEngine;

[System.Serializable]
public class Arrow : MonoBehaviour
{
    private Action<GameObject> onRelease;
    private int damage;
    private GameObject targetAiming;
    public int Damage { get => damage; set => damage = value; }
    public GameObject TargetAiming { get => targetAiming; set => targetAiming = value; }
    public Action<GameObject> OnRelease { get => onRelease; set => onRelease = value; }

    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new(0, 0, Mathf.Atan2((TargetAiming.transform.position - transform.position).y, (TargetAiming.transform.position - transform.position).x) * Mathf.Rad2Deg + 360);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * (TargetAiming.transform.position - transform.position).normalized * 10f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            //Debug.Log(collision);
            collision.GetComponent<SamuraiBoss>().Hp -= Damage;
            OnRelease(gameObject);
        }
    }
}
