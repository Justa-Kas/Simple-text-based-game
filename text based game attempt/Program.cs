using System;

namespace text_based_game_attempt
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to your new home. Build new weapons, new armor and fight for your life as you create something new for yourself. What is your name?");
            string name = Console.ReadLine();
            Console.WriteLine("Welcome, " + name + " If you need a list of commands, type \"help\", otherwise, what do you want to do?");

            playerAction();
            Console.WriteLine("You have died. GG.");
        }
        public static void playerAction()
        {
            double lvl = 1.0;
            int health = 5 + (int)lvl * 5;
            int defense = 0;
            string location = "DF";
            string armor = "None";
            string weapon = "Fists";
            int tooMuchFood = 0;
            int maxHealth = (int)(lvl * 6.5 + 5);
            Random rand = new Random();
            int enemyGen;
            int rocks = 0;
            int sticks = 0;
            int vine = 0;
            int weapGrade = 2;
            int strength = (int)lvl+weapGrade;
            do
            {
                string action = Console.ReadLine();
                if (action.ToLower() == "help")
                {
                    Console.WriteLine("Commands are as followed:\nF to look for a fight \nE to explore \nFF to find food\nA to craft armor \nW to craft weapon \n C to check stats \nEnd game.");

                }
                else if (action.ToLower() == ("c"))
                {
                    Console.WriteLine("Level: " + (int)lvl + ". Health: " + health + ". Weapon: " + weapon + ". Armor: " + armor + ". Location:" + location + ". Strength: " + strength + ".");
                }
                else if (action.ToLower() == ("ff"))
                {
                    if (tooMuchFood == 3)
                    {
                        Console.WriteLine("You've cleared out the place. Go fight, explore,or craft something before you can eat again.");
                    }
                    if (health >= maxHealth)
                    {
                        health = maxHealth;
                        Console.WriteLine("Eating would only slow you down, you're at max health. Health is " + health);
                    }
                    enemyGen = rand.Next(0, 10);
                    if (enemyGen <= 4)
                    {
                        Console.WriteLine("You found some berries! Health restored by 5 points.");
                        health += 6;
                        tooMuchFood++;
                    }
                    else if (enemyGen == 5)
                    {
                        Console.WriteLine("You found some leftovers from a recent hunt and steal as much as you can. Health increased by 20 points.");
                        health += 20;
                        tooMuchFood++;
                    }
                    else if (enemyGen <= 8)
                    {
                        Console.WriteLine("You found a couple crickets. They're supposed to be good for protein, right? Health restored by 3 points.");
                        health += 3;
                        tooMuchFood++;
                    }
                    else
                    {
                        Console.WriteLine("You failed to find any food. You didn't really need it, did you?");
                        tooMuchFood++;
                    }
                    if (health >= maxHealth)
                    {
                        health = maxHealth;
                        Console.WriteLine("You've maxed out your health. You're ready to take on just about any challenge! You have " + health + " health.");

                    }
                }
                else if (action.ToLower() == ("f"))
                {
                    int enHealth;
                    int enDamage;
                    string enName;
                    double lvlMult;
                    int setEnemy = setEn(location);
                    if (setEnemy == 1)
                    {
                        enHealth = 9;
                        enDamage = 2;
                        enName = "Big Rat";
                        lvlMult = 0.25 - (lvl * .01);

                    }
                    else if (setEnemy == 2)
                    {
                        enHealth = 12;
                        enDamage = 5;
                        enName = "Fur Ball";
                        lvlMult = 0.45 - lvl * .01;
                    }
                    else if (setEnemy == 3)
                    {
                        enHealth = 25;
                        enDamage = 13;
                        enName = "Small Fox";
                        lvlMult = .70 - lvl * .01;
                    }
                    else if (setEnemy == 4)
                    {
                        enHealth = 20;
                        enDamage = 38;
                        enName = "snake";
                        lvlMult = 0.85 - lvl * .01;
                    }
                    else if (setEnemy == 5)
                    {
                        enHealth = 57;
                        enDamage = 29;
                        enName = "Lone Coyote";
                        lvlMult = 1.5 - lvl * .01;
                    }
                    else if (setEnemy == 6)
                    {
                        enHealth = 87;
                        enDamage = 69;
                        enName = "wild boar";
                        lvlMult = 2 - lvl * .01;
                    }
                    else if (setEnemy == 7)
                    {
                        enHealth = 115;
                        enDamage = 70;
                        enName = "Shadowy Figure";
                        lvlMult = 4 - lvl * .01;
                    }
                    else
                    {
                        enHealth = 200;
                        enDamage = 125;
                        enName = "Shadowy Set";
                        lvlMult = 5 - lvl * .01;
                    }

                    Console.WriteLine("You've stumbled across a " + enName + ". You can either fight it by typing \"a\" or try to flee by typing \"flee\". If you fail, it will attack you. You have " + health + " health.");
                    bool search = true;
                    while (search == (true))
                    {
                        string decision = Console.ReadLine();
                        if (decision == ("a"))
                        {
                            enHealth -= strength;
                            health -= enDamage-defense;
                            if (enHealth <= 0)
                            {
                                Console.WriteLine("You have killed the " + enName + " and gained xp!");
                                int storelvl = (int)lvl;
                                lvl += lvlMult;
                                if ((int)lvl > storelvl)
                                {
                                    health = 5 + (int)lvl * 5;
                                    strength = (int)lvl + weapGrade;
                                }
                                search = false;
                                tooMuchFood--;

                            }
                            else if (health < 1)
                            {
                                Console.WriteLine("You've been killed by the " + enName + ". Better luck next time.");
                                search = false;
                            }
                            else
                            {
                                Console.WriteLine("You attacked the " + enName + " for " + strength + " damage. The " + enName + " has " + enHealth + " health and attacked you for " + enDamage + " damage. You have " + health + " health");
                            }
                        }


                        if (decision == ("flee"))
                        {
                            enemyGen = rand.Next(0, 10);
                            if (enemyGen <= 8)
                            {
                                Console.WriteLine("Got away safely"); search = false;
                                tooMuchFood--;
                            }
                            else
                            {
                                Console.WriteLine("You failed to get away. The " + enName + " flailed on you you for " + enDamage + " You have " + (health - enDamage) + " health");
                            }
                        }



                    }
                }
                else if (action.ToLower() == ("w"))
                {
                    bool keepItG = true;
                    string nextWeapon = "Pointy stick";
                    int reqRock = 1;
                    int reqStick = 5;
                    int reqVine = 0;
                    do { 
                    if (weapon == "Pointy stick") { nextWeapon = "Solid axe"; reqVine = 14; reqStick = 13; reqRock = 12; }
                    else if (weapon == "Solid axe") { nextWeapon = "Crude sword"; reqVine = 24; reqStick = 19; reqRock = 28; }
                    else if (weapon == "Crude sword") { nextWeapon = "Refined stone sword"; reqVine = 30; reqStick = 30; reqRock = 45; }
                    else if (weapon =="Refined stone sword") { Console.WriteLine("You already have the best weapon"); }
                    Console.WriteLine("You currently have " + weapon + " equipped. You currently have " + rocks + " rocks, " + vine + " vine, and " + sticks + " sticks. To make the " + nextWeapon + " you need " + reqStick + " sticks, " + reqRock + " rocks, and " + reqVine + " vines. To create this weapon, type create, otherwise, type cancel.");
                    
                    
                        {
                            string playerChoice = Console.ReadLine();
                            if (playerChoice.ToLower() == "create")
                            {
                                if ((sticks >= reqStick) && (rocks >= reqRock) && (vine >= reqVine))
                                {
                                    Console.WriteLine("Congrats, you were able to make the new weapon. Damage has been increased so get back to killing.");
                                    weapon = nextWeapon;
                                    if (weapon == "Pointy stick")
                                    {
                                        weapGrade += 5;
                                        strength = (int)lvl + weapGrade;
                                        keepItG = false;

                                    }
                                    else if (weapon == "Solid axe")
                                    {
                                        weapGrade += 10;
                                        strength = (int)lvl + weapGrade;
                                        keepItG = false;
                                    }
                                    else if (weapon == "Crude sword")
                                    {
                                        weapGrade = (int)(1.5 * lvl);
                                        strength = (int)lvl + weapGrade;
                                        keepItG = false;
                                    }
                                    else if (weapon == "Refined stone sword")
                                    {
                                        weapGrade = (2 * (int)lvl);
                                        strength = (int)lvl + weapGrade;
                                        keepItG = false;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You don't have enough materials to build this weapon. Explore to get more materials.");
                                    keepItG = false;
                                }
                            }
                            else
                            {
                                keepItG = false;
                                Console.WriteLine("Choose another task.");
                            }

                        }
                    } while (keepItG == true);


                }
                else if (action.ToLower() == ("a"))
                {
                    bool keepItG = true;
                    string nextArm = "Viney chainmail";
                    int reqRock = 0;
                    int reqStick = 2;
                    int reqVine = 12;
                    if (armor == "Viney chainmail") { nextArm = "Stick guard"; reqVine = 18; reqStick = 21; reqRock = 2; }
                    else if (armor == "Stick guard") { nextArm = "Rock Steady" ; reqVine = 24; reqStick = 19; reqRock = 28; }
                    else if (armor == "Rock Steady") { nextArm = "Heavy stone armor"; reqVine = 50; reqStick = 40; reqRock = 60; }
                    else if(armor=="Heavy stone armor"){ Console.WriteLine("You already have the best armor."); }
                    Console.WriteLine("You currently have " + armor + " equipped. You currently have " + rocks + " rocks, " + vine + " vine, and " + sticks + " sticks. To make the " + nextArm + " you need " + reqStick + " sticks, " + reqRock + " rocks, and " + reqVine + " vines. To create this weapon, type create, otherwise, type cancel.");
                    do
                    {
                        {
                            string playerChoice = Console.ReadLine();
                            if (playerChoice.ToLower() == "create")
                            {
                                if ((sticks >= reqStick) && (rocks >= reqRock) && (vine >= reqVine))
                                {
                                    Console.WriteLine("Congrats, you were able to make the new weapon. Damage has been increased so get back to killing.");
                                    armor = nextArm;
                                    if (armor == "Viney chainmail")
                                    {
                                        defense = (int)(lvl * .1);
                                        keepItG = false;

                                    }
                                    else if (armor == "Solid axe")
                                    {
                                        defense = (int)(lvl * .2);
                                        keepItG = false;
                                    }
                                    else if (armor == "Crude sword")
                                    {
                                        defense = (int)(lvl * .3);
                                        keepItG = false;
                                    }
                                    else if (armor == "Refined stone sword")
                                    {
                                        defense = (int)(lvl * .4);
                                        keepItG = false;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You don't have enough materials to build this weapon. Explore to get more materials.");
                                    keepItG = false;
                                }
                            }
                            else
                            {
                                keepItG = false;
                                Console.WriteLine("Choose another task.");
                            }

                        }
                    } while (keepItG == true);


                }
                else if (action.ToLower() == ("e"))
                {
                    if (lvl < 10)
                    {
                        enemyGen = rand.Next(0, 10);
                        if (enemyGen <= 4)
                        {
                            Console.WriteLine("You found a stick!");
                            sticks++;
                            tooMuchFood--;
                        }
                        else if (enemyGen <= 7)
                        {
                            Console.WriteLine("You found a vine!");
                            vine++;
                            tooMuchFood--;
                        }
                        else if (enemyGen == 8)
                        {
                            Console.WriteLine("You didn't find anything.");
                            tooMuchFood--;
                        }
                        else
                        {
                            Console.WriteLine("You found a rock!");
                            rocks++;
                            tooMuchFood--;
                        }

                    }
                    else if (lvl < 20)
                    {
                        enemyGen = rand.Next(0, 20);
                        if (enemyGen <= 4)
                        {
                            Console.WriteLine("You found a stick!");
                            sticks++;
                            tooMuchFood--;
                        }
                        else if (enemyGen <= 7)
                        {
                            Console.WriteLine("You found a vine!");
                            vine++;
                            tooMuchFood--;
                        }
                        else if (enemyGen == 8)
                        {
                            Console.WriteLine("You didn't find anything.");
                            tooMuchFood--;
                        }
                        else if (enemyGen <= 12)
                        {
                            Console.WriteLine("You found a rock!");
                            rocks++;
                            tooMuchFood--;
                        }
                        else if (enemyGen <= 14)
                        {
                            Console.Write("You found a branch. You break off ");
                            enemyGen = rand.Next(1, 5);
                            Console.WriteLine(enemyGen + " sticks. Success is yours!");
                            sticks += enemyGen;
                        }
                        else if (enemyGen <= 17)
                        {
                            Console.Write("You found a bunch of rocks strewn around a tree. You aren't sure if they're there for a reason, so you only decide to take ");
                            enemyGen = rand.Next(1, 5);
                            Console.WriteLine(enemyGen + " of them. Hopefully they're just a gift from the gods.");
                            rocks += enemyGen;
                        }
                        else
                        {
                            Console.Write("You found some wild berries. They look poisonous, but you see that there are some vines behind them. Carefully you reach in and grab ");
                            enemyGen = rand.Next(1, 5);
                            Console.WriteLine(enemyGen + " of them. Well done!");
                            vine += enemyGen;
                        }

                    }
                }
            } while (health > 0);
        }
        public static int setEn(string location)
        {
            Random rand = new Random();
            int enemyGen;
            int enemySelect = 0;

            while (enemySelect == 0)
            {
                Console.WriteLine("You decide to go looking for a fight. Type w to look for a weak enemy, s to look for a strong one, v to look for a very strong one, or i to look for an insane one.");
                string enStr = Console.ReadLine();
                if (location == "DF")
                {
                    if (enStr.ToLower() == "w")
                    {
                        enemyGen = rand.Next(0, 10);
                        if (enemyGen <= 8)
                        {
                            enemySelect = 1;
                        }
                        else
                        {
                            enemySelect = 2;
                        }
                    }
                    if (enStr.ToLower() == "s")
                    {
                        enemyGen = rand.Next(0, 10);
                        if (enemyGen <= 8)
                        {
                            enemySelect = 3;
                        }
                        else
                        {
                            enemySelect = 4;
                        }
                    }
                    if (enStr.ToLower() == "v")
                    {
                        enemyGen = rand.Next(0, 10);
                        if (enemyGen <= 8)
                        {
                            enemySelect = 5;
                        }
                        else
                        {
                            enemySelect = 6;
                        }
                    }
                    if (enStr.ToLower() == "i")
                    {
                        enemyGen = rand.Next(0, 10);
                        if (enemyGen <= 8)
                        {
                            enemySelect = 7;
                        }
                        else
                        {
                            enemySelect = 8;
                        }
                    }
                }
            }
            return enemySelect;
        }
    }
}