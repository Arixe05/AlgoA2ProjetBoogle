using System.Linq.Expressions;
using System.IO;
using System.Timers;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

{


// initialisation du dico
Console.WriteLine("Initialisation du jeux...\nVeuillez entrez la langue dans laquelle vous voulez jouer (FR ou EN).");
Dictionaire dico = new Dictionaire(Console.ReadLine());
dico.toString();

// intitialisation de la liste des lettres pour les dés 
        // création du tableau de lettre utilisé pour la création des dés, à metre dans le main lors de la création du main
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
    // test pour voir si notre tableau avec les différente valeur est correcte
    for(int i = 0; i< tabde.Length; i++)
    {
        Console.WriteLine($"{tabde[i].lettre}, {tabde[i].score}, {tabde[i].nombre}");
    }
    //création d'une liste avec des lettres pondéré
    List<string> ListeLettrePondéré = new List<string>();
     for (int i = 0; i<26; i++)
     {
        for (int j =tabde[i].nombre; j>0; j--)
        {
            ListeLettrePondéré.Add(tabde[i].lettre);
        }
     } 

     // création du tableau de jeux
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
   

    // créatrion des Joueurs

    Console.WriteLine("veuillez entre le pseudo du 1er joueur");
    Joueur j1 = new Joueur(Console.ReadLine(), tabde);
    Console.WriteLine("veuillez entre le pseudo du 2nd joueur");
    Joueur j2 = new Joueur(Console.ReadLine(), tabde);

    // Nombre de lanche du jeux

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
    // début de la partie
    tour = tour*2;
    // création du timer
    Tim T = new Tim(20*1000); // le 60 correspond à la durré du tour d'un joueur
    

    string m = ""; //mot trouvé
    // boucle du jeux, 
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
                    j1.AjouterMot(m);
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
                    j2.AjouterMot(m);
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

     // annonce de la fin et des score

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







             





