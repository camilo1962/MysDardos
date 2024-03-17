using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Linq;

public class gameControllerRueda : MonoBehaviour {
    public float MainMotionSpeed;
    public float MainMotionDistance;

    public AudioSource dardazo;
    public AudioClip sonidoDardo;

    public Text P1ScoreTxt;
    private int dardosLanzados = 0;
    public TMP_Text _dardosLanzados;
    public TMP_Text StatusTxt;
    public GameObject _12Blanco;
    public GameObject _12rojo;
    public  bool _12Rojo;
    public GameObject _12Verde;
    public GameObject _5Blanco;
    public GameObject _5rojo;
    public bool _5Rojo;
    public GameObject _5Verde;
    public GameObject _20Blanco;
    public GameObject _20rojo;
    public bool _20Rojo;
    public GameObject _20Verde;
    public GameObject _1Blanco;
    public GameObject _1rojo;
    public bool _1Rojo;
    public GameObject _1Verde;
    public GameObject _18Blanco;
    public GameObject _18rojo;
    public bool _18Rojo;
    public GameObject _18Verde;
    public GameObject _4Blanco;
    public GameObject _4rojo;
    public bool _4Rojo;
    public GameObject _4Verde;
    public GameObject _13Blanco;
    public GameObject _13rojo;
    public bool _13Rojo;
    public GameObject _13Verde;
    public GameObject _6Blanco;
    public GameObject _6rojo;
    public bool _6Rojo;
    public GameObject _6Verde;
    public GameObject _10Blanco;
    public GameObject _10rojo;
    public bool _10Rojo;
    public GameObject _10Verde;
    public GameObject _15Blanco;
    public GameObject _15rojo;
    public bool _15Rojo;
    public GameObject _15Verde;
    public GameObject _2Blanco;
    public GameObject _2rojo;
    public bool _2Rojo;
    public GameObject _2Verde;
    public GameObject _17Blanco;
    public GameObject _17rojo;
    public bool _17Rojo;
    public GameObject _17Verde;
    public GameObject _3Blanco;
    public GameObject _3rojo;
    public bool _3Rojo;
    public GameObject _3Verde;
    public GameObject _19Blanco;
    public GameObject _19rojo;
    public bool _19Rojo;
    public GameObject _19Verde;
    public GameObject _7Blanco;
    public GameObject _7rojo;
    public bool _7Rojo;
    public GameObject _7Verde;
    public GameObject _16Blanco;
    public GameObject _16rojo;
    public bool _16Rojo;
    public GameObject _16Verde;
    public GameObject _8Blanco;
    public GameObject _8rojo;
    public bool _8Rojo;
    public GameObject _8Verde;
    public GameObject _11Blanco;
    public GameObject _11rojo;
    public bool _11Rojo;
    public GameObject _11Verde;
    public GameObject _14Blanco;
    public GameObject _14rojo;
    public bool _14Rojo;
    public GameObject _14Verde;
    public GameObject _9Blanco;
    public GameObject _9rojo;
    public bool _9Rojo;
    public GameObject _9Verde;





    public GameObject gameOverPanel;
    public GameObject winPanel;

      

    int P1Score = 0;

    bool P1Turn = true;
    enum ThrowNumber { t1 = 1,t2,t3 };
    ThrowNumber throwNumber = ThrowNumber.t1;

    public Vector3 dartOffset;
    public Vector3 dartAngle;
    public GameObject dartPre;
    GameObject currentDart;
    Queue<GameObject> darts = new Queue<GameObject>();

    public ScoringValue scoringValue;

    public enum Mode { Main, MainMotion, Dart };
    public float transitionTime;
    public Mode mode;

    private Mode current;
    private Mode last;
    private float progressUnsmoothed;
    private float progress;
	// Use this for initialization
	void Start ()
    {

        LeerDatos();
        current = mode;
        last = mode;
        progress = 0;
        dardosLanzados = 30;
        _12Blanco.gameObject.SetActive(false);
        _12rojo.gameObject.SetActive(true);
        _12Rojo = true;
        _12Verde.gameObject.SetActive(false);
        _5Blanco.gameObject.SetActive(false);
        _5rojo.gameObject.SetActive(true);
        _5Rojo = true;
        _5Verde.gameObject.SetActive(false);
        _20Blanco.gameObject.SetActive(false);
        _20rojo.gameObject.SetActive(true);
        _20Rojo = true;
        _20Verde.gameObject.SetActive(false);
        _1Blanco.gameObject.SetActive(false);
        _1rojo.gameObject.SetActive(true);
        _1Rojo = true;
        _1Verde.gameObject.SetActive(false);
        _18Blanco.gameObject.SetActive(false);
        _18rojo.gameObject.SetActive(true);
        _18Rojo = true;
        _18Verde.gameObject.SetActive(false);
        _4Blanco.gameObject.SetActive(false);
        _4rojo.gameObject.SetActive(true);
        _4Rojo = true;
        _4Verde.gameObject.SetActive(false);
        _13Blanco.gameObject.SetActive(false);
        _13rojo.gameObject.SetActive(true);
        _13Rojo = true;
        _13Verde.gameObject.SetActive(false);
        _6Blanco.gameObject.SetActive(false);
        _6rojo.gameObject.SetActive(true);
        _6Rojo = true;
        _6Verde.gameObject.SetActive(false);
        _10Blanco.gameObject.SetActive(false);
        _10rojo.gameObject.SetActive(true);
        _10Rojo = true;
        _10Verde.gameObject.SetActive(false);
        _15Blanco.gameObject.SetActive(false);
        _15rojo.gameObject.SetActive(true);
        _15Rojo = true;
        _15Verde.gameObject.SetActive(false);
        _2Blanco.gameObject.SetActive(false);
        _2rojo.gameObject.SetActive(true);
        _2Rojo = true;
        _2Verde.gameObject.SetActive(false);
        _17Blanco.gameObject.SetActive(false);
        _17rojo.gameObject.SetActive(true);
        _17Rojo = true;
        _17Verde.gameObject.SetActive(false);
        _3Blanco.gameObject.SetActive(false);
        _3rojo.gameObject.SetActive(true);
        _3Rojo = true;
        _3Verde.gameObject.SetActive(false);
        _19Blanco.gameObject.SetActive(false);
        _19rojo.gameObject.SetActive(true);
        _19Rojo = true;
        _19Verde.gameObject.SetActive(false);
        _7Blanco.gameObject.SetActive(false);
        _7rojo.gameObject.SetActive(true);
        _7Rojo = true;
        _7Verde.gameObject.SetActive(false);
        _16Blanco.gameObject.SetActive(false);
        _16rojo.gameObject.SetActive(true);
        _16Rojo = true;
        _16Verde.gameObject.SetActive(false);
        _8Blanco.gameObject.SetActive(false);
        _8rojo.gameObject.SetActive(true);
        _8Rojo = true;
        _8Verde.gameObject.SetActive(false);
        _11Blanco.gameObject.SetActive(false);
        _11rojo.gameObject.SetActive(true);
        _11Rojo = true;
        _11Verde.gameObject.SetActive(false);
        _14Blanco.gameObject.SetActive(false);
        _14rojo.gameObject.SetActive(true);
        _14Rojo = true;
        _14Verde.gameObject.SetActive(false);
        _9Blanco.gameObject.SetActive(false);
        _9rojo.gameObject.SetActive(true);
        _9Rojo = true;
        _9Verde.gameObject.SetActive(false);

        gameOverPanel.gameObject.SetActive(false);
        winPanel.gameObject.SetActive(false);
       

    }

    private AudioSource GetDardazo()
    {
        return dardazo;
    }

    // Update is called once per frame
    void Update ()
    {
        P1ScoreTxt.text = P1Score.ToString();
        if(_12Rojo == false && _5Rojo == false && _20Rojo == false && _1Rojo == false && _18Rojo == false && _4Rojo == false && _13Rojo == false && _6Rojo == false && _10Rojo == false && _15Rojo == false && _2Rojo == false && _17Rojo == false && _3Rojo == false && _19Rojo == false && _7Rojo == false && _16Rojo == false && _8Rojo == false && _11Rojo == false && _14Rojo == false && _9Rojo == false)
        {
            winPanel.SetActive(true);
        }

        if (current != last)
        {
            progressUnsmoothed += Time.deltaTime / transitionTime;
            if (progressUnsmoothed >= 1)
            {
                progressUnsmoothed = 0;
                last = current;
            }
            progress = smooth(progressUnsmoothed);
        }
        else if (current != mode)
        {
            current = mode;
        }
        updatePos();

        if (Input.GetMouseButtonDown(0))
        {
            if (mode == Mode.Main)
            {
                mode = Mode.MainMotion;
            }
            else if(mode == Mode.MainMotion && progress == 0)
            {
                
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    
                    mode = Mode.Dart;
                    GameObject dart = (GameObject)Instantiate(dartPre, hit.point + new Vector3(0, 0, -1.85f), Quaternion.Euler(Vector3.zero));
                    dart.GetComponentInChildren<Animation>().Play("Throw");
                    dardosLanzados--;
                    Invoke("Dardazo", 0.5f);
                    if (dardosLanzados <= 0)
                    {
                        gameOverPanel.SetActive(true);
                    }                                  
                 
                    _dardosLanzados.text = dardosLanzados.ToString();
                    currentDart = dart;
                    darts.Enqueue(dart);
                    Score score = decodeScore(hit.point);
                    if (P1Turn)
                    {
                        P1Score += score.Points;
                        StatusTxt.text = " ";
                    }
                   
                    StatusTxt.text += " Marcado el <i>"+score.Points+"</i>.";

                    //if(throwNumber == ThrowNumber.t3)
                    //{
                    //    P1Turn = !P1Turn;
                    //    StatusTxt.text += " Nuevo jugador";
                    //    throwNumber = ThrowNumber.t1;
                    //}
                    //else { throwNumber++; }
                    
                }
            }
            else if(mode == Mode.Dart && progress == 0)
            {
                mode = Mode.Main;
                if (throwNumber == ThrowNumber.t1)
                {
                    while (darts.Count > 0)
                    {
                        GameObject d = darts.Dequeue();
                        d.GetComponentInChildren<Animation>().Play("Drop"); ;
                        Destroy(d, 1f);
                    }
                }
            }
        }
	}
    float smooth(float t)
    {
        return t * t * (3f - 2f * t);
    }
    void updatePos()
    {
        Dictionary<Mode, posRot> positions = new Dictionary<Mode, posRot>();

        positions[Mode.Main] = new posRot(
            new Vector3(
                0, 0, -20),
            Quaternion.Euler(0, 0, 0));

        positions[Mode.MainMotion] = new posRot(
            new Vector3(
               Mathf.Sin(Time.time * MainMotionSpeed) * MainMotionDistance,
               Mathf.Cos(Time.time * MainMotionSpeed) * MainMotionDistance,
               -20
            ),
            Quaternion.Euler(0, 0, 0));
        if (currentDart != null)
        {
            positions[Mode.Dart] = new posRot(currentDart.transform.position + dartOffset, Quaternion.Euler(dartAngle));
        }
        else
        {
            positions[Mode.Dart] = new posRot(Vector3.zero,Quaternion.Euler(Vector3.zero));
        }

        Vector3 finalPos;
        Quaternion finalRot;

        finalPos = Vector3.Lerp(positions[last].pos, positions[current].pos, progress);
        finalRot = Quaternion.Lerp(positions[last].rot, positions[current].rot, progress);

        transform.position = finalPos;
        transform.rotation = finalRot;
    }
    struct posRot
    {
        public Vector3 pos;
        public Quaternion rot;
        public posRot(Vector3 _pos, Quaternion _rot)
        {
            pos = _pos;
            rot = _rot;
        }
    }

    [System.Serializable]
    public struct ScoringValue
    {
        public Vector3 center;
        public float BE1xRadius;
        public float BE2xRadius;
        public float min3X;
        public float max3X;
        public float min2X;
        public float max2X;
        public ScoringAngles scoringAngles;
    }
    [System.Serializable]
    public struct ScoringAngles
    {

        public float angle5_20;
        public float angle20_1;
        public float angle1_18;
        public float angle18_4;
        public float angle4_13;
        public float angle13_6;
        public float angle6_10;
        public float angle10_15;
        public float angle15_2;
        public float angle2_17;
        public float angle17_3;
        public float angle3_19;
        public float angle19_7;
        public float angle7_16;
        public float angle16_8;
        public float angle8_11;
        public float angle11_14;
        public float angle14_9;
        public float angle9_12;
        public float angle12_5;
    }
    struct Score
    {
        public enum ScoreMultiplier { x1=1,x2,x3};
        public ScoreMultiplier scoreMultiplier;
        public int Number;
        public int Points { get { return Number * (int)scoreMultiplier; } }
    }
    Score decodeScore(Vector3 pos)
    {

        Score score = new Score();
        Vector2 offset = new Vector2((pos-scoringValue.center).x, (pos - scoringValue.center).y);
        if (offset.magnitude < scoringValue.BE2xRadius)
        {
            score.Number = 25;
            score.scoreMultiplier = Score.ScoreMultiplier.x2;
            return score;
        }
        else if (offset.magnitude < scoringValue.BE1xRadius)
        {
            score.Number = 25;
                      
            score.scoreMultiplier = Score.ScoreMultiplier.x1;
            return score;
        }
        else if(offset.magnitude <scoringValue.max3X && offset.magnitude > scoringValue.min3X)
        {
            score.scoreMultiplier = Score.ScoreMultiplier.x3;
        }
        else if (offset.magnitude < scoringValue.max2X && offset.magnitude > scoringValue.min2X)
        {
            score.scoreMultiplier = Score.ScoreMultiplier.x2;
        }
        else if (offset.magnitude > scoringValue.max2X)
        {
            score.scoreMultiplier = Score.ScoreMultiplier.x1;
            score.Number = 0;
            return score;
        }
        else
        {
            score.scoreMultiplier = Score.ScoreMultiplier.x1;
        }

        float angle = Vector2.Angle(Vector2.up, offset.normalized);
        if (offset.x < 0)
        {
            angle *= -1;
            angle += 360;
            angle %= 360;
        }

        if (angle<0)
        {
            Debug.LogError("Angle is "+angle+". It is negative");
        }

        if (angle<scoringValue.scoringAngles.angle20_1)
        {
            score.Number = 20;
            _20rojo.gameObject.SetActive(false);
            _20Rojo = false;
            _20Verde.gameObject.SetActive(true);

        }
        else if (angle < scoringValue.scoringAngles.angle1_18)
        {
            score.Number = 1;
            _1rojo.gameObject.SetActive(false);
            _1Rojo = false;
            _1Verde.gameObject.SetActive(true);
        }
        else if (angle < scoringValue.scoringAngles.angle18_4)
        {
            score.Number = 18;
            _18rojo.gameObject.SetActive(false);
            _18Rojo = false;
            _18Verde.gameObject.SetActive(true);

        }
        else if (angle < scoringValue.scoringAngles.angle4_13)
        {
            score.Number = 4;
            _4rojo.gameObject.SetActive(false);
            _4Rojo = false;
            _4Verde.gameObject.SetActive(true);
        }
        else if (angle < scoringValue.scoringAngles.angle13_6)
        {
            score.Number = 13;
            _13rojo.gameObject.SetActive(false);
            _13Rojo = false;
            _13Verde.gameObject.SetActive(true);
        }
        else if (angle < scoringValue.scoringAngles.angle6_10)
        {
            score.Number = 6;
            _6rojo.gameObject.SetActive(false);
            _6Rojo = false;
            _6Verde.gameObject.SetActive(true);
        }
        else if (angle < scoringValue.scoringAngles.angle10_15)
        {
            score.Number = 10;
            _10rojo.gameObject.SetActive(false);
            _10Rojo = false;
            _10Verde.gameObject.SetActive(true);
        }
        else if (angle < scoringValue.scoringAngles.angle15_2)
        {
            score.Number = 15;
            _15rojo.gameObject.SetActive(false);
            _15Rojo = false;
            _15Verde.gameObject.SetActive(true);

        }
        else if (angle < scoringValue.scoringAngles.angle2_17)
        {
            score.Number = 2;
            _2rojo.gameObject.SetActive(false);
            _2Rojo = false;
            _2Verde.gameObject.SetActive(true);
        }
        else if (angle < scoringValue.scoringAngles.angle17_3)
        {
            score.Number = 17;
            _17rojo.gameObject.SetActive(false);
            _17Rojo = false;
            _17Verde.gameObject.SetActive(true);

        }
        else if (angle < scoringValue.scoringAngles.angle3_19)
        {
            score.Number = 3;
            _3rojo.gameObject.SetActive(false);
            _3Rojo = false;
            _3Verde.gameObject.SetActive(true);
        }
        else if (angle < scoringValue.scoringAngles.angle19_7)
        {
            score.Number = 19;
            _19rojo.gameObject.SetActive(false);
            _19Rojo = false;
            _19Verde.gameObject.SetActive(true);

        }
        else if (angle < scoringValue.scoringAngles.angle7_16)
        {
            score.Number = 7;
            _7rojo.gameObject.SetActive(false);
            _7Rojo = false;
            _7Verde.gameObject.SetActive(true);
        }
        else if (angle < scoringValue.scoringAngles.angle16_8)
        {
            score.Number = 16;
            _16rojo.gameObject.SetActive(false);
            _16Rojo = false;
            _16Verde.gameObject.SetActive(true);
        }
        else if (angle < scoringValue.scoringAngles.angle8_11)
        {
            score.Number = 8;
            _8rojo.gameObject.SetActive(false);
            _8Rojo = false;
            _8Verde.gameObject.SetActive(true);
        }
        else if (angle < scoringValue.scoringAngles.angle11_14)
        {
            score.Number = 11;
            _11rojo.gameObject.SetActive(false);
            _11Rojo = false;
            _11Verde.gameObject.SetActive(true);
        }
        else if (angle < scoringValue.scoringAngles.angle14_9)
        {
            score.Number = 14;
            _14rojo.gameObject.SetActive(false);
            _14Rojo = false;
            _14Verde.gameObject.SetActive(true);
        }
        else if (angle < scoringValue.scoringAngles.angle9_12)
        {
            score.Number = 9;
            _9rojo.gameObject.SetActive(false);
            _9Rojo = false;
            _9Verde.gameObject.SetActive(true);
        }
        else if (angle < scoringValue.scoringAngles.angle12_5)
        {
            score.Number = 12;
            _12rojo.gameObject.SetActive(false);
            _12Rojo =false;
            _12Verde.gameObject.SetActive(true);
        }
        else
        {
            score.Number = 5;
            _5rojo.gameObject.SetActive(false);
            _5Rojo = false;
            _5Verde.gameObject.SetActive(true);

        }

        return score;
    }
    private void GuardarDatos()
    {
        SonidoEntreEscenas.instance.MainMotionSpeed = MainMotionSpeed;
    }

    private void LeerDatos()
    {
        MainMotionSpeed = PlayerPrefs.GetFloat("VeloDiana", MainMotionSpeed);
    }
    private void Dardazo()
    {
        dardazo.PlayOneShot(sonidoDardo);
    }
}