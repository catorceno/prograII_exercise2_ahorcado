using System;

class AhorcadoGame{
    private string[] words = {"PINTURA", "DIBUJO", "FOTOGRAFIA", "ESCRITURA", "LECTURA", "AJEDREZ", "JARDINERIA", "COSTURA", 
                          "TEJIDO", "SENDERISMO", "CAMPING", "DANZA", "CANTO", "MUSICA", "CINE", "TEATRO", "VIDEOJUEGOS", 
                          "CROCHET", "BICICLETA", "PATINAJE", "NATACION", "YOGA", "MEDITACION", "ORIGAMI", "MODELISMO", 
                          "CALIGRAFIA", "ASTRONOMIA", "COCINA", "REPOSTERIA", "MAGIA"};
    private List<char> usedLetters = new List<char>();
    private string randomWord = "";
    private string hiddenWord = "";
    private int failures;

    public void startGame(){
        // set random word
        int r = Random.Shared.Next(words.Length);
        randomWord = words[r];

        // set available failures
        if(randomWord.Length <= 7) failures = 4;
        else failures = 7;

        // set hidden word
        char[] aux = new char[randomWord.Length];
        for(int i = 0; i < aux.Length; ++i) aux[i] = '_';

        int revealed;
        if(aux.Length <= 6) revealed = 1;
        else if(aux.Length < 10) revealed = 2;
        else revealed = 3;
        int[] r2 = new int[revealed];
        for(int i = 0; i < r2.Length; ++i) r2[i] = Random.Shared.Next(aux.Length);

        for(int i = 0; i < r2.Length; ++i){
            for(int j = 0; j < aux.Length; ++j){
                if(j == r2[i]) aux[j] = randomWord[j];
            }
        }
        hiddenWord = new string(aux);

        Console.WriteLine("Bienvenido!");
        Console.WriteLine($"Tu numero de intentos fallidos es: {failures}");
        Console.WriteLine("El pasatiempo a adivinar es: ");
        Console.WriteLine();
    }
    public void play(){
        if(randomWord == "") {Console.WriteLine("Debes iniciar el juego antes de empezar a adivinar!"); return;}
        char input;
        while(randomWord != hiddenWord && failures > 0){
            Console.Write($"{new string(hiddenWord)}     ");
            Console.Write("Escribe una letra: ");
            input = char.ToUpper(Console.ReadKey().KeyChar);
            Console.Write("    ");

            if(verifyLetter(input) == true){
                if(isLetterOnWord(input) == true){
                    Console.WriteLine();
                    continue;
                }
            }
        }
        Console.WriteLine();
        endGame();
    }
    public bool verifyLetter(char letter){
        if(letter < 65 || letter > 90){
            Console.WriteLine("Escribe una letra válida del alfabeto por favor.");
            return false;
        }
        if(usedLetters.Contains(letter)){
            Console.WriteLine("Ya ingresaste esa letra antes!");
            return false;
        } usedLetters.Add(letter);
        return true;
    }
    public bool isLetterOnWord(char letter){
        char[] aux = new char[hiddenWord.Length];
        for(int i = 0; i < aux.Length; ++i) aux[i] = hiddenWord[i];
        int j = 0;
        for(int i = 0; i < aux.Length; ++i){
            if(letter == randomWord[i]){
                aux[i] = letter;
                hiddenWord = new string(aux);
                ++j;
            }
        }
        if(j != 0) return true;
        --failures;
        Console.WriteLine($"La letra no es parte de la palabra :(. Intentos restantes: {failures}");
        return false;
    }
    public void endGame(){
        if(failures == 0){
            Console.WriteLine($"Ahorcado! La palabra era: {randomWord}");
            Console.WriteLine();
        } else if (randomWord == hiddenWord){
            Console.WriteLine($"Felicidades! Advinaste el pasatiempo: {randomWord}");
            Console.WriteLine();
        }
    }
}