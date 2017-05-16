using UnityEngine;
using System.Collections;

public interface IPooledMonoBehaviour {

    void OnCreate();

    void OnGet();

    void OnRecycle();

}
