
    public class Joueur
{
    // Propriétés
    public string Pseudo { get; set; } //pseudo 
    public int Score { get; private set; } // Le score d
    public List<string> MotsTrouves { get; private set; } //iste des mots trouvé par le joueur
    private (string lettre, int score, int nombre)[] LettreScore;

    // Constructeur
    public Joueur(string pseudo, (string lettre, int score, int nombre)[] infoLettre)
    {
        Pseudo = pseudo;
        Score = 0;
        MotsTrouves = new List<string>();
        LettreScore = infoLettre;
    }
    /// ajCoute un mot trouvé par le joueur, en vérifiant qu'il n'est pas déjà dans la liste.
    /// True si le mot est ajouté, False s'il est déjà présent
    public bool AjouterMot(string mot, int points)
    {
        bool testmot = false;
        if (!MotsTrouves.Contains(mot))
        {
            MotsTrouves.Add(mot);
            int point = 0; 
            string m = mot;
            while (m != "")
            {
                for (int i = 0; i<LettreScore.Length; i++ )
                {
                    if (m[0].ToString() == LettreScore[i].lettre)
                    {
                        point += LettreScore[i].score;
                        m = m.Substring(1);
                    }
                }
            }
            Console.WriteLine("Le mot "+ mot.ToUpper()+" vaut "+ point + " points");
            testmot = true;

            
        }
        return testmot;
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
        Console.WriteLine($"Mots trouvés: {string.Join(", ", MotsTrouves)}");
    }
    // cette ligne est un test
    
}
    
