using Newtonsoft.Json;

namespace Day10
{

    /*
        ╔══════════╗ 
        ║ File I/O ║
        ╚══════════╝ 

        3 things are required for File I/O:
        1) Open the file
        2) read/write to the file
        3) close the file


        TIPS:
            use File.ReadAllText to open,read,close the file in 1 statement
            the using() statement can ensure that the file is closed

    */

    public enum Powers
    {
        Typing, Money, Jumping, Speed, Strength, Swimming
    }
    class Superhero
    {
        public string Name { get; set; }
        public string Secret { get; set; }
        public Powers Power { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                ╔══════════╗ 
                ║ File I/O ║
                ╚══════════╝ 

                [  Open the file  ]
                [  Write to the file  ]
                [  Close the file  ]
             
                you need the path to the file
                    use full path ( drive + directories + filename )
                    or use relative path ( directories + filename )
                    or current directory ( filename )


                
                using (StreamWriter sw = new StreamWriter(filePath)) // this line opens the file to write to it
                {                
                    //these lines write to the file
                    sw.Write("Batman");
                    sw.Write(54);
                    sw.Write(13.7);
                    sw.Write(true);

                }//this closes the file

            */

            string directories = @"C:\temp\2305"; //use @ in front of the string to ignore escape sequences inside the string
            string fileName = "tempFile.txt";
            string filePath = Path.Combine(directories, fileName); //use Path.Combine to get the proper directory separators

            //write CSV data
            //delimiter (data separator)
            char delimiter = '$';
            using (StreamWriter sw = new StreamWriter(filePath))//1) open the file
            {
                //2. write to the file
                sw.Write("Superheroes are awesome!"); sw.Write(delimiter);
                sw.Write(5); sw.Write(delimiter);
                sw.Write(420.13); sw.Write(delimiter);
                sw.Write(true);
                //sw.Close();//3.close the file
            }//3.close the file
            /*
                CHALLENGE 1:
                    Create a List of Superhero.
                    Write the list to a CSV file             
            */
            List<Superhero> heroes = new List<Superhero>();
            heroes.Add(new Superhero() { Name = "Batman", Secret = "Bruce Wayne", Power = Powers.Money });
            heroes.Add(new Superhero() { Name = "Superman", Secret = "Clark Kent", Power = Powers.Jumping });
            heroes.Add(new Superhero() { Name = "Wonder Woman", Secret = "Diana Prince", Power = Powers.Strength });
            heroes.Add(new Superhero() { Name = "Flash", Secret = "Barry Allen", Power = Powers.Speed });
            heroes.Add(new Superhero() { Name = "Aquaman", Secret = "Arthus Curry", Power = Powers.Swimming });
            string heroPath = "JLA.csv";
            //heroPath = Path.Combine(directories, heroPath);
            using (StreamWriter sw = new StreamWriter(heroPath))
            {
                char heroDelim = '*';
                bool isFirst = true;
                foreach (var hero in heroes)
                {
                    if (!isFirst) sw.WriteLine();
                    sw.Write($"{hero.Name}{delimiter}{hero.Secret}{delimiter}{hero.Power}");

                    isFirst = false;
                }
            }

            //reading CSV
            if (File.Exists(filePath))
            {
                //using (StreamReader sr = new StreamReader(filePath))
                //{

                //}
                //OR...
                string fileText = File.ReadAllText(filePath);//open, read, close the file
                string[] fileData = fileText.Split(delimiter);
                foreach (var item in fileData)
                {
                    Console.WriteLine(item);
                }
                int.TryParse(fileData[1], out int num);
                double.TryParse(fileData[2], out double d);
                bool.TryParse(fileData[3], out bool b);
            }

            /*
                CHALLENGE 2:

                    Open the CSV file and read the data into a new list of superheroes
             
            */
            //  hero\nhero\n
            //  name$secret$power
            List<Superhero> jla = new();
            using (StreamReader sr = new StreamReader(heroPath))
            {
                string line;
                while((line = sr.ReadLine()) != null) 
                { 
                    string[] heroData = line.Split(delimiter);
                    Superhero super = new()
                    {
                        Name = heroData[0],
                        Secret = heroData[1],
                        Power = (Powers)Enum.Parse(typeof(Powers), heroData[2])
                    };
                    jla.Add(super);
                }
            }
            //OR...use file.ReadAlltext
            jla = new();
            string jlaText = File.ReadAllText(heroPath);
            string[] heroesArray = jlaText.Split('\n');
            foreach (var hero in heroesArray)
            {
                string[] heroData = hero.Split(delimiter);
                Superhero super = new()
                {
                    Name = heroData[0],
                    Secret = heroData[1],
                    Power = (Powers)Enum.Parse(typeof(Powers), heroData[2])
                };
                jla.Add(super);
            }
            foreach (var item in jla)
            {
                Console.WriteLine($"{item.Name} {item.Secret} {item.Power}");
            }


            /*
                ╔═══════════════════╗ 
                ║ Splitting Strings ║
                ╚═══════════════════╝ 

                taking 1 string a separating it into multiple pieces of data

                use the string's Split method

            */
            string csvString = "Batman;Bruce Wayne;Bats;The Dark Knight#Joker#Bane#Poison Ivy";
            string[] data = csvString.Split(';');
            string[] dcData = csvString.Split(new char[] { ';', '#' });





            /*
                ╔═════════════╗ 
                ║ Serializing ║
                ╚═════════════╝ 

                Saving the state (data) of objects

            */
            Random randy = new();
            List<int> scores = new();
            for (int i = 0; i < 10; i++)
                scores.Add(randy.Next());

            string scorePath = "scores.json";
            using (StreamWriter sw = new StreamWriter(scorePath))
            {
                using (JsonTextWriter jtw = new(sw))
                {
                    JsonSerializer jsonSerializer = new();
                    jsonSerializer.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jtw, scores);
                }
            }
            //OR...
            File.WriteAllText(scorePath, JsonConvert.SerializeObject(scores));

            /*
             * Challenge 3:
                Serialize (write) the list of superheroes to a json file
            */
            heroPath = Path.ChangeExtension(heroPath, "json");
            File.WriteAllText(heroPath, JsonConvert.SerializeObject(heroes, Formatting.Indented));




            /*
                ╔═══════════════╗ 
                ║ Deserializing ║
                ╚═══════════════╝ 

                Recreating the objects from the saved state (data) of objects

            */
            List<int> loadedScores;

            if (File.Exists(scorePath))
            {
                string scoreText = File.ReadAllText(scorePath);
                try
                {
                    loadedScores = JsonConvert.DeserializeObject<List<int>>(scoreText);
                    foreach (var score in loadedScores)
                    {
                        Console.WriteLine(score);
                    }
                }
                catch (Exception)
                {
                } 
            }

            /*
             
                Challenge: deserialize the jla.json file into a list of superheroes

            */
            List<Superhero> jla2 = null;
            if (File.Exists(heroPath))
            {
                string heroText = File.ReadAllText(heroPath);
                try
                {
                    jla2 = JsonConvert.DeserializeObject<List<Superhero>>(heroText);
                }
                catch (Exception)
                {

                }
            }
            if(jla2 != null)
            {
                foreach (var hero in jla2)
                {
                    Console.WriteLine($"{hero.Name} {hero.Secret} {hero.Power}");
                }
            }

        }
    }
}