using System.ComponentModel.DataAnnotations.Schema;

public class De{
    private string[] de;
    private List<string> listeL;




    public De() 
    {
       
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

    List<string> ListeLettrePondéré = new List<string>();
     for (int i = 0; i<26; i++)
     {
        for (int j =tabde[i].nombre; j>0; j--)
        {
            ListeLettrePondéré.Add(tabde[i].lettre);
        }
     } 
   
        listeL = ListeLettrePondéré;
        

    string[] de = new string[6];
    Random rand = new Random();
    for (int i = 0; i<6; i++ )
    {
      de[i]= ListeLettrePondéré[rand.Next(0, ListeLettrePondéré.Count())] +" "; 
    }
   this.de = de;
    
    }

    public De(List<string> ListeLettrePondéré)
    {
         string[] de = new string[6];
    Random rand = new Random();
    for (int i = 0; i<6; i++ )
    {
      de[i]= ListeLettrePondéré[rand.Next(0, ListeLettrePondéré.Count())] +" "; 
    }
    listeL = ListeLettrePondéré;
   this.de = de;
    

    }


    public string lance()
    {
        Random r = new Random();
        return de[r.Next(0,6)];

    }  

    public string toString(){
        string str = "";
        for (int i = 0; i<6; i++)
        {str += de[i]+" ";}
        return str;
    }  
}
