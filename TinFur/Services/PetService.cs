using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TinFur.Models;

namespace TinFur.Services
{
    public class PetService
    {
        private readonly IMongoCollection<Pet> _petCollection;

        public PetService(
            IOptions<DatabaseSettings> dabaseSettings)
        {
            var mongoClient = new MongoClient(dabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(dabaseSettings.Value.DatabaseName);

            _petCollection = mongoDatabase.GetCollection<Pet>("Pet");
        }

        public async Task<List<Pet>> GetAsync() =>
            await _petCollection.Find(_ => true).ToListAsync();

        public async Task<Pet?> GetAsync(string id) =>
            await _petCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Pet newEmployee) =>
            await _petCollection.InsertOneAsync(newEmployee);

        public async Task UpdateAsync(string id, Pet updatedEmployee) =>
            await _petCollection.ReplaceOneAsync(x => x.Id == id, updatedEmployee);

        public async Task RemoveAsync(string id) => await _petCollection.DeleteOneAsync(x => x.Id == id);
    }
}
