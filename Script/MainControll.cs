using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainControll : MonoBehaviour {
    int score = 0;
    public Text outputPoint;

    public AudioClip audioScore;
    public AudioClip audioOver;
    private AudioSource audioSource;

    public GameObject fuckingENDgame;
    public Text FinalScore;

    public GameObject ObjBlock;
    public GameObject ObjDarken;

    int shield = 0;
    public GameObject ObjShield;
    public Text outputSheild;

    public Text outputShot;

    private void Start()
    {
        ObjShield.SetActive(false);

        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioScore;

        fuckingENDgame.SetActive(false);
    }

    public void Inc(int x)
    {
        score += x;
        outputPoint.text = score.ToString();
        audioSource.Play();
        if (score % 10 == 0) Instantiate(ObjDarken, ObjDarken.transform.position, Quaternion.identity);
        if (score % 5 == 0) ObjBlock.GetComponent<cloud_dis>().IncSpeed();
    }

    public void IsProtect(int x)
    {
        ObjShield.SetActive(true);

        shield += x;
        outputSheild.text = "G__\n" + (shield + 1).ToString();

        if (shield == -1)
        {
            GameObject ObjMan = GameObject.FindGameObjectWithTag("man");
            ObjMan.GetComponent<PolygonCollider2D>().isTrigger = false;
            ObjShield.SetActive(false);
        }
    }

    public void IsReload(int x)
    {
        outputShot.text = "S__\n" + x.ToString();
    }

    public void End_Game()
    {
        audioSource.clip = audioOver;
        audioSource.Play();
        fuckingENDgame.SetActive(true);
        FinalScore.text = score.ToString();
    }
}
