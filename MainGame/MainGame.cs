using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainGame : MonoBehaviour
{
    public GameObject StartTalk;   
    public TMPro.TextMeshProUGUI progressText;
    public TMPro.TextMeshProUGUI temaText;
    public TMPro.TextMeshProUGUI GameStatText;
    public TMPro.TextMeshProUGUI CharStatText1;
    public TMPro.TextMeshProUGUI CharStatText2;
    public TMPro.TextMeshProUGUI CharStatText3;
    public TMPro.TextMeshProUGUI CharStatText4;

    public int[] SavePoint;
    public string teamname;
    public string mainTema;
    public string subTema;

    public float fun; // ��� ����
    public float creativity; // â�� ����
    public float graphic; // �׷��� ����
    public float sound; // ���� ����
    public float proGress; // ��ô��
    public Button grahpicGameEvent;
    public Button soundGameEvent;
    public Button programingGameEvent;
    public SoundCharacter soundCharacter;
    public GraficCharacter graficCharacter;
    public DesignCharacter designCharacter;
    public ProgramingCharacter programingCharacter;
    public float CheckTime;
    public string FinalFun;
    public string FinalCreativity;
    public string FinalSound;
    public string FinalGrahpic;
    public float finalfun;
    public float finalcreativity;
    public float finalsound;
    public float finalgrahpic;

    private void Awake()
    {
        StartTalk.SetActive(true);
    }
    void Start()
    {
        SavePoint = new int[]{PlayerPrefs.GetInt("SavePoint1"), PlayerPrefs.GetInt("SavePoint2"), PlayerPrefs.GetInt("SavePoint3"), PlayerPrefs.GetInt("SavePoint4"),
                                PlayerPrefs.GetInt("SavePoint5"),PlayerPrefs.GetInt("SavePoint6"),PlayerPrefs.GetInt("SavePoint7")};
        proGress = PlayerPrefs.GetInt("ProGress");
        teamname = PlayerPrefs.GetString("TeamName");
        fun = PlayerPrefs.GetInt("Fun");
        creativity = PlayerPrefs.GetInt("Creativity");
        graphic = PlayerPrefs.GetInt("Graphic");
        sound = PlayerPrefs.GetInt("Sound");
        mainTema = PlayerPrefs.GetString("MainTema");
        subTema = PlayerPrefs.GetString("SubTema");
        CheckTime = 0;
    }

// Update is called once per frame
void Update()
    {
        fun = PlayerPrefs.GetInt("Fun");
        creativity = PlayerPrefs.GetInt("Creativity");
        graphic = PlayerPrefs.GetInt("Graphic");
        sound = PlayerPrefs.GetInt("Sound");
        progressText.text = "��ô�� : " + (int)proGress + "%";

        proGress += Time.deltaTime / 3;

        PlayerPrefs.SetInt("ProGress", (int)proGress);

        temaText.text = "�帣 : " + mainTema + " / " + subTema + "\n";
        GameStatText.text =  "\n       :  " + (int)fun + " �� " + "     : " + (int)creativity + " �� \n\n " + "     :  " + (int)graphic + " �� " + "     : " + (int)sound + " �� ";

        CharStatText1.text = "�Ƿ� : " + (int)graficCharacter.skill + "���ǵ� : " + (int)graficCharacter.senserity + "�Ƿε� : " + (int)graficCharacter.fatigue;
        CharStatText2.text = "�Ƿ� : " + (int)programingCharacter.skill + "���ǵ� : " + (int)programingCharacter.senserity + "�Ƿε� : " + (int)programingCharacter.fatigue;
        CharStatText3.text = "�Ƿ� : " + (int)designCharacter.skill + "���ǵ� : " + (int)designCharacter.senserity + "�Ƿε� : " + (int)designCharacter.fatigue;
        CharStatText4.text = "�Ƿ� : " + (int)soundCharacter.skill + "���ǵ� : " + (int)soundCharacter.senserity + "�Ƿε� : " + (int)soundCharacter.fatigue;


        if(proGress >= 0 && SavePoint[0] == 0)
        {

            PopUpSystem.instance.OpenPopUp("��ȹ�� �ۼ�", " ���� : " + PlayerPrefs.GetString("TeamName") + "�� ���ο� ������ ��ȹ�� �ۼ� �ܰ迡 ���Խ��ϴ�. \n��ȹ���ۼ��� ������ ��밡 �Ǵ¸�ŭ �ִ��� ����ְ� â�Ǽ��ְ� �ۼ��غ����� �սô�."
            ,
            () =>
            {
                Debug.Log("OKClick");
                SavePoint[0] = 1;
                PlayerPrefs.SetInt("SavePoint1", SavePoint[0]);

            },
            () =>
            {
                Debug.Log("OKCancel");
            });

        }
        else if(proGress >= 10 && SavePoint[1] == 0)
        {
            PopUpSystem.instance.OpenPopUp("���� ���� �ܰ�", " ���� : " + PlayerPrefs.GetString("TeamName") + "�� ������ ���� �ܰ迡 �����ϴ�. \n������ �������� �κ��� ����ϴ� �κ��Դϴ�.\n�����ؼ� ������ �����غ����� �սô�!"
            ,
            () =>
            {
                Debug.Log("OKClick");
                SavePoint[1] = 1;
                PlayerPrefs.SetInt("SavePoint2", SavePoint[1]);

            },
            () =>
            {
                Debug.Log("OKCancel");
            });
         
        }
        else if(proGress >= 30 && SavePoint[2] == 0)
        {
            grahpicGameEvent.gameObject.SetActive(true);
            CheckTime += Time.deltaTime;
            if(CheckTime >= 10)
            {
                PopUpSystem.instance.OpenPopUp("���� ���� �߻�!!", "�ɰ��� ���װ� �߻������� ���� ���� �����Ƚ��ϴ�..... \n\n��� ���� ������ 20 ��ŭ �϶��߽��ϴ�...."
            ,
            () =>
            {
                Debug.Log("OKClick");
                SavePoint[2] = 1;
                PlayerPrefs.SetInt("SavePoint3", SavePoint[2]);
                PlayerPrefs.SetInt("Fun", PlayerPrefs.GetInt("Fun") - 20);
                PlayerPrefs.SetInt("Creativity", PlayerPrefs.GetInt("Creativity") - 20);
                PlayerPrefs.SetInt("Sound", PlayerPrefs.GetInt("Sound") - 20);
                PlayerPrefs.SetInt("Graphic", PlayerPrefs.GetInt("Graphic") - 20);
                grahpicGameEvent.gameObject.SetActive(false);

            },
            () =>
            {
                Debug.Log("OKCancel");
            });
            }
            else
            {

            }
        }
        else if (proGress >= 50 && SavePoint[3] == 0)
        {
            PopUpSystem.instance.OpenPopUp("���� �׽�Ʈ �ܰ�", " ���� : " + PlayerPrefs.GetString("TeamName") + "�� ������ �׽�Ʈ �ܰ迡 �����ϴ�. \nȤ�ó� �� ���׳� ������ �̸� ã�Ƴ��� \n������ �ϼ����� �������ô�!"
            ,
            () =>
            {
                Debug.Log("OKClick");
                SavePoint[3] = 1;
                PlayerPrefs.SetInt("SavePoint4", SavePoint[3]);

            },
            () =>
            {
                Debug.Log("OKCancel");
            });

        }
        else if(proGress >= 65 && SavePoint[4] == 0)
        {
            soundGameEvent.gameObject.SetActive(true);
            CheckTime += Time.deltaTime;
            if (CheckTime >= 10)
            {
                PopUpSystem.instance.OpenPopUp("���� ���� �߻�!!", "BGM ��ũ ����...\nȿ���� ��ũ ����... \n����.....\n���õ� ���� ���� �۷����ϴ�.. \n\n��� ���� ������ 10 ��ŭ �϶��߽��ϴ�.\n��� ĳ������ �Ƿε��� 50��ŭ �����߽��ϴ�...."
            ,
            () =>
            {
                soundGameEvent.gameObject.SetActive(false);
                Debug.Log("OKClick");
                SavePoint[4] = 1;
                PlayerPrefs.SetInt("SavePoint5", SavePoint[4]);
                PlayerPrefs.SetInt("Fun", PlayerPrefs.GetInt("Fun") - 10);
                PlayerPrefs.SetInt("Creativity", PlayerPrefs.GetInt("Creativity") - 10);
                PlayerPrefs.SetInt("Sound", PlayerPrefs.GetInt("Sound") - 10);
                PlayerPrefs.SetInt("Graphic", PlayerPrefs.GetInt("Graphic") - 10);
                PlayerPrefs.SetFloat("FunFatugue", PlayerPrefs.GetFloat("FunFatugue") + 50);
                PlayerPrefs.SetFloat("DesignFatugue", PlayerPrefs.GetFloat("DesignFatugue") + 50);
                PlayerPrefs.SetFloat("GraphicFatugue", PlayerPrefs.GetFloat("GraphicFatugue") + 50);
                PlayerPrefs.SetFloat("SoundFatugue", PlayerPrefs.GetFloat("SoundFatugue") + 50);

            },
            () =>
            {
                Debug.Log("OKCancel");
            });
            }
            else
            {

            }
        }
        else if(proGress >= 80 && SavePoint[5] == 0)
        {
            PopUpSystem.instance.OpenPopUp("���� ����� �ܰ�", " ���� : " + PlayerPrefs.GetString("TeamName") + "�� ������ ����� �ܰ迡 �����ϴ�. \n���ְ� �� ���ֶ�! ���׸� �ִ��� ���ְ� �����鿡�� ���� ������ �����ݽô�."
            ,
            () =>
            {
                Debug.Log("OKClick");
                SavePoint[5] = 1;
                PlayerPrefs.SetInt("SavePoint6", SavePoint[5]);

            },
            () =>
            {
                Debug.Log("OKCancel");
            });
        }
        else if (proGress >= 90 && SavePoint[6] == 0)
        {
            programingGameEvent.gameObject.SetActive(true);
            CheckTime += Time.deltaTime;
            if (CheckTime >= 10)
            {
                PopUpSystem.instance.OpenPopUp("ũ��ū ����", "�������з� ���� ���� ���׵�� ���� \n�����鿡�� ���� ���� ���� �� �����ϴ�.\n������ ���ظ� �Խ��ϴ�!\n\n��� ���� ������ 15 ��ŭ �϶��߽��ϴ�.\n����Ʈ�� 500 ��ŭ �����߽��ϴ�...."
            ,
            () =>
            {
                programingGameEvent.gameObject.SetActive(false);

                Debug.Log("OKClick");
                SavePoint[6] = 1;
                PlayerPrefs.SetInt("SavePoint7", SavePoint[6]);
                PlayerPrefs.SetInt("Fun", PlayerPrefs.GetInt("Fun") - 15);
                PlayerPrefs.SetInt("Creativity", PlayerPrefs.GetInt("Creativity") - 15);
                PlayerPrefs.SetInt("Sound", PlayerPrefs.GetInt("Sound") - 15);
                PlayerPrefs.SetInt("Graphic", PlayerPrefs.GetInt("Graphic") - 15);
                PlayerPrefs.SetInt("Point", PlayerPrefs.GetInt("Point") - 500);
                
            },
            () =>
            {
                Debug.Log("OKCancel");
            });
            }
            else
            {

            }
        }
        else if(proGress >=100)
        {
            proGress = 0;
            PlayerPrefs.SetInt("ProGress", (int)proGress);
            if (fun<=30)
            {
                FinalFun = "���󿡼� ���� ��̾��� ����";
                finalfun = 1;
            }
            else if (fun <= 40)
            {
                FinalFun = "������ ���� ���°� �� ��մ�.";
                finalfun = 2;
            }
            else if (fun <= 50)
            {
                FinalFun = "�����ϴٰ� ��黷�ߴ�.";
                finalfun = 3;
            }
            else if (fun <= 60)
            {
                FinalFun = "�׷����� ����������?";
                finalfun = 4;
            }
            else if (fun <= 65)
            {
                FinalFun = "�� �� ������ �� ������ ����";
                finalfun = 5;
            }
            else if (fun <= 70)
            {
                FinalFun = "������� ���� �ƽ��� ����";
                finalfun = 6;
            }
            else if (fun <= 75)
            {
                FinalFun = "���� ������ �ø��� �� ����";
                finalfun = 7;
            }
            else if (fun <= 80)
            {
                FinalFun = "���Ǵ� ����";
                finalfun = 8;
            }
            else if (fun <= 90)
            {
                FinalFun = "�̷� ������ �� ���ݿ����� ��Ÿ���ǰ� ";
                finalfun = 9;
            }
            else if (fun >= 100)
            {
                FinalFun = "���� ���� 3�ð��� �� �־����ٸ� 4�ð� �� �� ������ �� ���̴�";
                finalfun = 10;
            }
            
            if (sound <= 30)
            {
                FinalSound = "��¥��Ʈ�� �η������� ����";
                finalsound = 1;
            }
            else if (sound <= 40)
            {
                FinalSound = "�Ͱ� ������..";
                finalsound = 2;
            }
            else if (sound <= 50)
            {
                FinalSound = "���ҰŸ��";
                finalsound = 3;
            }
            else if (sound <= 60)
            {
                FinalSound = "���۱ǿ� �Ȱɷȳ�?";
                finalsound = 4;
            }
            else if (sound <= 65)
            {
                FinalSound = "Į���� �ѼҸ���...?";
                finalsound = 5;
            }
            else if (sound <= 70)
            {
                FinalSound = "������ ���� �����.";
                finalsound = 6;
            }
            else if (sound <= 75)
            {
                FinalSound = "���� �߸��ص� �ǰھ�!";
                finalsound = 7;
            }
            else if (sound <= 80)
            {
                FinalSound = "���� ���Ƶ� ������ ������ ���δ�.";
                finalsound = 8;
            }
            else if (sound <= 90)
            {
                FinalSound = "������ ���� ��ƿ� �Ͱ���.";
                finalsound = 9;
            }
            else if (sound >= 100)
            {
                FinalSound = "�Ͱ� �ΰ��� ������ �� ���Ӷ���";
                finalsound = 10;
            }
            if (creativity <= 30)
            {
                FinalCreativity = "��� �󸶳� ���� ���������� ������";
                finalcreativity = 1;
            }
            else if (creativity <= 40)
            {
                FinalCreativity = "���ӿ��� ������ ������ ����.";
                finalcreativity = 2;
            }
            else if (creativity <= 50)
            {
                FinalCreativity = "�ٸ� ���Ӱ� �ٸ����� ����ü ����?";
                finalcreativity = 3;
            }
            else if (creativity <= 60)
            {
                FinalCreativity = "â�Ǽ��� ��¦ �ƽ���.";
                finalcreativity = 4;
            }
            else if (creativity <= 65)
            {
                FinalCreativity = "�����غ��� ���� ���������� ���ο���.";
                finalcreativity = 5;
            }
            else if (creativity <= 70)
            {
                FinalCreativity = "�� ������ �Ǹ��ϴ�.";
                finalcreativity = 6;
            }
            else if (creativity <= 75)
            {
                FinalCreativity = "�������� ������ ����!";
                finalcreativity = 7;
            }
            else if (creativity <= 80)
            {
                FinalCreativity = "���� �̷��� �������� ���ߴ�!";
                finalcreativity = 8;
            }
            else if (creativity <= 90)
            {
                FinalCreativity = "�����̴�...!";
                finalcreativity = 9;
            }
            else if (creativity >= 100)
            {
                FinalCreativity = "���ӿ� �뺧���� �־��ٸ� ���� �������� ��";
                finalcreativity = 10;
            }
            if (graphic <= 30)
            {
                FinalGrahpic = "�� ��ī�� �̰ͺ��� �� �׸���!";
                finalgrahpic = 1;
            }
            else if (graphic <= 40)
            {
                FinalGrahpic = "������ �ƴѰ� �ǽ� �� ����";
                finalgrahpic = 2;
            }
            else if (graphic <= 50)
            {
                FinalGrahpic = "��� ���� ���� ĳ����...";
                finalgrahpic = 3;
            }
            else if (graphic <= 60)
            {
                FinalGrahpic = "���� ����� ���� ���";
                finalgrahpic = 4;
            }
            else if (graphic <= 65)
            {
                FinalGrahpic = "ĳ���Ͱ� �ŷ��־�!";
                finalgrahpic = 5;
            }
            else if (graphic <= 70)
            {
                FinalGrahpic = "������ ������ ����� ���ȴ�.";
                finalgrahpic = 6;
            }
            else if (creativity <= 75)
            {
                FinalGrahpic = "�Ǹ��� �׷��ȵ�����";
                finalgrahpic = 7;
            }
            else if (graphic <= 80)
            {
                FinalGrahpic = "�ƴ� �̰� ���� ����� �׸��Ŷ��?";
                finalgrahpic = 8;
            }
            else if (graphic <= 90)
            {
                FinalGrahpic = "�̷� ����Ƽ�� ���� ��� ���� ����!";
                finalgrahpic = 9;
            }
            else if (graphic >= 100)
            {
                FinalGrahpic = "�׸��� ��� �����δ�!";
                finalgrahpic = 10;
            }
            PopUpSystem.instance.OpenPopUp("���� ���!", " ���� : " + PlayerPrefs.GetString("TeamName") + "�� ������ ���� ���߿Ϸ��߽��ϴ�!!\n ������ ������ �ɻ翡 �����ϴ�. \n� �ɻ����� ������ ����Ǵ� �����Դϴ�."
            ,
            () =>
            {
                Debug.Log("OKClick");
                GameEnding();
            },
            () =>
            {
                Debug.Log("OKCancel");
            });
        }

    }



    public void PuzzleGameEvent()
    {
        CheckTime = 0;
        SavePoint[2] = 1;
        PlayerPrefs.SetInt("SavePoint3", SavePoint[2]);
        grahpicGameEvent.gameObject.SetActive(false);
        SceneManager.LoadScene("JigsawPuzzle");
        

    }
    public void SoundGameEvent()
    {
        CheckTime = 0;
        SavePoint[4] = 1;
        PlayerPrefs.SetInt("SavePoint5", SavePoint[4]);
        grahpicGameEvent.gameObject.SetActive(false);
        SceneManager.LoadScene("SoundGame");
        

    }
    public void ProgramingGameEvent()
    {
        CheckTime = 0;
        SavePoint[6] = 1;
        PlayerPrefs.SetInt("SavePoint7", SavePoint[6]);
        grahpicGameEvent.gameObject.SetActive(false);
        SceneManager.LoadScene("CatchBug");


    }
    public void GameEnding()
    {
        float finalscore = finalfun + finalgrahpic + finalcreativity + finalsound;
        PopUpSystem.instance.OpenPopUp("���� ��", PlayerPrefs.GetString("TeamName") + "\n" +
                                        FinalFun + "   " + finalfun  +
                                        FinalCreativity + "   " + finalcreativity +
                                        FinalSound   + "   " + finalsound +
                                        FinalGrahpic + "   " + finalgrahpic +
                                        "\n �������� :  " + (int)finalscore + "��"
           ,
           () =>
           {
               Debug.Log("OKClick");
               if(finalscore <= 5)
               {
                   PlayerPrefs.SetInt("Point", PlayerPrefs.GetInt("Point") + 100);
               }
               else if (finalscore <= 10)
               {
                   PlayerPrefs.SetInt("Point", PlayerPrefs.GetInt("Point") + 300);
               }
               else if (finalscore <= 15)
               {
                   PlayerPrefs.SetInt("Point", PlayerPrefs.GetInt("Point") + 400);
               }
               else if (finalscore <= 20)
               {
                   PlayerPrefs.SetInt("Point", PlayerPrefs.GetInt("Point") + 500);
               }
               else if (finalscore <= 25)
               {
                   PlayerPrefs.SetInt("Point", PlayerPrefs.GetInt("Point") + 700);
               }
               else if (finalscore <= 30)
               {
                   PlayerPrefs.SetInt("Point", PlayerPrefs.GetInt("Point") + 800);
               }
               else if (finalscore <= 35)
               {
                   PlayerPrefs.SetInt("Point", PlayerPrefs.GetInt("Point") + 900);
               }
               else if (finalscore <= 39)
               {
                   PlayerPrefs.SetInt("Point", PlayerPrefs.GetInt("Point") + 1200);
               }
               else if (finalscore >= 40)
               {
                   PlayerPrefs.SetInt("Point", PlayerPrefs.GetInt("Point") + 3000);
               }
               SceneManager.LoadScene("Title");
           },
           () =>
           {
               Debug.Log("OKCancel");
           });
    }
}

