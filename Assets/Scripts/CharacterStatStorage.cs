using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatStorage : MonoBehaviour
{

    //[System.NonSerialized]
    public int[] health, 
                stamina, 
                whamitude, 
                popularity, 
                schoolSpirit,
                creepiness,
                skinThickness,
                independence,
                empathy = new int[9];

 void awake(){
    /*health[0]= 1; stamina[0] = 1; whamitude[0] = 1;
    health[1]= 2; stamina[1] = 2; whamitude[1] = 2;
    health[2]= 3; stamina[2] = 3; whamitude[2] = 3;
    health[3]= 4; stamina[3] = 4; whamitude[3] = 4;
    health[4]= 5; stamina[4] = 5; whamitude[4] = 5;
    health[5]= 6; stamina[5] = 6; whamitude[5] = 6;
    health[6]= 7; stamina[6] = 7; whamitude[6] = 7;
    health[7]= 8; stamina[7] = 8; whamitude[7] = 8;
    health[8]= 9; stamina[8] = 9; whamitude[8] = 9;

    popularity[0] = 1; schoolSpirit[0] = 1;
    popularity[1] = 2; schoolSpirit[1] = 2;
    popularity[2] = 3; schoolSpirit[2] = 3;
    popularity[3] = 4; schoolSpirit[3] = 4;
    popularity[4] = 5; schoolSpirit[4] = 5;
    popularity[5] = 6; schoolSpirit[5] = 6;
    popularity[6] = 7; schoolSpirit[6] = 7;
    popularity[7] = 8; schoolSpirit[7] = 8;
    popularity[8] = 9; schoolSpirit[8] = 9;

    creepiness[0] = 1; skinThickness[0] = 1;
    creepiness[1] = 2; skinThickness[1] = 2;
    creepiness[2] = 3; skinThickness[2] = 3;
    creepiness[3] = 4; skinThickness[3] = 4;
    creepiness[4] = 5; skinThickness[4] = 5;
    creepiness[5] = 6; skinThickness[5] = 6;
    creepiness[6] = 7; skinThickness[6] = 7;
    creepiness[7] = 8; skinThickness[7] = 8;
    creepiness[8] = 9; skinThickness[8] = 9;

    independence[0] = 1; empathy[0] = 1;
    independence[1] = 2; empathy[1] = 2;
    independence[2] = 3; empathy[2] = 3;
    independence[3] = 4; empathy[3] = 4;
    independence[4] = 5; empathy[4] = 5;
    independence[5] = 6; empathy[5] = 6;
    independence[6] = 7; empathy[6] = 7;
    independence[7] = 8; empathy[7] = 8;
    independence[8] = 9; empathy[8] = 9;*/
    
 }
 void Update(){
    /*health[0]= 1; stamina[0] = 1; whamitude[0] = 1;
    health[1]= 2; stamina[1] = 2; whamitude[1] = 2;
    health[2]= 3; stamina[2] = 3; whamitude[2] = 3;
    health[3]= 4; stamina[3] = 4; whamitude[3] = 4;
    health[4]= 5; stamina[4] = 5; whamitude[4] = 5;
    health[5]= 6; stamina[5] = 6; whamitude[5] = 6;
    health[6]= 7; stamina[6] = 7; whamitude[6] = 7;
    health[7]= 8; stamina[7] = 8; whamitude[7] = 8;
    health[8]= 9; stamina[8] = 9; whamitude[8] = 9;

    popularity[0] = 1; schoolSpirit[0] = 1;
    popularity[1] = 2; schoolSpirit[1] = 2;
    popularity[2] = 3; schoolSpirit[2] = 3;
    popularity[3] = 4; schoolSpirit[3] = 4;
    popularity[4] = 5; schoolSpirit[4] = 5;
    popularity[5] = 6; schoolSpirit[5] = 6;
    popularity[6] = 7; schoolSpirit[6] = 7;
    popularity[7] = 8; schoolSpirit[7] = 8;
    popularity[8] = 9; schoolSpirit[8] = 9;

    creepiness[0] = 1; skinThickness[0] = 1;
    creepiness[1] = 2; skinThickness[1] = 2;
    creepiness[2] = 3; skinThickness[2] = 3;
    creepiness[3] = 4; skinThickness[3] = 4;
    creepiness[4] = 5; skinThickness[4] = 5;
    creepiness[5] = 6; skinThickness[5] = 6;
    creepiness[6] = 7; skinThickness[6] = 7;
    creepiness[7] = 8; skinThickness[7] = 8;
    creepiness[8] = 9; skinThickness[8] = 9;

    independence[0] = 1; empathy[0] = 1;
    independence[1] = 2; empathy[1] = 2;
    independence[2] = 3; empathy[2] = 3;
    independence[3] = 4; empathy[3] = 4;
    independence[4] = 5; empathy[4] = 5;
    independence[5] = 6; empathy[5] = 6;
    independence[6] = 7; empathy[6] = 7;
    independence[7] = 8; empathy[7] = 8;
    independence[8] = 9; empathy[8] = 9;*/
    //Debug.Log(health[0]);
 }
}
