using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEvent : MonoBehaviour
{
    public GameObject Gal;
    public GameObject Otaku;
    public GameObject Letter;
    public GameObject Heart;
    public GameObject Laughed;

    public GameObject ParentObj;

    [SerializeField]
    private int resultnumber;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Events", resultnumber);
    }


    //yield return new WaitForSeconds (ïbêî);
    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator Events(int battleresult)
    {
       /* Debug.Log("ÇPÇO");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("ÇX");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("ÇW");
        yield return new WaitForSeconds(6.0f);
        Debug.Log("ÇQ");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("ÇP");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("ÇO");*/

        if(battleresult == 2)
        {
            Debug.Log("ÉMÉÉÉãÇòÉIÉ^ÉN");
            // yield return new WaitForSeconds(1.0f);
            Gal.SetActive(true);
            Otaku.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            Letter.SetActive(true);
            for (int i = 0; i < 18; i++)
            {
                Letter.transform.Translate(0.2f, 0f, 0f, Space.World);
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.3f);
            Vector3 OtakuScale = Otaku.transform.localScale;
            for (int i = 0; i < 6; i++)
            {
                OtakuScale.x *= -1;
                Otaku.transform.localScale = OtakuScale;
                Debug.Log(OtakuScale);
                yield return new WaitForSeconds(0.4f);
            }
            Letter.SetActive(false);
            for (int i = 0; i < 9; i++)
            {
                Otaku.transform.Translate(-0.4f, 0f, 0f, Space.World);
                yield return new WaitForSeconds(0.1f);
            }
            for (int i = 0; i < 5; i++)
            {
                Heart.SetActive(true);
                yield return new WaitForSeconds(0.3f);
                Heart.SetActive(false);
                yield return new WaitForSeconds(0.3f);
            }
            Laughed.SetActive(true);
            yield return new WaitForSeconds(1.2f);
            OtakuScale.x *= -1;
            Otaku.transform.localScale = OtakuScale;
            Vector3 OtakuAngle = Otaku.transform.eulerAngles;
            for (int i = 0; i < 28; i++)
            {
                int rnd = Random.Range(-180, 180);
                OtakuAngle.z = rnd;
                OtakuAngle.y = rnd;
                Otaku.transform.eulerAngles = OtakuAngle;
                Otaku.transform.Translate(0.4f, 0f, 0f, Space.World);
                yield return new WaitForSeconds(0.1f);
            }
            Gal.SetActive(false);
            Otaku.SetActive(false);
            Laughed.SetActive(false);
        }
        else
        {
            Debug.Log("");
            yield break;
        }
    }
}
