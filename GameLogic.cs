using System;
using System.Collections.Generic;

namespace Models
{

	public class GameLogic
	{
		

		// Player attack logic method
		public static int PlayerAttack(CharacterModel character, EnemyModel enemy)
		{
			// players attack - enemy health 
			int output = character.AttackDmg - enemy.Health;

			// Return enemy health
			return output;

		}

		// Enemy attack logic method
		public static void EnemyAttack()
		{
			// Enemy attack damage - player health

			// Return player health
		}

		// Check to see if enemy is dead method
		public static bool IsEnemyDead(int enemyHealth)
		{
			// Create is dead bool
			bool isDead = false;

			// If enemy Health <= 0
			if (enemyHealth <= 0)
			{
				isDead = true;

				return isDead;
			}
			else
			{
				return isDead;
			}
		}

		// Check to see if enemy is dead method
		public static void IsPlayerDead()
		{
			// Create is dead bool

			// If enemy Health <= 0

				// Return is dead true

			// Else return is dead false	
		}
	}
}