
using UnityEngine;
using System.Collections;
namespace PW
{

    public class DrinkableProduct : ProductGameObject
    {

        public override IEnumerator AnimateGoingToSlot()
        {
            yield return base.AnimateGoingToSlot();
            Destroy(gameObject);
        }

    }
}
