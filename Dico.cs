using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Runtime.Versioning;

public class Dictionaire {
    private string langue;
    private List<string> mots;
    private string cheminFichier;
    public Dictionaire(string langue)
{
    while (langue != "FR" && langue != "EN")
   {
        Console.WriteLine("entrez une langue valide (FR ou EN)");
        langue = Console.ReadLine();
   }
   this.langue = langue;
   cheminFichier = "MotsPossibles"+langue+".txt";
    mots = new List<string>();
    ChargerMots(cheminFichier);
}

// création du dico
private void ChargerMots(string cheminFichier)
{
    try
    {
        // Lire tout le contenu du fichier comme une seule chaîne
        string contenu = File.ReadAllText(cheminFichier);

        // Diviser le contenu en mots en utilisant l'espace comme séparateur
        mots = new List<string>(contenu.Split(' ', StringSplitOptions.RemoveEmptyEntries));
        Console.WriteLine("Chargement des mots");
    }
    catch (Exception e)
    {
        Console.WriteLine($"Erreur lors du chargement des mots: {e.Message}");
    }
}

public void toString()
{
    // on trie le fichier
    mots.Sort();
    Console.WriteLine("Le dictionaire est en "+langue);
   Dictionary<char, int> compteurMots = new Dictionary<char, int>();

    // Initialisation du dictionnaire avec toutes les lettres de l'alphabet
    for (char lettre = 'a'; lettre <= 'z'; lettre++)
    {
        compteurMots[lettre] = 0;
    }

    // Parcourir les mots et compter les occurrences
    foreach (string mot in mots)
    {
        char premiereLettre = char.ToLower(mot[0]);
        compteurMots[premiereLettre]++;
    }

    // Afficher les résultats
    foreach (var paire in compteurMots)
    {
        Console.WriteLine($"Le nombre de mots commençant par '{paire.Key}' est : {paire.Value}");
    }

    // on compte le nombre de mot en fonction de leur taille
    int[] comptage = new int[17]; 
    // on set tt les position de notre tableau à 0
    for (int i = 0; i< comptage.Length; i++)
    {
        comptage[i]=0;
    }
    // on parcout la liste de mot et on les comptes
    for(int i = 0; i<mots.Count; i++)
    {
        comptage[mots[i].Length]++;
    }
    //on affiche le résultat
    for(int i = 1; i<comptage.Length; i++)
    {
        Console.WriteLine("le nombre de mots de taille "+ i+" est : "+ comptage[i]);
    } 
}

// recherche dico récursive
 public bool RechDico(string mot)
{
    bool resultat = false;
    int fin = mots.Count-1;
    mot = mot.ToUpper().Trim();
    resultat = rechDicoRecursif(mot, 0, fin);
    return resultat;
}

private bool rechDicoRecursif(string mot, int début, int fin)
{
    int millieu = (début+fin)/2 ;
    if (début>fin)
    {
        return false;
    }  
    else if (mot.CompareTo(mots[millieu].ToUpper())==0)
    {
        return true;
    }
    else if (mot.CompareTo(mots[millieu].ToUpper())==-1)
    {
       return rechDicoRecursif(mot, début, millieu-1);
    }
    else
    {
       return rechDicoRecursif(mot, millieu+1, fin);
    }


}

}