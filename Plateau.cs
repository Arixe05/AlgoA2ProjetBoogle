using System.Runtime;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

public class Plateau 
{
    private int hauteur;
    private int largeur;

    private De[,] Pde;
    private string[,] plateau;

    public Plateau(int hauteur, int largeur,List<string> ListeLettrePondéré)
    {
        
        //potentiellement à mettre dans dans le main
        while (hauteur<=1 || largeur<=1)
        {
             Console.WriteLine("on ne peut pas jouer avec un tableau de taille inférieur ou égale à 1!\nVeuillez entrez de nouvelles valeurs");
             Console.WriteLine("veuillez entrer une hauteur");
             while (hauteur<=1)
             {
                try{
                    hauteur = Convert.ToInt32(Console.ReadLine());
                }
                catch{
                    Console.WriteLine("ce n'est pas le bon format") ;
                }
             }
             while (largeur<=1)
             {
                try{
                    largeur = Convert.ToInt32(Console.ReadLine());
                }
                catch{
                    Console.WriteLine("ce n'est pas le bon format") ;
                }
             }
        }
        this.hauteur= hauteur;
        this.largeur = largeur;
        Pde= new De[hauteur,largeur];
            
            for (int i = 0; i< hauteur; i++)
            {
                for (int j = 0; j<largeur; j++)
                {
                    Pde[i,j] = new De(ListeLettrePondéré);
                    
                }
            }
        plateau = new string[hauteur,largeur];
         

    }
    public void NouvPlat()
    {
            string[,] p = new string[hauteur,largeur];
            for (int i = 0; i< hauteur; i++)
            {
                for (int j = 0; j<largeur; j++)
                {
                    
                    p[i,j] = Pde[i,j].lance();
                }
            }
            plateau= p;
    }

    public string AfficherPlat()
    {
        string str = "";
        for (int i = 0; i< hauteur; i++)
        {
            for (int  j = 0; j<largeur; j++)
            {
                str += plateau[i,j];
            }
            str+="\n";
        }
        return str;
    }

    public bool Test_Plateau(string mot){
        bool test = false;
        mot = mot.Trim().ToUpper();
        /// je le but sera de trouver toute les occurence de la première lettre du mot dans une zone délimité par les cases autour de la lettre
        /// ensuiten on fait pareil jusqu'a ce que le mot fasse 0 lettre, si c'est le cas c'est que le mot est bien dans le tableau.
        /// faudra aussi voir pour ne pas compter la posisiton n-1
        /// la fonction sera séparé en 2, la première qui cherche la toute première lettre du mot, et la deuxième, ittérative, qui fera le reste.
       
        for (int i = 0; i< hauteur&& test == false; i++)
        {
            for (int j = 0; j<largeur&& test == false; j++)
            {
                if (plateau[i,j].Trim().ToUpper() == mot[0].ToString())
                {
                    test = test_PlateauRécusif(mot.Substring(1), i, j);
                }
            }
        }
        return test;
    }
    private bool test_PlateauRécusif(string mot, int i, int j)
    {

        if (mot == ""|| mot == null)
        {
            return true;
        }
        else{
            
            bool test = false;
            for (int x= i-1; x<=i+1&& test == false; x++)
            {
                for (int y = j-1; y<=j+1&& test == false; y++ )
                {
                    if (x>=0 && x<hauteur && y<largeur && y>=0)
                    {
                    
                        if (plateau[x,y].Trim().ToUpper()  == mot[0].ToString())
                        {
                            test = test_PlateauRécusif(mot.Substring(1), x, y);
                        }
                    }
                }
            }
            return test;
        }
        
    }
}