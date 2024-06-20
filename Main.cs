using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] GameObject GreenBall;
    [SerializeField] GameObject BlueBall;


    int nScore = 0;
    [SerializeField] TMPro.TMP_Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBalls());
    }

    public void AddScore(int n)
    {
        nScore += n;
        ScoreText.text = "Score : " + nScore;
    }


    IEnumerator SpawnBalls()
    {
        // 무한 루프 안에서 실행
        while (true)
        {
            GameObject ball;
            // 2초 기다림
            yield return new WaitForSeconds(2f);

            // 랜덤하게 공을 생성
            int random = Random.Range(0, 2);
            if (random == 0)
            {
                ball = Instantiate(GreenBall, new Vector3(Random.Range(-0.5f, 0.5f), 10, 0), Quaternion.identity);
            }
            else
            {
                ball = Instantiate(BlueBall, new Vector3(Random.Range(-0.5f, 0.5f), 10, 0), Quaternion.identity);
            }
            float addGravity = 2.0f;

            ball.GetComponent<Rigidbody>().AddForce(Vector3.down * addGravity, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
