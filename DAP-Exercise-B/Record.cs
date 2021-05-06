using System;
using System.Collections.Generic;
using System.Text;

namespace DAP_Exercise_B
{
    public class Record
    {
        // Instead of changing the variable types to ints, I decided to leave them as strings as they are stored in the database as strings. If I was doing calculations with the numbers, I might have decided against this.

        public string subject_id;
        public string fu_df_frequency;
        public string fu_df_prim_org;
        public string fu_df_prim_brand;

        // This is mispelled with two r's in REDCap. Normally, I would change this on REDCap to be fu_df_overweight and match. I didn't want to risk potentially erasing REDCap records.
        public string fu_df_overrweight;

        public Record(string subject_id,
            string fu_df_frequency,
            string fu_df_prim_org,
            string fu_df_prim_brand,
            string fu_df_overrweight
            )
        {
            this.subject_id = subject_id;
            this.fu_df_frequency = fu_df_frequency;
            this.fu_df_prim_org = fu_df_prim_org;
            this.fu_df_prim_brand = fu_df_prim_brand;
            this.fu_df_overrweight = fu_df_overrweight;
        }
    }
}
