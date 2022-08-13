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

    public float fun; // 재미 스탯
    public float creativity; // 창의 스탯
    public float graphic; // 그래픽 스탯
    public float sound; // 사운드 스탯
    public float proGress; // 진척도
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
        progressText.text = "진척도 : " + (int)proGress + "%";

        proGress += Time.deltaTime / 3;

        PlayerPrefs.SetInt("ProGress", (int)proGress);

        temaText.text = "장르 : " + mainTema + " / " + subTema + "\n";
        GameStatText.text =  "\n       :  " + (int)fun + " 점 " + "     : " + (int)creativity + " 점 \n\n " + "     :  " + (int)graphic + " 점 " + "     : " + (int)sound + " 점 ";

        CharStatText1.text = "실력 : " + (int)graficCharacter.skill + "성실도 : " + (int)graficCharacter.senserity + "피로도 : " + (int)graficCharacter.fatigue;
        CharStatText2.text = "실력 : " + (int)programingCharacter.skill + "성실도 : " + (int)programingCharacter.senserity + "피로도 : " + (int)programingCharacter.fatigue;
        CharStatText3.text = "실력 : " + (int)designCharacter.skill + "성실도 : " + (int)designCharacter.senserity + "피로도 : " + (int)designCharacter.fatigue;
        CharStatText4.text = "실력 : " + (int)soundCharacter.skill + "성실도 : " + (int)soundCharacter.senserity + "피로도 : " + (int)soundCharacter.fatigue;


        if(proGress >= 0 && SavePoint[0] == 0)
        {

            PopUpSystem.instance.OpenPopUp("기획서 작성", " 팀명 : " + PlayerPrefs.GetString("TeamName") + "의 새로운 게임이 기획서 작성 단계에 들어왔습니다. \n기획서작성은 게임의 토대가 되는만큼 최대한 재미있고 창의성있게 작성해보도록 합시다."
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
            PopUpSystem.instance.OpenPopUp("게임 제작 단계", " 팀명 : " + PlayerPrefs.GetString("TeamName") + "의 게임이 제작 단계에 들어갔습니다. \n게임의 전반적인 부분을 담당하는 부분입니다.\n집중해서 게임을 제작해보도록 합시다!"
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
                PopUpSystem.instance.OpenPopUp("게임 버그 발생!!", "심각한 버그가 발생했지만 깜박 잠이 들어버렸습니다..... \n\n모든 게임 스탯이 20 만큼 하락했습니다...."
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
            PopUpSystem.instance.OpenPopUp("게임 테스트 단계", " 팀명 : " + PlayerPrefs.GetString("TeamName") + "의 게임이 테스트 단계에 들어갔습니다. \n혹시나 모를 버그나 오류를 미리 찾아내어 \n게임의 완성도를 높여봅시다!"
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
                PopUpSystem.instance.OpenPopUp("게임 버그 발생!!", "BGM 싱크 오류...\n효과음 싱크 오류... \n오류.....\n오늘도 집에 가기 글렀습니다.. \n\n모든 게임 스탯이 10 만큼 하락했습니다.\n모든 캐릭터의 피로도가 50만큼 증가했습니다...."
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
            PopUpSystem.instance.OpenPopUp("게임 디버깅 단계", " 팀명 : " + PlayerPrefs.GetString("TeamName") + "의 게임이 디버깅 단계에 들어갔습니다. \n없애고 또 없애라! 버그를 최대한 없애고 유저들에게 멋진 게임을 보여줍시다."
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
                PopUpSystem.instance.OpenPopUp("크나큰 실패", "디버깅실패로 인한 많은 버그들로 인해 \n유저들에게 많은 비난을 받을 것 같습니다.\n막대한 손해를 입습니다!\n\n모든 게임 스탯이 15 만큼 하락했습니다.\n포인트가 500 만큼 감소했습니다...."
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
                FinalFun = "세상에서 제일 재미없는 게임";
                finalfun = 1;
            }
            else if (fun <= 40)
            {
                FinalFun = "가만히 숨을 쉬는게 더 재밌다.";
                finalfun = 2;
            }
            else if (fun <= 50)
            {
                FinalFun = "게임하다가 잠들뻔했다.";
                finalfun = 3;
            }
            else if (fun <= 60)
            {
                FinalFun = "그럭저럭 괜찮을지도?";
                finalfun = 4;
            }
            else if (fun <= 65)
            {
                FinalFun = "한 번 정도는 해 볼만한 게임";
                finalfun = 5;
            }
            else if (fun <= 70)
            {
                FinalFun = "재밌지만 뭔가 아쉬운 게임";
                finalfun = 6;
            }
            else if (fun <= 75)
            {
                FinalFun = "나름 수익을 올릴만 한 게임";
                finalfun = 7;
            }
            else if (fun <= 80)
            {
                FinalFun = "기대되는 게임";
                finalfun = 8;
            }
            else if (fun <= 90)
            {
                FinalFun = "이런 게임이 왜 지금에서야 나타난건가 ";
                finalfun = 9;
            }
            else if (fun >= 100)
            {
                FinalFun = "내게 매일 3시간씩 더 주어진다면 4시간 더 이 게임을 할 것이다";
                finalfun = 10;
            }
            
            if (sound <= 30)
            {
                FinalSound = "모짜르트가 부러워지는 게임";
                finalsound = 1;
            }
            else if (sound <= 40)
            {
                FinalSound = "귀가 아프다..";
                finalsound = 2;
            }
            else if (sound <= 50)
            {
                FinalSound = "음소거모드";
                finalsound = 3;
            }
            else if (sound <= 60)
            {
                FinalSound = "저작권에 안걸렸냐?";
                finalsound = 4;
            }
            else if (sound <= 65)
            {
                FinalSound = "칼에서 총소리가...?";
                finalsound = 5;
            }
            else if (sound <= 70)
            {
                FinalSound = "구색은 나름 갖췄다.";
                finalsound = 6;
            }
            else if (sound <= 75)
            {
                FinalSound = "음원 발매해도 되겠어!";
                finalsound = 7;
            }
            else if (sound <= 80)
            {
                FinalSound = "눈을 감아도 생생히 게임이 보인다.";
                finalsound = 8;
            }
            else if (sound <= 90)
            {
                FinalSound = "오늘을 위해 살아온 것같다.";
                finalsound = 9;
            }
            else if (sound >= 100)
            {
                FinalSound = "귀가 두개인 이유는 이 게임때문";
                finalsound = 10;
            }
            if (creativity <= 30)
            {
                FinalCreativity = "어디서 얼마나 베낀 게임인지도 모를정도";
                finalcreativity = 1;
            }
            else if (creativity <= 40)
            {
                FinalCreativity = "게임에서 쓰레기 냄새가 난다.";
                finalcreativity = 2;
            }
            else if (creativity <= 50)
            {
                FinalCreativity = "다른 게임과 다를점이 도대체 무엇?";
                finalcreativity = 3;
            }
            else if (creativity <= 60)
            {
                FinalCreativity = "창의성이 살짝 아쉽다.";
                finalcreativity = 4;
            }
            else if (creativity <= 65)
            {
                FinalCreativity = "경험해보지 못한 게임이지만 별로였다.";
                finalcreativity = 5;
            }
            else if (creativity <= 70)
            {
                FinalCreativity = "이 정도면 훌륭하다.";
                finalcreativity = 6;
            }
            else if (creativity <= 75)
            {
                FinalCreativity = "오랜만에 참신한 게임!";
                finalcreativity = 7;
            }
            else if (creativity <= 80)
            {
                FinalCreativity = "나도 이런건 생각하지 못했다!";
                finalcreativity = 8;
            }
            else if (creativity <= 90)
            {
                FinalCreativity = "갓겜이다...!";
                finalcreativity = 9;
            }
            else if (creativity >= 100)
            {
                FinalCreativity = "게임에 노벨상이 있었다면 필히 수상했을 것";
                finalcreativity = 10;
            }
            if (graphic <= 30)
            {
                FinalGrahpic = "내 조카도 이것보단 잘 그린다!";
                finalgrahpic = 1;
            }
            else if (graphic <= 40)
            {
                FinalGrahpic = "낙서가 아닌가 의심 될 정도";
                finalgrahpic = 2;
            }
            else if (graphic <= 50)
            {
                FinalGrahpic = "어디서 많이 보던 캐릭터...";
                finalgrahpic = 3;
            }
            else if (graphic <= 60)
            {
                FinalGrahpic = "나름 노력이 보인 배경";
                finalgrahpic = 4;
            }
            else if (graphic <= 65)
            {
                FinalGrahpic = "캐릭터가 매력있어!";
                finalgrahpic = 5;
            }
            else if (graphic <= 70)
            {
                FinalGrahpic = "앞으로 발전할 모습이 기대된다.";
                finalgrahpic = 6;
            }
            else if (creativity <= 75)
            {
                FinalGrahpic = "훌륭한 그래픽디자인";
                finalgrahpic = 7;
            }
            else if (graphic <= 80)
            {
                FinalGrahpic = "아니 이게 정말 사람이 그린거라고?";
                finalgrahpic = 8;
            }
            else if (graphic <= 90)
            {
                FinalGrahpic = "이런 퀄리티면 당장 사고 싶을 정도!";
                finalgrahpic = 9;
            }
            else if (graphic >= 100)
            {
                FinalGrahpic = "그림이 살아 움직인다!";
                finalgrahpic = 10;
            }
            PopUpSystem.instance.OpenPopUp("게임 출시!", " 팀명 : " + PlayerPrefs.GetString("TeamName") + "의 게임이 드디어 개발완료했습니다!!\n 개발한 게임이 심사에 들어갔습니다. \n어떤 심사평이 나올지 긴장되는 순간입니다."
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
        PopUpSystem.instance.OpenPopUp("최종 평가", PlayerPrefs.GetString("TeamName") + "\n" +
                                        FinalFun + "   " + finalfun  +
                                        FinalCreativity + "   " + finalcreativity +
                                        FinalSound   + "   " + finalsound +
                                        FinalGrahpic + "   " + finalgrahpic +
                                        "\n 최종점수 :  " + (int)finalscore + "점"
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

