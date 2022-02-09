using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    public Button botsButton;
    [SerializeField]
    public Button splitscreenButton;
    [SerializeField]
    public Button onlineButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BotsButtonOnClick() 
    {
        SceneManager.LoadScene("TestFPSScene");
    }

    public void SplitscreenButtonOnClick() 
    {
        Debug.Log("Splitscreen Clicked");
    }

    public void OnlineButtonOnClick() 
    {
        Debug.Log("Online Clicked");
    }

    public void QuitOnClick() 
    {
        Application.Quit();
    }
}
