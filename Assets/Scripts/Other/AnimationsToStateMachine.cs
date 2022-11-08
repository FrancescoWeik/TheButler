using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsToStateMachine : MonoBehaviour
{
    public PlayerShootPizzaState shootPizza;

    private void Start(){
        Player player = GetComponentInParent<Player>();
        shootPizza = player.shootState;
    }
    private void ShootPizza(){
        shootPizza.ShootPizza();
    }
    
    private void FinishAttack(){
        shootPizza.AnimationFinishTrigger();
    }
}
