using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_mongo.data
{

    public class Driver
    {

        public Driver() { _id =  ObjectId.GenerateNewId(); }  
        public ObjectId _id { get; set; }


        public string NationalId { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string FamilyName { get; set; }

        [StringLength(50)]
        public string EnName { get; set; }

        [StringLength(50)]
        public string EnFamilyName { get; set; }

        public string FullNameWNationalId => $"{Name} {FamilyName} ({NationalId})";
        public string FullName => $"{Name} {FamilyName}";

        public string EnFullNameWNationalId => $"{EnName} {EnFamilyName} ({NationalId})";
        public string EnFullName => $"{EnName} {EnFamilyName}";



        public  List<AddressInfo> AddressInfo { get; set; }


        public virtual ICollection<BankInfoDriver> BankInfos { get; set; }






    }
}