using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class ObstacleController : MonoBehaviour
{
    [Space]
    public GameObject fallingTarget; //Penanda Area jatuh obstacle
    public GameObject fallingObject; //Obstacle yang bakal jatuh
    public GameObject smokeParticle; //Efek obstacle jatuh
    public Transform imageTarget; //Image Target Vuforia


    [Space]
    public int HP = 5; //Base Health Point
    public Text hpText; //Text Health Point

    int score = 0; //Base Score
    public Text scoreText; //Text Score yang nongol pas maen


    [Space]
    public GameObject loseUI;
    public GameObject joyStickUI;
    public GameObject ktpUI;
    public Text totalScoreText; //Jumlah Score yang nongol abis kalah
    public Text highScoreText;  //Highscore saat ini


    [Space]
    public Vector3 center;
    public Vector3 size; //Buat nentuin area jatuh pake gizmo


    [Space]
    [SerializeField]
    float spawnSpeed = 1.5f;
    [SerializeField]
    int spawnCount;

    void Start()
    {
        Invoke("SpawnTarget", spawnSpeed);
        hpText.text = "HP = " + HP;
    }

    void SpawnTarget()
    {
        if (imageTarget != null)
        {
            bool found = imageTarget.GetComponent<DefaultTrackableEventHandler>().imageFound;
            if (found)
            {
                var target = Instantiate(fallingTarget, new Vector3(Random.Range(2.6f, -2.6f), 0.026f, Random.Range(2.6f, -2.6f)), Quaternion.identity);
                Destroy(target, 1f);
                SpawnFalling(target.transform);
            }
        } else
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0.026f, Random.Range(-size.z / 2, size.z / 2));
            var target = Instantiate(fallingTarget, pos, Quaternion.identity);
            Destroy(target, 1f);
            SpawnFalling(target.transform);
        }

        spawnCount++;

        if (spawnCount >=5 && spawnSpeed >= 0.5f)
        {
            spawnCount = 0;
            spawnSpeed = spawnSpeed - 0.15f;
        }

        Invoke("SpawnTarget", spawnSpeed);
    }

    void SpawnFalling(Transform target)
    {
        var fall = Instantiate(fallingObject, new Vector3(target.position.x, 7f, target.position.z), Quaternion.identity);
    }

    public void HpModifier(string Z)
    {
        if (Z == "minus") HP--;
        else if (Z == "plus") HP++;

        hpText.text = "HP = " + HP;

        if(HP <= 0)
        {
            HP = 0;
            Lose();
        }
    }

    public void ScoreModifier()
    {
        score++;
        scoreText.text = "Score " + score;

    }

    void Lose()
    {
        loseUI.SetActive(true);
        joyStickUI.SetActive(false);
        if(ktpUI !=null ) ktpUI.SetActive(false);

        var HS = PlayerPrefs.GetInt("HS", 0);
        if (score >= HS) PlayerPrefs.SetInt("HS", score);
        HS = PlayerPrefs.GetInt("HS", 0);
        highScoreText.text = "HighScore " + HS;
        totalScoreText.text = "Score " + score;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
