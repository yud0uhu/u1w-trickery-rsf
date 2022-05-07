using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultUIManager : MonoBehaviour
{
    [SerializeField] GameObject nextwindow;
    // Start is called before the first frame update
    void Start()
    {
        //ƒ^ƒbƒv‚ÅŽŸ‚Ö‚Æ‚©ŽÀ‘•‚·‚é
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Onclick()
    {
        nextwindow.SetActive(true);
    }
    public void OnClickNext()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void OnclickEnd()
    {
        SceneManager.LoadScene("Title");
    }
}
