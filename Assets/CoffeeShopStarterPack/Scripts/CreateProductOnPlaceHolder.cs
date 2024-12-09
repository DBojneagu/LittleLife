
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PW
{

    public class CreateProductOnPlaceHolder : MonoBehaviour
    {

        public GameObject objectToGenerate;

        private void OnMouseDown()
        {

            var go = GameObject.Instantiate(objectToGenerate, transform.parent);
            Destroy(objectToGenerate);
            go.transform.position = transform.position;

            var m_collider = go.GetComponent<Collider>();
            m_collider.enabled = true;

            go.SetActive(true);

            var productGO = go.GetComponent<ProductGameObject>();
            if (productGO.AddToPlateBeforeServed)
            {
                Destroy(go.transform.GetChild(0).gameObject);
            }


            Destroy(gameObject);
        }
    }
}
