using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariantBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
       Invoke("DestroyBulletVariant", 1.3f);
    }
    public void DestroyBulletVariant()
    {
       Destroy(gameObject);
    }
    public static void FuncionPrueba()
    {
        
    }
}
