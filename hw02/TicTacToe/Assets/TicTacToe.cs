using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToe : MonoBehaviour {

    private int turn = 1;
    private int empty = 9;
    private int[,] matrix = new int[3, 3];

    // Start is called before the first frame update
    void Start () {
        Reset ();
    }

    void Reset() {
        turn = 1;
        empty = 9;
        for (int i = 0; i < 3; ++i) {
            for (int j = 0; j < 3; ++j) {
                matrix[i,j] = 0;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnGUI() {
        GUI.skin.button.fontSize = 20;
        GUI.skin.label.fontSize = 30;
        if(GUI.Button(new Rect(450,400,200,80), "Reset")) {
            Reset();
        }
 
        int result = check();
        if(result == 1) {
            GUI.Label(new Rect(500, 20, 100, 50), "O wins");
        } else if (result == 2) {
            GUI.Label(new Rect(500, 20, 100, 50), "X wins");
        } else if (result == 3) {
            GUI.Label(new Rect(470, 20, 200, 50), "no one wins");
        }
 
        for(int i = 0; i < 3; ++i) {
            for(int j = 0; j < 3; ++j) {
                if (matrix[i, j] == 1) 
                    GUI.Button(new Rect(i * 100 + 400, j * 100 + 80, 100, 100), "O");
                if (matrix[i, j] == 2) 
                    GUI.Button(new Rect(i * 100 + 400, j * 100 + 80, 100, 100), "X");
                if(GUI.Button(new Rect(i * 100 + 400, j * 100 + 80, 100, 100), "")) {
                    if(result == 0) {
                        if (turn == 1)
                            matrix[i, j] = 1;
                        if (turn == 2)
                            matrix[i, j] = 2;
                        --empty;
                        if(empty%2 == 1) {
                            turn = 1;
                        } else {
                            turn = 2;
                        }
                    }
                }
            }
        }

    }

    // Decide if the game is over
    int check() {
        // The transverse
        for (int i = 0; i < 3; ++i) {
            if (matrix[i,0] != 0 && matrix[i,0] == matrix[i,1] && matrix[i,1] == matrix[i,2]) {
                return matrix[i,0];
            }
        }
        // The longitudinal
        for (int j = 0; j < 3; ++j) {
            if (matrix[0,j] != 0 && matrix[0,j] == matrix[1,j] && matrix[1,j] == matrix[2,j]) {
                return matrix[0,j];
            }
        }
        // The oblique
        if (matrix[1,1] != 0 &&
            matrix[0,0] == matrix[1,1] && matrix[1,1] == matrix[2,2] ||
            matrix[0,2] == matrix[1,1] && matrix[1,1] == matrix[2,0]) {
            return matrix[1,1];
        }
        if (empty == 0) {
            return 3;
        } else {
            return 0;
        }
    }
}
