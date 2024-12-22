using System;
using System.Data;
using System.Data.SqlClient;

namespace RailwayReservationSystem
{
    // Singleton for Database Connection
    public class Database
    {
        private static Database instance = null;
        private static readonly object lockObj = new object();
        private string connectionString = "Data Source=ICS-LT-3WS3V44\\SQLEXPRESS01;Initial Catalog=RailwayReservationSystem;" +
                "Integrated Security=true;";

        private Database() { }

        public static Database Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new Database();
                    }
                    return instance;
                }
            }
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }


    public interface IMenu
    {
        void DisplayMenu();
    }

    public class AdminMenu : IMenu
    {
        public void DisplayMenu()
        {
            Console.WriteLine("\nAdmin Menu:");
            Console.WriteLine("1. Add Train");
            Console.WriteLine("2. Delete Train");
            Console.WriteLine("3. Update Train");
            Console.WriteLine("4. View Active Trains");
            Console.WriteLine("5. View Stalled Trains");
            Console.WriteLine("6. View all Trains");
            Console.WriteLine("7. Marked as Deleted Trains");
            Console.WriteLine("8. Restore Trains");
            Console.WriteLine("9. Logout");
        }
    }

    public class UserMenu : IMenu
    {
        public void DisplayMenu()
        {
            Console.WriteLine("\nUser Menu:");
            Console.WriteLine("1. View Active Trains");
            Console.WriteLine("2. View Stalled Trains");
            Console.WriteLine("3. Book a Train");
            Console.WriteLine("4. Cancel Booking");
            Console.WriteLine("5. Logout");
        }
    }

    class Program
    {


        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nWelcome to Railway Reservation System");
                Console.WriteLine("1. Admin Login");
                Console.WriteLine("2. User Login");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AdminLogin();
                        break;
                    case 2:
                        UserLogin();
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Admin Login
        static void AdminLogin()
        {
            Console.Write("\nEnter Admin Name: ");
            string adminName = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            using (SqlConnection conn = Database.Instance.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Admin WHERE AdminName = @AdminName AND Password = @Password", conn);
                    cmd.Parameters.AddWithValue("@AdminName", adminName);
                    cmd.Parameters.AddWithValue("@Password", password);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Console.WriteLine("Login Successful!");
                        AdminOperations();
                    }
                    else
                    {
                        Console.WriteLine("Invalid credentials. Access denied.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        static void UserLogin()
        {
            Console.Write("\nEnter Username: ");
            string username = Console.ReadLine();

            using (SqlConnection conn = Database.Instance.GetConnection())
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE UserName = @UserName", conn);
                    cmd.Parameters.AddWithValue("@UserName", username);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        Console.WriteLine("Welcome, " + username + "!");
                        UserOperations();
                    }
                    else
                    {
                        reader.Close();


                        Console.WriteLine("User not found. Please register first.");

                        Console.Write("Enter Password: ");
                        string password = Console.ReadLine();

                        Console.Write("Enter Email: ");
                        string email = Console.ReadLine();

                        Console.Write("Enter Phone Number: ");
                        string phoneNumber = Console.ReadLine();


                        SqlCommand insertCmd = new SqlCommand("INSERT INTO Users (UserName, Password, Email, PhoneNumber) VALUES (@UserName, @Password, @Email, @PhoneNumber)", conn);
                        insertCmd.Parameters.AddWithValue("@UserName", username);
                        insertCmd.Parameters.AddWithValue("@Password", password);
                        insertCmd.Parameters.AddWithValue("@Email", email);
                        insertCmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);


                        try
                        {
                            insertCmd.ExecuteNonQuery();

                            SqlCommand getIdCmd = new SqlCommand("SELECT UserID FROM Users WHERE UserName = @UserName", conn);
                            getIdCmd.Parameters.AddWithValue("@UserName", username);

                            SqlDataReader idReader = getIdCmd.ExecuteReader();
                            if (idReader.Read())
                            {
                                int userId = (int)idReader["UserID"];
                                Console.WriteLine($"Registration successful. \t Your UserID is {userId} \t  Welcome, {username}!");
                                UserOperations();
                            }
                            idReader.Close();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }

                    //insertCmd.ExecuteNonQuery();

                    //Console.WriteLine("Registration successful. Welcome, " + username + "!");
                    //UserOperations(); 

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }






        static void AdminOperations()
        {
            AdminMenu adminMenu = new AdminMenu();

            while (true)
            {
                adminMenu.DisplayMenu();
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddTrain();
                        break;
                    case 2:
                        DeleteTrain();
                        break;
                    case 3:
                        UpdateTrain();
                        break;


                    case 4:
                        ViewActiveTrains();
                        break;
                    case 5:
                        ViewStalledTrains();
                        break;
                    case 6:
                        ViewAllTrains();
                        break;
                    case 7:
                        MarkTrainAsDeleted();
                        break;
                    case 8:
                        RestoreTrain();
                        break;
                    case 9:
                        return; 
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

            }
        }




        // User Operations
        static void UserOperations()
        {
            UserMenu userMenu = new UserMenu();

            while (true)
            {
                userMenu.DisplayMenu();
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ViewActiveTrains();
                        break;
                    case 2:
                        ViewStalledTrains();
                        break;
                    case 3:
                        BookTrain();
                        break;
                    case 4:
                        CancelBooking();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

      
        static void AddTrain()
        {
            Console.Write("Enter Train Name: ");
            string trainName = Console.ReadLine();

            Console.Write("Enter From Location: ");
            string fromLocation = Console.ReadLine();

            Console.Write("Enter To Location: ");
            string toLocation = Console.ReadLine();

            Console.Write("Enter Total Berths for First Class: ");
            int firstClassBerths = int.Parse(Console.ReadLine());

            Console.Write("Enter Total Berths for Second Class: ");
            int secondClassBerths = int.Parse(Console.ReadLine());

            Console.Write("Enter Total Berths for Sleeper Class: ");
            int sleeperClassBerths = int.Parse(Console.ReadLine());

            Console.Write("Is it Stalled? Enter 0 for Active & 1 for Stalled: ");
            int isStalled = int.Parse(Console.ReadLine());

            
            using (SqlConnection conn = Database.Instance.GetConnection())
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("AddTrain", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@TrainName", trainName);
                    cmd.Parameters.AddWithValue("@FromLocation", fromLocation);
                    cmd.Parameters.AddWithValue("@ToLocation", toLocation);
                    cmd.Parameters.AddWithValue("@FirstClassBerths", firstClassBerths);
                    cmd.Parameters.AddWithValue("@SecondClassBerths", secondClassBerths);
                    cmd.Parameters.AddWithValue("@SleeperClassBerths", sleeperClassBerths);
                    cmd.Parameters.AddWithValue("@IsStalled", isStalled);

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Train added successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }



        // Delete Train
        static void DeleteTrain()
        {
            Console.Write("Enter Train ID to delete: ");
            int trainId = int.Parse(Console.ReadLine());

            using (SqlConnection conn = Database.Instance.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DeleteTrain", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TrainId", trainId);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Train deleted successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }


        static void UpdateTrain()
        {
            Console.Write("Enter Train ID to update: ");
            int trainId = int.Parse(Console.ReadLine());
            Console.Write("Enter Train Name: ");
            string trainName = Console.ReadLine();
            Console.Write("Enter From Location: ");
            string fromLocation = Console.ReadLine();
            Console.Write("Enter To Location: ");
            string toLocation = Console.ReadLine();
            Console.Write("Enter Total Berths for First Class: ");
            int firstClassBerths = int.Parse(Console.ReadLine());
            Console.Write("Enter Total Berths for Second Class: ");
            int secondClassBerths = int.Parse(Console.ReadLine());
            Console.Write("Enter Total Berths for Sleeper Class: ");
            int sleeperClassBerths = int.Parse(Console.ReadLine());
            Console.Write("Is the train stalled? (true/false): ");
            bool isStalled = bool.Parse(Console.ReadLine());

            using (SqlConnection conn = Database.Instance.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UpdateTrain", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@TrainId", trainId);
                    cmd.Parameters.AddWithValue("@TrainName", trainName);
                    cmd.Parameters.AddWithValue("@FromLocation", fromLocation);
                    cmd.Parameters.AddWithValue("@ToLocation", toLocation);
                    cmd.Parameters.AddWithValue("@FirstClassBerths", firstClassBerths);
                    cmd.Parameters.AddWithValue("@SecondClassBerths", secondClassBerths);
                    cmd.Parameters.AddWithValue("@SleeperClassBerths", sleeperClassBerths);
                    cmd.Parameters.AddWithValue("@IsStalled", isStalled);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Train details updated successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }




        // View Active Trains
        static void ViewActiveTrains()
        {
            using (SqlConnection conn = Database.Instance.GetConnection())
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("GetActiveTrains", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();

                    Console.WriteLine("\nActive Trains:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["TrainId"]}, Name: {reader["TrainName"]}, From: {reader["FromLocation"]}, To: {reader["ToLocation"]}, FirstClassBerths: {reader["FirstClassBerths"]}, SecondClassBerths: {reader["SecondClassBerths"]}, SleeperClassBerths: {reader["SleeperClassBerths"]}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        // View Stalled Trains
        static void ViewStalledTrains()
        {
            using (SqlConnection conn = Database.Instance.GetConnection()) 
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("GetStalledTrains", conn); 
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();

                    Console.WriteLine("\nStalled Trains:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["TrainId"]}, Name: {reader["TrainName"]}, From: {reader["FromLocation"]}, To: {reader["ToLocation"]}, FirstClassBerths: {reader["FirstClassBerths"]}, SecondClassBerths: {reader["SecondClassBerths"]}, SleeperClassBerths: {reader["SleeperClassBerths"]}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }



        static void ViewAllTrains()
        {
            using (SqlConnection conn = Database.Instance.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GetActiveTrains", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();

                    Console.WriteLine("\nAll Active Trains:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["TrainId"]}, Name: {reader["TrainName"]}, From: {reader["FromLocation"]}, To: {reader["ToLocation"]}, FirstClassBerths: {reader["FirstClassBerths"]}, SecondClassBerths: {reader["SecondClassBerths"]}, SleeperClassBerths: {reader["SleeperClassBerths"]}");
                    }

                    reader.Close();

                    cmd = new SqlCommand("GetStalledTrains", conn);
                    reader = cmd.ExecuteReader();

                    Console.WriteLine("\nAll Stalled Trains:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["TrainId"]}, Name: {reader["TrainName"]}, From: {reader["FromLocation"]}, To: {reader["ToLocation"]}, FirstClassBerths: {reader["FirstClassBerths"]}, SecondClassBerths: {reader["SecondClassBerths"]}, SleeperClassBerths: {reader["SleeperClassBerths"]}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }






        static void MarkTrainAsDeleted()
        {
            using (SqlConnection conn = Database.Instance.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("MarkTrainDeleted", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    Console.Write("Train ID to mark as stalled: ");
                    int trainId = int.Parse(Console.ReadLine());

                    cmd.Parameters.AddWithValue("@TrainId", trainId);
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Train marked as stalled successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        // Restore a Train if it becomes operational again:(i.e.after Maintenance work is done)


        static void RestoreTrain()
        {
            using (SqlConnection conn = Database.Instance.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("RestoreTrains", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    Console.Write("Train ID to restore: ");
                    int trainId = int.Parse(Console.ReadLine());

                    cmd.Parameters.AddWithValue("@TrainId", trainId);
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Train restored successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }




       
        static int GetPriceForClass(string trainClass)
        {
            using (SqlConnection conn = Database.Instance.GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT Price FROM TicketPrices WHERE Class = @Class", conn);
                cmd.Parameters.AddWithValue("@Class", trainClass);

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    return (int)result;
                }
                return 0; // If no matching class found, return 0 as fallback
            }
        }

        static void BookTrain()
        {
            while (true)
            {
                Console.Write("Enter Train ID: ");
                int trainId = int.Parse(Console.ReadLine());

                Console.Write("Enter Class (First/Second/Sleeper): ");
                string trainClass = Console.ReadLine().ToLower();

                Console.Write("Enter Number of Tickets: ");
                int ticketsToBook = int.Parse(Console.ReadLine());

                using (SqlConnection conn = Database.Instance.GetConnection())
                {
                    conn.Open();

                    // Check availability
                    SqlCommand checkCmd = new SqlCommand("SELECT AvailableTickets FROM Tickets WHERE TrainId = @TrainId AND Class = @Class", conn);
                    checkCmd.Parameters.AddWithValue("@TrainId", trainId);
                    checkCmd.Parameters.AddWithValue("@Class", trainClass);
                    int availableTickets = (int)checkCmd.ExecuteScalar();

                    if (availableTickets >= ticketsToBook)
                    {
                        // Reduce available tickets
                        SqlCommand updateCmd = new SqlCommand("UPDATE Tickets SET AvailableTickets = AvailableTickets - @TicketsToBook WHERE TrainId = @TrainId AND Class = @Class", conn);
                        updateCmd.Parameters.AddWithValue("@TicketsToBook", ticketsToBook);
                        updateCmd.Parameters.AddWithValue("@TrainId", trainId);
                        updateCmd.Parameters.AddWithValue("@Class", trainClass);
                        updateCmd.ExecuteNonQuery();

                        // Calculate total amount based on class
                        int pricePerTicket = GetPriceForClass(trainClass);
                        int totalAmount = ticketsToBook * pricePerTicket;

                        Console.WriteLine($"Booking successful! Total amount: Rs.{totalAmount}");
                        break; // Exit the loop after successful booking
                    }
                    else
                    {
                        Console.WriteLine("Not enough seats available for the selected class. Please choose another class.");

                        Console.Write("Do you want to try booking for another class? (Y/N): ");
                        string choice = Console.ReadLine().ToUpper();

                        if (choice == "N")
                        {
                            Console.WriteLine("Booking process terminated.");
                            break; // Exit the loop if the user chooses to quit
                        }
                        else if (choice == "Y")
                        {
                            continue; // Loop again for booking another class
                        }
                    }
                }
            }
        }

        static void CancelBooking()
        {
            while (true)
            {
                Console.WriteLine("Enter Train ID:");
                int trainId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Class (First/Second/Sleeper):");
                string trainClass = Console.ReadLine().ToLower();

                Console.WriteLine("Enter Number of Tickets to Cancel:");
                int ticketsToCancel = int.Parse(Console.ReadLine());

                using (SqlConnection conn = Database.Instance.GetConnection())
                {
                    try
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand("CancelTrain", conn))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@TrainID", trainId);
                            cmd.Parameters.AddWithValue("@Class", trainClass);
                            cmd.Parameters.AddWithValue("@TicketsToCancel", ticketsToCancel);

                            cmd.ExecuteNonQuery(); // Execute stored procedure
                        }

                        // After execution, display the appropriate message
                        Console.WriteLine("Cancellation processed successfully.");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }

                // Option to repeat the process or exit
                Console.WriteLine("Do you want to cancel more tickets? (Y/N)");
                string choice = Console.ReadLine().ToLower();
                if (choice != "y")
                {
                    break;
                }
            }
        }
    }
}


