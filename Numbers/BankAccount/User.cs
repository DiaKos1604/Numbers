﻿namespace Basic.BankAccount
{
    public class User
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
       
        public  Bank Bank { get; set; }
    }
}
