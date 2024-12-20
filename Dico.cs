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


private void ChargerMots(string cheminFichier)
{
    try
    {
        
        string contenu = File.ReadAllText(cheminFichier);

        
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
    
    mots.Sort();
    Console.WriteLine("Le dictionaire est en "+langue);
   Dictionary<char, int> compteurMots = new Dictionary<char, int>();

    
    for (char lettre = 'a'; lettre <= 'z'; lettre++)
    {
        compteurMots[lettre] = 0;
    }

    
    foreach (string mot in mots)
    {
        char premiereLettre = char.ToLower(mot[0]);
        compteurMots[premiereLettre]++;
    }

    
    foreach (var paire in compteurMots)
    {
        Console.WriteLine($"Le nombre de mots commençant par '{paire.Key}' est : {paire.Value}");
    }

    
    int[] comptage = new int[17]; 
    
    for (int i = 0; i< comptage.Length; i++)
    {
        comptage[i]=0;
    }
    
    for(int i = 0; i<mots.Count; i++)
    {
        comptage[mots[i].Length]++;
    }
   
    for(int i = 1; i<comptage.Length; i++)
    {
        Console.WriteLine("le nombre de mots de taille "+ i+" est : "+ comptage[i]);
    } 
}
private void TriABulle()
    {
        int n = mots.Count;
        bool echange = true;
        
        while (echange)
        {
            echange = false;
            for (int i = 1; i < n; i++)
            {
                if (string.Compare(mots[i - 1], mots[i]) > 0)  
                {

                    string temp = mots[i - 1];
                    mots[i - 1] = mots[i];
                    mots[i] = temp;
                    echange = true;  
                }
            }
            n--;  
        }
        Console.WriteLine("Les mots ont été triés avec l'algorithme de tri à bulles.");
    }
    
private string[] TriFusion(string[] tab, int debut, int fin)
{
     if (debut < fin)
 {
     int mil = debut +fin / 2;
     string[] tabdroite = new string[fin - mil];
     string[] tabgauche = new string[mil - debut];
     for (int i = debut; i < mil; i++) { tabgauche[i] = tab[i]; }
     for (int j = mil; j < fin; j++) { tabdroite[j] = tab[j]; }
     TriFusion(tabgauche, debut, mil);
     TriFusion(tabdroite, mil + 1, fin - 1);
     tab = fusion(tabgauche, tabdroite);
     return tab;
 }
 else {
    string[] jsp = new string[0];
    return jsp;
 }
}
 public string[] fusion(string[] tab1, string[] tab2)
 {
     string[] tab = new string[tab1.Length + tab2.Length];

     int i = tab1.Length;
     int j = tab2.Length;
     for (int k= 0; k < tab.Length;k++)
     {
         if (tab1[i].CompareTo(tab2[j])<-1)
         {
             tab[k] = tab1[i];
             if (i < tab1.Length - 1) { i++; }
         }
         else
         {
             tab[k] = tab2[j];
             if (j < tab2.Length - 1) { j++; }
         }
     }
     return tab;

 }


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
