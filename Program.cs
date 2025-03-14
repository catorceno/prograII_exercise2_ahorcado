using System;

namespace _4.game_exercise{
    class Program{
        static void Main(string[] args){
            AhorcadoGame game1 = new AhorcadoGame();
            game1.startGame();
            game1.play();
        }
    }
}

/*
            Console.WriteLine(" ______");
            Console.WriteLine("|      |");
            Console.WriteLine("|      o");
            Console.WriteLine("|     -|-");
            Console.WriteLine("|     / \\");
            Console.WriteLine("|");
            Console.WriteLine(" ______");
            Console.WriteLine("|      |");
            Console.WriteLine("|      x");
            Console.WriteLine("|     -|-");
            Console.WriteLine("|     / \\");
            Console.WriteLine("|");
*/