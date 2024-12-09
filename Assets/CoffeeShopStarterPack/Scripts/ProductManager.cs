
using UnityEngine;
using System.Collections;
using System.Linq;
using System;
using UnityEditor;

namespace PW
{
    public class ProductManager : MonoBehaviour
    {
        [SerializeField]
        public Product[] Products;

        [SerializeField]
        public string ProductScreenshotsPath;

        [SerializeField]
        public GameObject placeholderPrefab;

        public void InstantiatePlaceHolder(Transform parent,Vector3 pos,GameObject go)
        {
            if (placeholderPrefab != null)
            {
                var placeGo = Instantiate(placeholderPrefab, pos, Quaternion.identity,parent);
                placeGo.GetComponent<CreateProductOnPlaceHolder>().objectToGenerate = go;
            }
            else
            {
                Debug.LogError("You are using this feature on the products but you didn't assign a prefab");
            }

        }

        private void OnEnable()
        {
            BasicGameEvents.onPlaceHolderRequired += InstantiatePlaceHolder;
        }

        private void OnDisable()
        {
            BasicGameEvents.onPlaceHolderRequired -= InstantiatePlaceHolder;

        }

        [ExecuteInEditMode]
        public bool RemoveProduct(int orderID)
        {
            var query = from x in Products where x.orderID == orderID select x ;

            Debug.Log("Trying to remove product with ID : " + orderID);

            if (query.Count() > 0)
            {
                var FoundProduct = query.First();
                var indexOfProduct = Array.IndexOf(Products,FoundProduct);

                //Delete the found product
                Products[indexOfProduct] = null;

                //Rearange our product array
                var tempArr = new Product[Products.Length -1];
                var newIndex = 0;
                for (int i = 0; i < Products.Length; i++)
                {
                    if (Products[i] != null)
                    {
                        tempArr[newIndex] = Products[i];

                        if (newIndex < Products.Length-2)
                            newIndex++;
                    }
                }
                Products = new Product[tempArr.Length];
                Array.Copy(tempArr, Products, tempArr.Length);
                return true;
            }
            else
            {
                Debug.Log("But couldn't found one matchinng");
                return false;
            }

        }

    }

}
