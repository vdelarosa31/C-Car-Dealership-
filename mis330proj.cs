using System;
using System.Collections.Generic;

public class Car
{
    public string Name { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public int Price { get; set; }

    public Car(string name, string brand, string model, int year, int price)
    {
        Name = name;
        Brand = brand;
        Model = model;
        Year = year;
        Price = price;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Car Name: {Name}\nCar Brand: {Brand}\nModel Type: {Model}\nYear: {Year}\nPrice: ${Price}");
    }
}

public class CarDealer
{
    private List<Car> carList = new List<Car>();
    private int muscleCount, suvCount, sportCount, sedanCount;

    public List<(string, int, int)> OfferDiscountOnMuscleCars(double discountPercentage)
    {
        List<(string, int, int)> priceComparison = new List<(string, int, int)>();
        foreach (var car in carList.OfType<Muscles>())
        {
            int originalPrice = car.Price;
            int discountedPrice = (int)(originalPrice * (1 - discountPercentage / 100));
            car.Price = discountedPrice;
            priceComparison.Add((car.Name, originalPrice, discountedPrice));
        }
        return priceComparison;
    }
    public void AddCar(Car car)
    {
        carList.Add(car);
        switch (car)
        {
            case Muscles _:
                muscleCount++;
                break;
            case SUVs _:
                suvCount++;
                break;
            case Sport _:
                sportCount++;
                break;
            case Sedans _:
                sedanCount++;
                break;
        }
    }

    public void DisplayCar()
    {
        Console.WriteLine("Available Cars:");
        foreach (Car car in carList)
        {
            car.DisplayInfo();
            Console.WriteLine();
        }
    }

    public int CountMuscles() => muscleCount;
    public int CountSUVs() => suvCount;
    public int CountSport() => sportCount;
    public int CountSedans() => sedanCount;

    public void BuyCar(string name)
    {
        Car car = carList.Find(j => j.Name == name);
        if (car != null)
        {
            carList.Remove(car);
            UpdateCarCounts(car);
            Console.WriteLine($"'{car.Name}' bought!");
        }
        else
        {
            Console.WriteLine($"Sorry, '{name}' is not available.");
        }
    }

    private void UpdateCarCounts(Car car)
    {
        switch (car)
        {
            case Muscles _:
                muscleCount--;
                break;
            case SUVs _:
                suvCount--;
                break;
            case Sport _:
                sportCount--;
                break;
            case Sedans _:
                sedanCount--;
                break;
        }
    }
}

public class Muscles : Car
{
    public double Horsepower { get; set; }

    public Muscles(string name, string brand, string model, int year, int price, double horsepower) : base(name, brand, model, year, price)
    {
        Horsepower = horsepower;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Horsepower: {Horsepower}");
    }
}

public class SUVs : Car
{
    public double Horsepower { get; set; }

    public SUVs(string name, string brand, string model, int year, int price, double horsepower) : base(name, brand, model, year, price)
    {
        Horsepower = horsepower;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Horsepower: {Horsepower}");
    }
}

public class Sport : Car
{
    public double Horsepower { get; set; }

    public Sport(string name, string brand, string model, int year, int price, double horsepower) : base(name, brand, model, year, price)
    {
        Horsepower = horsepower;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Horsepower: {Horsepower}");
    }
}

public class Sedans : Car
{
    public double Horsepower { get; set; }

    public Sedans(string name, string brand, string model, int year, int price, double horsepower) : base(name, brand, model, year, price)
    {
        Horsepower = horsepower;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Horsepower: {Horsepower}");
    }
}

// Assume Staff classes are defined here as per your initial script.

// Staff class representing the staff of the Car Dealership
public class Staff
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string JobTitle { get; set; }
    public int Years { get; set; }

    public Staff(string firstname, string lastname, string jobtitle, int years)
    {
        FirstName = firstname;
        LastName = lastname;
        JobTitle = jobtitle;
        Years = years;
    }
}

// StaffMgmt class representing the staffMgmt system
public class StaffMgmt
{
    private List<Staff> staffs;

    public StaffMgmt()
    {
        staffs = new List<Staff>();
    }

    // Method to add a Staff to the Jewlery Company
    public void AddStaff(string firstname, string lastname, string jobtitle, int years)
    {
        Staff staff = new Staff(firstname, lastname, jobtitle, years);
        staffs.Add(staff);
    }

    // Method to display the Active floor staff
    public void DisplayActiveStaffs()
    {
        Console.WriteLine($"\t   Name \tJob Title  \tYears w/ Company");
        foreach (var staff in staffs)
        {
            Console.WriteLine($"\t {staff.FirstName} {staff.LastName}  \t{staff.JobTitle} \t\t{staff.Years}");
        }

        // count total of active floor staff 
        int num_staffs = staffs.Count;
        Console.WriteLine("\nTotal numbers of staffs:" + num_staffs);

    }

}

// Staff class representing the Staff of the Jewelry Company


public class StaffPay
{
    //variables for Staff info and pay
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double RatePay { get; set; }
    public double Hours { get; set; }


    public StaffPay(string firstname, string lastname, double ratepay, double hours)
    {
        FirstName = firstname;
        LastName = lastname;
        RatePay = ratepay;
        Hours = hours;
    }

}


// StaffMgmt class representing the staffMgmt system
// StaffMgmtPay class representing the staffMgmt system
public class StaffMgmtPay
{
    private List<StaffPay> staffs;

    public StaffMgmtPay()
    {
        staffs = new List<StaffPay>();
    }

    // Method to add a Staff to the library
    public void AddStaff(string firstname, string lastname, double ratepay, double hours)
    {
        StaffPay staff = new StaffPay(firstname, lastname, ratepay, hours);
        staffs.Add(staff);
    }

    // Method to calculate the total AfterTax for all staff members
    public double CalculateTotalAfterTax()
    {
        double totalAfterTax = 0;
        foreach (var staff in staffs)
        {
            double BeforeTax = staff.RatePay * staff.Hours;
            double FedTax = BeforeTax * .10;
            double MSTax = BeforeTax * .07;
            double AfterTax = BeforeTax - FedTax - MSTax;
            totalAfterTax += AfterTax;
        }
        return totalAfterTax;
    }

    // Method to display Payroll infor for All Staff
    public void DisplayPayroll()
    {
        Console.WriteLine($"\tName     \tRate \tHours \tBeforeTax \tFedTax \tMSTax \tAfterTax");
        foreach (var staff in staffs)
        {
            double BeforeTax = staff.RatePay * staff.Hours;
            double FedTax = BeforeTax * .10;
            double MSTax = BeforeTax * .07;
            double AfterTax = BeforeTax - FedTax - MSTax;

            Console.Write($"\t{staff.FirstName} {staff.LastName}  \t{staff.RatePay} \t{staff.Hours}");
            Console.WriteLine("  \t" + BeforeTax + "\t\t" + FedTax + "  \t" + MSTax + "  \t" + AfterTax);
        }

        // Calculate and display the total AfterTax for all staff members
        double totalAfterTax = CalculateTotalAfterTax();
        Console.WriteLine("\nTotal AfterTax for all staff: $" + totalAfterTax);

        int num_staffs = staffs.Count;  // count total numbers of book in the library
        Console.WriteLine("\nTotal number of staff in the company: " + num_staffs);
    }
}


class Program
{
    static void Main(string[] args)
    {
        //Opening signature
        Console.WriteLine("Victor's Car Dealership!");
        Console.WriteLine("     ______");
        Console.WriteLine("   //  ||  \\\\");
        Console.WriteLine("  ||    ||   |-.___");
        Console.WriteLine("  ||    ||   |     `--.");
        Console.WriteLine("   \\\\___||___|________|");
        Console.WriteLine("     O        O");


        CarDealer CarDealer = new CarDealer();

        //Information for Cars
        Car hellcat = new Muscles("Hellcat", "Dodge", "SRT", 2023, 95995, 707);
        Car mustang = new Muscles("Mustang", "Ford", "GT", 2024, 30920, 486);
        Car camaro = new Muscles("Camaro", "Chevrolet", "ZL1", 2024, 53295, 650);

        Car rangerover = new SUVs("Range Rover", "Land Rover", "EVOQUE", 2024, 49900, 246);
        Car gwagon = new SUVs("G-Wagon", "Mercedes-Benz", "G-Class", 2024, 184050, 416);

        Car porschecayman = new Sport("Cayman", "Porsche", "718", 2024, 68300, 493);
        Car mazdamx5 = new Sport("MX-5", "Mazda", "Miata", 2024, 37010, 181);
        Car porsche911 = new Sport("911", "Porsche", "GT3", 2024, 182900, 502);
        Car mclaren720s = new Sport("720S", "McLaren", "S-Series", 2024, 499000, 710);

        Car hondacivic = new Sedans("Type R", "Honda", "Civic", 2024, 45890, 314);
        Car nissan = new Sedans("Skyline", "Nissan", "GTR", 2024, 122985, 565);

        //Add cars in
        CarDealer.AddCar(hellcat);
        CarDealer.AddCar(mustang);
        CarDealer.AddCar(camaro);
        CarDealer.AddCar(rangerover);
        CarDealer.AddCar(gwagon);
        CarDealer.AddCar(porschecayman);
        CarDealer.AddCar(mazdamx5);
        CarDealer.AddCar(porsche911);
        CarDealer.AddCar(mclaren720s);
        CarDealer.AddCar(hondacivic);
        CarDealer.AddCar(nissan);

        //displays avalible cars
        CarDealer.DisplayCar();

        //the print out for a count of available cars
        Console.WriteLine("\nNumber of Muscle Cars available: " + CarDealer.CountMuscles());
        Console.WriteLine("Number of SUVS available: " + CarDealer.CountSUVs());
        Console.WriteLine("Number of Sports Cars available: " + CarDealer.CountSport());
        Console.WriteLine("Number of Sedans available: " + CarDealer.CountSedans());

        Console.WriteLine("                 ");
        Console.WriteLine("========================================================                ");
        Console.WriteLine("                 ");

        // Marking "Muscle Car" as bought
        Console.WriteLine("\nBuying 'Muscle Car'...");
        CarDealer.BuyCar("Muscle Car");


        // Displaying original and discounted prices
        Console.WriteLine("\nOffering 10% discount on available muscle cars:");
        List<(string, int, int)> priceComparison = CarDealer.OfferDiscountOnMuscleCars(10);
        foreach (var (name, originalPrice, discountedPrice) in priceComparison)
        {
            Console.WriteLine($"Car Name: {name}\nOriginal Price: ${originalPrice}\nDiscounted Price: ${discountedPrice}");
            int savings = originalPrice - discountedPrice;
            Console.WriteLine($"Amount Saved: ${savings}\n");
        }

        // Displaying updated options
        Console.WriteLine("                 ");
        Console.WriteLine("========================================================                ");
        Console.WriteLine("                 ");

        //Opening signature
        Console.WriteLine("Victor's Car Dealership!");
        Console.WriteLine("     ______");
        Console.WriteLine("   //  ||  \\\\");
        Console.WriteLine("  ||    ||   |-.___");
        Console.WriteLine("  ||    ||   |     `--.");
        Console.WriteLine("   \\\\___||___|________|");
        Console.WriteLine("     O        O");

        //displays avalible jewelry
        CarDealer.DisplayCar();

        //the print out for a count of available jewlery
        Console.WriteLine("\nNumber of Muscle cars available: " + CarDealer.CountMuscles());
        Console.WriteLine("Number of SUVS available: " + CarDealer.CountSUVs());
        Console.WriteLine("Number of Sports car available: " + CarDealer.CountSport());
        Console.WriteLine("Number of Sedans available: " + CarDealer.CountSedans());

        // Create a list to store the items to be bought
        List<Car> checkoutList = new List<Car>();

        // Add the items to be bought to the checkout list
        checkoutList.Add(hellcat);
        checkoutList.Add(porschecayman);
        checkoutList.Add(mclaren720s);
        checkoutList.Add(gwagon);

        // Calculate the total price of the items in the checkout list
        int totalPrice = 0;
        foreach (var item in checkoutList)
        {
            totalPrice += item.Price;
        }

        // Display the checkout list and total price
        Console.WriteLine("\nCheckout List:");
        Console.WriteLine("======================");
        foreach (var item in checkoutList)
        {
            Console.WriteLine($"Item: {item.Name}, Price: ${item.Price}");
        }
        Console.WriteLine("======================");
        Console.WriteLine($"Total Price: ${totalPrice}");

        Console.WriteLine("                 ");
        Console.WriteLine("========================================================                ");
        Console.WriteLine("                 ");

        //the staff that is active on the floor
        StaffMgmt staffmgmt = new StaffMgmt();
        staffmgmt.AddStaff("Joel", "Embiid", "Assistant", 2);
        staffmgmt.AddStaff("Tyrese", "Maxey", "Sizer/Mender", 6);
        staffmgmt.AddStaff("Luka", "Doncic", "Custom Artist", 4);
        staffmgmt.AddStaff("Kelly", "Oubre", "Store Manager", 10);

        // Displaying only the staff that is active on the floor
        Console.WriteLine("\nActive Store Floor Staff:");
        staffmgmt.DisplayActiveStaffs();

        //The whole company staff
        StaffMgmtPay staffmgmtpay = new StaffMgmtPay();
        staffmgmtpay.AddStaff("Joel", "Embiid", 10, 25);
        staffmgmtpay.AddStaff("Tyrese", "Maxey", 25, 40);
        staffmgmtpay.AddStaff("Kelly", "Oubre", 18, 35);
        staffmgmtpay.AddStaff("Luka", "Doncic", 33, 40);
        staffmgmtpay.AddStaff("Steph", "Curry", 34, 40);
        staffmgmtpay.AddStaff("Victor", "Wembenyama", 38, 40);
        
        // Displaying Payroll
        Console.WriteLine("\nPayroll information:\n");
        staffmgmtpay.DisplayPayroll();


    }
}