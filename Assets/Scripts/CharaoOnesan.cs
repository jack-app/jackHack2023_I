using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaoOnesan : MonoBehaviour
{
    public GameObject Charao;
    public GameObject Onesan;
    public GameObject Fukidashi;
    public GameObject Dollar;
    public GameObject Batsu;
    public GameObject Heart;
    public GameObject Heart1;
    public GameObject Yukichi;
    public GameObject KissHeart;

    //public GameObject ParentObj;

    [SerializeField]
    private int resultnumber;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Events", resultnumber);
    }

    // Update is called once per frame
    void Update()
    {

    }


    private IEnumerator Events(int battleresult)
    {
        if (battleresult == 3)
        {
            Debug.Log("ƒ`ƒƒƒ‰’j‚˜‚¨Žo‚³‚ñ");
            // yield return new WaitForSeconds(1.0f);
            Charao.SetActive(true);
            Onesan.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            Vector3 FukidashiScale = Fukidashi.transform.localScale;
            for (int i = 0; i < 4; i++)
            {
                Fukidashi.SetActive(true);
                yield return new WaitForSeconds(0.6f);
                Fukidashi.SetActive(false);
                FukidashiScale.x *= -1;
                Fukidashi.transform.localScale = FukidashiScale;

            }
            yield return new WaitForSeconds(1.0f);
            Fukidashi.SetActive(true);
            Dollar.SetActive(true);
            yield return new WaitForSeconds(0.9f);
            Fukidashi.SetActive(false);
            Dollar.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            FukidashiScale.x *= -1;
            Fukidashi.transform.localScale = FukidashiScale;
            Fukidashi.SetActive(true);
            Batsu.SetActive(true);
            yield return new WaitForSeconds(0.9f);
            Fukidashi.SetActive(false);
            Batsu.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            for (int i = 0; i < 5; i++)
            {
                Charao.transform.Translate(-0.8f, 0f, 0f, Space.World);
                yield return new WaitForSeconds(0.1f);
            }
            KissHeart.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            KissHeart.SetActive(false);
            for (int i = 0; i < 5; i++)
            {
                Charao.transform.Translate(0.8f, 0f, 0f, Space.World);
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.6f);
            Heart.SetActive(true);
            Heart1.SetActive(true);
            yield return new WaitForSeconds(0.6f);
            Yukichi.transform.Translate(1.8f, 0f, 0f, Space.World);
            for (int j = 0; j < 3; j++)
            {
                Yukichi.transform.Translate(-1.8f, 0f, 0f, Space.World);
                Yukichi.SetActive(true);
                for (int i = 0; i < 6; i++)
                {
                    Yukichi.transform.Translate(0.3f, 0f, 0f, Space.World);
                    yield return new WaitForSeconds(0.1f);
                }
                Yukichi.SetActive(false);
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.3f);
            Vector3 OnesanScale = Onesan.transform.localScale;
            OnesanScale.x *= -1;
            Onesan.transform.localScale = OnesanScale;
            Onesan.transform.Translate(2.4f, 0f, 0f, Space.World);
            Heart.transform.Translate(2.3f, 0f, 0f, Space.World);
            Heart1.transform.Translate(2.3f, 0f, 0f, Space.World);
            yield return new WaitForSeconds(1.2f);
            Charao.SetActive(false);
            Onesan.SetActive(false);
            Heart.SetActive(false);
            Heart1.SetActive(false);
            //Laughed.SetActive(false);
            //ParentObj.SetActive(false);
        }
        else
        {
            Debug.Log("");
            yield break;
        }
    }
}

