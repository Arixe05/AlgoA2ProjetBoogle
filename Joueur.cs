
    public class Joueur
{
    // Propriétés
    public string Pseudo { get; set; } //pseudo 
    public int Score { get; private set; } // Le score d
    public List<string> MotsTrouves { get; private set; } //iste des mots trouvé par le joueur

    public int NBmot;
    private (string lettre, int score, int nombre)[] LettreScore;

    // Constructeur
    public Joueur(string pseudo, (string lettre, int score, int nombre)[] infoLettre)
    {
        Pseudo = pseudo;
        Score = 0;
        MotsTrouves = new List<string>();
        LettreScore = infoLettre;
        NBmot = 0;
    }
    /// ajCoute un mot trouvé par le joueur, en vérifiant qu'il n'est pas déjà dans la liste.
    /// True si le mot est ajouté, False s'il est déjà présent
    public void AjouterMot(string mot)
    {
        
        if (!MotsTrouves.Contains(mot))
        {
            MotsTrouves.Add(mot);
            int point = 0; 
            string m = mot.ToUpper();
           
            while (m!="")
            {
             
                for (int k = 0; k<LettreScore.Length&&m!=""; k++ )
                {
                    
                    if (m[0] == Convert.ToChar(LettreScore[k].lettre))
                    {
                        point += LettreScore[k].score;
                        m = m.Substring(1);
                        
                        
                    }
                }
            }
            NBmot++;
            Score += point;
            Console.WriteLine("Le mot "+ mot.ToUpper()+" vaut "+ point + " points");   
        }
        else {
            Console.WriteLine("le mot a déjà été entré ou n'a pas pu etre ajouté");
        }
        
    }

    /// Réinitialiser les mots trouvés pour un nouveau tour.
    public void ReinitialiserMots()
    {
        MotsTrouves.Clear();
    }

    /// Afficher les informations du joueur.
    public void AfficherInfos()
    {
        Console.WriteLine($"Pseudo: {Pseudo}");
        Console.WriteLine($"Score: {Score}");
        Console.WriteLine($"Mots trouvés: {NBmot}");
    }
    
    public int score()
    {
        return Score;
    }
    
}
    
