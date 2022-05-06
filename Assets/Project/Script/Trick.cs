using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trick : MonoBehaviour
{
    [SerializeField] GameProperties properties;
    public GameObject rsf;
    public LoadScene load;
    public void trick()
    {
        properties.uiMode.Value = UIMode.Main;
        if (properties.attension >= 30)
        {
            rsf.SetActive(true);
            Debug.Log("成功！！！！！！！");
            load.LoadResult();

        } else
        {
            rsf.SetActive(true);
            Debug.Log("失敗！！！！！！！");
        }
    }
}
