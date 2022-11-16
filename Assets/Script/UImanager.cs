using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{

    public GameObject gameover_Panel;
/*    public GameObject restart_Button;
    public GameObject quit_Button;*/

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        gameover_Panel.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerHealth>().health <= 0)
        {

            StartCoroutine(EnableGameOverPanel());
        }
    }

    IEnumerator EnableGameOverPanel()
    {
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0;
        gameover_Panel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartButtonClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void QuitButtonClick()
    {
        Application.Quit();
    }
}
