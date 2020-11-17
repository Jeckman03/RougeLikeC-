using System;
using System.Collections.Generic;

namespace Models
{

	public class GameLogic
	{
		

		// Player attack logic method
		public static (bool, int) PlayerAttack(CharacterModel character, EnemyModel enemy)
		{
			
			// players attack - enemy health 
			int enemyHealth = enemy.Health - character.AttackDmg;

			bool isDead = IsDead(enemyHealth);

			return (isDead, enemyHealth);

		}

		// Enemy attack logic method
		public static int EnemyAttack(EnemyModel enemy, CharacterModel character)
		{
			// Enemy attack damage - player health
			int output = (character.Defense - enemy.AttackDmg) - character.Health;

			// Return player health
			return output;
		}

		// Check to see if enemy is dead method
		public static bool IsDead(int health)
		{
			// Create is dead bool
			bool isDead = false;

			// If enemy Health <= 0
			if (health < 1)
			{
				isDead = true;

				return isDead;
			}
			else
			{
				return isDead;
			}
		}

		
	}
}