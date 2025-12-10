using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace test_repo1
{
    public class InsecureCodeExamples
    {
        // Hardcoded credentials - Security Hotspot
        private const string DB_PASSWORD = "SuperSecret123!";
        private const string API_KEY = "sk_test_1234567890abcdefghijklmno";
        
        // Duplicate code - Code Smell
        public void DoSomething(int x)
        {
            if (x > 0)
            {
                Console.WriteLine("Positive number");
            }
        }
        
        public void DoSomethingElse(int x)
        {
            if (x > 0)
            {
                Console.WriteLine("Positive number");
            }
        }
        
        // SQL Injection vulnerability - Vulnerability
        public DataTable GetUserData(string username)
        {
            using (var connection = new SqlConnection($"Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password={DB_PASSWORD};"))
            {
                var command = new SqlCommand($"SELECT * FROM Users WHERE Username = '{username}'", connection);
                var adapter = new SqlDataAdapter(command);
                var result = new DataTable();
                adapter.Fill(result);
                return result;
            }
        }
        
        // Insecure hashing - Security Hotspot
        public string HashPassword(string password)
        {
            var md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(inputBytes);
            return Convert.ToBase64String(hash);
        }
        
        // Empty catch block - Bug
        public void ProcessPayment(string creditCardNumber)
        {
            try
            {
                // Process payment
            }
            catch (Exception)
            {
                // Swallowing exception
            }
        }
        
        // Dead code - Code Smell
        private void UnusedMethod()
        {
            Console.WriteLine("This method is never called");
        }
        
        // Too many parameters - Code Smell
        public void TooManyParameters(int a, int b, int c, int d, int e, int f, int g)
        {
            // Method with too many parameters
        }
        
        // Potential null reference - Bug
        public string GetFullName(string firstName, string lastName)
        {
            return firstName + " " + lastName;
        }
        
        // Insecure random number generation - Security Hotspot
        public int GenerateRandomNumber()
        {
            Random rand = new Random();
            return rand.Next();
        }
    }
    
    // Large class - Code Smell
    public class GodClass
    {
        public void Method1() { /* ... */ }
        public void Method2() { /* ... */ }
        public void Method3() { /* ... */ }
        public void Method4() { /* ... */ }
        public void Method5() { /* ... */ }
        public void Method6() { /* ... */ }
        public void Method7() { /* ... */ }
        public void Method8() { /* ... */ }
        public void Method9() { /* ... */ }
        public void Method10() { /* ... */ }
        // ... and so on
    }
    
    // Long method - Code Smell
    public class LongMethodExample
    {
        public void ProcessData()
        {
            // ... many lines of code ...
            // This method should be refactored into smaller methods
            // ... many more lines of code ...
            
            // Just to make it compile
            Console.WriteLine("Processing data...");
        }
    }
}
