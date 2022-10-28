using ConsoleGame;

bool Running = true;
bool PlayerTurn = false;
bool EnemyTurn = true;
bool fight = true;


Player player = new Player();
Enemy enemy1 = new Enemy();

void print(string text)
{
    foreach(var a in text)
    {
        Console.Write(a);
        Thread.Sleep(20);
    }
}

void ErrorMessage()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    print("You have entered an option that is not listed in the menu! Please check your option and continue...");
    Console.ReadLine();
}

void LevelOne()
{
    Console.Clear();
    print("You defeatedd your enemies but you are very tired." +
            "\nWhile you were resting in the forest you heard that new enemy has arrived and looking for you!" +
            "\nHe sees your arm and comes to attack you!" +
            "You are ready to fight him!");

    while (fight == true)
    {
        Console.ReadLine();
        print($"\nPlayer Stats:\nPlayer HP: {player.hp}\nPlayer Attack: {player.attack}");
        print($"\nEnemy Stats:\nEnemy HP: {enemy1.hp}\nEnemy Attack: {enemy1.attack}");

        if (PlayerTurn == false && EnemyTurn == true)
        {
            print("\nEnemy attack!");
            player.hp -= enemy1.attack;
            if(player.hp > 0)
            {
                fight = true;
            }
            else if(player.hp <= 0)
            {
                fight = false;
                print("\nYou lost!");
            }
            PlayerTurn = true;
            EnemyTurn = false;
        } 
        else if (PlayerTurn == true && EnemyTurn == false)
        {
            print("\nYour turn to attack!");
            enemy1.hp -= player.attack;
            if (enemy1.hp > 0)
            {
                fight = true;
            }
            else if (enemy1.hp <= 0)
            {
                fight = false;
                print("\nYou defeated your enemy!");
            }
            PlayerTurn = false;
            EnemyTurn = true;
        }
    }
}

void LoadingGame()
{
    Console.Clear();
    while (Running == true)
    {
        try
        {
            Random rand = new Random();

            print("Hello please enter your name: ");
            string name = Console.ReadLine();

            List<string> BlockedNames = new List<string>();
            BlockedNames.Add("FCK");
            BlockedNames.Add("fck");

            if (!(BlockedNames.Contains(name)))
            {
                player.name = name;
                player.attack = rand.Next(100, 1000);
                player.hp = rand.Next(100, 1000);

                enemy1.id = 1;
                enemy1.attack = 40;
                enemy1.hp = 88;
                LevelOne();
            }
            else
            {

            }
        }
        catch (Exception e)
        {

        }
    }
}

void GameMenu()
{
    while (Running == true)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        string logo = @"

        ██╗    ██╗ █████╗ ██████╗ ██████╗ ██╗ ██████╗ ██████╗ 
        ██║    ██║██╔══██╗██╔══██╗██╔══██╗██║██╔═══██╗██╔══██╗
        ██║ █╗ ██║███████║██████╔╝██████╔╝██║██║   ██║██████╔╝
        ██║███╗██║██╔══██║██╔══██╗██╔══██╗██║██║   ██║██╔══██╗
        ╚███╔███╔╝██║  ██║██║  ██║██║  ██║██║╚██████╔╝██║  ██║
         ╚══╝╚══╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝ ╚═════╝ ╚═╝  ╚═╝

        ";
        Console.WriteLine(logo);
        string menu = @"
        +---------------------------------------+
        |               1] Start                |
        |               2] About                |
        |               3] Exit                 |
        +---------------------------------------+
        Option: ";
        print(menu);
        try
        {
            string option = Console.ReadLine();
            string a = option.ToLower();
            if (option == "1" || a == "start")
            {
                LoadingGame();
            }
            else if (option == "2" || a == "about")
            {
                print("About");
            }
            else if (option == "3" || a == "exit")
            {
                
            }
            else
            {
                ErrorMessage();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString);
        }
    }
}

GameMenu();