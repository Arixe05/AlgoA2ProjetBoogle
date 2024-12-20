using System.Linq.Expressions;
using System.IO;
using System.Timers;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing.Common;
{



Console.WriteLine("Initialisation du jeux...\nVeuillez entrez la langue dans laquelle vous voulez jouer (FR ou EN).");
Dictionaire dico = new Dictionaire(Console.ReadLine());
dico.toString();



List<string> MotNuage = new List<string>();


    (string lettre, int score, int nombre)[] tabde = new (string, int, int)[26];
    string contenu = File.ReadAllText("Lettres.txt");
    for (int i = 0; i<26; i++)
    {
        tabde[i].lettre = Convert.ToString(contenu.Substring(0, contenu.IndexOf(";")));
        contenu = contenu.Substring(contenu.IndexOf(";")+1);
        tabde[i].score = Convert.ToInt32(contenu.Substring(0, contenu.IndexOf(";")));
        contenu = contenu.Substring(contenu.IndexOf(";")+1);
        tabde[i].nombre = Convert.ToInt32(contenu.Substring(0, contenu.IndexOf(";")));
        contenu = contenu.Substring(contenu.IndexOf(";")+1);
        
    }

    for(int i = 0; i< tabde.Length; i++)
    {
        Console.WriteLine($"{tabde[i].lettre}, {tabde[i].score}, {tabde[i].nombre}");
    }
   
    List<string> ListeLettrePondéré = new List<string>();
     for (int i = 0; i<26; i++)
     {
        for (int j =tabde[i].nombre; j>0; j--)
        {
            ListeLettrePondéré.Add(tabde[i].lettre);
        }
     } 

    
     int hauteur = -1;
     int largeur =-1;      
     while (hauteur<=1)
    {
        Console.WriteLine("veuillez entrer une hauteur>1");
        try{
        hauteur = Convert.ToInt32(Console.ReadLine());
        }
        catch{
            Console.WriteLine("ce n'est pas le bon format") ;
        }
    }
    while (largeur<=1)
    {
        Console.WriteLine("veuillez entrer une largeur (>1)");
        try{
            largeur = Convert.ToInt32(Console.ReadLine());
        }
        catch{
            Console.WriteLine("ce n'est pas le bon format") ;
        }
    }
    Plateau p = new Plateau(hauteur, largeur, ListeLettrePondéré);
   

  

    Console.WriteLine("veuillez entre le pseudo du 1er joueur");
    Joueur j1 = new Joueur(Console.ReadLine(), tabde);
    Console.WriteLine("veuillez entre le pseudo du 2nd joueur");
    Joueur j2 = new Joueur(Console.ReadLine(), tabde);



    int tour = -1;
    Console.WriteLine("Veuillez entrer le nombre de tour (>=1)");
    while (tour <1)
    {
        
        try{
            
            tour = Convert.ToInt32(Console.ReadLine());
        }
        catch{
            Console.WriteLine("veuillez entrer une nouvelle valeur >=1");
        }
    }
   
    tour = tour*2;
  
    Tim T = new Tim(20*1000); // le 60 correspond à la durré du tour d'un joueur
    

    string m = ""; 
    T.lancetime();
    while (tour !=0)
    {   
        Console.WriteLine($"\nc'est au joueur {tour%2+1}  de jouer\n");
        T.start();
        if(tour%2 == 0)
        {
            j1.AfficherInfos();
            p.NouvPlat();
            Console.WriteLine(p.AfficherPlat());
         
            while (T.TFT()==false)
            {
                m = Console.ReadLine();
                if ( dico.RechDico(m) == true &&p.Test_Plateau(m) == true)
                {
                    int k = j1.score();
                    j1.AjouterMot(m);
                    if (k< j1.score())
                    {
                        MotNuage.Add(m);
                    }
                }
                else if (dico.RechDico(m)== false)
                {
                    Console.WriteLine("le mot n'est pas dans le dictionaire");
                }
                else {Console.WriteLine("le mot n'est pas dans le plateau");}
                Console.WriteLine("Vous avez un score de "+j1.score());
                
                
            }
            j1.ReinitialiserMots();
           
      
        }
        else
        {
            j2.AfficherInfos();
            p.NouvPlat();
             Console.WriteLine(p.AfficherPlat());
          
            while (T.TFT()==false)
            {
                m = Console.ReadLine();
                if (dico.RechDico(m)== true && p.Test_Plateau(m)== true)
                {
                    int k = j1.score();
                    j2.AjouterMot(m);
                    if (k< j2.score())
                    {
                        MotNuage.Add(m);
                    }
                }
                else if (dico.RechDico(m)== false)
                {
                    Console.WriteLine("le mot n'est pas dans le dictionaire");
                }
                else {Console.WriteLine("le mot n'est pas dans le plateau");}
                Console.WriteLine("Vous avez un score de "+j2.score());
                
                
            }
           j2.ReinitialiserMots();
      
        }
         T.stop();
        T.TFF();
        tour--;
    } 

    

    Console.WriteLine("\n\nVoici les scores de la partie\n");
    j1.AfficherInfos();
    Console.WriteLine();
    j2.AfficherInfos();
    Console.WriteLine();
    if(j1.score()>j2.score())
    {
        Console.WriteLine("C'est le joueur 1 qui à gagné");
    }
    else if (j1.score()==j2.score())

    {
         Console.WriteLine("Il y a égalité");
    }
    else{ Console.WriteLine("C'est le joueur 2 qui a gagné");}
 }

 static void TestUnitairePlateau(List<string >ListeLettrePondéré)
 {
    Plateau P = new Plateau(4, 4, ListeLettrePondéré);
    Console.WriteLine("plateau créer de taille 4*4 (la taille est normalement choisie pas les joueurs, avec fail safe pour une taille >1)");
    Console.WriteLine("test affichage plateau");
    Console.WriteLine(P.AfficherPlat()+"\n, retour sous la forme d'un"+P.AfficherPlat().ToString());
    Console.WriteLine("teste mélange plateau (2* de suite)");
   
    P.NouvPlat();
    Console.WriteLine(P.AfficherPlat());
    Console.WriteLine();
    P.NouvPlat();
    Console.WriteLine(P.AfficherPlat());

    Console.WriteLine("essayer de rentrer une suite de lettre dans le plateau (teste recherche récursive)");
    Console.WriteLine("est ce que le mot est dans le plateau : "+P.Test_Plateau(Console.ReadLine()));



 }
static void TestUnitaireDE()

{
    Console.WriteLine("création d'un dé basic, avec le constructeur de() (création de la liste de lettre dans le constructeur)");
    De D = new De();
    Console.WriteLine("affichage du dé");
    Console.WriteLine(D.toString());
    Console.WriteLine($"on lance 6 fois le dé : {D.lance}, {D.lance}, {D.lance}, {D.lance}, {D.lance}, {D.lance}");
    
}

static void TestUnitaireDico()
{
   Console.WriteLine("création du dico FR"); 
   Dictionaire d = new Dictionaire("FR");
   Console.WriteLine("affichage des informations du dico ");
   d.toString();
   Console.WriteLine("recherche du mot <llgragvg>"); 
   Console.WriteLine(d.RechDico("llgragvg")); 
   Console.WriteLine("recherche du mot <rencontre>"); 
   Console.WriteLine(d.RechDico("rencontre")); 
   Console.WriteLine("\n\nde meme en anglais\n\n");
   Console.WriteLine("création du dico FR"); 
   Dictionaire d2 = new Dictionaire("EN");
   Console.WriteLine("affichage des informations du dico ");
   d2.toString();
   Console.WriteLine("recherche du mot <llgragvg>"); 
   Console.WriteLine(d2.RechDico("llgragvg")); 
   Console.WriteLine("recherche du mot <boat>"); 
   Console.WriteLine(d2.RechDico("boat"));
  
}

static void TestUnitaireJoueur((string lettre, int score, int nombre)[] tabde )
{
        Console.WriteLine("Test Constructeur");
        Joueur joueur1 = new Joueur("Aymeric", tabde);
        Console.WriteLine(joueur1.Pseudo == "Aymeric" ? "Test constructeur : OK" : "Test constructeur : echec");
        Console.WriteLine(joueur1.Score == 0 ? "Score initial : OK" : "Score initial : echec");
        Console.WriteLine(joueur1.MotsTrouves.Count == 0 ? "Liste des mots trouvé vide : OK" : "Liste des mots trouvés vide : echec");

      
        Console.WriteLine("\nTest AjouterMot");
        Joueur joueur2 = new Joueur("Raphael",tabde);
        joueur2.AjouterMot("TROUBADOUR");
        joueur2.AjouterMot("TROUBADOUR");

       
        Console.WriteLine("\nTest ReinitialiserMots");
        Joueur joueur3 = new Joueur("Poplechiendepaul", tabde);
        joueur3.AjouterMot("TROUBADOUR");
        joueur3.ReinitialiserMots();
        Console.WriteLine(joueur3.MotsTrouves.Count == 0 && joueur3.Score == 0 ? "Réinitialisation des mots réussie : OK" : "Réinitialisation des mots échoué : echec");
        
        Console.WriteLine("\nTest AjouterMot et afficher");
        joueur3.AjouterMot("RAPHAEL");
        Console.WriteLine(joueur3.MotsTrouves.Contains("RAPHAEL") && joueur3.Score == 10 ? "Mot ajouté et score mis à jour : OK" : "Mot ajouté et score mis à jour : echec");

        
}
 }










             





