namespace ContactInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateInitialDataInContactsTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Contacts (FirstName, LastName, Email, PhoneNumber, Address, City, State, Country, PostCode, Status) VALUES ('Ravi', 'Kapoor', 'ravikapoor@abcd.xyz', 1234567890, 'Hinjewadi', 'Pune', 'Maharashtra', 'India', '411057', 'Active')");
            Sql("INSERT INTO Contacts (FirstName, LastName, Email, PhoneNumber, Address, City, State, Country, PostCode, Status) VALUES ('Neha', 'Sharma', 'nehasharma@abcd.xyz', 1234567891, 'Wakad', 'Pune', 'Maharashtra', 'India', '411057', 'Active')");
            Sql("INSERT INTO Contacts (FirstName, LastName, Email, PhoneNumber, Address, City, State, Country, PostCode, Status) VALUES ('Suresh', 'Thakur', 'sureshthakur@abcd.xyz', 1234567892, 'Navrangpura', 'Ahmedabad', 'Gujarat', 'India', '380009', 'Active')");
            Sql("INSERT INTO Contacts (FirstName, LastName, Email, PhoneNumber, Address, City, State, Country, PostCode, Status) VALUES ('Aman', 'Thope', 'amanthope@abcd.xyz', 1234567893, 'Andheri', 'Mumbai', 'Maharashtra', 'India', '400058', 'Inactive')");
            Sql("INSERT INTO Contacts (FirstName, LastName, Email, PhoneNumber, Address, City, State, Country, PostCode, Status) VALUES ('Reema', 'Jain', 'reemajain@abcd.xyz', 1234567894, 'Saket', 'New Delhi', 'New Delhi', 'India', '110017', 'Active')");
            Sql("INSERT INTO Contacts (FirstName, LastName, Email, PhoneNumber, Address, City, State, Country, PostCode, Status) VALUES ('Priya', 'Malhotra', 'priyamalhotra@abcd.xyz', 1234567895, 'M G Road', 'Indore', 'Madhya Pradesh', 'India', '452001', 'Active')");
            Sql("INSERT INTO Contacts (FirstName, LastName, Email, PhoneNumber, Address, City, State, Country, PostCode, Status) VALUES ('Jaya', 'Rajput', 'jayarajput@abcd.xyz', 1234567896, 'Electronic City', 'Bangalore', 'Karnataka', 'India', '560100', 'Active')");
            Sql("INSERT INTO Contacts (FirstName, LastName, Email, PhoneNumber, Address, City, State, Country, PostCode, Status) VALUES ('Kushal', 'Rana', 'kushalrana@abcd.xyz', 1234567897, 'Hinjewadi', 'Pune', 'Maharashtra', 'India', '411057', 'Active')");
            Sql("INSERT INTO Contacts (FirstName, LastName, Email, PhoneNumber, Address, City, State, Country, PostCode, Status) VALUES ('Amit', 'Reddy', 'amitreddy@abcd.xyz', 1234567898, 'Banjara Hills', 'Hyderabad', 'Telangana', 'India', '500034', 'Active')");
            Sql("INSERT INTO Contacts (FirstName, LastName, Email, PhoneNumber, Address, City, State, Country, PostCode, Status) VALUES ('Mukundan', 'Rajendran', 'mukundan@abcd.xyz', 1234567899, 'Velachery', 'Chennai', 'Tamilnadu', 'India', '600042', 'Active')");
            Sql("INSERT INTO Contacts (FirstName, LastName, Email, PhoneNumber, Address, City, State, Country, PostCode, Status) VALUES ('Yash', 'Singh', 'yashsingh@abcd.xyz', 1234567800, 'Saket', 'New Delhi', 'New Delhi', 'India', '110017', 'Inactive')");
            Sql("INSERT INTO Contacts (FirstName, LastName, Email, PhoneNumber, Address, City, State, Country, PostCode, Status) VALUES ('Hansa', 'Patel', 'hansapatel@abcd.xyz', 1234567801, 'Andheri', 'Mumbai', 'Maharashtra', 'India', '400058', 'Active')");
        }
        
        public override void Down()
        {
        }
    }
}
