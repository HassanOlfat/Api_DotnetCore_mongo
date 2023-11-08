using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_mongo.data
{
    public class BankInfo
    {

        public ObjectId _id { get; set; }

        //[Display(ResourceType = typeof(Properties.Resources), Name = nameof(Properties.Resources.Owner))]
        public string Owner { get; set; }


        public string BankName { get; set; }


    }

    public class BankInfoDriver : BankInfo
    {

        public ObjectId DriverId { get; set; }

        [ForeignKey(nameof(DriverId))]

        public virtual Driver Driver { get; set; }


    }


}