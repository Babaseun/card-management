namespace CardManagement.Data.EntityConfigurations
{
    public static class Restrictions
    {
        public static class User
        {
            public const int EmailLength = 70;
            public const int FirstNameLength = 50;
            public const int LastNameLength = 50;
        }
        
        public static class Contact
        {
            public const int PhoneNumberLength = 15;
        }
    }
}