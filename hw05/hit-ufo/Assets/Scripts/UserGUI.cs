using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{
    private IUserAction action;
    public int chance = 6;                   //机会次数
    //每个GUI的style
    GUIStyle chance_style = new GUIStyle();
    GUIStyle score_style = new GUIStyle();
    GUIStyle text_style = new GUIStyle();
    GUIStyle over_style = new GUIStyle();
    GUIStyle time_style = new GUIStyle();
    GUIStyle lost_chance_style = new GUIStyle();
    private int high_score = 0;            //最高分
    private bool game_start = false;       //游戏开始

    void Start ()
    {
        action = SSDirector.GetInstance().CurrentScenceController as IUserAction;
    }
	
	void OnGUI ()
    {
        chance_style.normal.textColor = new Color(1, 0, 0);
        chance_style.fontSize = 30;
        text_style.normal.textColor = new Color(0, 0, 0, 1);
        text_style.fontSize = 30;
        score_style.normal.textColor = new Color(1, 0, 0);
        score_style.fontSize = 30;
        over_style.normal.textColor = new Color(1, 0, 0);
        over_style.fontSize = 50;
        lost_chance_style.normal.textColor = new Color(1, 1, 1);
        lost_chance_style.fontSize = 30;
        time_style.normal.textColor = new Color(1, 0, 0);
        time_style.fontSize = 100;

        if (game_start)
        {
            //用户射击
            if (Input.GetButtonDown("Fire1"))
            {
                Vector3 pos = Input.mousePosition;
                action.Hit(pos);
            }

            GUI.Label(new Rect(10, 5, 200, 50), "Score:", text_style);
            GUI.Label(new Rect(100, 5, 200, 50), action.GetScore().ToString(), score_style);

            GUI.Label(new Rect(Screen.width - 320, 5, 50, 50), "Chance:", text_style);
            //显示当前血量
            for (int i = 0; i < chance; i++)
            {
                GUI.Label(new Rect(Screen.width - 200 + 30 * i, 5, 50, 50), "✰", chance_style);
            }
            for (int i = chance; i < 6; i++)
            {
                GUI.Label(new Rect(Screen.width - 200 + 30 * i, 5, 50, 50), "✰", lost_chance_style);
            }

            if (action.GetCoolTimes() >= 0 && action.GetRound() == 1) {
                        //    GUI.Label(new Rect(Screen.width / 2 - 100, 60, 200, 50), "", lost_chance_style);
                    if (action.GetCoolTimes() == 0) {
                        GUI.Label(new Rect(Screen.width / 2 - 200, 150, 200, 50), "ROUND 1", time_style);
                    }else
                        GUI.Label(new Rect(Screen.width / 2 - 30, 150, 200, 50), action.GetCoolTimes().ToString(), time_style);


            }
            if (action.GetRound() == 2 && action.GetCoolTimes2() > 0) {
                    GUI.Label(new Rect(Screen.width / 2 - 200, 150, 200, 50), "ROUND 2", time_style);

            }
            if (action.GetRound() == 3 && action.GetCoolTimes3() > 0) {
                    GUI.Label(new Rect(Screen.width / 2 - 200, 150, 200, 50), "ROUND 3", time_style);

            }


            //游戏结束
            if (chance == 0)
            {
                high_score = high_score > action.GetScore() ? high_score : action.GetScore();
                GUI.Label(new Rect(Screen.width / 2 - 100, 110, 100, 100), "GameOver", over_style);
                GUI.Label(new Rect(Screen.width / 2 - 80, 200, 50, 50), "Score:", text_style);
                GUI.Label(new Rect(Screen.width / 2 + 50, 200, 50, 50), high_score.ToString(), text_style);

                if (GUI.Button(new Rect(Screen.width / 2 - 60, 300, 100, 50), "Restart"))
                {
                    chance = 6;
                    action.ReStart();
                    return;
                }
                action.GameOver();
            }
        }
        else
        {
            GUI.Label(new Rect(Screen.width / 2 - 110, 110, 100, 100), "Hit UFO!", over_style);
        //    GUI.Label(new Rect(Screen.width / 2 - 150, Screen.width / 2 - 220, 400, 100), "大量UFO出现，点击它们，即可消灭，快来加入战斗吧", text_style);
            if (GUI.Button(new Rect(Screen.width / 2 - 60, 200, 100, 50), "Let's go!"))
            {
                game_start = true;
                
                action.BeginGame();
            }
        }
    }
    public void ReduceBlood()
    {
        if(chance > 0)
            chance--;
    }
}
