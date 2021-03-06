﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace alisanCapstone
{
	public class Player_Health : MonoBehaviour {

        private GameManager_Master gameManagerMaster;
        private Player_Master playerMaster;
        public int playerHealth;
        public Text healthText;
		public Collider bros;
		public GameObject deneme;
		void OnEnable()
		{
            SetInitialReferences();
            SetUI();
            playerMaster.EventPlayerHealthDeduction += DeductHealth;
            playerMaster.EventPlayerHealthIncrease += IncreaseHealth;
        }

		void OnDisable()
		{
            playerMaster.EventPlayerHealthDeduction -= DeductHealth;
            playerMaster.EventPlayerHealthIncrease -= IncreaseHealth;
        }

		void Start () 
		{
            //StartCoroutine(TestHealthDeduction());
		}

		void SetInitialReferences()
		{
            gameManagerMaster = GameObject.Find("GameManager").GetComponent<GameManager_Master>();
            playerMaster = GetComponent<Player_Master>();
		}

        IEnumerator TestHealthDeduction()
        {
            yield return new WaitForSeconds(2);
            //DeductHealth(100);
            playerMaster.CallEventPlayerHealthDeduction(50);

        }

        void DeductHealth(int healthChange)
        {
            playerHealth -= healthChange;

            if (playerHealth <= 0)
            {
                playerHealth = 100;
				deneme.transform.position = bros.GetComponent<PlayerPos> ().checkPos;
              //  gameManagerMaster.CallEventGameOver();
            }

            SetUI();
        }

        void IncreaseHealth(int healthChange)
        {
            playerHealth += healthChange;

            if (playerHealth > 100)
            {
                playerHealth = 100;
            }

            SetUI();
        }

        void SetUI()
        {
            if (healthText != null)
            {
                healthText.text = playerHealth.ToString();
            }
        }


	}
}


