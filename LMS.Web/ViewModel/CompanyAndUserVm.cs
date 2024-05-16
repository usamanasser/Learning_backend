namespace LMS.Web.ViewModel
{
    public class CompanyAndUserVm
    {

        //Company Data
        public string Name { get; set; }
        public string Id { get; set; }
        public string VatRegistrationNo { get; set; }
        public string CompanyRegNo { get; set; }
        public string LogoPath { get; set; }
        public string HouseNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public string Postcode { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string Country { get; set; }


        //User

        public string FirstName { get; set; }
        public string UserId { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; }


        public string Password { get; set; }


        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Mobile { get;  set; }
    }
}
