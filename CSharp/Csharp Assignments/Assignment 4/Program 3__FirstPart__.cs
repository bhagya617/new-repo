using System;

class DoctorDetails
{
    public string RegnNo { get; set; }
    public string Name { get; set; }
    public double FeesCharged { get; set; }

    public DoctorDetails(string regnNo, string name, double feesCharged)
    {
        RegnNo = regnNo;
        Name = name;
        FeesCharged = feesCharged;
    }
}

class Doctor
{
    private DoctorDetails doctorDetails;

   //implementing aggregation here
    public Doctor(DoctorDetails doctorDetails)
    {
        this.doctorDetails = doctorDetails;
    }

    public void DisplayDoctorDetails()
    {
        Console.WriteLine("\nDoctor's Details:");
        Console.WriteLine("Doctor Registration Number: " + doctorDetails.RegnNo);
        Console.WriteLine("Doctor Name: " + doctorDetails.Name);
        Console.WriteLine("Fees Charged: " + doctorDetails.FeesCharged);
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("Enter Doctor Registration Number:");
        string regnNo = Console.ReadLine();

        Console.WriteLine("Enter Doctor Name:");
        string name = Console.ReadLine();

        double feesCharged;
        while (true)
        {
            Console.WriteLine("Enter Fees Charged by the Doctor:");
            string feesInput = Console.ReadLine();

            if (double.TryParse(feesInput, out feesCharged) && feesCharged >= 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Please enter a valid non-negative number for fees.");
            }
        }

        
        DoctorDetails doctorDetails = new DoctorDetails(regnNo, name, feesCharged);

       
        Doctor doctor = new Doctor(doctorDetails);

        doctor.DisplayDoctorDetails();

        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();
    }
}
