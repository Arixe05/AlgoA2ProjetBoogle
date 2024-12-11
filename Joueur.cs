
    public class Joueur
{
    // Propriétés
    public string Pseudo { get; set; } //pseudo 
    public int Score { get; private set; } // Le score d
    public List<string> MotsTrouves { get; private set; } //iste des mots trouvé par le joueur

    // Constructeur
    public Joueur(string pseudo)
    {
        Pseudo = pseudo;
        Score = 0;
        MotsTrouves = new List<string>();
    }
    /// ajCoute un mot trouvé par le joueur, en vérifiant qu'il n'est pas déjà dans la liste.
    /// True si le mot est ajouté, False s'il est déjà présent
    public bool AjouterMot(string mot, int points)
    {
        if (!MotsTrouves.Contains(mot))
        {
            MotsTrouves.Add(mot);
            Score += points;
            return true;
        }
        return false;
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
    
