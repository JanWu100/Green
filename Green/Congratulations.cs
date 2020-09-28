namespace Green
{
    public class Congratulations
    {
        public static string[] Draw(int version)
        {
            if (version == 1)
            {
                string[] congrats =
                {
                    @"                                 _       
                                | |      
  ___ ___  _ __   __ _ _ __ __ _| |_ ___ 
 / __/ _ \| '_ \ / _` | '__/ _` | __/ __|
| (_| (_) | | | | (_| | | | (_| | |_\__ \
 \___\___/|_| |_|\__, |_|  \__,_|\__|___/
                  __/ |                  
                 |___/      "
                };
                return congrats;
            }
            else
            {
                string[] congrats =
                {
                    @"                                                888            
                                               888            
                                               888            
 .d8888b .d88b. 88888b.  .d88b. 888d888 8888b. 888888.d8888b  
d88P""   d88""""88b888 ""88bd88P""88b888P""      ""88b888   88K      
888     888  888888  888888  888888    .d888888888   ""Y8888b. 
Y88b.   Y88..88P888  888Y88b 888888    888  888Y88b.      X88 
 ""Y8888P ""Y88P"" 888  888 ""Y88888888    ""Y888888 ""Y888 88888P' 
                             888                              
                        Y8b d88P                              
                         ""Y88P""                               "
                };
                return congrats;
            }




        }
    }
   
}
