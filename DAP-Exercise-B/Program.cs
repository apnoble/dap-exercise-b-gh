using System;

namespace DAP_Exercise_B
{
    class Program
    {

        static void Main(string[] args)
        {
            PrintRecords();
        }


        // Print to the console the some values for all of the records for Project B
        static void PrintRecords()
        {
            DataService dataService = new DataService();
            Console.WriteLine("Loading data...");

            Record[] records = dataService.GetRecords().Result;

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");

            foreach (Record record in records)
            {
                Console.WriteLine("Subject_Id : " + record.subject_id);
                Console.WriteLine("How many times per day is your dog fed? : " + record.fu_df_frequency);
                Console.WriteLine("Is the primary component of your dog's diet organic? : " + record.fu_df_prim_org);
                Console.WriteLine("What brand of food makes up the primary component of your dog's diet? : " + record.fu_df_prim_brand);
                Console.WriteLine("Within the past year, has your dog been onsidered overweight? : " + record.fu_df_overrweight);
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            }

            Console.WriteLine("Press Enter to Continue.");
            Console.ReadLine();
            //Console.SetWindowPosition(0, 0);
        }
    }
}
