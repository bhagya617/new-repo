using System;
using System.Data;
using System.Data.SqlClient;

class ADO_TEST
{
    static void Main()
    {
        string connectionString = "Server=ICS-LT-3WS3V44\\SQLEXPRESS01;Database=tempdb;Trusted_Connection=True";

        
        SqlConnection conn = new SqlConnection(connectionString);

        
        conn.Open();

        SqlCommand cmd = new SqlCommand("InsProductDet", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        
        cmd.Parameters.AddWithValue("@ProductName", "Toothpaste");
        cmd.Parameters.AddWithValue("@Price", 222);

        
        SqlParameter productIdParam = new SqlParameter("@GeneratedProductId", SqlDbType.Int);
        productIdParam.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(productIdParam);

        SqlParameter discountedPriceParam = new SqlParameter("@DiscountedPrice", SqlDbType.Float);
        discountedPriceParam.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(discountedPriceParam);

        cmd.ExecuteNonQuery();

        //I WAS GETTING InvalidCastException ERROR SO HAD TO DOUBLE LATER
        int generatedProductId = (int)productIdParam.Value;
        double discountedPrice = (double)discountedPriceParam.Value; 

        Console.WriteLine("Generated ProductId: " + generatedProductId);
        Console.WriteLine("Discounted Price: " + discountedPrice);

        conn.Close();
        Console.ReadKey();
    }
}
