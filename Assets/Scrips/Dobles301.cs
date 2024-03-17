using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;

public class Dobles301 : MonoBehaviour
{

    public static Dobles301 Instance { get; private set; }


    public float MainMotionSpeed;
    public float MainMotionDistance;

    public AudioSource dardazo;
    public AudioClip sonidoDardo;

    int P1Score = 301;
    int P2Score = 301;
    public TMP_Text P1ScoreTxt;
    public TMP_Text P2ScoreTxt;
    public TMP_Text StatusTxt;
    public GameObject panelGameOver;
    public TMP_Text textoGanador;
   

    
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

    public void Awake()
    {
        if (Instance != null && Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    void Start ()

    {
        LeerDatos();
        current = mode;
        last = mode;
        progress = 0;
        panelGameOver.gameObject.SetActive(false);
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        P1ScoreTxt.text = P1Score.ToString();
        P2ScoreTxt.text = P2Score.ToString();
        
        if(P1Score  == 0)
        {
            GameOver();
        }
       
        if (P2Score == 0)
        {
            GameOver();
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
                    //dardazo.PlayOneShot(sonidoDardo);
                    Invoke("Dardazo", .5f);
                    currentDart = dart;
                    darts.Enqueue(dart);
                    Score score = decodeScore(hit.point);
                    if (P1Turn)
                    {
                        P1Score += score.Points;                                        
                        StatusTxt.text = "Jugador 1º";
                        if(P1Score <=-1)
                        {
                            P1Score -= score.Points;
                        }
                    }
                    else
                    {
                        P2Score += score.Points;
                        StatusTxt.text = "Jugador 2º";
                        if (P1Score <= -1)
                        {
                            P2Score -= score.Points;
                        }
                    }
                    StatusTxt.text += " Anota <i>" + score.Points + "</i>.";

                    if(throwNumber == ThrowNumber.t3)
                    {
                        P1Turn = !P1Turn;
                        StatusTxt.text += " Nuevo jugador";
                        throwNumber = ThrowNumber.t1;
                    }
                    else
                    {
                        throwNumber++;                       
                    }
                

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
            score.Number = -25;
            score.scoreMultiplier = Score.ScoreMultiplier.x2;
            return score;
        }
        else if (offset.magnitude < scoringValue.BE1xRadius)
        {
            score.Number = -25;
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
            score.Number = -20;
        }
        else if (angle < scoringValue.scoringAngles.angle1_18)
        {
            score.Number = -1;
        }
        else if (angle < scoringValue.scoringAngles.angle18_4)
        {
            score.Number = -18;
        }
        else if (angle < scoringValue.scoringAngles.angle4_13)
        {
            score.Number = -4;
        }
        else if (angle < scoringValue.scoringAngles.angle13_6)
        {
            score.Number = -13;
        }
        else if (angle < scoringValue.scoringAngles.angle6_10)
        {
            score.Number = - 6;
        }
        else if (angle < scoringValue.scoringAngles.angle10_15)
        {
            score.Number = -10;
        }
        else if (angle < scoringValue.scoringAngles.angle15_2)
        {
            score.Number = -15;
        }
        else if (angle < scoringValue.scoringAngles.angle2_17)
        {
            score.Number = - 2;
        }
        else if (angle < scoringValue.scoringAngles.angle17_3)
        {
            score.Number = -17;
        }
        else if (angle < scoringValue.scoringAngles.angle3_19)
        {
            score.Number = -3;
        }
        else if (angle < scoringValue.scoringAngles.angle19_7)
        {
            score.Number = -19;
        }
        else if (angle < scoringValue.scoringAngles.angle7_16)
        {
            score.Number = -7;
        }
        else if (angle < scoringValue.scoringAngles.angle16_8)
        {
            score.Number = -16;
        }
        else if (angle < scoringValue.scoringAngles.angle8_11)
        {
            score.Number = -8;
        }
        else if (angle < scoringValue.scoringAngles.angle11_14)
        {
            score.Number = -11;
        }
        else if (angle < scoringValue.scoringAngles.angle14_9)
        {
            score.Number = -14;
        }
        else if (angle < scoringValue.scoringAngles.angle9_12)
        {
            score.Number = -9;
        }
        else if (angle < scoringValue.scoringAngles.angle12_5)
        {
            score.Number = -12;
        }
        else
        {
            score.Number = -5;
        }

        return score;
    }

    public void GameOver()
    {
        panelGameOver.gameObject.SetActive(true);
        mode = Mode.Main;
        if (P1Score == 0)
            textoGanador.text = "Primer Jugador";
        if (P2Score == 0)
            textoGanador.text = "Segundo Jugador";
       
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