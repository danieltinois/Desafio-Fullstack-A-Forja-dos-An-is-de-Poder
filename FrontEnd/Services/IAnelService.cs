using ForjaDosAneisFrontend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForjaDosAneisFrontend.Services
{
  public interface IAnelService
  {
    Task<List<Anel>> GetAnéisAsync();
    Task<Anel> GetAnelByIdAsync(int id);
    Task CreateAnelAsync(Anel anel);
    Task UpdateAnelAsync(Anel anel);
    Task DeleteAnelAsync(int id);
  }
}
