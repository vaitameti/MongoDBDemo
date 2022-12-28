using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDataAccess.Models
{
    public class ChoreHistoryModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] //Gives a unique id to the prop 
        public string Id { get; set; }
        public string ChoreId { get; set; }
        public string ChoreText { get; set; }
        public UserModels WhoCompleted { get; set; }
        public DateTime DateCompleted { get; set; }

        public ChoreHistoryModel()
        {

        }

        public ChoreHistoryModel(ChoreModel chore)
        {
            ChoreId = chore.Id;
            DateCompleted = chore.LastCompleted ?? DateTime.Now;
            WhoCompleted = chore.AssignedTo;
            ChoreText = chore.ChoreText;

        }
    }
}
